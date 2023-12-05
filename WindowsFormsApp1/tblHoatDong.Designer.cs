
namespace WindowsFormsApp1
{
    partial class tblHoatDong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIDDV = new System.Windows.Forms.TextBox();
            this.txtIDKH = new System.Windows.Forms.TextBox();
            this.txtTimeS = new System.Windows.Forms.TextBox();
            this.txtTimeE = new System.Windows.Forms.TextBox();
            this.txtIDHD = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvhoatdong = new System.Windows.Forms.DataGridView();
            this.bntxoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoatdong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(242, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách hoạt động";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIDDV);
            this.groupBox1.Controls.Add(this.txtIDKH);
            this.groupBox1.Controls.Add(this.txtTimeS);
            this.groupBox1.Controls.Add(this.txtTimeE);
            this.groupBox1.Controls.Add(this.txtIDHD);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(8, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 142);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin các hoạt động";
            // 
            // txtIDDV
            // 
            this.txtIDDV.Location = new System.Drawing.Point(95, 64);
            this.txtIDDV.Name = "txtIDDV";
            this.txtIDDV.Size = new System.Drawing.Size(186, 20);
            this.txtIDDV.TabIndex = 7;
            // 
            // txtIDKH
            // 
            this.txtIDKH.Location = new System.Drawing.Point(95, 103);
            this.txtIDKH.Name = "txtIDKH";
            this.txtIDKH.Size = new System.Drawing.Size(186, 20);
            this.txtIDKH.TabIndex = 6;
            // 
            // txtTimeS
            // 
            this.txtTimeS.Location = new System.Drawing.Point(426, 22);
            this.txtTimeS.Name = "txtTimeS";
            this.txtTimeS.Size = new System.Drawing.Size(204, 20);
            this.txtTimeS.TabIndex = 5;
            // 
            // txtTimeE
            // 
            this.txtTimeE.Location = new System.Drawing.Point(414, 57);
            this.txtTimeE.Name = "txtTimeE";
            this.txtTimeE.Size = new System.Drawing.Size(204, 20);
            this.txtTimeE.TabIndex = 4;
            // 
            // txtIDHD
            // 
            this.txtIDHD.Location = new System.Drawing.Point(95, 22);
            this.txtIDHD.Name = "txtIDHD";
            this.txtIDHD.Size = new System.Drawing.Size(186, 20);
            this.txtIDHD.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTim);
            this.groupBox2.Controls.Add(this.txtTim);
            this.groupBox2.Location = new System.Drawing.Point(354, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 49);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhập mã hoạt động để tìm";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(258, 19);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(65, 24);
            this.btnTim.TabIndex = 9;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(6, 22);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(245, 20);
            this.txtTim.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvhoatdong);
            this.groupBox3.Location = new System.Drawing.Point(8, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(618, 223);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin các hoạt động";
            // 
            // dgvhoatdong
            // 
            this.dgvhoatdong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhoatdong.Location = new System.Drawing.Point(7, 19);
            this.dgvhoatdong.Name = "dgvhoatdong";
            this.dgvhoatdong.Size = new System.Drawing.Size(598, 198);
            this.dgvhoatdong.TabIndex = 0;
            this.dgvhoatdong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvhoatdong_CellClick);
            // 
            // bntxoa
            // 
            this.bntxoa.Location = new System.Drawing.Point(637, 351);
            this.bntxoa.Name = "bntxoa";
            this.bntxoa.Size = new System.Drawing.Size(78, 35);
            this.bntxoa.TabIndex = 12;
            this.bntxoa.Text = "Xóa";
            this.bntxoa.UseVisualStyleBackColor = true;
            this.bntxoa.Click += new System.EventHandler(this.bntxoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(639, 228);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(78, 35);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(637, 288);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(78, 35);
            this.btnsua.TabIndex = 14;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã hoạt động";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Thời gian kết thúc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mã khách hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mã dịch vụ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Thời gian bắt đầu ";
            // 
            // tblHoatDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(722, 422);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.bntxoa);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "tblHoatDong";
            this.Text = "tblHoatDong";
            this.Load += new System.EventHandler(this.tblHoatDong_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoatdong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtIDDV;
        private System.Windows.Forms.TextBox txtIDKH;
        private System.Windows.Forms.TextBox txtTimeS;
        private System.Windows.Forms.TextBox txtTimeE;
        private System.Windows.Forms.TextBox txtIDHD;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.DataGridView dgvhoatdong;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button bntxoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}