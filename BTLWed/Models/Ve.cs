using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class Ve
{
    public string VeId { get; set; } = null!;

    public string? LichId { get; set; }

    public string? GheId { get; set; }

    public string? KmId { get; set; }

    public string? KhachHangId { get; set; }

    public DateOnly? NgayDat { get; set; }

    public decimal? GiaVe { get; set; }

    public virtual Ghe? Ghe { get; set; }

    public virtual KhachHang? KhachHang { get; set; }

    public virtual KhuyenMai? Km { get; set; }

    public virtual LichChieu? Lich { get; set; }
}
