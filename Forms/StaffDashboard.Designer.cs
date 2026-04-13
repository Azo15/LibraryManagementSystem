namespace LibraryManagementSystem.Forms
{
    partial class StaffDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTopNav;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnBookManagement;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnBorrowTracking;
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
            this.btnBookManagement = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnBorrowTracking = new System.Windows.Forms.Button();
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
            this.panelTopNav.Controls.Add(this.btnBookManagement);
            this.panelTopNav.Controls.Add(this.btnUserManagement);
            this.panelTopNav.Controls.Add(this.btnBorrowTracking);
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
            this.lblLogo.Text = "📚 BOOKA";
            this.lblLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            
            // Nav Link Dimensions
            int navY = 22;
            int currentX = 180;
            System.Drawing.Font linkFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            System.Drawing.Color linkColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));

            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(currentX, navY);
            currentX += 90;
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(80, 28);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Ana Sayfa";
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = linkFont;
            this.btnHome.ForeColor = linkColor;
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            
            // 
            // btnBookManagement
            // 
            this.btnBookManagement.Location = new System.Drawing.Point(currentX, navY);
            currentX += 80;
            this.btnBookManagement.Name = "btnBookManagement";
            this.btnBookManagement.Size = new System.Drawing.Size(70, 28);
            this.btnBookManagement.TabIndex = 3;
            this.btnBookManagement.Text = "Kitaplar";
            this.btnBookManagement.FlatAppearance.BorderSize = 0;
            this.btnBookManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookManagement.Font = linkFont;
            this.btnBookManagement.ForeColor = linkColor;
            this.btnBookManagement.BackColor = System.Drawing.Color.White;
            this.btnBookManagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookManagement.Click += new System.EventHandler(this.btnBookManagement_Click);

            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Location = new System.Drawing.Point(currentX, navY);
            currentX += 100;
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(90, 28);
            this.btnUserManagement.TabIndex = 4;
            this.btnUserManagement.Text = "Okuyucular";
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = linkFont;
            this.btnUserManagement.ForeColor = linkColor;
            this.btnUserManagement.BackColor = System.Drawing.Color.White;
            this.btnUserManagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);

            // 
            // btnBorrowTracking
            // 
            this.btnBorrowTracking.Location = new System.Drawing.Point(currentX, navY);
            currentX += 100;
            this.btnBorrowTracking.Name = "btnBorrowTracking";
            this.btnBorrowTracking.Size = new System.Drawing.Size(90, 28);
            this.btnBorrowTracking.TabIndex = 5;
            this.btnBorrowTracking.Text = "Ödünç İade";
            this.btnBorrowTracking.FlatAppearance.BorderSize = 0;
            this.btnBorrowTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowTracking.Font = linkFont;
            this.btnBorrowTracking.ForeColor = linkColor;
            this.btnBorrowTracking.BackColor = System.Drawing.Color.White;
            this.btnBorrowTracking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrowTracking.Click += new System.EventHandler(this.btnBorrowTracking_Click);

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
            this.btnLogout.Font = linkFont;
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
            this.btnChangePassword.Font = linkFont;
            this.btnChangePassword.ForeColor = linkColor;
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
            // StaffDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTopNav);
            this.Name = "StaffDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Paneli";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTopNav.ResumeLayout(false);
            this.panelTopNav.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
