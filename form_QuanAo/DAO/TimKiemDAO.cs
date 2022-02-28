using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class TimKiemDAO
    {
       
       
        public static bool KTMaSP(int ma)
        {
            string query = "select count(*) from SANPHAM where MASP = @MASP";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", ma);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;
        }
        public static DataTable TimKiemSP(int ma)
        {
            string query = "Select * FROM SANPHAM WHERE MASP = @MASP ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", ma);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool KTMaHD(int ma)
        {
            string query = "select count(*) from HOADON where MAHD = @MAHD";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAHD", ma);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;
        }
        public static DataTable TimKiemHD(int ma)
        {
            string query = "Select * FROM HOADON WHERE MAHD= @MAHD ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAHD", ma);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool KTMaKH(int ma)
        {
            string query = "select count(*) from KHACHHANG where MAKH = @MAKH";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAKH", ma);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;
        }
        public static DataTable TimKiemKH(int ma)
        {
            string query = "Select * FROM KHACHHANG WHERE MAKH = @MAKH ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAKH", ma);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool KTMaNV(int ma)
        {
            string query = "select count(*) from NHANVIEN where MANV = @MANV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MANV", ma);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;
        }
        public static DataTable TimKiemNV(int ma)
        {
            string query = "Select * FROM NHANVIEN WHERE MANV = @MANV ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MANV", ma);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool KTMaCTSP(int ma)
        {
            string query = "select count(*) from CHITIETSANPHAM where MASP = @MASP";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", ma);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;
        }
        public static DataTable TimKiemCTSP(int ma)
        {
            string query = "Select * FROM CHITIETSANPHAM WHERE MASP = @MASP ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", ma);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool KTMaCTHD(int ma)
        {
            string query = "select count(*) from CHITIETHOADON where MAHD = @MAHD";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAHD", ma);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;
        }
        public static DataTable TimKiemCTHD(int ma)
        {
            string query = "Select * FROM CHITIETHOADON WHERE MAHD = @MAHD ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAHD", ma);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool KTMaSX(int ma)
        {
            string query = "select count(*) from NHASANXUAT where MASX = @MASX";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASX", ma);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;
        }
        public static DataTable TimKiemNSX(int ma)
        {
            string query = "Select * FROM NHASANXUAT WHERE MASX = @MASX ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASX", ma);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
    }
}
