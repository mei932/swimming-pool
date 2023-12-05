using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Object
{
    class hoatdong
    {
        private string IDHoatDong;
        private string IDDichVu;
        private string IDKhachHang;
        private DateTime ThoiGianBatDau;
        private DateTime ThoiGianKetThuc;


        public hoatdong(string IDHoatDong, string IDDichVu, string IDKhachHang, DateTime ThoiGianBatDau, DateTime ThoiGianKetThuc)
        {
            this.IDHoatDong = IDHoatDong;
            this.IDDichVu = IDDichVu;
            this.IDKhachHang = IDKhachHang;
            this.ThoiGianBatDau =       ThoiGianBatDau;
            this.ThoiGianKetThuc = ThoiGianKetThuc;

        }
        public string IDHoatDongProperty
        {
            get { return IDHoatDong; }
            set { IDHoatDong = value; }
        }

        public string IDDichVuProperty
        {
            get { return IDDichVu; }
            set { IDDichVu = value; }
        }

        public string IDKhachHangProperty
        {
            get { return IDKhachHang; }
            set { IDKhachHang = value; }
        }

        public DateTime ThoiGianBatDauProperty
        {
            get { return ThoiGianBatDau; }
            set { ThoiGianBatDau = value; }
        }

        public DateTime ThoiGianKetThucProperty
        {
            get { return ThoiGianKetThuc; }
            set { ThoiGianKetThuc = value; }
        }

    }
}
