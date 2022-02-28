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
    public class NhanvienBUS
    {
        public static bool KTDangNhap(string username, string password)
        {
            if (NhanvienDAO.KTTKTonTai(username))
            {
                return NhanvienDAO.LayMK(username) == password;
            }
            return false;
        }
        public static DataTable layDSNV()
        {
            return NhanvienDAO.layDSNV();
        }
        public static bool ThemNhanVien(NhanvienDTO nv)
        {
            return NhanvienDAO.ThemNhanVien(nv);
        }
        public static bool XoaNV(int MANV)
        {
            return NhanvienDAO.XoaNhanVien(MANV);
        }
        public static bool SuaNV(NhanvienDTO nv)
        {
            return NhanvienDAO.SuaNV(nv);
        }
        public static string LayTenNV(string manv)
        {
            return NhanvienDAO.LayTenNV(manv);
        }
        public static bool KTMaNV(int manv)
        {
            return NhanvienDAO.KTMaNV(manv);
        }
        public static DataTable TimKiemNV(int manv)
        {
            return NhanvienDAO.TimKiemNV(manv);
        }
       public static string TennNV(string username)
        {
            return NhanvienDAO.TenNV(username);
        }    
        
    }
}

