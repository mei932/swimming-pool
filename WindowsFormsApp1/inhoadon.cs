using OfficeOpenXml;
using QLbeboi;
using QLbeboi.Modify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class inhoadon : Form
    {
        Modifyall modifyall = new Modifyall();
        public inhoadon()
        {
            InitializeComponent();
        }

        private void inhoadon_Load(object sender, EventArgs e)
        {
            DataTable dataTable = modifyall.Table("SELECT IDKhachHang FROM tblKhachHang");

            // Đặt nguồn dữ liệu cho ComboBox
            cbTim.DisplayMember = "IDKhachHang";
            cbTim.ValueMember = "IDKhachHang";
            cbTim.DataSource = dataTable;
        }

        private void txtTim_Click(object sender, EventArgs e)
        {
            string selectedID = cbTim.SelectedValue.ToString(); // Assuming the ValueMember of the ComboBox is set to the IDKhachHang

            using (SqlConnection con = connection.GetSqlConnection())
            {
                string query = @"SELECT 
                                    KH.IDKhachHang, 
                                    KH.Hoten AS 'Tên Khách Hàng', 
                                    DV.TenGoi AS 'Tên Dịch Vụ', 
                                    HD.ThoiGianBatDau AS 'Thời Gian Bắt Đầu', 
                                    HD.ThoiGianKetThuc AS 'Thời Gian Kết Thúc', 
                                    DATEDIFF(MINUTE, HD.ThoiGianBatDau, HD.ThoiGianKetThuc) AS 'Thời Gian Sử Dụng',
                                    CASE 
                                        WHEN DATEDIFF(MINUTE, HD.ThoiGianBatDau, HD.ThoiGianKetThuc) % 60 > 30 THEN (DATEDIFF(MINUTE, HD.ThoiGianBatDau, HD.ThoiGianKetThuc) / 60 + 1) * 25000
                                        ELSE (DATEDIFF(MINUTE, HD.ThoiGianBatDau, HD.ThoiGianKetThuc) / 60) * 25000
                                    END AS 'Thành Tiền'
                                FROM tblKhachHang KH
                                JOIN tblHoatDong HD ON KH.IDKhachHang = HD.IDKhachHang
                                JOIN tblDichVu DV ON HD.IDDichVu = DV.IDDichVu
                               
                                WHERE KH.IDKhachHang = @SelectedID";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@SelectedID", selectedID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvData.DataSource = table;
            }
            using (SqlConnection conn = connection.GetSqlConnection())
            {
                string query1 = @"SELECT 
                                    KH.IDKhachHang, 
                                    KH.Hoten AS 'Tên Khách Hàng', 
                                    SUM(
                                        CASE 
                                            WHEN DATEDIFF(MINUTE, HD.ThoiGianBatDau, HD.ThoiGianKetThuc) % 60 > 30 THEN (DATEDIFF(MINUTE, HD.ThoiGianBatDau, HD.ThoiGianKetThuc) / 60 + 1) * 25000
                                            ELSE (DATEDIFF(MINUTE, HD.ThoiGianBatDau, HD.ThoiGianKetThuc) / 60) * 25000
                                        END
                                    ) AS 'Tổng Thành Tiền'
                                FROM tblKhachHang KH
                                JOIN tblHoatDong HD ON KH.IDKhachHang = HD.IDKhachHang
                                JOIN tblDichVu DV ON HD.IDDichVu = DV.IDDichVu
                               
                                WHERE KH.IDKhachHang = @SelectedID
                                GROUP BY KH.IDKhachHang, KH.Hoten";
                // JOIN tblDoanhThu DT ON HD.IDHoatDong = DT.IDHoatDong

                SqlCommand command = new SqlCommand(query1, conn);
                command.Parameters.AddWithValue("@SelectedID", selectedID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Display data in DataGridView
                //dataGridView.DataSource = table;

                // Get total billing amount and display in TextBox
                if (table.Rows.Count > 0)
                {
                    string totalBilling = table.Rows[0]["Tổng Thành Tiền"].ToString();
                    txtTongTien.Text = totalBilling;
                }
            }


        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = "File_hoa_don_" + cbTim.Text + ".xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(sfd.FileName);
                        using (ExcelPackage package = new ExcelPackage(file))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Hoadondoanhthu");

                            var headerCell = worksheet.Cells["C1"];
                            headerCell.Value = "HÓA ĐƠN THANH TOÁN";
                            headerCell.Style.Font.Color.SetColor(System.Drawing.Color.Red);
                            headerCell.Style.Font.Bold = true;

                            // Get data from DataGridView
                            DataTable table = (DataTable)dgvData.DataSource;

                            // Write data to Excel worksheet
                            int rowCount = table.Rows.Count;
                            int colCount = table.Columns.Count;

                            // Write header row
                            for (int i = 1; i <= colCount; i++)
                            {
                                worksheet.Column(i).Width = 20;
                                worksheet.Cells[3, i].Value = table.Columns[i - 1].ColumnName;
                            }

                            // Write data rows
                            for (int r = 0; r < rowCount; r++)
                            {
                                for (int c = 0; c < colCount; c++)
                                {
                                    worksheet.Cells[r + 4, c + 1].Value = table.Rows[r][c];
                                }
                            }

                            worksheet.Cells[rowCount + 5, colCount-1].Value = "TỔNG TIỀN:";
                            worksheet.Cells[rowCount + 5, colCount].Value = txtTongTien.Text;

                            worksheet.Cells[rowCount + 7, colCount ].Value = "NGƯỜI LẬP ĐƠN";
                            worksheet.Cells[rowCount + 12, colCount-1].Value = "Hà Nội, Ngày......, Tháng,......Năm";

                            // Save the Excel file
                            package.Save();
                        }

                        MessageBox.Show("Xuất Excel thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
