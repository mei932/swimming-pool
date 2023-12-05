using QLbeboi;
using QLbeboi.Modify;
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
using WindowsFormsApp1.Object;

namespace WindowsFormsApp1
{
    public partial class tblKhachHang : Form
    {
        Modifyall modifyall = new Modifyall();
        khachhang kh;
        public tblKhachHang()
        {
            InitializeComponent();
        }
        public bool CheckValue()
        {
            if (string.IsNullOrWhiteSpace(txtIDKhachHang.Text) || string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtNgaysinh.Text) || string.IsNullOrWhiteSpace(txtGT.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }
        public void Getvaluetextbox()
        {
            string IDNhanVien = txtIDKhachHang.Text;
            string name = txtname.Text;
            string NgaySinh = txtNgaysinh.Text;
            string GT = txtGT.Text;
            string SDT = txtSDT.Text;
            string email = txtemail.Text;
            kh = new khachhang(IDNhanVien, name, NgaySinh, GT, SDT, email);
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDKhachHang_TextChanged(object sender, EventArgs e)
        {
           
        }
        public void load_data()
        {
            dgvKhachhang.DataSource = modifyall.Table("SELECT *FROM tblKhachHang");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckValue()) // Kiểm tra dữ liệu đã nhập
            {
                SqlConnection conn = connection.GetSqlConnection();

                string sqlCheck = "SELECT COUNT(*) FROM tblKhachHang WHERE IDKhachHang = @sMaKH";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@sMaKH", txtIDKhachHang.Text);

                try
                {
                    conn.Open();
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra mã khách hàng: " + ex.Message);
                    return;
                }
                finally
                {
                    conn.Close();
                }
                Getvaluetextbox();
                // Gọi phương thức InsertData để thêm dữ liệu vào SQL

                string query = "INSERT INTO tblKhachHang (IDKhachHang, HoTen, NgaySinh,GioiTinh, SDT, email) " +
                           "VALUES (@IDKhachHang, @name, @NgaySinh, @GT, @SDT, @email)";
                SqlCommand insert = new SqlCommand(query, conn);
                insert.Parameters.AddWithValue("@IDKhachHang", kh.IDKhachHangProperty);
                insert.Parameters.AddWithValue("@name", kh.NameProperty);
                insert.Parameters.AddWithValue("@NgaySinh", kh.NgaySinhProperty);
                insert.Parameters.AddWithValue("@GT", kh.GioiTinhProperty);
                insert.Parameters.AddWithValue("@SDT", kh.SDTProperty);
                insert.Parameters.AddWithValue("@email", kh.EmailProperty);

                // Sau khi thêm dữ liệu, cập nhật lại DataGridView
                dgvKhachhang.DataSource = modifyall.Table("SELECT * FROM tblNhanVien");

                load_data();
                try
                {
                    conn.Open();
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    load_data();// Tải lại dữ liệu trong DataGridView
                                                 // DeleteTextBoxes(); // Xóa các TextBox sau khi thêm thành công
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message);
                }
                finally
                {
                    conn.Close();

                }
            }

        }

        private void tblKhachHang_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void dgvKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhachhang.Rows.Count >= 0)
            {
                txtIDKhachHang.Text = dgvKhachhang.SelectedRows[0].Cells[0].Value.ToString();
                txtname.Text = dgvKhachhang.SelectedRows[0].Cells[1].Value.ToString();
                txtNgaysinh.Text = dgvKhachhang.SelectedRows[0].Cells[2].Value.ToString();
                txtGT.Text = dgvKhachhang.SelectedRows[0].Cells[3].Value.ToString();
                txtSDT.Text = dgvKhachhang.SelectedRows[0].Cells[3].Value.ToString();
                txtemail.Text = dgvKhachhang.SelectedRows[0].Cells[4].Value.ToString();


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                return;
            }
            if (CheckValue())
            {
                SqlConnection con = connection.GetSqlConnection();
                string sql = "SELECT COUNT (*) FROM tblKhachHang where IDKhachHang= @IDNhanVien";
                SqlCommand sqlCmd = new SqlCommand(sql, con);
                sqlCmd.Parameters.AddWithValue("@IDNhanVien", txtIDKhachHang.Text);
                con.Open();
                int count = (int)sqlCmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }

                Getvaluetextbox();
                string update = "UPDATE tblKhachHang SET HoTen = @name, NgaySinh = @NgaySinh, GioiTinh= @GT, SDT = @SDT, email = @email WHERE IDKhachHang = @IDKhachHang";
                SqlCommand udt = new SqlCommand(update, con);
                udt.Parameters.AddWithValue("@IDKhachHang", kh.IDKhachHangProperty);
                udt.Parameters.AddWithValue("@name", kh.NameProperty);
                udt.Parameters.AddWithValue("@NgaySinh", kh.NgaySinhProperty);
                udt.Parameters.AddWithValue("@GT", kh.GioiTinhProperty);
                udt.Parameters.AddWithValue("@SDT", kh.SDTProperty);
                udt.Parameters.AddWithValue("@email", kh.EmailProperty);
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        udt.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã sửa thông tin nhân viên thành công!");
                        load_data();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachhang.Rows.Count > 1)
            {
                string choose = dgvKhachhang.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblKhachHang ";
                query += " WHERE IDKhachHang = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modifyall.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 nhân viên thành công!");
                        load_data();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string name = txtTim.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng để tìm!");
                return;
            }
            else
            {
                string query = "SELECT * FROM tblKhachHang WHERE IDKhachHang =  @sMaNV";

                using (SqlConnection conn = connection.GetSqlConnection())
                {
                    DataTable resultTable = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sMaNV", name);
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(resultTable);
                    }

                    dgvKhachhang.DataSource = resultTable;
                }
            }

        }
    }
}
