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
    public class SanPhamBUS
    {
       public static DataTable LayDSSanPham()
        {
            return SanPhamDAO.LayDSSanPham();
        }
        public static DataTable LayDSCT()
        {
            return SanPhamDAO.LayDSCT();
        }
        public static bool ThemSanPham(SanPhamDTO sp)
        {
            return SanPhamDAO.ThemSanPham(sp);
        }
        
        public static string LayMaHD()
        {
            return BanHangDAO.LayMaHD();
        }
        public static bool ThemCTSP(ChiTietSanPhamDTO ctsp)
        {
            return SanPhamDAO.ThemCTSP(ctsp);
        }
        public static Boolean XoaSP(int masp)
        {
            return SanPhamDAO.XoaSanPham(masp);
        }
        public static bool SuaSanPham(SanPhamDTO sp)
        {
            return (SanPhamDAO.SuaSanPham(sp));
        }
        public static DataTable DSLoaiSP()
        {

            return SanPhamDAO.DSLoaiSP();
        }
        public static DataTable DSNSX()
        {
            return SanPhamDAO.DSNSX();
        }
        public static DataTable DSMAU()
        {
            return SanPhamDAO.DSMAU();
        }
        public static DataTable DSSIZE()
        {
            return SanPhamDAO.DSSIZE();
        }
        public static bool KTMaSP(int masp)
        {
            return SanPhamDAO.KTMaSP(masp);
        }
        public static DataTable TimKiemSP(int masp)
        {
            return SanPhamDAO.TimKiemSP(masp);
        }
        public static string LayLoai(int loaisp)
        {
            return SanPhamDAO.LayLoaiSP(loaisp);
        }
        public static string Laynsx(int nsx)
        {
            return SanPhamDAO.LayNSX(nsx);
        }
        public static string LayMaSP()
        {
            return SanPhamDAO.LayMaSP();
        }
        public static bool SuaCTSP(ChiTietSanPhamDTO ctsp)
        {
            return SanPhamDAO.SuaCTSP(ctsp);
        }
        public static bool XoaCTSP(ChiTietSanPhamDTO ctsp)
        {
            return SanPhamDAO.xoactsp(ctsp);

        }
        public static DataTable TimKiemCT(int masp)
        {
            return SanPhamDAO.TimKiemCT(masp);
        }
    }
}
