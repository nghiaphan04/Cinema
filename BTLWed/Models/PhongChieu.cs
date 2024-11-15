using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class PhongChieu
{
    public string PhongId { get; set; } = null!;

    public string? RapId { get; set; }

    public string? TenPhong { get; set; }

    public string? LoaiPhong { get; set; }

    public int? SoGhe { get; set; }

    public virtual ICollection<Ghe> Ghes { get; set; } = new List<Ghe>();

    public virtual ICollection<LichChieu> LichChieus { get; set; } = new List<LichChieu>();

    public virtual RapChieuPhim? Rap { get; set; }
}
