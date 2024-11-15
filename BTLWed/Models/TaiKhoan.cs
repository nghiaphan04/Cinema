using System;
using System.Collections.Generic;

namespace BTLWed.Models;

public partial class TaiKhoan
{
    public string TaiKhoanId { get; set; } = null!;

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? VaiTro { get; set; }

    public string? KhachHangId { get; set; }

    public virtual KhachHang? KhachHang { get; set; }
}
