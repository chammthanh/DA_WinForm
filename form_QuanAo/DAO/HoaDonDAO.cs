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
    public class HoaDonDAO
    {
        public static DataTable laydshd()
        {
            string query = "select * from HOADON";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool themhd(HoaDonDTO hd)
        {
            string query = "insert into HOADON (  MAKH, NGAYLAP, MANV, TONGTIEN,TRANGTHAI) VALUES (@MAKH, @NGAYLAP, @MANV, @TONGTIEN,@TRANGTHAI)";
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@MAKH", hd.MaKH);
            param[1] = new SqlParameter("@NGAYLAP", hd.NgLap);
            param[2] = new SqlParameter("@MANV", hd.MaNV);
            param[3] = new SqlParameter("@TONGTIEN", hd.TongTien);
            param[4] = new SqlParameter("@TRANGTHAI", hd.TrangThai);

            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }
        public static bool xoahd(HoaDonDTO hd)
        {
            string query = "update HOADON set TRANGTHAI = 0 where MAHD=@MAHD";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAHD", hd.MaHD);
            return DataProvider.ExecuteNonQuery(query, param) == 1;

        }
        public static bool suahd(HoaDonDTO hd)
        {
            string query = " update HOADON set MAKH=@MAKH, NGAYLAP=@NGAYLAP, MANV=@MANV, TONGTIEN=@TONGTIEN,TRANGTHAI=@TRANGTHAI WHERE MAHD=@MAHD";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@MAHD", hd.MaHD);
            param[1] = new SqlParameter("@MAKH", hd.MaKH);
            param[2] = new SqlParameter("@NGAYLAP", hd.NgLap);
            param[3] = new SqlParameter("@MANV", hd.MaNV);
            param[4] = new SqlParameter("@TONGTIEN", hd.TongTien);
            param[5] = new SqlParameter("@TRANGTHAI", hd.TrangThai);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }
        public static DataTable LayMaNV()
        {
            string query = "select MANV from NHANVIEN";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query,param);
        }
        public static int LayMaHD()
        {
            string query = "select top 1 * from HOADON order by MAHD desc";
            SqlParameter[] param = new SqlParameter[0];
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString());
        }
        public static bool KTMASP(int masp)
        {
            string query = "select count(*) from SANPHAM where MASP = @MASP";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", masp);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) == 1;
        }
        public static DataTable LayDSCT()
        {
            string query = "select * from CHITIETHOADON ";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }    
        public static string LayDonGia(int masp)
        {
            string query = "select DONGIA from SANPHAM where MASP = @MASP";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", masp);
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }    
        public static bool themcthd(ChiTietHoaDonDTO cthd)
        {
            string query = "insert into CHITIETHOADON(MAHD,MASP,SOLUONG,DONGIA) values(@MAHD,@MASP,@SOLUONG,@DONGIA)";
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@MAHD", cthd.MaHD);
            param[1] = new SqlParameter("@MASP", cthd.MaSP);
            param[2] = new SqlParameter("@SOLUONG", cthd.SoLuong);
            param[3] = new SqlParameter("@DONGIA", cthd.DonGia);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }
        public static bool suacthd(ChiTietHoaDonDTO cthd)
        {
            string query = "update CHITIETHOADON set SOLUONG = @SOLUONG, DONGIA=@DONGIA where MAHD = @MAHD AND MASP = @MASP";
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@MAHD", cthd.MaHD);
            param[1] = new SqlParameter("@MASP", cthd.MaSP);
            param[2] = new SqlParameter("@SOLUONG", cthd.SoLuong);
            param[3] = new SqlParameter("@DONGIA", cthd.DonGia);
            param[4] = new SqlParameter("@MA", cthd.masptam);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }
        public static bool xoacthd(ChiTietHoaDonDTO cthd)
        {
            string query = "delete from CHITIETHOADON where MAHD=@MAHD AND MASP=@MASP";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@MAHD", cthd.MaHD);
            param[1] = new SqlParameter("@MASP", cthd.MaSP);
            return DataProvider.ExecuteNonQuery(query, param)==1;
        }    
        public static DataTable LayMaKH()
        {
            string query = "select MAKH from KHACHHANG";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static DataTable rptHoaDon(int mahd)
        {
            string query = "RPTHOADON";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAHD", mahd);
            DataTable dt = DataProvider.HoaDon(query, param);

            return dt;
        }
        public static int MaHD()
        {
            string query = "SELECT TOP 1 * FROM HOADON ORDER BY MAHD DESC";
            SqlParameter[] param = new SqlParameter[0];
            int i = Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]);

            return i;
        }
        public static bool KTMaHD(int mahd)
        {
            string query = "select count(*) from HOADON  where MAHD = @MAHD";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAHD", mahd);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;
        }
        public static DataTable TimKiemHD(int mahd)
        {
            string query = "select * from HOADON where MAHD = @MAHD";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAHD", mahd);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static DataTable TimKiemCT(int mahd)
        {
            string query = "select * from CHITIETHOADON where MAHD = @MAHD";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MAHD", mahd);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
    }
}