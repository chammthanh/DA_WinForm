using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class NSXDAO
    {
        public static DataTable LayDSNSX()
        {
            string query = "select * from NHASANXUAT";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool ThemNSX(NSXDTO nsx)
        {
            string query = "insert into NHASANXUAT values(@TENNSX)";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TENNSX", nsx.TenNSX);
            return DataProvider.ExecuteNonQuery(query, param)==1;
        }
        public static bool SuaNSX(NSXDTO nsx)
        {
            string query = "update NHASANXUAT set TENNHASX = @TENNHASX where MASX = @MASX";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@MASX", nsx.MaSX);
            param[1] = new SqlParameter("@TENNHASX", nsx.TenNSX);
            return DataProvider.ExecuteNonQuery(query, param) == 1;

        }
        public static bool XoaNSX(NSXDTO nsx)
        {
            string query = "delete from NHASANXUAT where MASX = @MASX";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASX", nsx.MaSX);
            return DataProvider.ExecuteNonQuery(query, param) == 1;

        }
        
        public static bool KT(int masx)
        {
            string query = "select count(*) from NHASANXUAT where MASX = @MASX";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASX", masx);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) == 1;
        }
        public static DataTable TimKiem(int masx)
        {
            string query = "Select * from NHASANXUAT where MASX = @MASX";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASX", masx);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
    }
}
