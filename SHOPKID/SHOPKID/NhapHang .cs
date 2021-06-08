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
using Dall_Ball.DTO;
using DevExpress.XtraGrid.Views.Grid;
using SHOPKID.Report;

namespace SHOPKID
{
    public partial class NhapHang : DevExpress.XtraEditors.XtraUserControl
    {
        BanHang_Dall_Ball bh = new BanHang_Dall_Ball();
        SanPham_Dall_Ball sp = new SanPham_Dall_Ball();
        NhaCungCap_Dall_Ball ncc = new NhaCungCap_Dall_Ball();
        HoaDonNhapHangRpt rpt = new HoaDonNhapHangRpt();
       
        List<NhapHangDTOT> lst = new List<NhapHangDTOT>();
        long tongtien = 0;
        List<SanPhamDTO> sp1 = new List<SanPhamDTO>();
        PhieuNhap_DALL_BaLL pn = new PhieuNhap_DALL_BaLL();
        KhoDaLL_BaLL kh = new KhoDaLL_BaLL();
        
        bool add = false;
        
        public NhapHang()
        {
            InitializeComponent();
           
        }

       
        public void BanHang_Load(object sender, EventArgs e)
        {
            txtTenNv.Enabled = false;
            
            load_pn();
            Load_CbSp();
            loadSreachKh();
            txtNhanVien.Text = DangNhap.tennv;
          
           
        }
        public void load_pn()
        {

            gridBH_SP.DataSource = pn.load_pn();
            txtTenNv.Text = DangNhap.tennv;
           

        } 
        public void load_ctpn()
        {

            if (gridViewBH_SP.RowCount > 0)
            {
                try
                {
                    //string mahd = gridViewBH_SP.GetRowCellValue(gridViewBH_SP.FocusedRowHandle, "MaPN").ToString();
                    gridSPDChon.DataSource = pn.loadchitietpn(txtMaHD.Text);
                }
                catch(Exception e)
                {
                    XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!");
                }
               
            }
           

        }
        public void Load_SpBH()
        {

           
            gridBH_SP.DataSource = sp1;
        }

        public void Load_CbSp()
        {
            SearchLUSanPham.Properties.DataSource = sp.GetSpAll();
            SearchLUSanPham.Properties.DisplayMember = "TenSp1";
            SearchLUSanPham.Properties.ValueMember = "MaSp1";

        }

