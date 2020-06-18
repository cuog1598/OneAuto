using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_OneAuto.DTO;

namespace QL_OneAuto.DAO
{
    public class DaiLy
    {
        private static DaiLy instance;

        public static DaiLy Instance
        {
            get { if (instance == null) instance = new DaiLy(); return instance; }
            private set { instance = value; }
        }
        private List<DaiLyDTO> list = new List<DaiLyDTO>();
        public void Add(DaiLyDTO x)
        {
            list.Add(x);
        }


        public DaiLyDTO this[string id]
        {
            get
            {
                DaiLyDTO people = list.Find(x => x.Madl == id);
                if (people is null)
                {
                    people = new DaiLyDTO();
                    people.Tendaily = "<Không tìm thấy>";
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
        public DaiLyDTO this[int x]
        {
            get
            {
                if (x >= Length || x < 0) return null;
                return list[x];
            }
        }


        public void GetFullInfo(string danhsach = "DaiLy_NhanVien")
        {
            
                list.Clear();
                DataTable ds = DataProvider.Instance.ExecuteQuery(danhsach);
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    DaiLyDTO people;

                    //DateTime ngaysinh = Convert.ToDateTime(ds.Rows[i]["NgaySinh"]);

                    people = new DaiLyDTO((int)ds.Rows[i]["MaDaL"], ds.Rows[i]["MaNV"].ToString(), ds.Rows[i]["TenNV"].ToString(), ds.Rows[i]["DiaChi"].ToString(), ds.Rows[i]["TenChuDaiLy"].ToString(), ds.Rows[i]["TenDaiLy"].ToString(), ds.Rows[i]["SDT"].ToString(), ds.Rows[i]["MaDL"].ToString());

                    Add(people);

                }
           
        }
        public bool Update(string madl, string TenChuDaiLy, string DiaChi, string SDT, string tendaily,string Email)
        {
            string query = string.Format("update DaiLy set tenchudaily=N'{1}', DiaChi=N'{2}',SDT = '{3}',TenDaiLy = N'{4}', email='{5}' where madl='{0}'",madl,TenChuDaiLy,DiaChi,SDT,tendaily,Email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        //thêm địa lý
        public bool insert(string madl,string manv, string tenchudaily, string diachi, string sdt ,string tendl, string email)
        {
            string query = string.Format("insert DaiLy (MaDL,MaNV,TenChuDaiLy, DiaChi, SDT, TenDaiLy,email) values ('{0}','{1}',N'{2}',N'{3}','{4}',N'{5}','{6}')", madl,manv,tenchudaily,diachi,sdt,tendl,email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}

    

 
