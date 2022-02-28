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
    public class SanPhamDAO
    {
        public static DataTable LayDSSanPham()
        {
            string query = "select * from SANPHAM ";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static DataTable LayDSCT()
        {
            string query = "select * from CHITIETSANPHAM";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool ThemSanPham(SanPhamDTO sp)
        {
            string query = "insert into SANPHAM (TENSP, MALOAI, DONGIA, SOLUONGTON, MASX, HINHANH, TRANGTHAI ) values (@TENSP, @MALOAI, @DONGIA, @SOLUONGTON, @MASX, @HINHANH, @TRANGTHAI)";
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@TENSP", sp.Tensp);
            param[1] = new SqlParameter("@MALOAI", sp.Maloai);
            param[2] = new SqlParameter("@DONGIA", sp.DonGia);
            param[3] = new SqlParameter("@SOLUONGTON", sp.SoLuongTon);
            param[4] = new SqlParameter("@MASX", sp.Masx);
            param[5] = new SqlParameter("@HINHANH", sp.HinhAnh);
            param[6] = new SqlParameter("@TRANGTHAI", sp.TrangThai);
            return DataProvider.ExecuteNonQuery(query, param) == 1;

        }
        public static string LayMaSP()
        {
            string query = "select top 1 * from SANPHAM order by MASP desc";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }
        
        public static bool ThemCTSP(ChiTietSanPhamDTO ctsp)
        {
            string query = "insert into CHITIETSANPHAM (MASP,SIZE, MAU) values (@MASP,@SIZE,@MAU)";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@MASP", ctsp.MaSP);
            param[1] =new SqlParameter("@SIZE", ctsp.Size);
            param[2] =  new SqlParameter("@MAU", ctsp.Mau);
            return DataProvider.ExecuteNonQuery(query, param) == 1;

        }
  
        public static bool XoaSanPham(int masp)
        {
            string query = "UPDATE SANPHAM Set TRANGTHAI=0 WHERE MASP = @MASP  ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP",masp);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }
        public static bool SuaSanPham(SanPhamDTO sp)
        {
            string query = "UPDATE SANPHAM Set  TENSP = @TENSP, MALOAI = @MALOAI, DONGIA = @DONGIA, SOLUONGTON = @SOLUONGTON, MASX = @MASX, HINHANH = @HINHANH, TRANGTHAI =@TRANGTHAI WHERE  MASP = @MASP ";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@MASP", sp.Masp);
            param[1] = new SqlParameter("@TENSP", sp.Tensp);
            param[2] = new SqlParameter("@MALOAI", sp.Maloai);
            param[3] = new SqlParameter("@DONGIA", sp.DonGia);
            param[4] = new SqlParameter("@SOLUONGTON", sp.SoLuongTon);
            param[5] = new SqlParameter("@MASX", sp.Masx);
            param[6] = new SqlParameter("@HINHANH", sp.HinhAnh);
            param[7] = new SqlParameter("@TRANGTHAI", sp.TrangThai);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }
        public static bool SuaCTSP(ChiTietSanPhamDTO ctsp)
        {
            string query = "update CHITIETSANPHAM set SIZE =@SIZE, MAU =@MAU WHERE (MASP = @MASP AND SIZE LIKE @SIZE ) OR" +
                "(MASP =@MASP AND MAU LIKE @MAU+'%')";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@MASP", ctsp.MaSP);
            param[1] = new SqlParameter("@SIZE", ctsp.Size);
            param[2] = new SqlParameter("@MAU", ctsp.Mau);
            return DataProvider.ExecuteNonQuery(query, param) == 1;

        }
        public static DataTable DSLoaiSP()
        {
            string query = "select * from LOAISANPHAM ";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static string LayLoaiSP(int loaisp)
        {
            string query = "select TENLOAI from LOAISANPHAM where MALOAI = @MALOAI";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MALOAI",loaisp);
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }
        public static string LayNSX(int masx)
        {
            string query = "select TENNHASX from NHASANXUAT where MASX = @MASX";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASX", masx);
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }
        public static DataTable DSNSX()
        {
            string query = "Select * from NHASANXUAT";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static DataTable DSMAU()
        {
            string query = "Select Distinct MAU from CHITIETSANPHAM";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static DataTable DSSIZE()
        {
            string query = "Select Distinct SIZE from CHITIETSANPHAM";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }

        public static bool KTMaSP(int masp)
        {
            string query = "select count(*) from SANPHAM  where MASP = @MASP";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", masp);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) != 0;
        }
        public static DataTable TimKiemSP(int masp)
        {
            string query = "select * from SANPHAM where MASP = @MASP";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", masp);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static DataTable TimKiemCT(int masp)
        {
            string query = "select * from CHITIETSANPHAM where MASP = @MASP";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MASP", masp);
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool xoactsp(ChiTietSanPhamDTO ctsp)
        {
            string query = "delete from CHITIETSANPHAM where MASP = @MASP and MAU LIKE @MAU AND SIZE LIKE @SIZE";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@MASP", ctsp.MaSP);
            param[1] = new SqlParameter("@SIZE", ctsp.Size);
            param[2] = new SqlParameter("@MAU", ctsp.Mau);
            return DataProvider.ExecuteNonQuery(query, param) == 1;
        }    
    }

}
