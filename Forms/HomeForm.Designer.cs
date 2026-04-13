namespace LibraryManagementSystem.Forms
{
    partial class HomeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlBanner;
        
        // 4 Stat Cards
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCardTitle1;
        private System.Windows.Forms.Label lblUsersCount;
        
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCardTitle2;
        private System.Windows.Forms.Label lblCategoriesCount;

        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCardTitle3;
        private System.Windows.Forms.Label lblBooksCount;

        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblCardTitle4;
        private System.Windows.Forms.Label lblBorrowsCount;

        // Charts
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLine;

        // Side Feed Panel
        private System.Windows.Forms.Panel pnlSideFeed;
        private System.Windows.Forms.Label lblSideFeedTitle;
        private System.Windows.Forms.FlowLayoutPanel flpActivities;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            
            this.pnlBanner = new System.Windows.Forms.Panel();
            
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCardTitle1 = new System.Windows.Forms.Label();
            this.lblUsersCount = new System.Windows.Forms.Label();
            
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCardTitle2 = new System.Windows.Forms.Label();
            this.lblCategoriesCount = new System.Windows.Forms.Label();

            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCardTitle3 = new System.Windows.Forms.Label();
            this.lblBooksCount = new System.Windows.Forms.Label();

            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblCardTitle4 = new System.Windows.Forms.Label();
            this.lblBorrowsCount = new System.Windows.Forms.Label();

            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLine = new System.Windows.Forms.DataVisualization.Charting.Chart();
            
            this.pnlSideFeed = new System.Windows.Forms.Panel();
            this.lblSideFeedTitle = new System.Windows.Forms.Label();
            this.flpActivities = new System.Windows.Forms.FlowLayoutPanel();

            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.pnlSideFeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlBanner
            // 
            this.pnlBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBanner.Location = new System.Drawing.Point(30, 20);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(950, 150);
            this.pnlBanner.TabIndex = 0;
            this.pnlBanner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBanner_Paint);

            // 
            // Layout sizes
            // 
            int cardWidth = 220;
            int cardHeight = 100;
            int spacing = 20;
            int startX = 30;
            int currentY = 190;

            // 
            // pnlCard1
            // 
            this.pnlCard1.Location = new System.Drawing.Point(startX, currentY);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlCard1.TabIndex = 1;
            this.pnlCard1.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            this.pnlCard1.Controls.Add(this.lblCardTitle1);
            this.pnlCard1.Controls.Add(this.lblUsersCount);

            this.lblCardTitle1.AutoSize = true;
            this.lblCardTitle1.Location = new System.Drawing.Point(20, 20);
            this.lblCardTitle1.Text = "OKUYUCULAR";
            this.lblCardTitle1.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTitle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle1.BackColor = System.Drawing.Color.White;

            this.lblUsersCount.AutoSize = true;
            this.lblUsersCount.Location = new System.Drawing.Point(20, 50);
            this.lblUsersCount.Text = "0";
            this.lblUsersCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblUsersCount.BackColor = System.Drawing.Color.White;

            // 
            // pnlCard2
            // 
            this.pnlCard2.Location = new System.Drawing.Point(startX + cardWidth + spacing, currentY);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlCard2.TabIndex = 2;
            this.pnlCard2.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            this.pnlCard2.Controls.Add(this.lblCardTitle2);
            this.pnlCard2.Controls.Add(this.lblCategoriesCount);

            this.lblCardTitle2.AutoSize = true;
            this.lblCardTitle2.Location = new System.Drawing.Point(20, 20);
            this.lblCardTitle2.Text = "TÜRLER";
            this.lblCardTitle2.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTitle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle2.BackColor = System.Drawing.Color.White;

            this.lblCategoriesCount.AutoSize = true;
            this.lblCategoriesCount.Location = new System.Drawing.Point(20, 50);
            this.lblCategoriesCount.Text = "0";
            this.lblCategoriesCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCategoriesCount.BackColor = System.Drawing.Color.White;

            // 
            // pnlCard3
            // 
            this.pnlCard3.Location = new System.Drawing.Point(startX + (cardWidth * 2) + (spacing * 2), currentY);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlCard3.TabIndex = 3;
            this.pnlCard3.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            this.pnlCard3.Controls.Add(this.lblCardTitle3);
            this.pnlCard3.Controls.Add(this.lblBooksCount);

            this.lblCardTitle3.AutoSize = true;
            this.lblCardTitle3.Location = new System.Drawing.Point(20, 20);
            this.lblCardTitle3.Text = "KİTAPLAR";
            this.lblCardTitle3.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTitle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle3.BackColor = System.Drawing.Color.White;

            this.lblBooksCount.AutoSize = true;
            this.lblBooksCount.Location = new System.Drawing.Point(20, 50);
            this.lblBooksCount.Text = "0";
            this.lblBooksCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBooksCount.BackColor = System.Drawing.Color.White;

            // 
            // pnlCard4
            // 
            this.pnlCard4.Location = new System.Drawing.Point(startX + (cardWidth * 3) + (spacing * 3), currentY);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(cardWidth+10, cardHeight);
            this.pnlCard4.TabIndex = 4;
            this.pnlCard4.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            this.pnlCard4.Controls.Add(this.lblCardTitle4);
            this.pnlCard4.Controls.Add(this.lblBorrowsCount);

            this.lblCardTitle4.AutoSize = true;
            this.lblCardTitle4.Location = new System.Drawing.Point(20, 20);
            this.lblCardTitle4.Text = "AKTİF ÖDÜNÇ";
            this.lblCardTitle4.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTitle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle4.BackColor = System.Drawing.Color.White;

            this.lblBorrowsCount.AutoSize = true;
            this.lblBorrowsCount.Location = new System.Drawing.Point(20, 50);
            this.lblBorrowsCount.Text = "0";
            this.lblBorrowsCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBorrowsCount.BackColor = System.Drawing.Color.White;

            // 
            // chartPie
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPie.Legends.Add(legend1);
            this.chartPie.Location = new System.Drawing.Point(30, 310);
            this.chartPie.Name = "chartPie";
            this.chartPie.Size = new System.Drawing.Size(400, 350);
            this.chartPie.TabIndex = 5;
            this.chartPie.Text = "Kitap Tür Dağılımı";
            // Add a title to chart
            this.chartPie.Titles.Add(new System.Windows.Forms.DataVisualization.Charting.Title("Kitap Tür Dağılımı", System.Windows.Forms.DataVisualization.Charting.Docking.Top, new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold), System.Drawing.Color.FromArgb(44, 62, 80)));

            // 
            // chartLine
            // 
            chartArea2.Name = "ChartArea1";
            this.chartLine.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartLine.Legends.Add(legend2);
            this.chartLine.Location = new System.Drawing.Point(450, 310);
            this.chartLine.Name = "chartLine";
            this.chartLine.Size = new System.Drawing.Size(530, 350);
            this.chartLine.TabIndex = 6;
            this.chartLine.Text = "Son 6 Ayın Ödünç Alma Trendi";
            this.chartLine.Titles.Add(new System.Windows.Forms.DataVisualization.Charting.Title("Son 6 Ayın Ödünç Alma Trendi", System.Windows.Forms.DataVisualization.Charting.Docking.Top, new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold), System.Drawing.Color.FromArgb(44, 62, 80)));
            // Make charts stretch slightly if needed, but fixed size is usually safer.
            this.chartLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Bottom)));
            this.chartPie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Bottom)));

            // 
            // pnlSideFeed
            // 
            this.pnlSideFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSideFeed.Location = new System.Drawing.Point(1000, 190);
            this.pnlSideFeed.Name = "pnlSideFeed";
            this.pnlSideFeed.Size = new System.Drawing.Size(470, 470);
            this.pnlSideFeed.TabIndex = 7;
            this.pnlSideFeed.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            this.pnlSideFeed.Controls.Add(this.lblSideFeedTitle);
            this.pnlSideFeed.Controls.Add(this.flpActivities);

            // 
            // lblSideFeedTitle
            // 
            this.lblSideFeedTitle.AutoSize = true;
            this.lblSideFeedTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSideFeedTitle.Text = "SON İŞLEMLER & BİLDİRİMLER";
            this.lblSideFeedTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSideFeedTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSideFeedTitle.BackColor = System.Drawing.Color.White;

            // 
            // flpActivities
            // 
            this.flpActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.flpActivities.Location = new System.Drawing.Point(20, 50);
            this.flpActivities.Name = "flpActivities";
            this.flpActivities.Size = new System.Drawing.Size(430, 400);
            this.flpActivities.TabIndex = 8;
            this.flpActivities.BackColor = System.Drawing.Color.White;
            this.flpActivities.AutoScroll = true;
            this.flpActivities.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpActivities.WrapContents = false;

            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 700);
            this.Controls.Add(this.pnlSideFeed);
            this.Controls.Add(this.chartLine);
            this.Controls.Add(this.chartPie);
            this.Controls.Add(this.pnlCard4);
            this.Controls.Add(this.pnlCard3);
            this.Controls.Add(this.pnlCard2);
            this.Controls.Add(this.pnlCard1);
            this.Controls.Add(this.pnlBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // We will embed this
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            this.pnlSideFeed.ResumeLayout(false);
            this.pnlSideFeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
