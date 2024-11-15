using BTLWed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BTLWed.Controllers
{
    public class TrangChuController : Controller
    {
        QlrapChieuContext db  = new QlrapChieuContext();
        private string dangChieu = "dang_chieu";
        private string sapChieu = "sap_chieu";

        [HttpGet]
        public IActionResult TrangChu()
        {
            var danhSachPhimDangChieu = new List<object>();
            var danhSachPhimSapChieu = new List<object>();

            // Lấy các ghế đã đặt
            var gheDaDat = db.Ghes
                .Where(g => g.TrangThai != "trong")
                .ToList();

            // Lấy các lịch chiếu
            var lichChieus = db.LichChieus
                .Include(lc => lc.Phim)
                .ToList();

            foreach (var phim in db.Phims)
            {
                var phimInfo = new
                {
                    PhimId = phim.PhimId,
                    TenPhim = phim.TenPhim,
                    Poster = phim.Poster,
                    TheLoai = phim.TheLoai,
                    ThoiLuong = phim.ThoiLuong,
                    TrangThai = phim.TrangThai,
                    TrangThaiVe = lichChieus
                        .Where(lc => lc.PhimId == phim.PhimId)
                        .Any(lc => gheDaDat
                            .Any(g => g.PhongId == lc.PhongId)) ? "Còn vé" : "Hết vé"
                };

                if (phim.TrangThai == dangChieu)
                {
                    danhSachPhimDangChieu.Add(phimInfo);
                }
                else if (phim.TrangThai == sapChieu)
                {
                    danhSachPhimSapChieu.Add(phimInfo);
                }
            }

            // Lấy danh sách tin tức
            var danhSachTinTuc = db.TinTucs
                .Where(tt => tt.TrangThai == "cong_khai")
                .OrderByDescending(tt => tt.NgayDang)
                .Take(16) 
                .ToList();

            ViewBag.DanhSachPhimDangChieu = danhSachPhimDangChieu;
            ViewBag.DanhSachPhimSapChieu = danhSachPhimSapChieu;
            ViewBag.DanhSachTinTuc = danhSachTinTuc;

            return View();
        }


        [HttpGet]
        public IActionResult ChiTietPhim(string PhimId)
        {
            var phim = db.Phims.Find(PhimId);
            if (phim == null)
            {
                return NotFound(); 
            }

            var danhSachTinTuc = db.TinTucs
                .Where(tt => tt.PhimId == PhimId && tt.TrangThai == "cong_khai")
                .OrderByDescending(tt => tt.NgayDang)
                .Take(8) 
                .ToList();
            var danhSachPhimDeXuat = db.Phims
                .Where(p => p.PhimId != PhimId && p.TrangThai == dangChieu && p.TheLoai == phim.TheLoai)
                .OrderBy(p => Guid.NewGuid())  
                .Take(4)                      
                .ToList();


            ViewBag.DanhSachTinTuc = danhSachTinTuc;
            ViewBag.DanhSachPhimDeXuat = danhSachPhimDeXuat;

            return View(phim); 
        }

        public JsonResult LayDuLieuSuatChieu(string id, string ngay)
        {
            var gioChieu = (
                from s in db.LichChieus
                join p in db.PhongChieus on s.PhongId equals p.PhongId
                where s.PhimId == id && s.NgayChieu.ToString() == ngay
                select new
                {
                    GioChieu = s.GioChieu.ToString().Substring(0, 5),
                    idPhong = p.PhongId,
                    TenPhong = p.TenPhong,
                    LoaiPhong = p.LoaiPhong
                }
            ).ToList();  

            return Json(new { showtimes = gioChieu });
        }
        [HttpGet]

        public IActionResult LayDuLieuGhe(string idPhong)
        {
            var danhSachGhe = (
                from g in db.Ghes
                where g.PhongId == idPhong
                select g
            ).ToList();

            danhSachGhe = danhSachGhe.OrderBy(g => ExtractNaturalOrder(g.SoGhe)).ToList();

            var danhSachGheVip = danhSachGhe.Where(g => g.LoaiGhe == "VIP").ToList();
            var danhSachGheThuong = danhSachGhe.Where(g => g.LoaiGhe == "Thường").ToList();
            var danhSachGheDoi = danhSachGhe.Where(g => g.LoaiGhe == "Đôi").ToList();

            return Json(new
            {
                dsGheVip = danhSachGheVip,
                dsGheThuong = danhSachGheThuong,
                dsGheDoi = danhSachGheDoi,
                tongSoGhe = danhSachGhe.Count()
            });
        }

        private (string, int) ExtractNaturalOrder(string soGhe)
        {
            var match = Regex.Match(soGhe, @"^([A-Za-z]+)(\d+)$");
            if (match.Success)
            {
                string prefix = match.Groups[1].Value; 
                int number = int.Parse(match.Groups[2].Value); 
                return (prefix, number);
            }
            return (soGhe, 0);
        }

        public JsonResult LayDuLieuDoUong()
        {
            var danhSachDoUong = (
                from b in db.BongNuocs
              select b
            ).ToList();

            return Json(new { dsDoUong = danhSachDoUong });
        }








    }
}
