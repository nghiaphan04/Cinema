using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class DanhGium
{
    public string DanhGiaId { get; set; } = null!;

    public string? PhimId { get; set; }

    public string? KhachHangId { get; set; }

    public int? SoSao { get; set; }

    public string? BinhLuan { get; set; }

    public DateOnly? NgayDanhGia { get; set; }

    public virtual KhachHang? KhachHang { get; set; }

    public virtual Phim? Phim { get; set; }
}
