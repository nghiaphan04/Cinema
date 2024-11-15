using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class BongNuoc
{
    public string Id { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public decimal Gia { get; set; }

    public int SoLuong { get; set; }

    public string? TrangThai { get; set; }

    public string? MoTa { get; set; }

    public string? KmId { get; set; }

    public virtual KhuyenMai? Km { get; set; }
}
