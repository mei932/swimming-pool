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
    public partial class tblHoatDong : Form
    {
        Modifyall modifyall = new Modifyall();
        hoatdong hd;
        public tblHoatDong()
        {
            InitializeComponent();
        }

        public bool CheckValue()
        {
            if (string.IsNullOrWhiteSpace(txtIDHD.Text) || string.IsNullOrWhiteSpace(txtIDDV.Text) ||
                string.IsNullOrWhiteSpace(txtIDKH.Text) || string.IsNullOrWhiteSpace(txtTimeS.Text) ||
                string.IsNullOrWhiteSpace(txtTimeE.Text))

            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }
        public void Getvaluetextbox()
        {
            string IDHD = txtIDHD.Text;
            string IDDV = txtIDDV.Text;
            string IDKH = txtIDKH.Text;
            DateTime timeS = DateTime.Parse(txtTimeS.Text);
            DateTime timeE = DateTime.Parse(txtTimeE.Text);
            hd = new hoatdong(IDHD, IDDV, IDKH, timeS, timeE);
        }
        public void load_data()
        {
            dgvhoatdong.DataSource = modifyall.Table("select * from tblHoatDong");
        }
        private void dgvhoatdong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvhoatdong.Rows.Count >= 0)
            {
               txtIDHD.Text = dgvhoatdong.SelectedRows[0].Cells[0].Value.ToString();
                txtIDDV.Text = dgvhoatdong.SelectedRows[0].Cells[1].Value.ToString();
                txtIDKH.Text = dgvhoatdong.SelectedRows[0].Cells[2].Value.ToString();
                txtTimeS.Text = dgvhoatdong.SelectedRows[0].Cells[3].Value.ToString();
                txtTimeE.Text = dgvhoatdong.SelectedRows[0].Cells[4].Value.ToString();


            }
        }
        private void tblHoatDong_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckValue()) // Kiểm tra dữ liệu đã nhập
            {
                SqlConnection conn = connection.GetSqlConnection();

                string sqlCheck = "SELECT COUNT(*) FROM tblHoatDong WHERE IDHoatDong = @IDHD";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@IDHD", txtIDHD.Text);

                try
                {
                    conn.Open();
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã hoạt động đã tồn tại!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra mã hoạt động: " + ex.Message);
                    return;
                }
                finally
                {
                    conn.Close();
                }
                Getvaluetextbox();
                // Gọi phương thức InsertData để thêm dữ liệu vào SQL

                string query = "INSERT INTO tblHoatDong (IDHoatDong, IDDichVu, IDKhachHang,ThoiGianBatDau, ThoiGianKetThuc) " +
                           "VALUES (@IDHD, @IDDV, @IDKH, @Times, @Timee)";
                SqlCommand insert = new SqlCommand(query, conn);
                insert.Parameters.AddWithValue("@IDHD", hd.IDHoatDongProperty);
                insert.Parameters.AddWithValue("@IDDV", hd.IDDichVuProperty);
                insert.Parameters.AddWithValue("@IDKH", hd.IDKhachHangProperty);
                insert.Parameters.AddWithValue("@Times", hd.ThoiGianBatDauProperty);
                insert.Parameters.AddWithValue("@Timee", hd.ThoiGianKetThucProperty);


                // Sau khi thêm dữ liệu, cập nhật lại DataGridView
                dgvhoatdong.DataSource = modifyall.Table("SELECT * FROM tblHoatDong");

                load_data();
                try
                {
                    conn.Open();
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Thêm dữ liệu thành công!");
                    load_data();// Tải lại dữ liệu trong DataGridView
                                // DeleteTextBoxes(); // Xóa các TextBox sau khi thêm thành công
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
                finally
                {
                    conn.Close();

                }
            }
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDHD.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hoạt động!");
                return;
            }
            if (CheckValue())
            {
                SqlConnection con = connection.GetSqlConnection();
                string sql = "SELECT COUNT (*) FROM tblHoatDong where IDHoatDong= @IDHD";
                SqlCommand sqlCmd = new SqlCommand(sql, con);
                sqlCmd.Parameters.AddWithValue("@IDHD", txtIDHD.Text);
                con.Open();
                int count = (int)sqlCmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Mã hoạt dộng không tồn tại!");
                    return;
                }

                Getvaluetextbox();
                string update = "UPDATE tblHoatDong SET IDDichVu = @IDDV, IDKhachHang = @IDKH, ThoiGianBatDau= @Times, ThoiGianKetThuc= @Timee WHERE IDHoatDong = @IDHD";
                SqlCommand udt = new SqlCommand(update, con);
                udt.Parameters.AddWithValue("@IDHD", hd.IDHoatDongProperty);
                udt.Parameters.AddWithValue("@IDDV", hd.IDDichVuProperty);
                udt.Parameters.AddWithValue("@IDKH", hd.IDKhachHangProperty);
                udt.Parameters.AddWithValue("@Times", hd.ThoiGianBatDauProperty);
                udt.Parameters.AddWithValue("@Timee", hd.ThoiGianKetThucProperty);
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



        private void bntxoa_Click(object sender, EventArgs e)
        {
            if (dgvhoatdong.Rows.Count > 1)
            {
                string choose = dgvhoatdong.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblHoatDong ";
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
                string query = "SELECT * FROM tblHoatDong WHERE IDHoatDong =  @sMaNV";

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

                    dgvhoatdong.DataSource = resultTable;
                }
            }
        }

    
    }
}
