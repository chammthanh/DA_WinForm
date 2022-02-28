using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class KhachHangDAO
    {
        public static DataTable LayDSKH()
        {
            string query = "Select * from KHACHHANG";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool themkh(KhachHangDTO kh)
        {
            string query = " insert into KHACHHANG(TENKH,SDT)VALUES(@TENKH,@SDT)";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@TENKH", kh.TenKH);
            param[1] = new SqlParameter("@SDT", kh.SDT);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }
        public static bool xoakh(KhachHangDTO kh)
        {
            string query = " Delete from KHACHHANG Where MAKH = @MAKH";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAKH", kh.MaKH);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }
        public static bool suakh(KhachHangDTO kh)
        {
            string query = "UPDATE KHACHHANG SET TENKH = @TENKH,SDT=@SDT where MAKH=@MAKH ";

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@MAKH", kh.MaKH);
            param[1] = new SqlParameter("@TENKH", kh.TenKH);
            param[2] = new SqlParameter("@SDT", kh.SDT);
            return DataProvider.ExecuteNonQuery(query, param) == 1;

        }
        public static bool KTMaKH(KhachHangDTO kh)
        {
            string query = "select count(*) from KHACHHANG where MAKH = @MAKH";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAKH", kh.MaKH);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;

        }
        public static DataTable LayDSTimKiem(KhachHangDTO kh)
        {
            string query = "select * from KHACHHANG where MAKH = @MAKH";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAKH", kh.MaKH);
            return DataProvider.ExecuteSelectQuery(query, param);
        }    
        public static bool KTSDT(KhachHangDTO kh)
        {
            string query = "select count(*) from KHACHHANG where SDT = @SDT";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SDT", kh.SDT);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) == 0;
        }
    }
}
