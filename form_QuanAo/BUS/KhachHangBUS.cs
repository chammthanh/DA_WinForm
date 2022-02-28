using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
namespace BUS
{
    public class KhachHangBUS
    {
        public static DataTable LayDSKH()
        {
            return KhachHangDAO.LayDSKH();
        }
        public static bool themkh(KhachHangDTO kh)
        {
            return KhachHangDAO.themkh(kh);
        }
        public static bool xoakh(KhachHangDTO kh)
        {
            return KhachHangDAO.xoakh(kh);
        }
        public static bool suakh(KhachHangDTO kh)
        {
            return KhachHangDAO.suakh(kh);
        }
        public static bool KTMaKH(KhachHangDTO kh)
        {
            return KhachHangDAO.KTMaKH(kh);
        }
        public static DataTable LayDSTimKiem(KhachHangDTO kh)
        {
            return KhachHangDAO.LayDSTimKiem(kh);
        }
        public static bool KTSDT(KhachHangDTO kh)
        {
            return KhachHangDAO.KTSDT(kh);
        }
    }
}
