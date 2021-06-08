using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Dall_Ball;
using Dall_Ball.DTO;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraEditors;


namespace SHOPKID
{
    public partial class NhaCungCap : DevExpress.XtraEditors.XtraUserControl
    {
        NhaCungCap_Dall_Ball NCC = new NhaCungCap_Dall_Ball();
        bool add = false, update = false;
       
        public NhaCungCap()
        {
            InitializeComponent();
        }

        public void NhaCungCap_Load(object sender, EventArgs e)
        {
            hienthi(true);
            txtMaNCC.Enabled = false;
            loadnhacc();
            bind(true);
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
        }

        public void hienthi(bool t)
        {
            if (t)
            {
                //txtMaNCC.Enabled = false;
                txtDiaChi.Enabled = false;
                txtTenNCC.Enabled = false;
                txtSDT.Enabled = false;
            }
            else
            {
                txtDiaChi.Enabled = true;
                //txtMaNCC.Enabled = true;
                txtSDT.Enabled = true;
                txtTenNCC.Enabled = true;
            }
        }

        public void loadnhacc()
        {

            dsNhacc.DataSource = NCC.loaddataNCC();
        }

        public void bind(bool t)
        {
            if (t)
            {
                txtMaNCC.DataBindings.Clear();
                txtMaNCC.DataBindings.Add("Text", dsNhacc.DataSource, "MaNCC");
                txtTenNCC.DataBindings.Clear();
                txtTenNCC.DataBindings.Add("Text", dsNhacc.DataSource, "TenNCC");
                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text", dsNhacc.DataSource, "DiaChi");
                txtSDT.DataBindings.Clear();
                txtSDT.DataBindings.Add("Text", dsNhacc.DataSource, "SDT");
            }
            else
            {
                txtTenNCC.DataBindings.Clear();
                txtMaNCC.DataBindings.Clear();
                txtSDT.DataBindings.Clear();
                txtDiaChi.DataBindings.Clear();
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            NhaCungCap_Load(sender, e);
        }

        public bool kiemtradulieuso(string x)
        {
            int a = 0;
            bool t = int.TryParse(x, out a);
            if (t)
            {
                return true;
            }
            return false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenNCC.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Không được để trống tên nhà cung cấp");
                    return;
                }
                if (txtSDT.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Không được để trống số điện thoại");
                    return;
                }
                else if (!kiemtradulieuso(txtSDT.Text))
                {
                    XtraMessageBox.Show("Số điện thoại phải nhập số");
                    return;
                }

                if (add)
                {
                    NCC.themNhaCC(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text);
                    XtraMessageBox.Show("Thành Công");
                    NhaCungCap_Load(sender, e);


                }
                if (update)
                {
                    DialogResult rs;
                    rs = XtraMessageBox.Show("Bạn Có Muốn Sửa Nhà Cung Cấp Không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (rs == DialogResult.Yes)
                    {
                        if (NCC.sua1NCC(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text))
                        {
                            XtraMessageBox.Show("Thành Công");
                            NhaCungCap_Load(sender, e);


                        }
                    }

                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                add = true;
                update = false;
                resetvalues();
                bind(false);
                hienthi(false);
                txtMaNCC.Text = "";
                txtTenNCC.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtTenNCC.Focus();
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
                if (gridView1.RowCount <= 0)
                {
                    txtMaNCC.Text = "NC001";
                }
                else
                {
                    txtMaNCC.Text = NCC.getmaNhaCC();
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount <= 0)
                {
                    XtraMessageBox.Show("Không có nhà cung cấp nào");
                    return;
                }
                DialogResult rs;
                rs = XtraMessageBox.Show("ban có muôn xóa không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (rs == DialogResult.Yes)
                {

                    List<string> dshoadon = new List<string>();
                    dshoadon = NCC.mahdnhaptheonhacc(txtMaNCC.Text);
                    //for (int i = 0; i < dshoadon.Count; i++)
                    //{
                    //    hdnhap.xoanhd(dshoadon[i].ToString());
                    //}
                    if (NCC.xoa1NCC(txtMaNCC.Text))
                    {
                        XtraMessageBox.Show(" Xóa thành Công");
                        NhaCungCap_Load(sender, e);
                    }

                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                update = true;
                add = false;
                hienthi(false);
                btnLuu.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;





            workbook = application.Workbooks.Add(Type.Missing);
            application.Visible = true;
            application.WindowState = Excel.XlWindowState.xlMaximized;
            //getdatabase   
            workbook.Worksheets.Add();
            worksheet = workbook.Sheets[1];



            worksheet.Cells[1, 1] = "Thông Tin Nhà Cung Cấp";
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã Nhà cung cấp";
            worksheet.Cells[3, 3] = "Tên Nhà Cung Cấp";
            worksheet.Cells[3, 4] = "Số Điện Thoại";
            worksheet.Cells[3, 5] = "Địa Chỉ";
          



            List<NhaCungCapDTO> k = new List<NhaCungCapDTO>();
            k = NCC.loadnhacclist();

            for (int i = 0; i < k.Count; i++)
            {
                worksheet.Cells[i + 4, 1] = i + 1;
                worksheet.Cells[i + 4, 2] = k[i].Mancc1;
                worksheet.Cells[i + 4, 3] = k[i].Tenncc1;
                worksheet.Cells[i + 4, 4] = k[i].Sdt1;
                worksheet.Cells[i + 4, 5] = k[i].Diachi1;
               

            }
            // định dạng trang
            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
            worksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;
            worksheet.PageSetup.TopMargin = 0;

            //định dạng cột

            worksheet.Range["A1", "K100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "K100"].Font.Size = 14;
            worksheet.Range["A1", "K1"].MergeCells = true;
            worksheet.Range["A1", "K3"].Font.Bold = true;

            // kẻ bảng
            worksheet.Range["A3", "I" + (k.Count + 3)].Borders.LineStyle = 1;


            // định dạng các dòng
            worksheet.Range["A1", "K1"].HorizontalAlignment = 3;
            worksheet.Range["A3", "K3"].HorizontalAlignment = 3;
            worksheet.Range["A4", "K4" + k.Count.ToString()].HorizontalAlignment = 3;

            worksheet.Columns.AutoFit();
        }

        public void resetvalues()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTenNCC.Focus();
        }


    }
}
