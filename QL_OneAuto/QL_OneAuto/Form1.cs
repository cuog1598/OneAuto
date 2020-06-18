using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_OneAuto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btHOME.Focus();
        }
        // thoát chtr
        private void button13_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_CheckedChanged(object sender, EventArgs e)
        {
            waitForm(); SidePanel.Width = button3.Width;
            SidePanel.Left = button3.Left;
            //load usercontrol


            if (!mainPanel.Controls.Contains(NhanVien.Instance))
            {
                mainPanel.Controls.Add(NhanVien.Instance);
                NhanVien.Instance.Dock = DockStyle.Fill;
                NhanVien.Instance.BringToFront();

            }
            else
            {
                NhanVien.Instance.BringToFront();
                NhanVien.Instance.btnNhanVien.Focus();
                

            }
        }
           
        
       

        private void btHOME_CheckedChanged(object sender, EventArgs e)
        {
            SidePanel.Width = btHOME.Width;
            SidePanel.Left = btHOME.Left;

            waitForm();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            waitForm(); SidePanel.Width = btnQuanTri.Width;
            SidePanel.Left = btnQuanTri.Left;

            if (!mainPanel.Controls.Contains(QuanTri.Instance))
            {
                mainPanel.Controls.Add(QuanTri.Instance);
                QuanTri.Instance.Dock = DockStyle.Fill;
                QuanTri.Instance.BringToFront();
            }
            else
                QuanTri.Instance.BringToFront();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            waitForm(); SidePanel.Width = radioButton2.Width;
            SidePanel.Left = radioButton2.Left;

            if (!mainPanel.Controls.Contains(DonHang.Instance))
            {
                mainPanel.Controls.Add(DonHang.Instance);
                DonHang.Instance.Dock = DockStyle.Fill;
                DonHang.Instance.BringToFront();
            }
            else
                DonHang.Instance.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btHOME_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(HOME.Instance))
            {
                mainPanel.Controls.Add(HOME.Instance);
                HOME.Instance.Dock = DockStyle.Fill;
                HOME.Instance.BringToFront();
            }
            else
                HOME.Instance.BringToFront();
        }
        public void waitForm()
        {
           WaitControl.ShowWaitForm();
            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(15);
            }
            WaitControl.CloseWaitForm();
        }
    }
}
