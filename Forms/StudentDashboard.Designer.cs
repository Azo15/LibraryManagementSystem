namespace LibraryManagementSystem.Forms
{
    partial class StudentDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        public System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnSearchBooks;
        private System.Windows.Forms.Button btnBorrowRequest;
        private System.Windows.Forms.Button btnTrackBorrows;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblTitle;

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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnTrackBorrows = new System.Windows.Forms.Button();
            this.btnBorrowRequest = new System.Windows.Forms.Button();
            this.btnSearchBooks = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnChangePassword);
            this.panelSidebar.Controls.Add(this.btnTrackBorrows);
            this.panelSidebar.Controls.Add(this.btnBorrowRequest);
            this.panelSidebar.Controls.Add(this.btnSearchBooks);
            this.panelSidebar.Controls.Add(this.panelHeader);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(260, 600);
            this.panelSidebar.TabIndex = 0;
            
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(260, 100);
            this.panelHeader.TabIndex = 0;
            
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(161, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kütüphane YS";
            
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblWelcome.Location = new System.Drawing.Point(15, 60);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(76, 17);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Hoşgeldiniz";
            
            // 
            // btnSearchBooks
            // 
            this.btnSearchBooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearchBooks.FlatAppearance.BorderSize = 0;
            this.btnSearchBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchBooks.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSearchBooks.ForeColor = System.Drawing.Color.White;
            this.btnSearchBooks.Location = new System.Drawing.Point(0, 100);
            this.btnSearchBooks.Name = "btnSearchBooks";
            this.btnSearchBooks.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSearchBooks.Size = new System.Drawing.Size(260, 60);
            this.btnSearchBooks.TabIndex = 1;
            this.btnSearchBooks.Text = "🔍  Kitap Arama";
            this.btnSearchBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchBooks.UseVisualStyleBackColor = true;
            this.btnSearchBooks.Click += new System.EventHandler(this.btnSearchBooks_Click);
            
            // 
            // btnBorrowRequest
            // 
            this.btnBorrowRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBorrowRequest.FlatAppearance.BorderSize = 0;
            this.btnBorrowRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowRequest.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBorrowRequest.ForeColor = System.Drawing.Color.White;
            this.btnBorrowRequest.Location = new System.Drawing.Point(0, 160);
            this.btnBorrowRequest.Name = "btnBorrowRequest";
            this.btnBorrowRequest.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBorrowRequest.Size = new System.Drawing.Size(260, 60);
            this.btnBorrowRequest.TabIndex = 2;
            this.btnBorrowRequest.Text = "📤  Ödünç Talebi";
            this.btnBorrowRequest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrowRequest.UseVisualStyleBackColor = true;
            this.btnBorrowRequest.Click += new System.EventHandler(this.btnBorrowRequest_Click);
            
            // 
            // btnTrackBorrows
            // 
            this.btnTrackBorrows.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrackBorrows.FlatAppearance.BorderSize = 0;
            this.btnTrackBorrows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrackBorrows.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTrackBorrows.ForeColor = System.Drawing.Color.White;
            this.btnTrackBorrows.Location = new System.Drawing.Point(0, 220);
            this.btnTrackBorrows.Name = "btnTrackBorrows";
            this.btnTrackBorrows.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTrackBorrows.Size = new System.Drawing.Size(260, 60);
            this.btnTrackBorrows.TabIndex = 3;
            this.btnTrackBorrows.Text = "📦  Durum Takibi";
            this.btnTrackBorrows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrackBorrows.UseVisualStyleBackColor = true;
            this.btnTrackBorrows.Click += new System.EventHandler(this.btnTrackBorrows_Click);
            
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnChangePassword.Location = new System.Drawing.Point(0, 480);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnChangePassword.Size = new System.Drawing.Size(260, 60);
            this.btnChangePassword.TabIndex = 4;
            this.btnChangePassword.Text = "🔑  Şifre Değiştir";
            this.btnChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogout.Location = new System.Drawing.Point(0, 540);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(260, 60);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "🚪  Çıkış Yap";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(260, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(740, 600);
            this.panelContent.TabIndex = 1;
            
            // 
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Name = "StudentDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Öğrenci Paneli";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
