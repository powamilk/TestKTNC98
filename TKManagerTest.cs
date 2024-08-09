using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTNCTest98
{
    public class TKManagerTest
    {
        private TKManager manager;

        [SetUp]
        public void SetUp()
        {
            manager = new TKManager();
        }

        [Test]
        public void ThemTaiKhoan_HopLe()
        {
            var taiKhoan = new TaiKhoan(1, "user123", "password123");
            manager.ThemTaiKhoan(taiKhoan);
            Assert.IsTrue(manager.GetAllTaiKhoans().Any(tk => tk.ID == 1));
        }

        [Test]
        public void ThemTaiKhoan_TenDangNhapRong()
        {
            Assert.Throws<ArgumentException>(() => manager.ThemTaiKhoan(new TaiKhoan(1, "", "password123")));
        }

        [Test]
        public void ThemTaiKhoan_MatKhauRong()
        {
            Assert.Throws<ArgumentException>(() => manager.ThemTaiKhoan(new TaiKhoan(1, "user123", "")));
        }

        [Test]
        public void ThemTaiKhoan_TenDangNhapCoKyTuDacBiet()
        {
            Assert.Throws<ArgumentException>(() => manager.ThemTaiKhoan(new TaiKhoan(1, "user@123", "password123")));
        }

        [Test]
        public void CapNhatTaiKhoan_HopLe()
        {
            manager.ThemTaiKhoan(new TaiKhoan(1, "user123", "password123"));
            manager.CapNhatTaiKhoan(1, "newUser", "newPass");
            var tk = manager.GetTaiKhoanById(1);
            Assert.AreEqual("newUser", tk.TenDangNhap);
            Assert.AreEqual("newPass", tk.MatKhau);
        }

        [Test]
        public void CapNhatTaiKhoan_TaiKhoanKhongTonTai()
        {
            Assert.Throws<ArgumentException>(() => manager.CapNhatTaiKhoan(99, "newUser", "newPass"));
        }

        [Test]
        public void CapNhatTaiKhoan_TenDangNhapTrungLap()
        {
            manager.ThemTaiKhoan(new TaiKhoan(1, "user1", "pass1"));
            manager.ThemTaiKhoan(new TaiKhoan(2, "user2", "pass2"));
            Assert.Throws<ArgumentException>(() => manager.CapNhatTaiKhoan(2, "user1", "newPass"));
        }

        [Test]
        public void XoaTaiKhoan_HopLe()
        {
            manager.ThemTaiKhoan(new TaiKhoan(1, "userToDelete", "password123"));
            manager.XoaTaiKhoan(1);
            Assert.IsFalse(manager.GetAllTaiKhoans().Any(tk => tk.ID == 1));
        }

        [Test]
        public void XoaTaiKhoan_TaiKhoanKhongTonTai()
        {
            manager.XoaTaiKhoan(99);
            Assert.IsEmpty(manager.GetAllTaiKhoans());
        }

        [Test]
        public void XoaTaiKhoan_TaiKhoanDaXoa()
        {
            manager.ThemTaiKhoan(new TaiKhoan(1, "user", "password123"));
            manager.XoaTaiKhoan(1);
            Assert.Throws<ArgumentException>(() => manager.CapNhatTaiKhoan(1, "newUser", "newPassword"));
        }

        [Test]
        public void ThemTaiKhoan_TenDangNhap_MaxLength()
        {
            var taiKhoan = new TaiKhoan(1, new string('a', 15), "password123");
            manager.ThemTaiKhoan(taiKhoan);
            Assert.IsTrue(manager.GetAllTaiKhoans().Any(tk => tk.ID == 1 && tk.TenDangNhap.Length == 15));
        }

        [Test]
        public void ThemTaiKhoan_TenDangNhap_TooLong()
        {
            Assert.Throws<ArgumentException>(() => manager.ThemTaiKhoan(new TaiKhoan(1, new string('a', 16), "password123")));
        }

        [Test]
        public void ThemTaiKhoan_MatKhau_MaxLength()
        {
            var taiKhoan = new TaiKhoan(1, "user123", new string('b', 20));
            manager.ThemTaiKhoan(taiKhoan);
            Assert.IsTrue(manager.GetAllTaiKhoans().Any(tk => tk.ID == 1 && tk.MatKhau.Length == 20));
        }

        [Test]
        public void ThemTaiKhoan_MatKhau_TooLong()
        {
            Assert.Throws<ArgumentException>(() => manager.ThemTaiKhoan(new TaiKhoan(1, "user123", new string('b', 21))));
        }

        [Test]
        public void CapNhatTaiKhoan_TenDangNhap_MaxLength()
        {
            manager.ThemTaiKhoan(new TaiKhoan(1, "user", "password123"));
            manager.CapNhatTaiKhoan(1, new string('a', 15), "newPassword");
            var tk = manager.GetTaiKhoanById(1);
            Assert.AreEqual(new string('a', 15), tk.TenDangNhap);
        }

        [Test]
        public void CapNhatTaiKhoan_TenDangNhap_TooLong()
        {
            manager.ThemTaiKhoan(new TaiKhoan(1, "user", "password123"));
            Assert.Throws<ArgumentException>(() => manager.CapNhatTaiKhoan(1, new string('a', 16), "newPassword"));
        }

        [Test]
        public void CapNhatTaiKhoan_MatKhau_MaxLength()
        {
            manager.ThemTaiKhoan(new TaiKhoan(1, "user", "password123"));
            manager.CapNhatTaiKhoan(1, "newUser", new string('b', 20));
            var tk = manager.GetTaiKhoanById(1);
            Assert.AreEqual(new string('b', 20), tk.MatKhau);
        }

        [Test]
        public void CapNhatTaiKhoan_MatKhau_TooLong()
        {
            manager.ThemTaiKhoan(new TaiKhoan(1, "user", "password123"));
            Assert.Throws<ArgumentException>(() => manager.CapNhatTaiKhoan(1, "newUser", new string('b', 21)));
        }

        [Test]
        public void XoaTaiKhoan_KhiDanhSachRong()
        {
            Assert.DoesNotThrow(() => manager.XoaTaiKhoan(1)); 
        }

        [Test]
        public void XoaTaiKhoan_SauXoa()
        {
            manager.ThemTaiKhoan(new TaiKhoan(1, "user", "password123"));
            manager.XoaTaiKhoan(1);
            Assert.IsEmpty(manager.GetAllTaiKhoans());
        }

    }
}
