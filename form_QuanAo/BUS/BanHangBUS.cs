using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;
namespace BUS
{
    public class BanHangBUS
    {
        public static DataTable LayDSSP()
        {
            return BanHangDAO.LayDSSP();

        }
        public static DataTable TimKiemSP(int masp)
        {
            return BanHangDAO.TimKiemSP(masp);
        }
        public static bool KTKH(string sdt)
        {
            return BanHangDAO.KTKH(sdt);
        }
        public static string LayTenKH(string sdt)
        {
            return BanHangDAO.LayTenKH(sdt);
        }
        public static bool ThemKH(KhachHangDTO kh)
        {
            return BanHangDAO.ThemKTMoi(kh);
        }
        public static bool ThemHD(HoaDonDTO hd, List<clsSanPham> lstsanpham)
        {
            return BanHangDAO.ThemHD(hd, lstsanpham);
        }
        public static string LayMaKH(string sdt)
        {
            return BanHangDAO.LayMaKH(sdt);
        }
        public static bool ThemCTHD(ChiTietHoaDonDTO cthd)
        {
            return BanHangDAO.ThemCTHD(cthd);
        }
        public static string LayMaHD()
        {
            return BanHangDAO.LayMaHD();
        }
        public static bool KTMaSP(int masp)
        {
            return BanHangDAO.KTMaSP(masp);
        }

    }
}
