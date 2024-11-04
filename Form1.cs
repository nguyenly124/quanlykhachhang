using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Collections.Generic;


namespace form_quan_ly_khach_hang
{
    public partial class Form1 : Form
    {
        int tongtien = 0;
        private
        BindingSource bindingSource1 = new BindingSource();
        BindingSource bindingSource2 = new BindingSource();

        // Danh sách các sản phẩm (Ví dụ)
        List<khachhang> danhsachkh = new List<khachhang>();

        // Giỏ hàng
        List<dichvu> danhsachdv = new List<dichvu>();
        private int maKhachHangTiepTheo = 5;
        public Form1()
        {
            InitializeComponent();

            danhsachkh.Add(new khachhang { makh = 1, tenkh = "Hằng", sodt = "0857329538", diachi = "" });
            danhsachkh.Add(new khachhang { makh = 2, tenkh = "Hồng ", sodt = "0567843243", diachi = "" });
            danhsachkh.Add(new khachhang { makh = 3, tenkh = "Hà ", sodt = "0345275832", diachi = "" });
            danhsachkh.Add(new khachhang { makh = 4, tenkh = "Hiếu ", sodt = "0352748245", diachi = "" });
            danhsachdv.Add(new dichvu { madv = "dv1", tendv = "dv1", gia = 538293 });
            danhsachdv.Add(new dichvu { madv = "dv2", tendv = "dv2", gia = 567893 });
            danhsachdv.Add(new dichvu { madv = "dv3", tendv = "dv3", gia = 452839 });
            danhsachdv.Add(new dichvu { madv = "dv4", tendv = "dv4", gia = 1638492 });

            // Hiển thị danh sách sản phẩm lên DataGridView
            dataGridViewkh.DataSource = danhsachkh;
            dataGridViewdv.DataSource = danhsachdv;
            // Liên kết DataGridView với BindingSource
            dataGridViewkh.DataSource = bindingSource1;
            bindingSource1.DataSource = danhsachkh;

            // Sự kiện CellClick
            dataGridViewkh.CellClick += dataGridViewkh_CellClick;
            // Liên kết DataGridView với BindingSource
            dataGridViewdv.DataSource = bindingSource2;
            bindingSource2.DataSource = danhsachdv;
           
            // Sự kiện CellClick
            dataGridViewdv.CellClick += dataGridViewdv_CellClick;
        }
        private string sinhma()
        {
            string prefix = "HD";
            string ngay = DateTime.Now.ToString("yyyyMMdd");
            Random rd = new Random();
            int soNgauNhien = rd.Next(1000, 9999);
            string maHoaDon = prefix + ngay + soNgauNhien;

            // Kiểm tra trùng lặp trong cơ sở dữ liệu
            // ...

            return maHoaDon;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridViewkh.SelectedRows.Count  > 0)
            {
                // Lấy chỉ số của hàng được chọn
                int index = dataGridViewkh.SelectedRows[0].Index;

                // Xác nhận việc xóa
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Xóa khách hàng khỏi danh sách
                    danhsachkh.RemoveAt(index);

                    // Cập nhật lại DataGridView
                    dataGridViewkh.DataSource = null;
                    dataGridViewkh.DataSource = danhsachkh;

                    
                }
                
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
            }
        
    }

        private void button4_Click(object sender, EventArgs e)
        {
            
            {
                // Xóa thông tin trong GroupBox "Hóa đơn dịch vụ"
                txtmahd.Text = "";
                txttenkh.Text = "";
                txtsodtkh.Text = "";
                listBox1.Items.Clear();
                txttien.Text = "0";

                // Thông báo
                MessageBox.Show("Hóa đơn đã được tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Thêm các logic khác nếu cần (ví dụ: lưu thông tin hóa đơn vào cơ sở dữ liệu)
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btthem_Click(object sender, EventArgs e)
        {
            khachhang khachHangMoi = new khachhang();
            khachHangMoi.makh = maKhachHangTiepTheo++;
            khachHangMoi.tenkh = txtten.Text;
            khachHangMoi.sodt = txtsodt.Text;
            khachHangMoi.diachi = txtdiachi.Text;

            // Thêm khách hàng vào danh sách
            danhsachkh.Add(khachHangMoi);

            // Cập nhật lại DataGridView
            dataGridViewkh.DataSource = null;
            dataGridViewkh.DataSource = danhsachkh;

            // Xóa dữ liệu trong các TextBox
            txtten.Clear();
            txtsodt.Clear();
            txtdiachi.Clear();
        }
        private void dataGridViewkh_CellClick(object sender, DataGridViewCellEventArgs
   e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewkh.Rows[e.RowIndex];
                
                txtten.Text = row.Cells["tenkh"].Value.ToString();
                txttenkh.Text = row.Cells["tenkh"].Value.ToString();
                txtsodt.Text = row.Cells["sodt"].Value.ToString();
                txtsodtkh.Text = row.Cells["sodt"].Value.ToString();
                txtdiachi.Text = row.Cells["diachi"].Value.ToString();
                if (txtmahd.Text == null) txtmahd.Text = sinhma();
            }
        }
        private void dataGridViewdv_CellClick(object sender, DataGridViewCellEventArgs
 e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewdv.Rows[e.RowIndex];
                string thongTinDichVu = $"Mã dịch vụ: {row.Cells["madv"].Value}___ \n" +
                                        $"Tên dịch vụ: {row.Cells["tendv"].Value}___ \n" +
                                        $"Đơn giá: {row.Cells["gia"].Value}";

                listBox1.Items.Add(thongTinDichVu);
                if (int.TryParse(row.Cells["Gia"].Value.ToString(), out int gia))
                {
                    tongtien += gia;
                }
                txttien.Text = tongtien.ToString();
                if (txtmahd.Text == null) txtmahd.Text=sinhma();
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
       
        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (dataGridViewkh.SelectedRows.Count > 0)
            {
                // Lấy chỉ số của hàng được chọn
                int index = dataGridViewkh.SelectedRows[0].Index;
                // Lấy thông tin từ các TextBox và cập nhật vào đối tượng khách hàng
                danhsachkh[index].tenkh = txtten.Text;
                danhsachkh[index].sodt = txtsodt.Text;
                danhsachkh[index].diachi = txtdiachi.Text;
                // Cập nhật lại DataGridView
                dataGridViewkh.DataSource = null;
                dataGridViewkh.DataSource = danhsachkh;

            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.");
            }

            // Đổ dữ liệu vào các TextBox

            

        }
    }
}
