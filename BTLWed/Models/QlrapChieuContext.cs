using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTLWed.Models;

public partial class QlrapChieuContext : DbContext
{
    public QlrapChieuContext()
    {
    }

    public QlrapChieuContext(DbContextOptions<QlrapChieuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BongNuoc> BongNuocs { get; set; }

    public virtual DbSet<DanhGium> DanhGia { get; set; }

    public virtual DbSet<Ghe> Ghes { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<LichChieu> LichChieus { get; set; }

    public virtual DbSet<Phim> Phims { get; set; }

    public virtual DbSet<PhongChieu> PhongChieus { get; set; }

    public virtual DbSet<RapChieuPhim> RapChieuPhims { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThongKe> ThongKes { get; set; }

    public virtual DbSet<TinTuc> TinTucs { get; set; }

    public virtual DbSet<Ve> Ves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PHANDINHNGHIA\\SQLEXPRESS02;Initial Catalog=QLRapChieu;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BongNuoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BongNuoc__3213E83F41CE0718");

            entity.ToTable("BongNuoc");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("gia");
            entity.Property(e => e.KmId)
                .HasMaxLength(50)
                .HasColumnName("km_id");
            entity.Property(e => e.MoTa)
                .HasColumnType("text")
                .HasColumnName("mo_ta");
            entity.Property(e => e.SoLuong).HasColumnName("so_luong");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("cong_khai")
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.Km).WithMany(p => p.BongNuocs)
                .HasForeignKey(d => d.KmId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__BongNuoc__km_id__656C112C");
        });

        modelBuilder.Entity<DanhGium>(entity =>
        {
            entity.HasKey(e => e.DanhGiaId).HasName("PK__DanhGia__D96802BF05F3742B");

            entity.Property(e => e.DanhGiaId)
                .HasMaxLength(50)
                .HasColumnName("danh_gia_id");
            entity.Property(e => e.BinhLuan)
                .HasColumnType("text")
                .HasColumnName("binh_luan");
            entity.Property(e => e.KhachHangId)
                .HasMaxLength(50)
                .HasColumnName("khach_hang_id");
            entity.Property(e => e.NgayDanhGia).HasColumnName("ngay_danh_gia");
            entity.Property(e => e.PhimId)
                .HasMaxLength(50)
                .HasColumnName("phim_id");
            entity.Property(e => e.SoSao).HasColumnName("so_sao");

            entity.HasOne(d => d.KhachHang).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.KhachHangId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__DanhGia__khach_h__66603565");

            entity.HasOne(d => d.Phim).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.PhimId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DanhGia__phim_id__6754599E");
        });

        modelBuilder.Entity<Ghe>(entity =>
        {
            entity.HasKey(e => e.GheId).HasName("PK__Ghe__44F8BDB360A19A9C");

            entity.ToTable("Ghe");

            entity.Property(e => e.GheId)
                .HasMaxLength(50)
                .HasColumnName("ghe_id");
            entity.Property(e => e.LoaiGhe).HasMaxLength(20);
            entity.Property(e => e.PhongId)
                .HasMaxLength(50)
                .HasColumnName("phong_id");
            entity.Property(e => e.SoGhe)
                .HasMaxLength(10)
                .HasColumnName("so_ghe");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.Phong).WithMany(p => p.Ghes)
                .HasForeignKey(d => d.PhongId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Ghe__phong_id__68487DD7");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.KhachHangId).HasName("PK__KhachHan__D69D1E8AF3BAAA55");

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.Email, "UQ__KhachHan__AB6E616495A013C7").IsUnique();

            entity.Property(e => e.KhachHangId)
                .HasMaxLength(50)
                .HasColumnName("khach_hang_id");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("dia_chi");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .HasColumnName("so_dien_thoai");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.KmId).HasName("PK__KhuyenMa__36072E160788CE1E");

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.KmId)
                .HasMaxLength(50)
                .HasColumnName("km_id");
            entity.Property(e => e.GiaTri)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("gia_tri");
            entity.Property(e => e.MoTa)
                .HasColumnType("text")
                .HasColumnName("mo_ta");
            entity.Property(e => e.NgayBatDau).HasColumnName("ngay_bat_dau");
            entity.Property(e => e.NgayKetThuc).HasColumnName("ngay_ket_thuc");
            entity.Property(e => e.TenKm)
                .HasMaxLength(255)
                .HasColumnName("ten_km");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasColumnName("trang_thai");
        });

        modelBuilder.Entity<LichChieu>(entity =>
        {
            entity.HasKey(e => e.LichId).HasName("PK__LichChie__246C9F3DD3C00D44");

            entity.ToTable("LichChieu");

            entity.Property(e => e.LichId)
                .HasMaxLength(50)
                .HasColumnName("lich_id");
            entity.Property(e => e.GioChieu).HasColumnName("gio_chieu");
            entity.Property(e => e.NgayChieu).HasColumnName("ngay_chieu");
            entity.Property(e => e.NgayKetThuc).HasMaxLength(20);
            entity.Property(e => e.PhimId)
                .HasMaxLength(50)
                .HasColumnName("phim_id");
            entity.Property(e => e.PhongId)
                .HasMaxLength(50)
                .HasColumnName("phong_id");
            entity.Property(e => e.RapId)
                .HasMaxLength(50)
                .HasColumnName("rap_id");

            entity.HasOne(d => d.Phim).WithMany(p => p.LichChieus)
                .HasForeignKey(d => d.PhimId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__LichChieu__phim___693CA210");

            entity.HasOne(d => d.Phong).WithMany(p => p.LichChieus)
                .HasForeignKey(d => d.PhongId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__LichChieu__phong__6A30C649");

            entity.HasOne(d => d.Rap).WithMany(p => p.LichChieus)
                .HasForeignKey(d => d.RapId)
                .HasConstraintName("FK__LichChieu__rap_i__6B24EA82");
        });

        modelBuilder.Entity<Phim>(entity =>
        {
            entity.HasKey(e => e.PhimId).HasName("PK__Phim__131F4EC7F7E3C7F0");

            entity.ToTable("Phim");

            entity.Property(e => e.PhimId)
                .HasMaxLength(50)
                .HasColumnName("phim_id");
            entity.Property(e => e.DaoDien)
                .HasMaxLength(255)
                .HasColumnName("dao_dien");
            entity.Property(e => e.DienVien)
                .HasColumnType("text")
                .HasColumnName("dien_vien");
            entity.Property(e => e.MoTa)
                .HasColumnType("text")
                .HasColumnName("mo_ta");
            entity.Property(e => e.NgayKhoiChieu).HasColumnName("ngay_khoi_chieu");
            entity.Property(e => e.Poster)
                .HasMaxLength(255)
                .HasColumnName("poster");
            entity.Property(e => e.TenPhim)
                .HasMaxLength(255)
                .HasColumnName("ten_phim");
            entity.Property(e => e.TheLoai)
                .HasMaxLength(100)
                .HasColumnName("the_loai");
            entity.Property(e => e.ThoiLuong).HasColumnName("thoi_luong");
            entity.Property(e => e.Trailer)
                .HasMaxLength(255)
                .HasColumnName("trailer");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(10)
                .HasColumnName("trang_thai");
        });

        modelBuilder.Entity<PhongChieu>(entity =>
        {
            entity.HasKey(e => e.PhongId).HasName("PK__PhongChi__F67F2229D3857828");

            entity.ToTable("PhongChieu");

            entity.Property(e => e.PhongId)
                .HasMaxLength(50)
                .HasColumnName("phong_id");
            entity.Property(e => e.LoaiPhong)
                .HasMaxLength(10)
                .HasColumnName("loai_phong");
            entity.Property(e => e.RapId)
                .HasMaxLength(50)
                .HasColumnName("rap_id");
            entity.Property(e => e.SoGhe).HasColumnName("so_ghe");
            entity.Property(e => e.TenPhong)
                .HasMaxLength(50)
                .HasColumnName("ten_phong");

            entity.HasOne(d => d.Rap).WithMany(p => p.PhongChieus)
                .HasForeignKey(d => d.RapId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PhongChie__rap_i__6C190EBB");
        });

        modelBuilder.Entity<RapChieuPhim>(entity =>
        {
            entity.HasKey(e => e.RapId).HasName("PK__RapChieu__C9E66069D31095A7");

            entity.ToTable("RapChieuPhim");

            entity.Property(e => e.RapId)
                .HasMaxLength(50)
                .HasColumnName("rap_id");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("dia_chi");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .HasColumnName("so_dien_thoai");
            entity.Property(e => e.TenRap)
                .HasMaxLength(255)
                .HasColumnName("ten_rap");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TaiKhoanId).HasName("PK__TaiKhoan__1284327C7BEEDC36");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__363698B33CA36550").IsUnique();

            entity.Property(e => e.TaiKhoanId)
                .HasMaxLength(50)
                .HasColumnName("tai_khoan_id");
            entity.Property(e => e.KhachHangId)
                .HasMaxLength(50)
                .HasColumnName("khach_hang_id");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .HasColumnName("mat_khau");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(255)
                .HasColumnName("ten_dang_nhap");
            entity.Property(e => e.VaiTro)
                .HasMaxLength(20)
                .HasDefaultValue("khach_hang")
                .HasColumnName("vai_tro");

            entity.HasOne(d => d.KhachHang).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.KhachHangId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__TaiKhoan__khach___6D0D32F4");
        });

        modelBuilder.Entity<ThongKe>(entity =>
        {
            entity.HasKey(e => e.ThongKeId).HasName("PK__ThongKe__9B66CDACF48FF8AC");

            entity.ToTable("ThongKe");

            entity.Property(e => e.ThongKeId)
                .HasMaxLength(50)
                .HasColumnName("thong_ke_id");
            entity.Property(e => e.DoanhThu)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("doanh_thu");
            entity.Property(e => e.Ngay).HasColumnName("ngay");
            entity.Property(e => e.RapId)
                .HasMaxLength(50)
                .HasColumnName("rap_id");
            entity.Property(e => e.SoVeBan).HasColumnName("so_ve_ban");

            entity.HasOne(d => d.Rap).WithMany(p => p.ThongKes)
                .HasForeignKey(d => d.RapId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ThongKe__rap_id__6E01572D");
        });

        modelBuilder.Entity<TinTuc>(entity =>
        {
            entity.HasKey(e => e.TinTucId).HasName("PK__TinTuc__DDE8B93591C66DB8");

            entity.ToTable("TinTuc");

            entity.Property(e => e.TinTucId)
                .HasMaxLength(50)
                .HasColumnName("tin_tuc_id");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(255)
                .HasColumnName("anh_dai_dien");
            entity.Property(e => e.NgayDang).HasColumnName("ngay_dang");
            entity.Property(e => e.NoiDung)
                .HasColumnType("text")
                .HasColumnName("noi_dung");
            entity.Property(e => e.PhimId)
                .HasMaxLength(50)
                .HasColumnName("phim_id");
            entity.Property(e => e.TacGia)
                .HasMaxLength(255)
                .HasColumnName("tac_gia");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(255)
                .HasColumnName("tieu_de");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(10)
                .HasDefaultValue("cong_khai")
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.Phim).WithMany(p => p.TinTucs)
                .HasForeignKey(d => d.PhimId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TinTuc__phim_id__6EF57B66");
        });

        modelBuilder.Entity<Ve>(entity =>
        {
            entity.HasKey(e => e.VeId).HasName("PK__Ve__3EBE499F0A885F20");

            entity.ToTable("Ve");

            entity.Property(e => e.VeId)
                .HasMaxLength(50)
                .HasColumnName("ve_id");
            entity.Property(e => e.GheId)
                .HasMaxLength(50)
                .HasColumnName("ghe_id");
            entity.Property(e => e.GiaVe)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("gia_ve");
            entity.Property(e => e.KhachHangId)
                .HasMaxLength(50)
                .HasColumnName("khach_hang_id");
            entity.Property(e => e.KmId)
                .HasMaxLength(50)
                .HasColumnName("km_id");
            entity.Property(e => e.LichId)
                .HasMaxLength(50)
                .HasColumnName("lich_id");
            entity.Property(e => e.NgayDat).HasColumnName("ngay_dat");

            entity.HasOne(d => d.Ghe).WithMany(p => p.Ves)
                .HasForeignKey(d => d.GheId)
                .HasConstraintName("FK__Ve__ghe_id__6FE99F9F");

            entity.HasOne(d => d.KhachHang).WithMany(p => p.Ves)
                .HasForeignKey(d => d.KhachHangId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Ve__khach_hang_i__70DDC3D8");

            entity.HasOne(d => d.Km).WithMany(p => p.Ves)
                .HasForeignKey(d => d.KmId)
                .HasConstraintName("FK__Ve__km_id__71D1E811");

            entity.HasOne(d => d.Lich).WithMany(p => p.Ves)
                .HasForeignKey(d => d.LichId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Ve__lich_id__72C60C4A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
