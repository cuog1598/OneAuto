using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_OneAuto.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set { instance = value; }
        }

        public string Ma { get => ma; set => ma = value; }

        public DataTable Load()
        {
            string query = "Select * from NhanVien";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        private string ma;
    }
}
