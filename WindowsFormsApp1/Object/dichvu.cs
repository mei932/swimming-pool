using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Object
{
    class dichvu
    {
        private string IDDichVu;
        private string TenGoi;
        private string LoaiDichVu;
        private string MoTa;
        private float Gia;

        public dichvu(string IDDichVu, string TenGoi, string LoaiDichVu, string MoTa, float Gia)
        {
            this.IDDichVu = IDDichVu;
            this.TenGoi = TenGoi;
            this.LoaiDichVu = LoaiDichVu;
            this.MoTa = MoTa;
            this.Gia = Gia;
          
        }
        public string IDDichVuProperty
        {
            get { return IDDichVu; }
            set { IDDichVu = value; }
        }

        public string TenGoiProperty
        {
            get { return TenGoi; }
            set { TenGoi = value; }
        }

        public string LoaiDichVuProperty
        {
            get { return LoaiDichVu; }
            set { LoaiDichVu = value; }
        }

        public string MoTaProperty
        {
            get { return MoTa; }
            set { MoTa = value; }
        }

        public float GiaProperty
        {
            get { return Gia; }
            set { Gia = value; }
        }


    }
}
