namespace Lab6ex03
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ttHoten = new TextBox();
            soHD = new TextBox();
            ttSotien = new TextBox();
            ttCCCD = new TextBox();
            ttSoPhong = new ComboBox();
            ttNgaytt = new ComboBox();
            btnThem = new Button();
            btnLuu = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Sitka Heading", 9F);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(81, 81);
            label1.Name = "label1";
            label1.Size = new Size(88, 21);
            label1.TabIndex = 0;
            label1.Text = "Số hợp đồng";
            //label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Font = new Font("Sitka Heading", 9F);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(81, 145);
            label2.Name = "label2";
            label2.Size = new Size(51, 21);
            label2.TabIndex = 0;
            label2.Text = "Họ tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Font = new Font("Sitka Heading", 9F);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(81, 192);
            label3.Name = "label3";
            label3.Size = new Size(66, 21);
            label3.TabIndex = 0;
            label3.Text = "Số CCCD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Font = new Font("Sitka Heading", 9F);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(81, 240);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 0;
            label4.Text = "Số tiền TT";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(442, 193);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 0;
            label5.Text = "Số Phòng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(442, 241);
            label6.Name = "label6";
            label6.Size = new Size(119, 20);
            label6.TabIndex = 0;
            label6.Text = "Ngày thanh toán";
            // 
            // ttHoten
            // 
            ttHoten.Location = new Point(221, 145);
            ttHoten.Name = "ttHoten";
            ttHoten.Size = new Size(340, 27);
            ttHoten.TabIndex = 1;
            // 
            // soHD
            // 
            soHD.Enabled = false;
            soHD.Location = new Point(221, 75);
            soHD.Name = "soHD";
            soHD.Size = new Size(125, 27);
            soHD.TabIndex = 1;
            //soHD.TextChanged += textBox2_TextChanged;
            // 
            // ttSotien
            // 
            ttSotien.Location = new Point(221, 240);
            ttSotien.Name = "ttSotien";
            ttSotien.Size = new Size(125, 27);
            ttSotien.TabIndex = 1;
            // s
            // ttCCCD
            // 
            ttCCCD.Location = new Point(221, 190);
            ttCCCD.Name = "ttCCCD";
            ttCCCD.Size = new Size(125, 27);
            ttCCCD.TabIndex = 1;
            // 
            // ttSoPhong
            // 
            ttSoPhong.FormattingEnabled = true;
            ttSoPhong.Location = new Point(624, 189);
            ttSoPhong.Name = "ttSoPhong";
            ttSoPhong.Size = new Size(151, 28);
            ttSoPhong.TabIndex = 2;
            //ttSoPhong.SelectedIndexChanged += ttSoPhong_SelectedIndexChanged;
            // 
            // ttNgaytt
            // 
            ttNgaytt.FormattingEnabled = true;
            ttNgaytt.Location = new Point(624, 239);
            ttNgaytt.Name = "ttNgaytt";
            ttNgaytt.Size = new Size(151, 28);
            ttNgaytt.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(209, 363);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            //btnThem.Click += button1_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(383, 363);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            //btnLuu.Click += button1_Click_1;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(545, 363);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(btnThem);
            Controls.Add(ttNgaytt);
            Controls.Add(ttSoPhong);
            Controls.Add(soHD);
            Controls.Add(ttSotien);
            Controls.Add(ttCCCD);
            Controls.Add(ttHoten);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Thanh toán";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox ttHoten;
        private TextBox soHD;
        private TextBox ttSotien;
        private TextBox ttCCCD;
        private ComboBox ttSoPhong;
        private ComboBox ttNgaytt;
        private Button btnThem;
        private Button btnLuu;
        private Button btnThoat;
    }
}
