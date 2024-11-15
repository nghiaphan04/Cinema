using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class RapChieuPhim
{
    public string RapId { get; set; } = null!;

    public string TenRap { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<LichChieu> LichChieus { get; set; } = new List<LichChieu>();

    public virtual ICollection<PhongChieu> PhongChieus { get; set; } = new List<PhongChieu>();

    public virtual ICollection<ThongKe> ThongKes { get; set; } = new List<ThongKe>();
}
