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
    public partial class tblDoanhThu : Form
    {
        public tblDoanhThu()
        {
            InitializeComponent();
        }
        Modifyall modifyall = new Modifyall();
        doanhthu dt;
        public bool CheckValue()
        {
            if (string.IsNullOrWhiteSpace(txtMDT.Text) || string.IsNullOrWhiteSpace(txtMNV.Text) ||
                string.IsNullOrWhiteSpace(txtNTH.Text) || string.IsNullOrWhiteSpace(txtHD.Text) ||
                string.IsNullOrWhiteSpace(txtSoTien.Text))

            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }
        public void Getvaluetextbox()
        {
            string MDT = txtMDT.Text;
            string MNV = txtMNV.Text;
            DateTime NTH = DateTime.Parse(txtNTH.Text);
            float SoTien = float.Parse(txtSoTien.Text);
            string HD = txtHD.Text;
            dt = new doanhthu(MDT, MNV, NTH, SoTien, HD);
        }
        public void load_data()
        {
            dgvDoanhThu.DataSource = modifyall.Table("select * from tblDoanhThu");
        }
        private void tblDoanhThu_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void dgvDoanhThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDoanhThu.Rows.Count >= 0)
            {
                txtMDT.Text = dgvDoanhThu.SelectedRows[0].Cells[0].Value.ToString();
                txtMNV.Text = dgvDoanhThu.SelectedRows[0].Cells[1].Value.ToString();
                txtNTH.Text = dgvDoanhThu.SelectedRows[0].Cells[2].Value.ToString();
                txtSoTien.Text = dgvDoanhThu.SelectedRows[0].Cells[3].Value.ToString();
                txtHD.Text = dgvDoanhThu.SelectedRows[0].Cells[4].Value.ToString();


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
                string query = "SELECT * FROM tblDoanhThu WHERE IDDoanhThu =  @sMaNV";

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

                    dgvDoanhThu.DataSource = resultTable;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckValue()) // Kiểm tra dữ liệu đã nhập
            {
                SqlConnection conn = connection.GetSqlConnection();

                string sqlCheck = "SELECT COUNT(*) FROM tblDoanhThu WHERE IDDoanhThu = @ID";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@ID", txtMDT.Text);

                try
                {
                    conn.Open();
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã doanh thu đã tồn tại!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra mã doanh thu : " + ex.Message);
                    return;
                }
                finally
                {
                    conn.Close();
                }

                Getvaluetextbox();

                string query = "INSERT INTO tblDoanhThu (IDDoanhThu, IDNhanVien, NgayThucHien, SoTien, IDHoatDong) " +
                               "VALUES (@ID, @IDNV, @NTH, @ST, @IDHD)";
                SqlCommand insert = new SqlCommand(query, conn);
                insert.Parameters.AddWithValue("@ID", dt.IDDoanhThuProperty);
                insert.Parameters.AddWithValue("@IDNV", dt.IDDoanhThuProperty);
                insert.Parameters.AddWithValue("@NTH", dt.NgayThucHienProperty);
                insert.Parameters.AddWithValue("@ST", dt.SoTienProperty);
                insert.Parameters.AddWithValue("@IDHD", dt.HoatDongProperty);

                try
                {
                    conn.Open();
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Thêm  thành công!");
                    load_data(); // Tải lại dữ liệu trong DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi h vụ: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMDT.Text))
            {
                MessageBox.Show("Vui lòng nhập mã doanh thu!");
                return;
            }
            if (CheckValue())
            {
                SqlConnection con = connection.GetSqlConnection();
                string sql = "SELECT COUNT (*) FROM tblDoanhThu where IDDoanhThu= @IDDT";
                SqlCommand sqlCmd = new SqlCommand(sql, con);
                sqlCmd.Parameters.AddWithValue("@IDDT", txtMDT.Text);
                con.Open();
                int count = (int)sqlCmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Mã không tồn tại!");
                    return;
                }

                Getvaluetextbox();
                string update = "UPDATE tblDoanhThu SET  IDNhanVien = @IDNV, NgayThucHien=@NTH, SoTien= @SoTien, IDHoatDong= @HD WHERE IDDoanhThu = @IDDT";
                SqlCommand udt = new SqlCommand(update, con);
                udt.Parameters.AddWithValue("@IDDT", dt.IDDoanhThuProperty);
                udt.Parameters.AddWithValue("@IDNV", dt.IDNhanVienProperty);
                udt.Parameters.AddWithValue("@NTH", dt.NgayThucHienProperty);
                udt.Parameters.AddWithValue("@SoTien", dt.SoTienProperty);
                udt.Parameters.AddWithValue("@HD", dt.HoatDongProperty);
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        udt.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã sửa thông tin thành công!");
                        load_data();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvDoanhThu.Rows.Count > 1)
            {
                string choose = dgvDoanhThu.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblDoanhThu ";
                query += " WHERE IDHoatDong = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modifyall.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 đối tượng thành công!");
                        load_data();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

      
    }
}
