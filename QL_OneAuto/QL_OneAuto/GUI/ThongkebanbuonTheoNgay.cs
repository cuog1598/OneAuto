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

    public partial class ThongkebanbuonTheoNgay : UserControl
    {

        private static ThongkebanbuonTheoNgay _instance;
        public static ThongkebanbuonTheoNgay Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ThongkebanbuonTheoNgay();
                return _instance;
            }
        }
    
        public ThongkebanbuonTheoNgay()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string query = string.Format("exec listTheoNgay '{0} 00:00:00','{1} 23:59:59',2", dateStart.Text, dateEnd.Text);
            gridControl1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