    private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHD.Text.Length > 0)
                {
                    FuncitonBanHang tt = new FuncitonBanHang();
                    int soluong = int.Parse(spinSoLuong.Text);
                    long dongia = tt.GetGianhapSptheoma(SearchLUSanPham.EditValue.ToString());
                    long thanhtien = tt.GetThanhTien(soluong, dongia);
                    string masp = SearchLUSanPham.EditValue.ToString();

                    NhapHangDTOT dt = new NhapHangDTOT();
                    //dt.Mapn = masp;
                    dt.MaPN = txtMaHD.Text;
                    dt.MaSP = masp;
                    dt.TenSP = SearchLUSanPham.Text;
                    dt.SoLuongNhap = soluong;
                    dt.GiaNhap = dongia;
                    dt.ThanhTien = thanhtien;
                    int s = 1;
                    if (lst.Count == 0)
                    {
                        s = 1;
                    }
                    else
                    {
                        for (int i = 0; i < lst.Count; i++)
                        {
                            if (masp == lst[i].MaSP)
                            {
                                s++;
                            }
                        }
                    }
                    if (s == 1)
                    {
                        if (int.Parse(spinSoLuong.Text) <= 0)
                        {
                            XtraMessageBox.Show("Số lượng phải lớn hơn 0");
                            return;
                        }
                        tongtien += thanhtien;
                        //if (spinSoLuong.Value <= 0)
                        //{
                        //    XtraMessageBox.Show("Số lượng hơn 0");
                        //    return;
                        //}
                        lst.Add(dt);
                        loadtam();
                        updateSoluong();

                    }



                }
                txtTongTien.Text = tongtien.ToString();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!");
            }
            
        }
        
        public void loadtam()
        {
            gridSPDChon.DataSource = lst;
            gridSPDChon.RefreshDataSource();


        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            try
            {
                add = true;
                dateNgayHD.DateTime = DateTime.Now;
                dateNgayHD.Enabled = true;
                txtMaHD.Text = pn.matudongtang();
                txtTenNv.Text = DangNhap.tennv;
                gridSPDChon.DataSource = null;
                spinSoLuong.Value = 0;
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!");
            }
            
        }
        public void loadSreachKh()
        {
            SreachKh.Properties.DataSource = ncc.loaddataNCC();
            SreachKh.Properties.DisplayMember = "TenNCC";
            SreachKh.Properties.ValueMember = "MaNCC";
        }

        private void SearchLUSanPham_EditValueChanged(object sender, EventArgs e)
        {
            // FuncitonBanHang tt = new FuncitonBanHang();
            //MessageBox.Show();
            spinSoLuong.Value = 0;
           
        }

        private void Column_btnXoa_Click(object sender, EventArgs e)
        {

            try
            {
                if (gridViewBH_SP.RowCount <= 0)
                {
                    txtTongTien.Text = "";
                    return;
                }
                else
                {
                    //var gv = gridSPDChon.MainView as GridView;
                    //var index = gv.FocusedRowHandle;
                    string masp = gridViewSPDChon.GetRowCellValue(gridViewSPDChon.FocusedRowHandle, "MaSP").ToString();
                    var index = lst.FindIndex(t => t.MaSP == masp);
                    tongtien = tongtien - lst[index].ThanhTien;
                    txtTongTien.Text = tongtien.ToString();
                    lst.RemoveAt(index);
                    loadtam();
                    DeleteSoluong();
                    return;
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!");
            }
          
            
         
            
        }

        private void gridSPDChon_Click(object sender, EventArgs e)
        {

        }

        //private void spinGiamPhanTram_EditValueChanged(object sender, EventArgs e)
        //{
          
        //        if (int.Parse(spinGiamPhanTram.Text) > 0)
        //           txtGiamGiaVND.Text = (tongtien * (int.Parse(spinGiamPhanTram.Text)/100)).ToString();
            
        //}
        public void updateSoluong()
        {
            sp1 = sp.GetSpAll();
            for (int i=0;i<sp1.Count;i++)
            {
                for(int j=0;j<lst.Count;j++)
                {
                    if(sp1[i].MaSp1==lst[j].MaSP)
                    {
                        sp1[i].SoluongTon1-= lst[j].SoLuongNhap;
                    }
                }
            }
            //Load_SpBH();
        }
        public void datatbinds()
        {
         
        }
        public void DeleteSoluong()
        {
            sp1 = sp.GetSpAll();
            for (int i = 0; i < sp1.Count; i++)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    if (sp1[i].MaSp1 == lst[j].MaSP)
                    {
                        sp1[i].SoluongTon1 += lst[j].SoLuongNhap;
                    }
                }
            }
            //Load_SpBH();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (add)
                {
                    if (SreachKh.Text == "[EditValue is null]")
                    {
                        XtraMessageBox.Show("Bạn chưa chọn tên nhà cung cấp");
                        return;
                    }
                    if (pn.kiemtraphieunhap(txtMaHD.Text))
                    {
                        XtraMessageBox.Show("Đã tồn tại phiếu nhập này");
                        return;
                    }

                    pn.them1pn(txtMaHD.Text, SreachKh.EditValue.ToString(), DangNhap.matennv, DateTime.Parse(dateNgayHD.EditValue.ToString()), long.Parse(txtTongTien.Text));




                    for (int i = 0; i < lst.Count; i++)
                    {
                        pn.them1chitetpn(txtMaHD.Text, lst[i].MaSP, lst[i].GiaNhap, lst[i].SoLuongNhap, lst[i].ThanhTien);


                    }

                    for (int i = 0; i < lst.Count; i++)
                    {
                        kh.upadtekho(lst[i].MaSP, kh.getsoluongkho(lst[i].MaSP) + lst[i].SoLuongNhap);
                    }

                    DialogResult rs;
                    rs = XtraMessageBox.Show("Bạn có muốn xuất phiếu nhập", "Xuất phiếu nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (rs != DialogResult.Yes)
                    {
                        XtraMessageBox.Show("Nhập Hàng Thành Công");
                        lst.Clear();
                        add = false;
                        load_pn();
                        load_ctpn();
                        tongtien = 0;
                        txtTongTien.Text = "";
                        return;

                    }
                    rpt.showdata(txtMaHD.Text, DangNhap.tennv, SreachKh.Text);
                    lst.Clear();
                    add = false;
                    load_pn();
                    load_ctpn();
                    tongtien = 0;
                    txtTongTien.Text = "";
                    return;
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void gridViewBH_SP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (!add)
                {
                    string mahd = gridViewBH_SP.GetRowCellValue(gridViewBH_SP.FocusedRowHandle, "MaPN").ToString();
                    string datengay = gridViewBH_SP.GetRowCellValue(gridViewBH_SP.FocusedRowHandle,"NgayNhap").ToString();
                    //string nhcc = gridViewBH_SP.GetRowCellValue(gridViewBH_SP.FocusedRowHandle,"TenNCC").ToString();
                    //string makh=
                    //string masp = SreachKh.EditValue.ToString();
                    txtTongTien.Text = pn.gettongtien(mahd);
                    dateNgayHD.Text = datengay;
                   // SreachKh.Text = nhcc;
                    txtMaHD.Text = mahd;
                    load_ctpn();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!");
            }
            

    
;        }

        private void ckCheckKho_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                pn.deletectpn(txtMaHD.Text);
                if (pn.kiemtrachitiethd(txtMaHD.Text))
                {
                    pn.delete(txtMaHD.Text);
                }
                XtraMessageBox.Show("Xóa Thành Công");
                add = false;
                load_pn();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!");
            }
           
         

        }

        private void gridBH_SP_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("1");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            txtNhanVien.Text = "";
            dateNgayHD.Text = "";
            
            gridSPDChon.DataSource = null;
            
            labelNote.Text = "";
            txtTongTien.Text = "";
        }
    }
}
