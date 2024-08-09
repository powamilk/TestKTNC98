using KTNCTest98;

public class TKManager
{
    private List<TaiKhoan> taiKhoans = new List<TaiKhoan>();

    public void ThemTaiKhoan(TaiKhoan taiKhoan)
    {
        if (string.IsNullOrWhiteSpace(taiKhoan.TenDangNhap) || taiKhoan.TenDangNhap.Length > 15 || taiKhoan.TenDangNhap.Any(ch => !char.IsLetterOrDigit(ch)))
        {
            throw new ArgumentException("Tên đăng nhập không hợp lệ.");
        }

        if (string.IsNullOrWhiteSpace(taiKhoan.MatKhau) || taiKhoan.MatKhau.Length > 20)
        {
            throw new ArgumentException("Mật khẩu không hợp lệ.");
        }

        if (taiKhoans.Any(tk => tk.TenDangNhap == taiKhoan.TenDangNhap))
        {
            throw new ArgumentException("Tên đăng nhập đã tồn tại.");
        }

        taiKhoans.Add(taiKhoan);
    }

    public void CapNhatTaiKhoan(int id, string newTenDangNhap, string newMatKhau)
    {
        var tk = taiKhoans.FirstOrDefault(i => i.ID == id);
        if (tk == null)
        {
            throw new ArgumentException("Tài khoản không tồn tại.");
        }

        if (string.IsNullOrWhiteSpace(newTenDangNhap) || newTenDangNhap.Length > 15 || newTenDangNhap.Any(ch => !char.IsLetterOrDigit(ch)))
        {
            throw new ArgumentException("Tên đăng nhập không hợp lệ.");
        }

        if (string.IsNullOrWhiteSpace(newMatKhau) || newMatKhau.Length > 20)
        {
            throw new ArgumentException("Mật khẩu không hợp lệ.");
        }

        if (taiKhoans.Any(tk => tk.TenDangNhap == newTenDangNhap && tk.ID != id))
        {
            throw new ArgumentException("Tên đăng nhập đã tồn tại.");
        }

        tk.TenDangNhap = newTenDangNhap;
        tk.MatKhau = newMatKhau;
    }

    public void XoaTaiKhoan(int id)
    {
        var tk = taiKhoans.FirstOrDefault(i => i.ID == id);
        if (tk == null)
        {
            throw new ArgumentException("Tài khoản không tồn tại.");
        }
        taiKhoans.Remove(tk);
    }

    public TaiKhoan GetTaiKhoanById(int id) => taiKhoans.FirstOrDefault(tk => tk.ID == id);
    public List<TaiKhoan> GetAllTaiKhoans() => taiKhoans;
}
