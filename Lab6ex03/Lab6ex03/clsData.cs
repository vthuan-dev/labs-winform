using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // dùng Microsoft.Data.SqlClient

namespace Lab6ex03
{
    public class clsData
    {
        public static string ConnectionString = "Server=DESKTOP-03C08VS; Database=ThanhToan; uid=mylogin; pwd=mylogin; TrustServerCertificate=True";

        public static bool TestConnection()
        {
            try
            {
                using (var con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    MessageBox.Show("Kết nối CSDL thành công!");
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối SQL: " + ex.Message);
                return false;
            }
        }

        public static int GetNextSoHD()
        {
            int newSoHD = 1;
            try
            {
                using (var con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    string query = "SELECT MAX(SoHD) FROM KhachHang";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            newSoHD = Convert.ToInt32(result) + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy số hóa đơn: " + ex.Message);
            }
            return newSoHD;
        }

        public static DataTable GetNgayThanhToan()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    string query = "SELECT DISTINCT NgayTT FROM KhachHang WHERE NgayTT IS NOT NULL";
                    using (var cmd = new SqlCommand(query, con))
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy Ngày thanh toán: " + ex.Message);
            }
            return dt;
        }

        public static DataTable GetSoPhong()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    string query = "SELECT DISTINCT Phong FROM KhachHang WHERE Phong IS NOT NULL";
                    using (var cmd = new SqlCommand(query, con))
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy Số phòng: " + ex.Message);
            }
            return dt;
        }

        public static bool SaveKhachHang(int soHD, string tenKH, string soCMND, decimal soTien, DateTime ngayTT, int maPhong)
        {
            try
            {
                using (var con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    string query = "INSERT INTO KhachHang (SoHD, TenKH, SoCMND, SoTien, NgayTT, Phong) VALUES (@SoHD, @TenKH, @SoCMND, @SoTien, @NgayTT, @Phong)";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SoHD", soHD);
                        cmd.Parameters.AddWithValue("@TenKH", tenKH);
                        cmd.Parameters.AddWithValue("@SoCMND", soCMND);
                        cmd.Parameters.AddWithValue("@SoTien", soTien);
                        cmd.Parameters.AddWithValue("@NgayTT", ngayTT);
                        cmd.Parameters.AddWithValue("@Phong", maPhong);

                        MessageBox.Show("Trước khi lưu vào cơ sở dữ liệu!");

                        int result = cmd.ExecuteNonQuery(); // Kiểm tra số dòng bị ảnh hưởng
                        if (result > 0)
                        {
                            MessageBox.Show("Lưu hóa đơn thành công!");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu được lưu vào cơ sở dữ liệu!");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
                return false;
            }
        }


    }
}
