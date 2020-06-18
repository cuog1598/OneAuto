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

    public partial class HOME : UserControl
    {
        private static HOME _instance;
        public static HOME Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HOME();
                return _instance;
            }
        }
        public HOME()
        {
            InitializeComponent();
        }
        private int dem = 2;
        private void load()
        {
            if (dem == 10)
            {
                dem = 1;
            }
            if (dem == 1 ||dem==5)
            {
                pictureBox1.Image = Properties.Resources._1;
                dem++;
            }
            else
            {
                pictureBox1.Image = Properties.Resources._9;
                dem++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            load();
        }
    }


    }
