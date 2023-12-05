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

namespace QLbeboi
{
    public partial class tblNhanVien : Form
    {
        Modifyall modifyall = new Modifyall();
        nhanvien nhanvien;

        public tblNhanVien()
        {
            InitializeComponent();
        }
        public bool CheckValue()
        {
            if (string.IsNullOrWhiteSpace(txtIDNhanVien.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDate.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }
        public void Getvaluetextbox()
        {
            string IDNhanVien = txtIDNhanVien.Text;
            string name = txtName.Text;
            string NgaySinh = txtDate.Text;
            string Chucvu = txtChucvu.Text;
            string DiaChi = txtDiaChi.Text;
            string SDT = txtSDT.Text;
            string email = txtemail.Text;
            nhanvien = new nhanvien(IDNhanVien, name, NgaySinh, Chucvu, DiaChi, SDT, email);
        }

        private void tblNhanVien_Load(object sender, EventArgs e)
        {
            load_data();
        }
        public void load_data()
        {
            dgvNhanVien.DataSource = modifyall.Table("SELECT *FROM tblNhanVien");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckValue()) // Kiểm tra dữ liệu đã nhập
            {
                SqlConnection conn = connection.GetSqlConnection();

                string sqlCheck = "SELECT COUNT(*) FROM tblNhanVien WHERE IDNhanVien = @sMaNV";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@sMaNV", txtIDNhanVien.Text);

                try
                {
                    conn.Open();
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra mã nhân viên: " + ex.Message);
                    return;
                }
                finally
                {
                    conn.Close();
                }
                Getvaluetextbox();
                // Gọi phương thức InsertData để thêm dữ liệu vào SQL

                string query = "INSERT INTO tblNhanVien (IDNhanVien, HoTen, NgaySinh, Chucvu, DiaChi, SDT, email) " +
                           "VALUES (@IDNhanVien, @name, @NgaySinh, @Chucvu, @DiaChi, @SDT, @email)";
                SqlCommand insert = new SqlCommand(query, conn);
                insert.Parameters.AddWithValue("@IDNhanVien", nhanvien.IDNhanVienProperty);
                insert.Parameters.AddWithValue("@name", nhanvien.NameProperty);
                insert.Parameters.AddWithValue("@NgaySinh", nhanvien.NgaySinhProperty);
                insert.Parameters.AddWithValue("@Chucvu", nhanvien.ChucvuProperty);
                insert.Parameters.AddWithValue("@DiaChi", nhanvien.DiaChiProperty);
                insert.Parameters.AddWithValue("@SDT", nhanvien.SDTProperty);
                insert.Parameters.AddWithValue("@email", nhanvien.EmailProperty);

                // Sau khi thêm dữ liệu, cập nhật lại DataGridView
                dgvNhanVien.DataSource = modifyall.Table("SELECT * FROM tblNhanVien");

                load_data();
                try
                {
                    conn.Open();
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    tblNhanVien_Load(sender, e); // Tải lại dữ liệu trong DataGridView
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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.Rows.Count >= 0)
            {
                txtIDNhanVien.Text = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvNhanVien.SelectedRows[0].Cells[1].Value.ToString();
                txtDate.Text = dgvNhanVien.SelectedRows[0].Cells[2].Value.ToString();
                txtChucvu.Text = dgvNhanVien.SelectedRows[0].Cells[3].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.SelectedRows[0].Cells[4].Value.ToString();
                txtSDT.Text = dgvNhanVien.SelectedRows[0].Cells[5].Value.ToString();
                txtemail.Text = dgvNhanVien.SelectedRows[0].Cells[6].Value.ToString();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtIDNhanVien.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                return;
            }
            if (CheckValue())
            {
                SqlConnection con = connection.GetSqlConnection();
                string sql = "SELECT COUNT (*) FROM tblNhanVien where IDNhanVien= @IDNhanVien";
                SqlCommand sqlCmd = new SqlCommand(sql, con);
                sqlCmd.Parameters.AddWithValue("@IDNhanVien", txtIDNhanVien.Text);
                con.Open();
                int count = (int)sqlCmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }

                Getvaluetextbox();
                string update = "UPDATE tblNhanVien SET HoTen = @name, NgaySinh = @NgaySinh, Chucvu = @Chucvu, DiaChi = @DiaChi, SDT = @SDT, email = @email WHERE IDNhanVien = @IDNhanVien";
                SqlCommand udt = new SqlCommand(update, con);
                udt.Parameters.AddWithValue("@IDNhanVien", nhanvien.IDNhanVienProperty);
                udt.Parameters.AddWithValue("@name", nhanvien.NameProperty);
                udt.Parameters.AddWithValue("@NgaySinh", nhanvien.NgaySinhProperty);
                udt.Parameters.AddWithValue("@Chucvu", nhanvien.ChucvuProperty);
                udt.Parameters.AddWithValue("@DiaChi", nhanvien.DiaChiProperty);
                udt.Parameters.AddWithValue("@SDT", nhanvien.SDTProperty);
                udt.Parameters.AddWithValue("@email", nhanvien.EmailProperty);
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        udt.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã sửa thông tin nhân viên thành công!");
                        tblNhanVien_Load(sender, e);
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
            if (dgvNhanVien.Rows.Count > 1)
            {
                string choose = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblNhanVien ";
                query += " WHERE IDNhanVien = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modifyall.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 nhân viên thành công!");
                        tblNhanVien_Load(sender, e);
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
                MessageBox.Show("Vui lòng nhập mã nhân viên để tìm!");
                return;
            }
            else
            {
                string query = "SELECT * FROM tblNhanVien WHERE IDNhanVien =  @sMaNV";

                using (SqlConnection conn = connection.GetSqlConnection())
                {
                    DataTable resultTable = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sMaNV",  name );
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(resultTable);
                    }

                    dgvNhanVien.DataSource = resultTable;
                }
            } 

        }
    }
}
