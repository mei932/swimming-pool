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
    public partial class tblDichVu : Form
    {
        Modifyall modifyall = new Modifyall();
        dichvu dv;
        public tblDichVu()
        {
            InitializeComponent();
        }
        public bool CheckValue()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtLoai.Text) || string.IsNullOrWhiteSpace(txtMota.Text) ||
                string.IsNullOrWhiteSpace(txtGia.Text))
                
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }
        public void Getvaluetextbox()
        {
            string IDDichVu = txtID.Text;
            string TenGoi = txtname.Text;
            string Loai = txtLoai.Text;
            string MoTa = txtMota.Text;
            float Gia = float.Parse(txtGia.Text);
            dv = new dichvu(IDDichVu, TenGoi, Loai, MoTa, Gia);
        }
        private void tblDichVu_Load(object sender, EventArgs e)
        {
            load_data();
        }
        public void load_data()
        {
            dgvDichVu.DataSource = modifyall.Table("select * from tblDichVu");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            /* if (CheckValue()) // Kiểm tra dữ liệu đã nhập
             {
                 SqlConnection conn = connection.GetSqlConnection();

                 string sqlCheck = "select IDDichVu from tblDichVu WHERE IDDichVu = @ID";
                 SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                 cmdCheck.Parameters.AddWithValue("@ID", txtID.Text);

                 try
                 {
                     conn.Open();
                     int count = (int)cmdCheck.ExecuteScalar();
                     if (count > 0)
                     {
                         MessageBox.Show("Mã dịch vụ đã tồn tại!");
                         return;
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Lỗi kiểm tra mã dịch vụ : " + ex.Message);
                     return;
                 }
                 finally
                 {
                     conn.Close();
                 }
                 Getvaluetextbox();
                 // Gọi phương thức InsertData để thêm dữ liệu vào SQL

                 string query = "INSERT INTO tblDichVu (IDDichVu, TenGoi, LoaiDichVu, MoTa, Gia) " +
                  "VALUES (@ID, @TenGoi, @LoaiDichVu, @MoTa, @Gia)";
                 SqlCommand insert = new SqlCommand(query, conn);
                 insert.Parameters.AddWithValue("@ID", dv.IDDichVuProperty);
                 insert.Parameters.AddWithValue("@TenGoi", dv.TenGoiProperty);
                 insert.Parameters.AddWithValue("@LoaiDichVu", dv.LoaiDichVuProperty);
                 insert.Parameters.AddWithValue("@MoTa", dv.MoTaProperty);
                 insert.Parameters.AddWithValue("@Gia", dv.GiaProperty);


                 // Sau khi thêm dữ liệu, cập nhật lại DataGridView
                 dgvDichVu.DataSource = modifyall.Table("SELECT * FROM tblDichVu");

                 load_data();
                 try
                 {
                     conn.Open();
                     insert.ExecuteNonQuery();
                     MessageBox.Show("Thêm dịch vụ thành công!");
                     load_data();// Tải lại dữ liệu trong DataGridView
                                 // DeleteTextBoxes(); // Xóa các TextBox sau khi thêm thành công
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Lỗi thêm dịch vụ: " + ex.Message);
                 }
                 finally
                 {
                     conn.Close();

                 }
             }*/
            if (CheckValue()) // Kiểm tra dữ liệu đã nhập
            {
                SqlConnection conn = connection.GetSqlConnection();

                string sqlCheck = "SELECT COUNT(*) FROM tblDichVu WHERE IDDichVu = @ID";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@ID", txtID.Text);

                try
                {
                    conn.Open();
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã dịch vụ đã tồn tại!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra mã dịch vụ : " + ex.Message);
                    return;
                }
                finally
                {
                    conn.Close();
                }

                Getvaluetextbox();

                string query = "INSERT INTO tblDichVu (IDDichVu, TenGoi, LoaiDichVu, MoTa, Gia) " +
                               "VALUES (@ID, @TenGoi, @LoaiDichVu, @MoTa, @Gia)";
                SqlCommand insert = new SqlCommand(query, conn);
                insert.Parameters.AddWithValue("@ID", dv.IDDichVuProperty);
                insert.Parameters.AddWithValue("@TenGoi", dv.TenGoiProperty);
                insert.Parameters.AddWithValue("@LoaiDichVu", dv.LoaiDichVuProperty);
                insert.Parameters.AddWithValue("@MoTa", dv.MoTaProperty);
                insert.Parameters.AddWithValue("@Gia", dv.GiaProperty);

                try
                {
                    conn.Open();
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Thêm dịch vụ thành công!");
                    load_data(); // Tải lại dữ liệu trong DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm dịch vụ: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ!");
                return;
            }
            if (CheckValue())
            {
                SqlConnection con = connection.GetSqlConnection();
                string sql = "select * from tblDichVu where IDDichVu= @ID";
                SqlCommand sqlCmd = new SqlCommand(sql, con);
                sqlCmd.Parameters.AddWithValue("@ID", txtID.Text);
                con.Open();
                int count = (int)sqlCmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }

                Getvaluetextbox();
                string update = "UPDATE tblDichVu SET TenGoi = @name, LoaiDichVu = @dv, MoTa= @MT, Gia= @gia WHERE IDDichVu = @ID";
                SqlCommand udt = new SqlCommand(update, con);
                udt.Parameters.AddWithValue("@ID", dv.IDDichVuProperty);
                udt.Parameters.AddWithValue("@name", dv.TenGoiProperty);
                udt.Parameters.AddWithValue("@dv", dv.LoaiDichVuProperty);
                udt.Parameters.AddWithValue("@MT", dv.MoTaProperty);
                udt.Parameters.AddWithValue("@gia", dv.GiaProperty);

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
            if (dgvDichVu.Rows.Count > 1)
            {
                string choose = dgvDichVu.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblDichVu ";
                query += " WHERE IDDichVu = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modifyall.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 dịch vụ thành công!");
                        load_data();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtTim.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ để tìm!");
                return;
            }
            else
            {
                string query = "SELECT * FROM tblDichVu WHERE IDDichVu =  @sMaNV";

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

                    dgvDichVu.DataSource = resultTable;
                }
            }
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDichVu.Rows.Count >= 0)
            {
                txtID.Text = dgvDichVu.SelectedRows[0].Cells[0].Value.ToString();
                txtname.Text = dgvDichVu.SelectedRows[0].Cells[1].Value.ToString();
                txtLoai.Text = dgvDichVu.SelectedRows[0].Cells[2].Value.ToString();
                txtMota.Text = dgvDichVu.SelectedRows[0].Cells[3].Value.ToString();
                txtGia.Text = dgvDichVu.SelectedRows[0].Cells[4].Value.ToString();
               


            }
        }
    }
}
