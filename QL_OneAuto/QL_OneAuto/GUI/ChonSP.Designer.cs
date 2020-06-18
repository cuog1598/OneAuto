namespace QL_OneAuto.GUI
{
    partial class ChonSP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChonSP));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.bgListNV = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bgListNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bgListNV
            // 
            this.bgListNV.AppearanceButton.Normal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bgListNV.AppearanceButton.Normal.Options.UseFont = true;
            windowsUIButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions1.Image")));
            windowsUIButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions2.Image")));
            this.bgListNV.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Đóng", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "close", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Chọn", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "choose", -1, false)});
            this.bgListNV.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.bgListNV.Controls.Add(this.panel2);
            this.bgListNV.Controls.Add(this.textBox1);
            this.bgListNV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bgListNV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bgListNV.Location = new System.Drawing.Point(0, 251);
            this.bgListNV.Name = "bgListNV";
            this.bgListNV.Size = new System.Drawing.Size(637, 62);
            this.bgListNV.TabIndex = 19;
            this.bgListNV.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.bgListNV_ButtonClick);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(204, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 43);
            this.panel2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(277, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(637, 251);
            this.gridControl1.TabIndex = 20;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenLoai,
            this.colTenSP,
            this.colGiaTien,
            this.gridColumn1});
            this.gridView1.DetailHeight = 360;
            this.gridView1.FooterPanelHeight = 30;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupRowHeight = 30;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            this.gridView1.ViewCaptionHeight = 30;
            // 
            // colTenLoai
            // 
            this.colTenLoai.Caption = "Loại Sản phẩm";
            this.colTenLoai.FieldName = "TenLoai";
            this.colTenLoai.Name = "colTenLoai";
            this.colTenLoai.OptionsColumn.AllowEdit = false;
            this.colTenLoai.OptionsColumn.ReadOnly = true;
            this.colTenLoai.Visible = true;
            this.colTenLoai.VisibleIndex = 0;
            this.colTenLoai.Width = 167;
            // 
            // colTenSP
            // 
            this.colTenSP.Caption = "Tên SP";
            this.colTenSP.FieldName = "TenSP";
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.OptionsColumn.AllowEdit = false;
            this.colTenSP.OptionsColumn.ReadOnly = true;
            this.colTenSP.Visible = true;
            this.colTenSP.VisibleIndex = 1;
            this.colTenSP.Width = 148;
            // 
            // colGiaTien
            // 
            this.colGiaTien.Caption = "Giá tiền";
            this.colGiaTien.FieldName = "GiaTien";
            this.colGiaTien.Name = "colGiaTien";
            this.colGiaTien.OptionsColumn.AllowEdit = false;
            this.colGiaTien.OptionsColumn.ReadOnly = true;
            this.colGiaTien.Visible = true;
            this.colGiaTien.VisibleIndex = 3;
            this.colGiaTien.Width = 92;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "mã sản phẩm";
            this.gridColumn1.FieldName = "MaSP";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 156;
            // 
            // ChonSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 313);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.bgListNV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChonSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn sản phẩm";
            this.Load += new System.EventHandler(this.ChonSP_Load);
            this.bgListNV.ResumeLayout(false);
            this.bgListNV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel bgListNV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLoai;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSP;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaTien;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}