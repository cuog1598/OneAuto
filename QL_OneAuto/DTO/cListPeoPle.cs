using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_OneAuto 
{
    public class cListPeoPle
    {
        private static cListPeoPle instance;

        public static cListPeoPle Instance
        {
            get { if (instance == null) instance = new cListPeoPle(); return instance; }
            private set { instance = value; }
        }


        // Lưu bằng list
        private List<People> list = new List<People>();
        // Lấy ra độ dài list
        public int Length
        {
            get { return list.Count; }
        }
        public void Add(People x)
        {
            list.Add(x);
        }


        // inderxer lấy ra nhân viên bằng cách truy cập vào vị trí
        public People this[int x]
        {
            get
            {
                if (x >= Length || x < 0) return null;
                return list[x];
            }
        }
        // indexer lấy ra nhân viên bằng cách truy cập id 
        public People this[string id]
        {
            get
            {
                People people = list.Find(x => x.Id == id);
                if (people is null)
                {
                    people = new People();
                    people.Hoten = "<Không tìm thấy>";
                }
                return people;

            }
        }
        
        public void GetFullInfo(string danhsach = "ListNhanVien")
        {
            try
            {
                list.Clear();
                DataTable ds = DataProvider.Instance.ExecuteQuery(danhsach);
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    People people;

                    DateTime ngaysinh = Convert.ToDateTime(ds.Rows[i]["NgaySinh"].ToString());
                  
                    DateTime ngaytao = Convert.ToDateTime(ds.Rows[i]["NgayNhap"]);
                    people = new People(ds.Rows[i]["MaNV"].ToString(), ds.Rows[i]["TenNV"].ToString(), ds.Rows[i]["SDT"].ToString(), ds.Rows[i]["DiaChi"].ToString(), ds.Rows[i]["TenLoai"].ToString(), ds.Rows[i]["email"].ToString(), String.Format("{0:yyyy-MM-dd}", ngaysinh), ngaytao);

                    Add(people);

                }
            }
            catch { }
        }

        public bool Update(string hoten, string phone, string diachi, string email, DateTime ngaysinh , string manv, int maloai)
        {
            string query = string.Format("update NhanVien set TenNV=N'{0}',SDT='{1}', DiaChi=N'{2}',email = '{3}',ngaysinh = '{4}', maloai={6} where MaNV='{5}'",hoten,phone,diachi,email,ngaysinh,manv,maloai );
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool insert(string hoten, string phone, string diachi, string email, DateTime? ngaysinh, string manv, int maloai)
        {
            string query = string.Format("insert NhanVien  (MaNV,TenNV,SDT,DiaChi,email,NgaySinh,NgayNhap,MaLoai) values ('{5}',N'{0}','{1}',N'{2}','{3}','{4}', getdate(),'{6}')", hoten, phone, diachi, email, ngaysinh, manv, maloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool insert2(string hoten, string phone, string diachi, string email , string manv, int maloai)
        {
            string query = string.Format("insert NhanVien  (MaNV,TenNV,SDT,DiaChi,email,NgayNhap,MaLoai) values ('{5}',N'{0}','{1}',N'{2}','{3}', getdate(),'{6}')", hoten, phone, diachi, email,"a", manv, maloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public DataTable LoadCbb()
        {
            //  string query = "select * from PHONGTRO p, KHACHTRO k, ThuePhong th , BangGia b where b.MaBG = p.MaBG and th.MaPT=p.MaPT and p.MaPT = k.MaPT and k.TrangThaiTro ='TRUE'and k.ChuNha='True' and TrangThaiThue='True' and th.Status='True'";

            string query = "select * from LoaiNhanVien";

            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;

        }
    }
}
