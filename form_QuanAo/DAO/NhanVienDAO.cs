using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace DAO
{
    public class NhanvienDAO

    {
        public static bool KTTKTonTai(string username)
        {
            string query = "Select count(*) from NHANVIEN where USERNAME like @Username + '%' and TRANGTHAI =1";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Username", username);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) == 1;
        }
        public static string LayMK(string username)
        {
            string query = "Select PASSWORD from NHANVIEN where USERNAME like @Username + '%'";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Username", username);
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }
       
        public static DataTable layDSNV()
        {
            string query = "Select * FROM NHANVIEN";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool ThemNhanVien(NhanvienDTO nv)
        {
            string query = "insert into NHANVIEN(HOTENNV,NGSINH,DCHI,GIOITINH,LUONG,USERNAME,PASSWORD,TRANGTHAI) values(@HOTENNV,@NGSINH,@DCHI,@GIOITINH,@LUONG,@USERNAME,@PASSWORD,@TRANGTHAI)";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@HOTENNV", nv.HOTENNV);
            param[1] = new SqlParameter("@NGSINH", nv.NGSINH);
            param[2] = new SqlParameter("@DCHI", nv.DCHI);
            param[3] = new SqlParameter("@GIOITINH", nv.GIOITINH);
            param[4] = new SqlParameter("@LUONG", nv.LUONG);
            param[5] = new SqlParameter("@USERNAME", nv.USERNAME);
            param[6] = new SqlParameter("@PASSWORD", nv.PASSWORD);
            param[7] = new SqlParameter("@TRANGTHAI", nv.TRANGTHAI);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }
        public static string LayMaNV()
        {
            string query = "select top 1 * from NHANVIEN order by MANV desc";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }
        public static bool SuaNV(NhanvienDTO nv)
        {
            string query = "UPDATE NHANVIEN Set HOTENNV =@HOTENNV,NGSINH =@NGSINH,DCHI = @DCHI, GIOITINH = @GIOITINH, LUONG = @LUONG,USERNAME = @USERNAME, PASSWORD = @PASSWORD, TRANGTHAI =@TRANGTHAI WHERE  MANV = @MANV ";
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@MANV", nv.MANV);
            param[1] = new SqlParameter("@HOTENNV", nv.HOTENNV);
            param[2] = new SqlParameter("@NGSINH", nv.NGSINH);
            param[3] = new SqlParameter("@DCHI", nv.DCHI);
            param[4] = new SqlParameter("@GIOITINH", nv.GIOITINH);
            param[5] = new SqlParameter("@LUONG", nv.LUONG);
            param[6] = new SqlParameter("@USERNAME", nv.USERNAME);
            param[7] = new SqlParameter("@PASSWORD", nv.PASSWORD);
            param[8] = new SqlParameter("@TRANGTHAI", nv.TRANGTHAI);
            return DataProvider.ExecuteNonQuery(query, param) == 1;

        }
        public static bool XoaNhanVien(int MANV)
        {
            string query = "UPDATE NHANVIEN Set TRANGTHAI=0 WHERE MANV = @MANV  ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MANV", MANV);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }

        public static string LayTenNV(string manv)
        {
            string query = "select HOTENNV from NHANVIEN where MANV = @MANV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MANV", manv);
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }

        public static bool KTMaNV(int manv)
        {
            string query = "select count(*) from NHANVIEN where MANV = @MANV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MANV", manv);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;

        }
        public static DataTable TimKiemNV(int manv)
        {
            string query = "select * from NHANVIEN where MANV = @MANV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MANV", manv);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static string TenNV(string username)
        {
            string query = "select HOTENNV from NHANVIEN where USERNAME like @USERNAME";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@USERNAME", username);
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }    
    }
}
