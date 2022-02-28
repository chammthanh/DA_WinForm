using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsSanPham
    {
        private int _MASP;
        private int _MAHD;
        private int _SOLUONG;
        private decimal _DONGIA;

        public int MASP { get => _MASP; set => _MASP = value; }
        public int MAHD { get => _MAHD; set => _MAHD = value; }
        public int SOLUONG { get => _SOLUONG; set => _SOLUONG = value; }
        public decimal DONGIA { get => _DONGIA; set => _DONGIA = value; }
    }
}
