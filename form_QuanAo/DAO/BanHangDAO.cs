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
    public class BanHangDAO
    {
        public static DataTable LayDSSP()
        {
            string query = "Select SANPHAM.MASP, TENSP, SOLUONGTON, DONGIA, MAU, SIZE, TRANGTHAI " +
                "FROM SANPHAM left join  CHITIETSANPHAM on SANPHAM.MASP = CHITIETSANPHAM.MASP";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool KTMaSP(int masp)
        {
            string query = "select count(*) from CHITIETSANPHAM inner join SANPHAM on SANPHAM.MASP=CHITIETSANPHAM.MASP where CHITIETSANPHAM.MASP = @MASP";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", masp);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) !=0;
        }
        public static DataTable TimKiemSP(int masp)
        {
            string query = "Select SANPHAM.MASP, TENSP, SOLUONGTON, DONGIA, MAU, SIZE, TRANGTHAI " +
                "FROM SANPHAM left join  CHITIETSANPHAM on SANPHAM.MASP = CHITIETSANPHAM.MASP where CHITIETSANPHAM.MASP = @MASP";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", masp);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool KTKH(string sdt)
        {
            string query = "select count(*) from KHACHHANG where SDT like @SDT + '%'";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SDT", sdt);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query,param).Rows[0][0])== 1;
        }
        public static string LayTenKH(string sdt)
        {
            string query = "select TENKH from KHACHHANG where SDT like @SDT + '%'";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SDT", sdt);
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }
        public static bool ThemKTMoi(KhachHangDTO kh)
        {
            string query = "insert into KHACHHANG (TENKH,SDT ) values (@TENKH,@SDT)";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@TENKH", kh.TenKH);
            param[1] = new SqlParameter("@SDT", kh.SDT);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }
        public static string LayMaKH(string sdt)
        {
            string query = "select MAKH from KHACHHANG where SDT like @SDT +'%'";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SDT", sdt);
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }
        public static bool ThemHD(HoaDonDTO hd,List<clsSanPham> lstsanpham)
        {
            string query = "insert into HOADON(MAKH,NGAYLAP,MANV,TONGTIEN,TRANGTHAI) values(@MAKH,@NGAYLAP,@MANV,@TONGTIEN,@TRANGTHAI); SELECT CAST(SCOPE_IDENTITY() AS int)";
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@MAKH", hd.MaKH);
            param[1] = new SqlParameter("@NGAYLAP", hd.NgLap);
            param[2] = new SqlParameter("@MANV", hd.MaNV);
            param[3] = new SqlParameter("@TONGTIEN", hd.TongTien);
            param[4] = new SqlParameter("@TRANGTHAI", hd.TrangThai);
            int i = 0;
            try
            {
                int mahd = DataProvider.ExecuteInsertQueryScalar(query, param);
                query = "INSERT INTO CHITIETHOADON (MAHD, MASP, SOLUONG, DONGIA) values (@mahd, @masp, @soluong,@dongia)";
                foreach(var item in lstsanpham)
                {
                    SqlParameter[] param2 = new SqlParameter[4];
                    param2[0] = new SqlParameter("@mahd", mahd);
                    param2[1] = new SqlParameter("@masp", item.MASP);
                    param2[2] = new SqlParameter("@soluong", item.SOLUONG);
                    param2[3] = new SqlParameter("@dongia", item.DONGIA);

                    int result = DataProvider.ExecuteNonQuery(query, param2);
                    if (result == 1)
                        i++;
                }    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (i == lstsanpham.Count)
                return true;
            return false;

        }
        
        public static string LayMaHD()
        {
            string query = "select top 1 * from HOADON order by MAHD desc";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }

        public static bool ThemCTHD(ChiTietHoaDonDTO cthd)
        {
            string query = "insert into CHITIETHOADON(MAHD,MASP,SOLUONG,DONGIA) values (@MAHD,@MASP,@SOLUONG,@DONGIA)";
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@MAHD", LayMaHD());
            param[1] = new SqlParameter("@MASP", cthd.MaSP);
            param[2] = new SqlParameter("@SOLUONG", cthd.SoLuong);
            param[3] = new SqlParameter("@DONGIA", cthd.DonGia);
            return DataProvider.ExecuteNonQuery(query, param) == 1;

        }

    }
}
