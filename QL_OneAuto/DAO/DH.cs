using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_OneAuto.DTO;
namespace QL_OneAuto.DAO
{
    public class DH
    {
        private static DH instance;

        public static DH Instance
        {
            get { if (instance == null) instance = new DH(); return instance; }
            private set { instance = value; }
        }
        private List<DonHangDTO> list = new List<DonHangDTO>();
        public void Add(DonHangDTO x)
        {
            list.Add(x);
        }


        public DonHangDTO this[string id]
        {
            get
            {
                DonHangDTO people = list.Find(x => x.Madh == id);
                if (people is null)
                {
                    people = new DonHangDTO();
                    people.Tenkh = "<Không tìm thấy>";
                }
                return people;

            }
        }

        // Lấy ra độ dài list
        public int Length
        {
            get { return list.Count; }
        }
        // inderxer lấy ra nhân viên bằng cách truy cập vào vị trí
        public DonHangDTO this[int x]
        {
            get
            {
                if (x >= Length || x < 0) return null;
                return list[x];
            }
        }


        public void GetFullInfo(string danhsach = "listTTbanle")
        {
            list.Clear();
            try
            {
                
                DataTable ds = DataProvider.Instance.ExecuteQuery(danhsach);
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    DonHangDTO people;
                    DateTime ngaynhap = Convert.ToDateTime(ds.Rows[i]["NgayNhap"]);
                    //DateTime ngaysinh = Convert.ToDateTime(ds.Rows[i]["NgaySinh"]);
                    double a = Convert.ToDouble(ds.Rows[i]["TongTien"]);
                    double b = Convert.ToDouble(ds.Rows[i]["GiaTien"]);
                    people = new DonHangDTO(ds.Rows[i]["MaDH"].ToString(), ds.Rows[i]["TenSP"].ToString(), ds.Rows[i]["SDT"].ToString(), ds.Rows[i]["TenKH"].ToString(),ngaynhap,(int)ds.Rows[i]["SL"],b,a, ds.Rows[i]["TenNV"].ToString(), ds.Rows[i]["DiaChi"].ToString());

                    Add(people);

                }
            }
            catch { }
        }
        
        //lấy top 1 đơn hàng
        public int Top1DH()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select top 1 with ties  id from KhachHang order by id desc");
            }

            catch
            {
                return -1;
            }
        }

        
        //lấy id bằng makh
        public int idKH(string makh)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select  id from KhachHang where KhachHang.MaKH='" + makh+"'");
            }

            catch
            {
                return -1;
            }
        }

        public int DHtop1()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select top 1 with ties  stt from DonHang order by stt desc");
            }

            catch
            {
                return -1;
            }
        }
        //"insert KhachHang  (TenKH,DiaChi,SDT,email,ngaynhap) values (N'{0}',N'{1}','{2}','{3}', getdate())"
        public bool insert(string Tenkh, string dckh, string sdtkh, string emailkh, string masp, int soluong,double giamgia, string manv)
        {
            
            string query = string.Format("insert KhachHang(TenKH, DiaChi, SDT, email, ngaynhap) values(N'{0}', N'{1}', '{2}', '{3}', getdate()) ", Tenkh, dckh, sdtkh, emailkh, masp, soluong, manv, 1, giamgia, Top1DH());
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool insert2(string Tenkh, string dckh, string sdtkh, string emailkh, string masp, int soluong, double giamgia, string manv,int maloai)
        {

            string query = string.Format("insert DonHang(MaDH, MaSP, NgayNhap, SL, MaNV, GiamGia, id,MaLoai) values('0','{0}', getdate(),{1},'{2}',{3},{4},{5})",masp, soluong, manv, giamgia, Top1DH(),maloai);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool insertDH( string masp, int soluong, double giamgia, string manv, string makh,int maloai)
        {

            string query = string.Format("insert DonHang (MaDH,MaSP, NgayNhap, SL, MaNV, GiamGia,id,MaLoai) values('0','{0}',getdate(),{1},'{2}',{3},{4},{5})", masp,soluong,manv,giamgia ,idKH(makh),maloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


    }
}

