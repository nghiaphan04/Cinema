using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class TinTuc
{
    public string TinTucId { get; set; } = null!;

    public string? PhimId { get; set; }

    public string TieuDe { get; set; } = null!;

    public string? NoiDung { get; set; }

    public DateOnly? NgayDang { get; set; }

    public string? TacGia { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? TrangThai { get; set; }

    public virtual Phim? Phim { get; set; }
}
