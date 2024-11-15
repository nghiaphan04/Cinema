using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class KhachHang
{
    public string KhachHangId { get; set; } = null!;

    public string? Ten { get; set; }

    public string? Email { get; set; }

    public string? SoDienThoai { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
