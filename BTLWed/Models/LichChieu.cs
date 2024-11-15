using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class LichChieu
{
    public string LichId { get; set; } = null!;

    public string? PhimId { get; set; }

    public string? RapId { get; set; }

    public string? PhongId { get; set; }

    public DateOnly? NgayChieu { get; set; }

    public TimeOnly? GioChieu { get; set; }

    public string? NgayKetThuc { get; set; }

    public virtual Phim? Phim { get; set; }

    public virtual PhongChieu? Phong { get; set; }

    public virtual RapChieuPhim? Rap { get; set; }

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
