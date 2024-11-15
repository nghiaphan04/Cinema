using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class ThongKe
{
    public string ThongKeId { get; set; } = null!;

    public DateOnly? Ngay { get; set; }

    public int? SoVeBan { get; set; }

    public decimal? DoanhThu { get; set; }

    public string? RapId { get; set; }

    public virtual RapChieuPhim? Rap { get; set; }
}
