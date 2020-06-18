using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_OneAuto 
{
    public class KhachHang
    {
        public KhachHang( string makh,  string tenkh, string diachi, string sdt   ,DateTime ngaynhap,string email)
        {
            this.makh = makh;
            this.Email = email;
            this.tenkh = tenkh;
            this.diachi = diachi;
            this.Ngaysinh = ngaysinh;
            //this.tennv = tennv;
            this.sdt = sdt;
            this.ngaynhap = ngaynhap;
        }
        //mặc đinh
        public KhachHang()
        {

        }

        public KhachHang(KhachHang x)
        {
            this.makh = x.makh;
             
            this.tenkh = x.tenkh;
            this.diachi = x.diachi;
            
            //this.tennv = x.tennv;
            this.sdt = x.sdt;
            this.ngaynhap = x.ngaynhap;
        }
        private string makh;
        private string chudaily;
        private string tenkh;
        private string diachi;
        private string sdt;
        private DateTime ngaysinh;
        private string email;
        private string tennv;
        private DateTime ngaynhap;

        public string Makh { get => makh; set => makh = value; }
        public string Chudaily { get => chudaily; set => chudaily = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        
         
        public string Tennv { get => tennv; set => tennv = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public DateTime Ngaynhap { get => ngaynhap; set => ngaynhap = value; }
        public string Email { get => email; set => email = value; }
    }

}
