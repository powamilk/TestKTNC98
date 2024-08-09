using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTNCTest98
{
    [TestFixture]
    public class TinhToanTests
    {
        private TinhToan tinhToan;

        [SetUp]
        public void SetUp()
        {
            tinhToan = new TinhToan();
        }

        //Phân vùng
        [Test]
        public void TinhDienTich_ValidValues()
        {
            Assert.AreEqual(20, tinhToan.TinhDienTich(4, 5));
            Assert.AreEqual(900, tinhToan.TinhDienTich(30, 30));
            Assert.AreEqual(0, tinhToan.TinhDienTich(0, 10));
            Assert.AreEqual(0, tinhToan.TinhDienTich(10, 0));
        }

        [Test]
        public void TinhDienTich_ChieuDaiNhoHon0()
        {
            Assert.Throws<ArgumentException>(() => tinhToan.TinhDienTich(-1, 10));
        }

        [Test]
        public void TinhDienTich_ChieuRongNhoHon0()
        {
            Assert.Throws<ArgumentException>(() => tinhToan.TinhDienTich(10, -1));
        }

        [Test]
        public void TinhDienTich_ChieuDaiLonHon150()
        {
            Assert.Throws<ArgumentException>(() => tinhToan.TinhDienTich(151, 10));
        }

        [Test]
        public void TinhDienTich_ChieuRongLonHon150()
        {
            Assert.Throws<ArgumentException>(() => tinhToan.TinhDienTich(10, 151));
        }

        // Giá trị biên

        [Test]
        public void TinhDienTich_ChieuDaiBằng0_ChieuRongBằng0()
        {
            Assert.AreEqual(0, tinhToan.TinhDienTich(0, 0));
        }

        [Test]
        public void TinhDienTich_ChieuDaiBằng0_ChieuRongMax()
        {
            Assert.AreEqual(0, tinhToan.TinhDienTich(0, 150));
        }

        [Test]
        public void TinhDienTich_ChieuDaiMax_ChieuRongBằng0()
        {
            Assert.AreEqual(0, tinhToan.TinhDienTich(150, 0));
        }

        [Test]
        public void TinhDienTich_ChieuDaiMax_ChieuRongMax()
        {
            Assert.AreEqual(22500, tinhToan.TinhDienTich(150, 150));
        }

        
    }
}
