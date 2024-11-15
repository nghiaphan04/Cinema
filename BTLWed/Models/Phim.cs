using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class Phim
{
    public string PhimId { get; set; } = null!;

    public string TenPhim { get; set; } = null!;

    public string? MoTa { get; set; }

    public int? ThoiLuong { get; set; }

    public string? TheLoai { get; set; }

    public string? DaoDien { get; set; }

    public string? DienVien { get; set; }

    public DateOnly? NgayKhoiChieu { get; set; }

    public string? TrangThai { get; set; }

    public string? Poster { get; set; }

    public string? Trailer { get; set; }
   

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ICollection<LichChieu> LichChieus { get; set; } = new List<LichChieu>();

    public virtual ICollection<TinTuc> TinTucs { get; set; } = new List<TinTuc>();
}
