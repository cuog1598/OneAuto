using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_OneAuto.GUI
{
    public partial class ThongKeBB : UserControl
    {
        private static ThongKeBB _instance;
        public static ThongKeBB Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ThongKeBB();
                return _instance;
            }
        }
        public ThongKeBB()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            comboBox1.DataSource = DataProvider.Instance.ExecuteQuery("SELECT 'Tháng ' + CAST(MONTH(NgayNhap) as varchar) as thang , month(NgayNhap) as tha from DonHang  group by MONTH(NgayNhap)order by MONTH(NgayNhap) asc");
            comboBox2.DataSource = DataProvider.Instance.ExecuteQuery(" SELECT 'năm ' + CAST(year(NgayNhap) as nvarchar) as nam, year(NgayNhap) as na from DonHang  group by year(NgayNhap)order by year(NgayNhap) desc");
            comboBox1.DisplayMember = "thang";
            comboBox1.ValueMember = "tha";

            comboBox2.DisplayMember = "nam";
            comboBox2.ValueMember = "na";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string query = string.Format("exec listTheoThang {0},{1},2", comboBox1.SelectedValue, comboBox2.SelectedValue);
            gridControl1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
