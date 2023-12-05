using QLbeboi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class tblTKtheongay : Form
    {
        public tblTKtheongay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nam = txtnam.Text;
            string sql = "SELECT TOP 1 nv.Hoten AS 'Tên nhân viên', SUM(dt.SoTien) AS 'Tổng doanh thu' " +
                    "FROM tblNhanVien nv " +
                    "JOIN tblDoanhThu dt ON nv.IDNhanVien = dt.IDNhanVien " +
                    "WHERE YEAR(dt.NgayThucHien) = @Nam " +
                    "GROUP BY nv.Hoten " +
                    "ORDER BY SUM(dt.SoTien) DESC";
            using (SqlConnection con = connection.GetSqlConnection())
            {
                con.Open(); // Mở kết nối trước khi thực hiện truy vấn

                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@Nam", nam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string tenNhanVien = reader["Tên nhân viên"].ToString();
                    string tongDoanhThu = reader["Tổng doanh thu"].ToString();

                    txtName.Text = tenNhanVien;
                    txtTong.Text = tongDoanhThu;
                }
                else
                {
                    txtName.Text = $"Năm {nam} không có dữ liệu để thống kê.";
                    txtTong.Text = $"Năm {nam} không có dữ liệu để thống kê.";
                }

                reader.Close();
                con.Close(); // Đóng kết nối sau khi sử dụng xong
            }






            

            string sqll = "SELECT TOP 1 " +
                         "    dv.TenGoi AS 'Tên dịch vụ', " +
                         "    COUNT(hd.IDDichVu) AS 'Số lượng' " +
                         "FROM tblHoatDong hd " +
                         "JOIN tblDichVu dv ON hd.IDDichVu = dv.IDDichVu " +
                         "WHERE YEAR(hd.ThoiGianBatDau) = @Nam OR YEAR(hd.ThoiGianKetThuc) = @Nam " +
                         "GROUP BY dv.TenGoi " +
                         "ORDER BY COUNT(hd.IDDichVu) DESC";

            using (SqlConnection con = connection.GetSqlConnection())
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqll, con);
                command.Parameters.AddWithValue("@Nam", nam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string tenDichVu = reader["Tên dịch vụ"].ToString();
                    string soLuong = reader["Số lượng"].ToString();

                    txxtTenDv.Text = tenDichVu;
                    txtTongSl.Text = soLuong;
                }
                else
                {
                    txxtTenDv.Text = $"Năm {nam} không có dữ liệu để thống kê.";
                    txtTongSl.Text = $"Năm {nam} không có dữ liệu để thống kê.";
                }

                reader.Close();
                con.Close();
            }


            string sqlTongDoanhThu = "SELECT SUM(dt.SoTien) AS 'Tổng doanh thu' " +
                                         "FROM tblDoanhThu dt " +
                                         "WHERE YEAR(dt.NgayThucHien) = @Nam";
            using (SqlConnection con = connection.GetSqlConnection())
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlTongDoanhThu, con);
                command.Parameters.AddWithValue("@Nam", nam);

                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    decimal tongDoanhThu = Convert.ToDecimal(result);
                    // Hiển thị kết quả vào ô TextBox hoặc nơi bạn muốn
                    txtTongDoanhThu.Text = tongDoanhThu.ToString("N2");
                }
                else
                {
                    txtTongDoanhThu.Text = $"Năm {nam} không có dữ liệu để tính tổng doanh thu.";
                }

                con.Close();
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
