using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class Ghe
{
    public string GheId { get; set; } = null!;

    public string? PhongId { get; set; }

    public string? SoGhe { get; set; }

    public string? TrangThai { get; set; }

    public string? LoaiGhe { get; set; }

    public virtual PhongChieu? Phong { get; set; }

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
