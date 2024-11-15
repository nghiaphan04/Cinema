using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class KhuyenMai
{
    public string KmId { get; set; } = null!;

    public string? TenKm { get; set; }

    public string? MoTa { get; set; }

    public decimal? GiaTri { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<BongNuoc> BongNuocs { get; set; } = new List<BongNuoc>();

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
