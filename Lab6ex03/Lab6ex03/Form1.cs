using System;
using System.Data;
using System.Windows.Forms;

namespace Lab6ex03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadPhong();
            LoadNgayThanhToan();
            
            // Đăng ký sự kiện click cho nút Lưu
            btnLuu.Click += btnLuu_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsData.TestConnection();
            LoadNgayThanhToan();
            LoadSoPhong();
            btnThem_Click(null, null);
        }

        private void LoadSoPhong()
        {
            ttSoPhong.Items.Clear();
            DataTable dt = clsData.GetSoPhong();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Phong"] != DBNull.Value)
                {
                    ttSoPhong.Items.Add(row["Phong"].ToString());
                }
            }
        }

        private void LoadNgayThanhToan()
        {
            try 
            {
                // Thêm ngày hiện tại vào ComboBox
                ttNgaytt.Items.Add(DateTime.Now.ToString("yyyy-MM-dd"));
                ttNgaytt.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load ngày thanh toán: {ex.Message}");
            }
        }

        private void LoadPhong()
        {
            try
            {
                DataTable dt = clsData.GetPhong();
                ttSoPhong.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ttSoPhong.Items.Add(row["MaPhong"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load phòng: {ex.Message}");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int soHDMoi = clsData.GetNextSoHD();
            soHD.Text = soHDMoi.ToString();

            ttHoten.Text = "";
            ttCCCD.Text = "";
            ttSotien.Text = "";
            ttNgaytt.SelectedIndex = -1;
            ttSoPhong.SelectedIndex = -1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(soHD.Text))
                {
                    MessageBox.Show("Vui lòng nhấn nút Thêm để tạo số hợp đồng mới!");
                    return;
                }

                if (string.IsNullOrEmpty(ttHoten.Text) || 
                    string.IsNullOrEmpty(ttCCCD.Text) || 
                    string.IsNullOrEmpty(ttSotien.Text) ||
                    ttSoPhong.SelectedItem == null ||
                    ttNgaytt.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                int soHopDong = int.Parse(soHD.Text);
                string tenKH = ttHoten.Text.Trim();
                string soCMND = ttCCCD.Text.Trim();
                decimal soTien;
                if (!decimal.TryParse(ttSotien.Text, out soTien))
                {
                    MessageBox.Show("Số tiền không hợp lệ!");
                    return;
                }
                
                DateTime ngayTT = DateTime.Parse(ttNgaytt.Text);
                int maPhong = int.Parse(ttSoPhong.Text);

                bool result = clsData.SaveKhachHang(soHopDong, tenKH, soCMND, soTien, ngayTT, maPhong);
                if (result)
                {
                    MessageBox.Show("Lưu thành công!");
                    // Reset form sau khi lưu thành công
                    btnThem_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
