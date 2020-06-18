using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_OneAuto 
{
    public partial class QuanTri : UserControl
    {

        private static QuanTri _instance;
        public static QuanTri Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QuanTri();
                return _instance;
            }
        }
        public QuanTri()
        {
            InitializeComponent();
        }
    }
}
