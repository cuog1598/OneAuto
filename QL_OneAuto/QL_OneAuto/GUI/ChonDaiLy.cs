﻿using DevExpress.XtraBars.Docking2010;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_OneAuto.GUI
{
    public partial class ChonDaiLy : DevExpress.XtraEditors.XtraForm
    {
        public string  ID_Choose = null;
        public ChonDaiLy()
        {
            InitializeComponent();
            gridControl1.DataSource = DataProvider.Instance.ExecuteQuery("DaiLy_NhanVien");
            textBox1.DataBindings.Add("text", gridControl1.DataSource, "MaDL");
        }

        private void bgListNV_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "choose":
                    ID_Choose = textBox1.Text;
                    this.DialogResult = DialogResult.OK;
                    Close();
                    break;
                case "close":
                    this.Close();
                    break;
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            if (gridControl1.FocusedView is null) return;

            ID_Choose = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
