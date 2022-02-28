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
    public class HoaDonBUS
    {
        public static DataTable laydshd()
        {
            return HoaDonDAO.laydshd();
        }
        public static bool themhd(HoaDonDTO hd)
        {
            return HoaDonDAO.themhd(hd);
        }
        public static bool xoahd(HoaDonDTO hd)
        {
            return HoaDonDAO.xoahd(hd);
        }
        public static bool suahd(HoaDonDTO hd)
        {
            return HoaDonDAO.suahd(hd);
        }
        public static DataTable LayMaNV()
        {
            return HoaDonDAO.LayMaNV();
        }
        public static int LayMaHD()
        {
            return HoaDonDAO.LayMaHD();
        }
        public static bool KTMASP(int masp)
        {
            return HoaDonDAO.KTMASP(masp);
        }
        public static DataTable LayDSCTHD()
        {
            return HoaDonDAO.LayDSCT();
        }
        public static string LayDonGia(int masp)
        {
            return HoaDonDAO.LayDonGia(masp);
        }
        public static bool ThemCTHD(ChiTietHoaDonDTO cthd)
        {
            return HoaDonDAO.themcthd(cthd);
        }
        public static bool SuaCTHD(ChiTietHoaDonDTO cthd)
        {
            return HoaDonDAO.suacthd(cthd);
        }    
        public static bool XoaCTHD(ChiTietHoaDonDTO cthd)
        {
            return HoaDonDAO.xoacthd(cthd);
        }
        public static DataTable LayDSKH()
        {
            return HoaDonDAO.LayMaKH();
        }
        public static DataTable rptHoaDon(int mahd)
        {
            return HoaDonDAO.rptHoaDon(mahd);
        }
        public static int MaHD()
        {
            return HoaDonDAO.MaHD();
        }
        public static bool KTMaHD(int mahd)
        {
            return HoaDonDAO.KTMaHD(mahd);
        }
        public static DataTable TimKiemHD(int mahd)
        {
            return HoaDonDAO.TimKiemHD(mahd);
        }
        public static DataTable TimKiemCT(int mahd)
        {
            return HoaDonDAO.TimKiemCT(mahd);
        }
    }
}
