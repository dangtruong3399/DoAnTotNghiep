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
using Dall_Ball;
using System.IO;
using System.Drawing.Drawing2D;

namespace SHOPKID
{
    public partial class SanPham : DevExpress.XtraEditors.XtraUserControl
    {
        SanPham_Dall_Ball sp = new SanPham_Dall_Ball();
        LoaiSanPham_Dall_Ball lsp = new LoaiSanPham_Dall_Ball();
        KhoDaLL_BaLL kh = new KhoDaLL_BaLL();
        PhieuNhap_DALL_BaLL pn = new PhieuNhap_DALL_BaLL();
        BanHang_Dall_Ball bh = new BanHang_Dall_Ball();
        bool add = false, update = false;
        OpenFileDialog open;
        bool saveanh = false;
        //string maloaisp;


        public SanPham()
        {
            InitializeComponent();

        }
        public void loadsp()
        {
            dsSanPham.DataSource = sp.loadspandlsp();

        }

        public bool kiemtraso(string x)
        {
            int a = 0;
            bool t = int.TryParse(x, out a);
            if (t)
            {
                return true;
            }
            else
                return false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                hienthi(false);
                add = true;
                txtTenSP.Text = "";
                txtDVT.Text = "";

                txtGiaBan.Text = "";
                txtGiaNhap.Text = "";
                txtLinkHA.Text = "";
                txtSLTon.Text = "";
                txtMoTa.Text = "";

                txtTenSP.Focus();
                databinds(false);
                txtLinkHA.Enabled = false;
                btnLuuFile.Enabled = true;
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                pictureEdit1.Image = null;
                if (gridView1.DataRowCount <= 0)
                {
                    txtMaSP.Text = "SP001";
                }
                else
                {
                    txtMaSP.Text = sp.getmasptutang();
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            

        }

        public void SanPham_Load(object sender, EventArgs e)
        {
            loadcombox();
            loadsp();
            hienthi(true);
            txtSLTon.Enabled = false;
            txtMaSP.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuuFile.Enabled = false;
            

            databinds(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();

        }

        public void hienthi(bool t)
        {
            if (t)
            {
                txtTenSP.Enabled = false;

                txtMoTa.Enabled = false;
                txtLinkHA.Enabled = false;
                txtGiaNhap.Enabled = false;
                txtGiaBan.Enabled = false;
                txtDVT.Enabled = false;
                cboloaisp.Enabled = false;
            }
            else
            {
                cboloaisp.Enabled = true;
                txtTenSP.Enabled = true;

                txtMoTa.Enabled = true;
                txtLinkHA.Enabled = true;
                txtGiaNhap.Enabled = true;
                txtGiaBan.Enabled = true;
                txtDVT.Enabled = true;
            }
        }


        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            SanPham_Load(sender, e);
        }

        public void loadcombox()
        {
            if (lsp.loaddulieuloaisanpham().Count > 0)
            {
                cboloaisp.Properties.DataSource = lsp.loaddulieuloaisanpham();
                cboloaisp.Properties.DisplayMember = "TenLoai";
                cboloaisp.Properties.ValueMember = "MaLoai";

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                hienthi(false);
                update = true;
                add = false;
                btnLuuFile.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                txtLinkHA.Enabled = false;
                databinds(false);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa", "Đồng ý xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    pn.deletectpnmasp(txtMaSP.Text);
                    bh.deletectpxmasp(txtMaSP.Text);
                    kh.xoakho(txtMaSP.Text);
                    pn.deletepnall();
                    bh.deletepnallbh();
                    sp.xoa1sanpham(txtMaSP.Text);
                    loadsp();
                    databinds(true);

                    XtraMessageBox.Show("Thành Công");
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenSP.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên sản phẩm");
                    return;
                }
                if (txtDVT.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập đơn vị tính");
                }
                if (txtGiaBan.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập giá bán");
                    return;
                }
                if (!kiemtraso(txtGiaBan.Text))
                {
                    XtraMessageBox.Show("Bạn phải nhập số tại giá bán");
                    return;
                }
                if (!kiemtraso(txtGiaNhap.Text))
                {
                    XtraMessageBox.Show("Bạn phải nhập số tại giá nhập");
                    return;
                }
                if (txtGiaNhap.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập giá nhập");
                    return;
                }
                //if (txtLinkHA.Text.Length <= 0)
                //{
                //    XtraMessageBox.Show("Bạn chưa nhập Link Hình Ảnh");
                //    return;
                //}
                if (txtMoTa.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập Mô Tả");
                    return;
                }

                long gianhap = long.Parse(txtGiaNhap.Text);
                long giaban = long.Parse(txtGiaBan.Text);

                if (gianhap > giaban)
                {
                    XtraMessageBox.Show("Giá nhập phải nhỏ hơn giá bán");
                    return;
                }

                //if (pictureEdit1.Image == null)
                //{
                //    XtraMessageBox.Show("Bạn nhập sai link định dạng hình ảnh");
                //    return;
                //}
                if (add)
                {
                    if (XtraMessageBox.Show("Bạn có muốn thêm sản phẩm mới", "Đồng ý thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sp.them1loaisanpham(txtMaSP.Text, txtTenSP.Text, txtDVT.Text, giaban, gianhap, txtLinkHA.Text, txtMoTa.Text, cboloaisp.EditValue.ToString());
                        SanPham_Load(sender, e);
                        XtraMessageBox.Show("Thêm thành công");
                    }
                }
                if (update)
                {
                    if (XtraMessageBox.Show("Bạn có muốn sửa hàng hóa này", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        //MessageBox.Show(maloaisp);
                        sp.sua1sanpham(txtMaSP.Text, txtTenSP.Text, txtDVT.Text, giaban, gianhap, txtLinkHA.Text, txtMoTa.Text, cboloaisp.EditValue.ToString());

                        SanPham_Load(sender, e);
                        XtraMessageBox.Show("Sửa Thành Công");

                    }
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            

        }

        private void txtLinkHA_EditValueChanged(object sender, EventArgs e)
        {

            //string imagePath = "E:\\DoAnTotNghiep\\SHOPKID\\SHOPKID\\bin\\Debug\\Images\\sp1.png";
            //Bitmap bit = new Bitmap(imagePath,false);
            //pictureEdit1.Image = bit;



            //Image image;
            //using (var fs = File.Open(imagePath, FileMode.Open))
            //{
            //    byte[] ImageArray = new byte[fs.Length];

            //    byte[] b = new byte[2048];
            //    int iLen = b.Length;
            //    int iStart = 0;

            //    try
            //    {
            //        while (fs.Read(b, 0, b.Length) > 0)
            //        {
            //            b.CopyTo(ImageArray, iStart);

            //            if ((fs.Length - fs.Position) < b.Length)
            //            {
            //                while (fs.Position < fs.Length)
            //                {
            //                    ImageArray.SetValue((byte)fs.ReadByte(), iStart++);
            //                }
            //                break;
            //            }
            //            iStart += b.Length;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //       // Response.Write("Image load failed. (" + ex.Message + ")");
            //    }

            //    fs.Close();

            //    MemoryStream ms = new MemoryStream(ImageArray, 0, ImageArray.Length);
            //    image = Image.FromStream(ms, false);
            //    // Save the file  
            //    //thumbImg.Save(uploadFolder + "/" + uniqueFileName, image.RawFormat);
            //} // chay thu xem 

            ////Image img = Image.FromFile(imagePath);  // Chay thu xem bac
            //// dợ xy nhe


            //    //null; FileStream fs = null;
            //    //try
            //    //{
            //    //    using (var _fs = new FileStream("E:\\DoAnTotNghiep\\SHOPKID\\SHOPKID\\bin\\Debug\\Images\\sp1.jpg", FileMode.Open))
            //    //        img = Image.FromStream(_fs,);
            //    //}

            ////finally
            ////{
            ////    fs.Close();
            ////}
            //pictureEdit1.Image = image;

            try
            {
                string saveanhluu = "";
                if (gridView1.RowCount > 0)
                {
                    saveanhluu = Application.StartupPath + "\\Images\\" + gridView1.GetFocusedRowCellValue("HinhAnh").ToString();
                }
                else
                {
                    saveanhluu = Application.StartupPath + "\\Images\\" + txtLinkHA.Text;
                }



                if (saveanh)
                {
                    if (txtLinkHA.Text.Length > 0 && File.Exists(saveanhluu))
                    {
                        pictureEdit1.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + txtLinkHA.Text);

                    }
                    else if (!File.Exists(saveanhluu))
                    {
                        pictureEdit1.Image = null;
                        XtraMessageBox.Show("Ảnh này đã bị xóa");
                    }
                }
                if (!saveanh)
                {
                    if (txtLinkHA.Text.Length > 0 && File.Exists(saveanhluu))
                    {
                        pictureEdit1.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + txtLinkHA.Text);

                    }
                    else if (!File.Exists(saveanhluu))
                    {
                        pictureEdit1.Image = null;
                        XtraMessageBox.Show("Ảnh này đã bị xóa");
                    }


                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            
        }
        public string catfile(string x)
        {
            string filename = "";
            string x2 = "";

            filename = x.Substring(x.LastIndexOf("\\"));

            x2 = filename.Substring(1, filename.Length - 1);

            return x2;
        }

        public void databinds(bool t)
        {
            if (t)
            {
                txtMaSP.DataBindings.Clear();
                txtMaSP.DataBindings.Add("Text", dsSanPham.DataSource, "MaSP");
                txtTenSP.DataBindings.Clear();
                txtTenSP.DataBindings.Add("Text", dsSanPham.DataSource, "TenSP");
                txtDVT.DataBindings.Clear();
                txtDVT.DataBindings.Add("Text", dsSanPham.DataSource, "DonViTinh");
                txtGiaBan.DataBindings.Clear();
                txtGiaBan.DataBindings.Add("Text", dsSanPham.DataSource, "GiaBan");
                txtGiaNhap.DataBindings.Clear();
                txtGiaNhap.DataBindings.Add("Text", dsSanPham.DataSource, "GiaNhap");
                txtLinkHA.DataBindings.Clear();
                txtLinkHA.DataBindings.Add("Text", dsSanPham.DataSource, "HinhAnh");
                txtSLTon.DataBindings.Clear();
                txtSLTon.DataBindings.Add("Text", dsSanPham.DataSource, "SoLuong");
                txtMoTa.DataBindings.Clear();
                txtMoTa.DataBindings.Add("Text", dsSanPham.DataSource, "MoTa");
                cboloaisp.DataBindings.Clear();
                cboloaisp.DataBindings.Add("Text", dsSanPham.DataSource, "MaLoai");
            }
            if (!t)
            {
                txtMaSP.DataBindings.Clear();
                txtTenSP.DataBindings.Clear();
                txtDVT.DataBindings.Clear();
                txtGiaBan.DataBindings.Clear();
                txtGiaNhap.DataBindings.Clear();
                txtLinkHA.DataBindings.Clear();
                txtSLTon.DataBindings.Clear();
                txtMoTa.DataBindings.Clear();
                cboloaisp.DataBindings.Clear();
            }
        }

        private void cboloaisp_EditValueChanged(object sender, EventArgs e)
        {
            //maloaisp = cboloaisp.EditValue.ToString();
            //MessageBox.Show(maloaisp);
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            try
            {
                open = new OpenFileDialog();
                Image img;
                open.InitialDirectory = @"C:\";
                open.Title = "Select Picture";
                //Windows Bitmap|*.bmp|JPEG Image|*.jpg|
                open.Filter = "PNG|*.png|All Files|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {

                    img = Image.FromFile(open.FileName);
                    pictureEdit1.Image = img;
                }
                SaveFileDialog save = new SaveFileDialog();
                save.InitialDirectory = @"" + Application.StartupPath + "\\Images\\";
                save.RestoreDirectory = true;
                save.FileName = ".jpg";
                save.Filter = "PNG|*.png|All Files|*.*";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    //string a = catfile(save.FileName);
                    //string b = catfile(open.FileName);
                    //if (a != b)
                    //{
                    pictureEdit1.Image.Save(save.FileName);
                    txtLinkHA.Text = catfile(save.FileName);
                    XtraMessageBox.Show("Hiển Thị Ảnh Thành Công");
                    saveanh = true;
                    ////}
                    //else
                    //{

                    //    XtraMessageBox.Show("Ảnh này đã Lưu");
                    //    txtLinkHA.Text = catfile(open.FileName);
                    //}

                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            
        }

        public void SanphamVisbile_load(object sender, EventArgs e)
        {
            loadcombox();

        }
    }
}
