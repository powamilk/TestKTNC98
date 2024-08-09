using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTNCTest98
{
    public class TinhToan
    {
        public int TinhDienTich(int chieuDai, int chieuRong)
        {
            if (chieuDai < 0 || chieuDai > 150 || chieuRong < 0 || chieuRong > 150)
            {
                throw new ArgumentException("Chiều dài và chiều rộng phải nằm trong khoảng từ 0 đến 150.");
            }
            return chieuDai * chieuRong;
        }


    }
}
