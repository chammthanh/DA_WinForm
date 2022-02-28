using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
namespace BUS
{
    public class TimKiemBUS
    {
        public static DataTable HOADON()
        {
            return HoaDonDAO.laydshd();
        }
        public static DataTable KHACHHANG()
        {
            return KhachHangDAO.LayDSKH();
        }
        public static DataTable NHANVIEN()
        {
            return NhanvienDAO.layDSNV();
        }
        public static DataTable SANPHAM()
        {
            return SanPhamDAO.LayDSSanPham();
        }
        public static DataTable CHITIETSANPHAM()
        {
            return SanPhamDAO.LayDSCT();
        }
        public static DataTable CHITIETHOADON()
        {
            return HoaDonDAO.LayDSCT();
        }
        public static DataTable NHASANXUAT()
        {
            return NSXDAO.LayDSNSX();
        }
        //SANPHAM
        public static bool KTMaSP(int ma)
        {
            return TimKiemDAO.KTMaSP(ma);
        }
        public static DataTable TimKiemSP(int ma)
        {
            return TimKiemDAO.TimKiemSP(ma);
        }

        //HOADON
        public static bool KTMaHD(int ma)
        {
            return TimKiemDAO.KTMaHD(ma);
        }
        public static DataTable TimKiemHD(int ma)
        {
            return TimKiemDAO.TimKiemHD(ma);
        }

        //KHACHHANG
        public static bool KTMaKH(int ma)
        {
            return TimKiemDAO.KTMaKH(ma);
        }
        public static DataTable TimKiemKH(int ma)
        {
            return TimKiemDAO.TimKiemKH(ma);
        }

        //NHANVIEN
        public static bool KTMaNV(int ma)
        {
            return TimKiemDAO.KTMaNV(ma);
        }
        public static DataTable TimKiemNV(int ma)
        {
            return TimKiemDAO.TimKiemNV(ma);
        }
        //CHITIETHOADON
        public static bool KTMaCTHD(int ma)
        {
            return TimKiemDAO.KTMaCTHD(ma);
        }
        public static DataTable TimKiemCTHD(int ma)
        {
            return TimKiemDAO.TimKiemCTHD(ma);
        }

        //CHITIETSANPHAM
        public static bool KTMaCTSP(int ma)
        {
            return TimKiemDAO.KTMaCTSP(ma);
        }
        public static DataTable TimKiemCTSP(int ma)
        {
            return TimKiemDAO.TimKiemCTSP(ma);
        }
        //NSX
        public static bool KTMaNSX(int ma)
        {
            return TimKiemDAO.KTMaSX(ma);
        }
        public static DataTable TimKiemNSX(int ma)
        {
            return TimKiemDAO.TimKiemNSX(ma);
        }
    }
}
