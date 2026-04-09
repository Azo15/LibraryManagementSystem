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
            this.pnlStats.BackColor = System.Drawing.Color.Transparent;
            this.pnlStats.Controls.Add(this.lblDailyBorrows);
            this.pnlStats.Controls.Add(this.lblDailyReturns);
            this.pnlStats.Controls.Add(this.lblWeeklyBorrows);
            this.pnlStats.Controls.Add(this.lblMonthlyBorrows);
            this.pnlStats.Controls.Add(this.lblOverdue);
            this.pnlStats.Location = new System.Drawing.Point(30, 70);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(940, 70);
            this.pnlStats.TabIndex = 1;
            
            // 
            // lblDailyBorrows
            // 
            this.lblDailyBorrows.AutoSize = false;
            this.lblDailyBorrows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblDailyBorrows.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDailyBorrows.ForeColor = System.Drawing.Color.White;
            this.lblDailyBorrows.Location = new System.Drawing.Point(0, 0);
            this.lblDailyBorrows.Name = "lblDailyBorrows";
            this.lblDailyBorrows.Size = new System.Drawing.Size(160, 60);
            this.lblDailyBorrows.TabIndex = 1;
            this.lblDailyBorrows.Text = "Günlük Ödünç\n0";
            this.lblDailyBorrows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // lblDailyReturns
            // 
            this.lblDailyReturns.AutoSize = false;
            this.lblDailyReturns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblDailyReturns.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDailyReturns.ForeColor = System.Drawing.Color.White;
            this.lblDailyReturns.Location = new System.Drawing.Point(180, 0);
            this.lblDailyReturns.Name = "lblDailyReturns";
            this.lblDailyReturns.Size = new System.Drawing.Size(160, 60);
            this.lblDailyReturns.TabIndex = 2;
            this.lblDailyReturns.Text = "Günlük İade\n0";
            this.lblDailyReturns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // lblWeeklyBorrows
            // 
            this.lblWeeklyBorrows.AutoSize = false;
            this.lblWeeklyBorrows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblWeeklyBorrows.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWeeklyBorrows.ForeColor = System.Drawing.Color.White;
            this.lblWeeklyBorrows.Location = new System.Drawing.Point(360, 0);
            this.lblWeeklyBorrows.Name = "lblWeeklyBorrows";
            this.lblWeeklyBorrows.Size = new System.Drawing.Size(160, 60);
            this.lblWeeklyBorrows.TabIndex = 3;
            this.lblWeeklyBorrows.Text = "Haftalık Ödünç\n0";
            this.lblWeeklyBorrows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // lblMonthlyBorrows
            // 
            this.lblMonthlyBorrows.AutoSize = false;
            this.lblMonthlyBorrows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lblMonthlyBorrows.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMonthlyBorrows.ForeColor = System.Drawing.Color.White;
            this.lblMonthlyBorrows.Location = new System.Drawing.Point(540, 0);
            this.lblMonthlyBorrows.Name = "lblMonthlyBorrows";
            this.lblMonthlyBorrows.Size = new System.Drawing.Size(160, 60);
            this.lblMonthlyBorrows.TabIndex = 4;
            this.lblMonthlyBorrows.Text = "Aylık Ödünç\n0";
            this.lblMonthlyBorrows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // lblOverdue
            // 
            this.lblOverdue.AutoSize = false;
            this.lblOverdue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblOverdue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOverdue.ForeColor = System.Drawing.Color.White;
            this.lblOverdue.Location = new System.Drawing.Point(720, 0);
            this.lblOverdue.Name = "lblOverdue";
            this.lblOverdue.Size = new System.Drawing.Size(160, 60);
            this.lblOverdue.TabIndex = 5;
            this.lblOverdue.Text = "Gecikmiş Kitaplar\n0";
            this.lblOverdue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
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
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostBorrowed)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
