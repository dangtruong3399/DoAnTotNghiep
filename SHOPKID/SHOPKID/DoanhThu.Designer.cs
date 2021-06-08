namespace SHOPKID
{
    partial class DoanhThu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected void Dispose(bool disposing)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoanhThu));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridDoanhThu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnMAHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTongGB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTongGN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTongDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnThucThi = new DevExpress.XtraEditors.SimpleButton();
            this.dateNgayKT = new DevExpress.XtraEditors.DateEdit();
            this.dateNgayBD = new DevExpress.XtraEditors.DateEdit();
            this.lblBaoCaoDT = new System.Windows.Forms.Label();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblNgayBD = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblNgayKT = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKT.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayKT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridDoanhThu);
            this.layoutControl1.Controls.Add(this.btnThucThi);
            this.layoutControl1.Controls.Add(this.dateNgayKT);
            this.layoutControl1.Controls.Add(this.dateNgayBD);
            this.layoutControl1.Controls.Add(this.lblBaoCaoDT);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 260, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(813, 544);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridDoanhThu
            // 
            this.gridDoanhThu.Location = new System.Drawing.Point(12, 102);
            this.gridDoanhThu.MainView = this.gridView1;
            this.gridDoanhThu.Name = "gridDoanhThu";
            this.gridDoanhThu.Size = new System.Drawing.Size(789, 430);
            this.gridDoanhThu.TabIndex = 9;
            this.gridDoanhThu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnMAHD,
            this.gridColumnDATE,
            this.gridColumnTongGB,
            this.gridColumnTongGN,
            this.gridColumnTongDT});
            this.gridView1.GridControl = this.gridDoanhThu;
            this.gridView1.GroupPanelText = "Doanh Thu Hóa Đơn Bán Ra";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // gridColumnMAHD
            // 
            this.gridColumnMAHD.Caption = "Mã Hóa Đơn";
            this.gridColumnMAHD.FieldName = "MahD";
            this.gridColumnMAHD.MinWidth = 25;
            this.gridColumnMAHD.Name = "gridColumnMAHD";
            this.gridColumnMAHD.Visible = true;
            this.gridColumnMAHD.VisibleIndex = 0;
            this.gridColumnMAHD.Width = 94;
            // 
            // gridColumnDATE
            // 
            this.gridColumnDATE.Caption = "Ngày Lập Hóa Đơn";
            this.gridColumnDATE.FieldName = "NgaylapHd";
            this.gridColumnDATE.MinWidth = 25;
            this.gridColumnDATE.Name = "gridColumnDATE";
            this.gridColumnDATE.Visible = true;
            this.gridColumnDATE.VisibleIndex = 1;
            this.gridColumnDATE.Width = 94;
            // 
            // gridColumnTongGB
            // 
            this.gridColumnTongGB.Caption = "Tổng Giá Bán";
            this.gridColumnTongGB.DisplayFormat.FormatString = "{0:#,##0\" VNĐ\"}";
            this.gridColumnTongGB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumnTongGB.FieldName = "Tongiaban";
            this.gridColumnTongGB.MinWidth = 25;
            this.gridColumnTongGB.Name = "gridColumnTongGB";
            this.gridColumnTongGB.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Tongiaban", "Tổng Giá Bán=        {0:#,##0\" VNĐ\"}")});
            this.gridColumnTongGB.Visible = true;
            this.gridColumnTongGB.VisibleIndex = 2;
            this.gridColumnTongGB.Width = 94;
            // 
            // gridColumnTongGN
            // 
            this.gridColumnTongGN.Caption = "Tổng Giá Nhập";
            this.gridColumnTongGN.DisplayFormat.FormatString = "{0:#,##0\" VNĐ\"}";
            this.gridColumnTongGN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumnTongGN.FieldName = "Tongianhap";
            this.gridColumnTongGN.MinWidth = 25;
            this.gridColumnTongGN.Name = "gridColumnTongGN";
            this.gridColumnTongGN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Tongianhap", "Tổng Giá Nhập=        {0:#,##0\" VNĐ\"}")});
            this.gridColumnTongGN.Visible = true;
            this.gridColumnTongGN.VisibleIndex = 3;
            this.gridColumnTongGN.Width = 94;
            // 
            // gridColumnTongDT
            // 
            this.gridColumnTongDT.Caption = "Doanh Thu";
            this.gridColumnTongDT.DisplayFormat.FormatString = "{0:#,##0\" VNĐ\"}";
            this.gridColumnTongDT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumnTongDT.FieldName = "DoanhThu";
            this.gridColumnTongDT.MinWidth = 25;
            this.gridColumnTongDT.Name = "gridColumnTongDT";
            this.gridColumnTongDT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DoanhThu", "Tổng Doanh Thu=        {0:#,##0\" VNĐ\"}")});
            this.gridColumnTongDT.Visible = true;
            this.gridColumnTongDT.VisibleIndex = 4;
            this.gridColumnTongDT.Width = 94;
            // 
            // btnThucThi
            // 
            this.btnThucThi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThucThi.ImageOptions.Image")));
            this.btnThucThi.Location = new System.Drawing.Point(627, 60);
            this.btnThucThi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThucThi.Name = "btnThucThi";
            this.btnThucThi.Size = new System.Drawing.Size(40, 38);
            this.btnThucThi.StyleController = this.layoutControl1;
            this.btnThucThi.TabIndex = 8;
            this.btnThucThi.Click += new System.EventHandler(this.btnThucThi_Click);
            // 
            // dateNgayKT
            // 
            this.dateNgayKT.EditValue = null;
            this.dateNgayKT.Location = new System.Drawing.Point(473, 60);
            this.dateNgayKT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateNgayKT.Name = "dateNgayKT";
            this.dateNgayKT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayKT.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayKT.Size = new System.Drawing.Size(150, 22);
            this.dateNgayKT.StyleController = this.layoutControl1;
            this.dateNgayKT.TabIndex = 6;
            // 
            // dateNgayBD
            // 
            this.dateNgayBD.EditValue = null;
            this.dateNgayBD.Location = new System.Drawing.Point(242, 60);
            this.dateNgayBD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateNgayBD.Name = "dateNgayBD";
            this.dateNgayBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayBD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayBD.Size = new System.Drawing.Size(162, 22);
            this.dateNgayBD.StyleController = this.layoutControl1;
            this.dateNgayBD.TabIndex = 5;
            // 
            // lblBaoCaoDT
            // 
            this.lblBaoCaoDT.BackColor = System.Drawing.Color.Transparent;
            this.lblBaoCaoDT.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBaoCaoDT.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBaoCaoDT.Location = new System.Drawing.Point(12, 12);
            this.lblBaoCaoDT.Name = "lblBaoCaoDT";
            this.lblBaoCaoDT.Size = new System.Drawing.Size(789, 44);
            this.lblBaoCaoDT.TabIndex = 4;
            this.lblBaoCaoDT.Text = "BÁO CÁO DOANH THU";
            this.lblBaoCaoDT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lblNgayBD,
            this.lblNgayKT,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(813, 544);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblBaoCaoDT;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(793, 48);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lblNgayBD
            // 
            this.lblNgayBD.Control = this.dateNgayBD;
            this.lblNgayBD.Location = new System.Drawing.Point(165, 48);
            this.lblNgayBD.Name = "lblNgayBD";
            this.lblNgayBD.Size = new System.Drawing.Size(231, 42);
            this.lblNgayBD.Text = "Từ ngày:";
            this.lblNgayBD.TextSize = new System.Drawing.Size(62, 17);
            // 
            // lblNgayKT
            // 
            this.lblNgayKT.Control = this.dateNgayKT;
            this.lblNgayKT.Location = new System.Drawing.Point(396, 48);
            this.lblNgayKT.Name = "lblNgayKT";
            this.lblNgayKT.Size = new System.Drawing.Size(219, 42);
            this.lblNgayKT.Text = " đến ngày";
            this.lblNgayKT.TextSize = new System.Drawing.Size(62, 17);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(165, 42);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(659, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(134, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnThucThi;
            this.layoutControlItem2.Location = new System.Drawing.Point(615, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(44, 42);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridDoanhThu;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(793, 434);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DoanhThu";
            this.Size = new System.Drawing.Size(813, 544);
            this.Load += new System.EventHandler(this.DoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKT.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayBD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayKT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnThucThi;
        //private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewerBCDT;
        private DevExpress.XtraEditors.DateEdit dateNgayKT;
        private DevExpress.XtraEditors.DateEdit dateNgayBD;
        private System.Windows.Forms.Label lblBaoCaoDT;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem lblNgayBD;
        private DevExpress.XtraLayout.LayoutControlItem lblNgayKT;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridDoanhThu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMAHD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDATE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTongGB;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTongGN;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTongDT;
    }
}