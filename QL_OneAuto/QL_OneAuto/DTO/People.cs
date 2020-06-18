using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_OneAuto
{
    public class People
    {
        public People(string id, string hoten, string phone,string diachi,string tenloai, string email, string ngaysinh, DateTime ngaytao )
        {
            this.tenloai = tenloai;
            this.diachi = diachi;
            this.phone = phone;
            this.Ngaysinh = ngaysinh;
            this.ngaytao = ngaytao;
            this.Id = id;
            this.hoten = hoten;
            this.email = email;
        }
        //mặc đinh
        public People()
        {

        }
        //copy
        public People(People x)
        {
            this.Tenloai = x.tenloai;
            this.diachi = x.diachi;
            this.phone = x.phone;
            this.Ngaysinh = x.Ngaysinh;
            this.ngaytao = x.ngaytao;
            this.Id = x.id;
            this.hoten = x.hoten;
            this.email = x.email;
        }

        public void GetFullInfo( )
        {
            try { 
            DataTable ds = DataProvider.Instance.ExecuteQuery("select * from NhanVien n, loainhanvien l where l.MaLoai=n.MaLoai and MaNV='" + id + "'");
            tenloai = ds.Rows[0]["TenLoai"].ToString();
            diachi = ds.Rows[0]["DiaChi"].ToString();
            email = ds.Rows[0]["Email"].ToString();
            Ngaysinh = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(ds.Rows[0]["NgaySinh"]));
            ngaytao = Convert.ToDateTime(ds.Rows[0]["NgayNhap"]);
            hoten = ds.Rows[0]["TenNV"].ToString();
            phone = ds.Rows[0]["SDT"].ToString();
            }
            catch
            {

            }
 
        }
        public void GetFullInfobyID(string a)
        {

            DataTable ds = DataProvider.Instance.ExecuteQuery("select * from NhanVien n, loainhanvien l where l.MaLoai=n.MaLoai and MaNV='" + a + "'");
            tenloai = ds.Rows[0]["TenLoai"].ToString();
            diachi = ds.Rows[0]["DiaChi"].ToString();
            email = ds.Rows[0]["Email"].ToString();
            Ngaysinh = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(ds.Rows[0]["NgaySinh"]));
            ngaytao = Convert.ToDateTime(ds.Rows[0]["NgayNhap"]);
            hoten = ds.Rows[0]["TenNV"].ToString();
            phone = ds.Rows[0]["SDT"].ToString();

        }
        //Lấy toàn bộ thông tin của đối tượng này dựa vào ID


        private string phone;
        private string ngaysinh;
        private DateTime ngaytao;
        private string id;
        private string hoten;
        private string tenloai;
        private string email;
        private string diachi;


        public string Phone { get => phone; set => phone = value; }
       // public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public DateTime Ngaytao { get => ngaytao; set => ngaytao = value; }
        public string Hoten { get => hoten; set => hoten = value; }
     
         
        public string Email { get => email; set => email = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Tenloai { get => tenloai; set => tenloai = value; }
        public string Id { get => id; set => id = value; }
        public string Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
    }

    public class nhanvien : People
    {
        
        //mặc đinh
        public nhanvien()
        {

        }
        public nhanvien(string phone, DateTime ngaysinh, DateTime ngaytao, int id, string hoten)
        {

        }
        
       
    }
}
