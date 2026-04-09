namespace LibraryManagementSystem.Forms
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
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
            this.lblOverdue = new System.Windows.Forms.Label();
            this.lblMonthlyBorrows = new System.Windows.Forms.Label();
            this.lblWeeklyBorrows = new System.Windows.Forms.Label();
            this.lblDailyReturns = new System.Windows.Forms.Label();
            this.lblDailyBorrows = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostBorrowed)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnRefresh);
            this.panelMain.Controls.Add(this.dgvMostBorrowed);
            this.panelMain.Controls.Add(this.lblMostBorrowed);
            this.panelMain.Controls.Add(this.lblOverdue);
            this.panelMain.Controls.Add(this.lblMonthlyBorrows);
            this.panelMain.Controls.Add(this.lblWeeklyBorrows);
            this.panelMain.Controls.Add(this.lblDailyReturns);
            this.panelMain.Controls.Add(this.lblDailyBorrows);
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
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Raporlar ve Analizler";
            // 
            // lblDailyBorrows
            // 
            this.lblDailyBorrows.AutoSize = true;
            this.lblDailyBorrows.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDailyBorrows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblDailyBorrows.Location = new System.Drawing.Point(30, 70);
            this.lblDailyBorrows.Name = "lblDailyBorrows";
            this.lblDailyBorrows.Size = new System.Drawing.Size(130, 18);
            this.lblDailyBorrows.TabIndex = 1;
            this.lblDailyBorrows.Text = "Günlük Ödünç: 0";
            // 
            // lblDailyReturns
            // 
            this.lblDailyReturns.AutoSize = true;
            this.lblDailyReturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDailyReturns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblDailyReturns.Location = new System.Drawing.Point(200, 70);
            this.lblDailyReturns.Name = "lblDailyReturns";
            this.lblDailyReturns.Size = new System.Drawing.Size(110, 18);
            this.lblDailyReturns.TabIndex = 2;
            this.lblDailyReturns.Text = "Günlük İade: 0";
            // 
            // lblWeeklyBorrows
            // 
            this.lblWeeklyBorrows.AutoSize = true;
            this.lblWeeklyBorrows.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWeeklyBorrows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblWeeklyBorrows.Location = new System.Drawing.Point(370, 70);
            this.lblWeeklyBorrows.Name = "lblWeeklyBorrows";
            this.lblWeeklyBorrows.Size = new System.Drawing.Size(140, 18);
            this.lblWeeklyBorrows.TabIndex = 3;
            this.lblWeeklyBorrows.Text = "Haftalık Ödünç: 0";
            // 
            // lblMonthlyBorrows
            // 
            this.lblMonthlyBorrows.AutoSize = true;
            this.lblMonthlyBorrows.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMonthlyBorrows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lblMonthlyBorrows.Location = new System.Drawing.Point(550, 70);
            this.lblMonthlyBorrows.Name = "lblMonthlyBorrows";
            this.lblMonthlyBorrows.Size = new System.Drawing.Size(120, 18);
            this.lblMonthlyBorrows.TabIndex = 4;
            this.lblMonthlyBorrows.Text = "Aylık Ödünç: 0";
            // 
            // lblOverdue
            // 
            this.lblOverdue.AutoSize = true;
            this.lblOverdue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOverdue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblOverdue.Location = new System.Drawing.Point(720, 70);
            this.lblOverdue.Name = "lblOverdue";
            this.lblOverdue.Size = new System.Drawing.Size(160, 18);
            this.lblOverdue.TabIndex = 5;
            this.lblOverdue.Text = "Gecikmiş Kitaplar: 0";
            // 
            // lblMostBorrowed
            // 
            this.lblMostBorrowed.AutoSize = true;
            this.lblMostBorrowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMostBorrowed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblMostBorrowed.Location = new System.Drawing.Point(30, 120);
            this.lblMostBorrowed.Name = "lblMostBorrowed";
            this.lblMostBorrowed.Size = new System.Drawing.Size(220, 20);
            this.lblMostBorrowed.TabIndex = 6;
            this.lblMostBorrowed.Text = "En Çok Ödünç Alınan Kitaplar";
            // 
            // dgvMostBorrowed
            // 
            this.dgvMostBorrowed.AllowUserToAddRows = false;
            this.dgvMostBorrowed.AllowUserToDeleteRows = false;
            this.dgvMostBorrowed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMostBorrowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostBorrowed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Başlık" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Author", HeaderText = "Yazar" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "BorrowCount", HeaderText = "Ödünç Sayısı" }
            });
            this.dgvMostBorrowed.Location = new System.Drawing.Point(30, 150);
            this.dgvMostBorrowed.MultiSelect = false;
            this.dgvMostBorrowed.Name = "dgvMostBorrowed";
            this.dgvMostBorrowed.ReadOnly = true;
            this.dgvMostBorrowed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMostBorrowed.Size = new System.Drawing.Size(940, 380);
            this.dgvMostBorrowed.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(840, 550);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 35);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Yenile";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostBorrowed)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

