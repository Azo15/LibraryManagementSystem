namespace LibraryManagementSystem.Forms
{
    partial class StudentDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTopNav;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSearchBooks;
        private System.Windows.Forms.Button btnMyBorrows;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTopNav = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSearchBooks = new System.Windows.Forms.Button();
            this.btnMyBorrows = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelTopNav.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // panelTopNav
            // 
            this.panelTopNav.BackColor = System.Drawing.Color.White;
            this.panelTopNav.Controls.Add(this.btnLogout);
            this.panelTopNav.Controls.Add(this.btnChangePassword);
            this.panelTopNav.Controls.Add(this.lblWelcome);
            this.panelTopNav.Controls.Add(this.lblLogo);
            this.panelTopNav.Controls.Add(this.btnHome);
            this.panelTopNav.Controls.Add(this.btnSearchBooks);
            this.panelTopNav.Controls.Add(this.btnMyBorrows);
            this.panelTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopNav.Location = new System.Drawing.Point(0, 0);
            this.panelTopNav.Name = "panelTopNav";
            this.panelTopNav.Size = new System.Drawing.Size(1024, 70);
            this.panelTopNav.TabIndex = 0;
            this.panelTopNav.Paint += (s, e) => {
                System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, this.panelTopNav.ClientRectangle, 
                    System.Drawing.Color.White, 0, System.Windows.Forms.ButtonBorderStyle.None,
                    System.Drawing.Color.White, 0, System.Windows.Forms.ButtonBorderStyle.None,
                    System.Drawing.Color.White, 0, System.Windows.Forms.ButtonBorderStyle.None,
                    System.Drawing.Color.FromArgb(236, 240, 241), 1, System.Windows.Forms.ButtonBorderStyle.Solid);
            };

            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(58)))), ((int)(((byte)(255)))));
            this.lblLogo.Location = new System.Drawing.Point(20, 20);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(120, 30);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "📚 EduLibrary";
            this.lblLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(180, 22);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(80, 28);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Ana Sayfa";
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            
            // 
            // btnSearchBooks
            // 
            this.btnSearchBooks.Location = new System.Drawing.Point(270, 22);
            this.btnSearchBooks.Name = "btnSearchBooks";
            this.btnSearchBooks.Size = new System.Drawing.Size(100, 28);
            this.btnSearchBooks.TabIndex = 3;
            this.btnSearchBooks.Text = "Kitap Ara";
            this.btnSearchBooks.FlatAppearance.BorderSize = 0;
            this.btnSearchBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearchBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnSearchBooks.BackColor = System.Drawing.Color.White;
            this.btnSearchBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchBooks.Click += new System.EventHandler(this.btnSearchBooks_Click);

            // 
            // btnMyBorrows
            // 
            this.btnMyBorrows.Location = new System.Drawing.Point(380, 22);
            this.btnMyBorrows.Name = "btnMyBorrows";
            this.btnMyBorrows.Size = new System.Drawing.Size(120, 28);
            this.btnMyBorrows.TabIndex = 4;
            this.btnMyBorrows.Text = "Ödünçlerim";
            this.btnMyBorrows.FlatAppearance.BorderSize = 0;
            this.btnMyBorrows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyBorrows.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMyBorrows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnMyBorrows.BackColor = System.Drawing.Color.White;
            this.btnMyBorrows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyBorrows.Click += new System.EventHandler(this.btnMyBorrows_Click);

            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(920, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 40);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Çıkış Yap";
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(58)))), ((int)(((byte)(255)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePassword.Location = new System.Drawing.Point(830, 22);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(80, 28);
            this.btnChangePassword.TabIndex = 7;
            this.btnChangePassword.Text = "Şifre";
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnChangePassword.BackColor = System.Drawing.Color.White;
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);

            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblWelcome.Location = new System.Drawing.Point(650, 28);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(150, 15);
            this.lblWelcome.TabIndex = 8;
            this.lblWelcome.Text = "Hoş Geldiniz";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 70);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1024, 698);
            this.panelContent.TabIndex = 1;

            // 
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTopNav);
            this.Name = "StudentDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Öğrenci Paneli";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTopNav.ResumeLayout(false);
            this.panelTopNav.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
