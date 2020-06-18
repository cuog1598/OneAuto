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
    public partial class thongkebanle : UserControl
    {
        private static thongkebanle _instance;
        public static thongkebanle Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new thongkebanle();
                return _instance;
            }
        }
        public thongkebanle()
        {
            InitializeComponent();
            if(string.IsNullOrEmpty(comboBox1.Text))
            {
                btnXem.Enabled = false;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string query = string.Format("exec listTheoThang {0},{1},1", comboBox1.SelectedValue, comboBox2.SelectedValue);
            gridControl1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        private void loadcbb()
        {
            btnXem.Enabled = true;
            comboBox1.DataSource = DataProvider.Instance.ExecuteQuery("SELECT 'Tháng ' + CAST(MONTH(NgayNhap) as varchar) as thang , month(NgayNhap) as tha from DonHang  group by MONTH(NgayNhap)order by MONTH(NgayNhap) asc");
            comboBox2.DataSource = DataProvider.Instance.ExecuteQuery(" SELECT 'năm ' + CAST(year(NgayNhap) as nvarchar) as nam, year(NgayNhap) as na from DonHang  group by year(NgayNhap)order by year(NgayNhap) desc");
            comboBox1.DisplayMember = "thang";
            comboBox1.ValueMember = "tha";

            comboBox2.DisplayMember = "nam";
             comboBox2.ValueMember = "na";
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            loadcbb();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            loadcbb();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
