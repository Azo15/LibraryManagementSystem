namespace LibraryManagementSystem.Forms
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblDailyBorrows;
        private System.Windows.Forms.Label lblDailyReturns;
        private System.Windows.Forms.Label lblWeeklyBorrows;
        private System.Windows.Forms.Label lblMonthlyBorrows;
        private System.Windows.Forms.Label lblOverdue;
        private System.Windows.Forms.Label lblMostBorrowed;
        private System.Windows.Forms.DataGridView dgvMostBorrowed;
        private System.Windows.Forms.Button btnRefresh;

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
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvMostBorrowed = new System.Windows.Forms.DataGridView();
            this.lblMostBorrowed = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblOverdue = new System.Windows.Forms.Label();
            this.lblMonthlyBorrows = new System.Windows.Forms.Label();
            this.lblWeeklyBorrows = new System.Windows.Forms.Label();
            this.lblDailyReturns = new System.Windows.Forms.Label();
            this.lblDailyBorrows = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostBorrowed)).BeginInit();
            this.SuspendLayout();
            
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnRefresh);
            this.panelMain.Controls.Add(this.dgvMostBorrowed);
            this.panelMain.Controls.Add(this.lblMostBorrowed);
            this.panelMain.Controls.Add(this.pnlStats);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1000, 600);
            this.panelMain.TabIndex = 0;
            
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Analizler ve Raporlar";
            
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.Controls.Add(this.lblDailyBorrows);
            this.pnlStats.Controls.Add(this.lblDailyReturns);
            this.pnlStats.Controls.Add(this.lblWeeklyBorrows);
            this.pnlStats.Controls.Add(this.lblMonthlyBorrows);
            this.pnlStats.Controls.Add(this.lblOverdue);
            this.pnlStats.Location = new System.Drawing.Point(30, 70);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(940, 80);
            this.pnlStats.TabIndex = 1;
            
            // 
            // lblDailyBorrows
            // 
            this.lblDailyBorrows.AutoSize = true;
            this.lblDailyBorrows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDailyBorrows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblDailyBorrows.Location = new System.Drawing.Point(20, 30);
            this.lblDailyBorrows.Name = "lblDailyBorrows";
            this.lblDailyBorrows.Size = new System.Drawing.Size(130, 21);
            this.lblDailyBorrows.TabIndex = 1;
            this.lblDailyBorrows.Text = "Günlük Ödünç: 0";
            
            // 
            // lblDailyReturns
            // 
            this.lblDailyReturns.AutoSize = true;
            this.lblDailyReturns.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDailyReturns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblDailyReturns.Location = new System.Drawing.Point(200, 30);
            this.lblDailyReturns.Name = "lblDailyReturns";
            this.lblDailyReturns.Size = new System.Drawing.Size(110, 21);
            this.lblDailyReturns.TabIndex = 2;
            this.lblDailyReturns.Text = "Günlük İade: 0";
            
            // 
            // lblWeeklyBorrows
            // 
            this.lblWeeklyBorrows.AutoSize = true;
            this.lblWeeklyBorrows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWeeklyBorrows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblWeeklyBorrows.Location = new System.Drawing.Point(370, 30);
            this.lblWeeklyBorrows.Name = "lblWeeklyBorrows";
            this.lblWeeklyBorrows.Size = new System.Drawing.Size(140, 21);
            this.lblWeeklyBorrows.TabIndex = 3;
            this.lblWeeklyBorrows.Text = "Haftalık Ödünç: 0";
            
            // 
            // lblMonthlyBorrows
            // 
            this.lblMonthlyBorrows.AutoSize = true;
            this.lblMonthlyBorrows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMonthlyBorrows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblMonthlyBorrows.Location = new System.Drawing.Point(550, 30);
            this.lblMonthlyBorrows.Name = "lblMonthlyBorrows";
            this.lblMonthlyBorrows.Size = new System.Drawing.Size(120, 21);
            this.lblMonthlyBorrows.TabIndex = 4;
            this.lblMonthlyBorrows.Text = "Aylık Ödünç: 0";
            
            // 
            // lblOverdue
            // 
            this.lblOverdue.AutoSize = true;
            this.lblOverdue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOverdue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblOverdue.Location = new System.Drawing.Point(740, 30);
            this.lblOverdue.Name = "lblOverdue";
            this.lblOverdue.Size = new System.Drawing.Size(160, 21);
            this.lblOverdue.TabIndex = 5;
            this.lblOverdue.Text = "Gecikmiş Kitaplar: 0";
            
            // 
            // lblMostBorrowed
            // 
            this.lblMostBorrowed.AutoSize = true;
            this.lblMostBorrowed.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMostBorrowed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblMostBorrowed.Location = new System.Drawing.Point(30, 180);
            this.lblMostBorrowed.Name = "lblMostBorrowed";
            this.lblMostBorrowed.Size = new System.Drawing.Size(220, 25);
            this.lblMostBorrowed.TabIndex = 6;
            this.lblMostBorrowed.Text = "Popüler Kitaplar Listesi";
            
            // 
            // dgvMostBorrowed
            // 
            this.dgvMostBorrowed.AllowUserToAddRows = false;
            this.dgvMostBorrowed.AllowUserToDeleteRows = false;
            this.dgvMostBorrowed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMostBorrowed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMostBorrowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostBorrowed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Kitap Başlığı" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Author", HeaderText = "Yazar Bilgisi" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "BorrowCount", HeaderText = "Ödünç Alınma Sayısı" }
            });
            this.dgvMostBorrowed.Location = new System.Drawing.Point(30, 220);
            this.dgvMostBorrowed.MultiSelect = false;
            this.dgvMostBorrowed.Name = "dgvMostBorrowed";
            this.dgvMostBorrowed.ReadOnly = true;
            this.dgvMostBorrowed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMostBorrowed.Size = new System.Drawing.Size(940, 310);
            this.dgvMostBorrowed.TabIndex = 7;
            
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(840, 545);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 35);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Güncelle";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raporlar";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostBorrowed)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
