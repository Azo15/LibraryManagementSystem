using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LibraryManagementSystem.Services;
using System.Windows.Forms.DataVisualization.Charting;

namespace LibraryManagementSystem.Forms
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            LibraryManagementSystem.Utils.ThemeManager.ApplyTheme(this);
            LoadStats();
            SetupCharts();
        }

        private void LoadStats()
        {
            // Ideally we get these from database, we simulate based on ReporService
            DateTime today = DateTime.Now;
            lblUsersCount.Text = "24"; // Dummy or real
            lblCategoriesCount.Text = "9";
            lblBooksCount.Text = "19"; 
            lblBorrowsCount.Text = ReportService.GetOverdueCount().ToString();
        }

        private void SetupCharts()
        {
            // Doughnut Chart Setup
            chartPie.Series.Clear();
            var series1 = new Series("Türler");
            series1.ChartType = SeriesChartType.Doughnut;
            series1.Points.AddXY("Roman", 30);
            series1.Points.AddXY("Bilim", 20);
            series1.Points.AddXY("Tarih", 15);
            series1.Points.AddXY("Çocuk", 10);
            series1.Points.AddXY("Sanat", 25);
            
            // Apply vibrant colors
            series1.Points[0].Color = Color.FromArgb(74, 58, 255); // Vibrant blue
            series1.Points[1].Color = Color.FromArgb(255, 99, 132); // Pink/Red
            series1.Points[2].Color = Color.FromArgb(255, 205, 86); // Yellow
            series1.Points[3].Color = Color.FromArgb(75, 192, 192); // Teal
            series1.Points[4].Color = Color.FromArgb(153, 102, 255); // Purple
            
            chartPie.Series.Add(series1);
            chartPie.Legends[0].Docking = Docking.Right;

            // Line Chart Setup
            chartLine.Series.Clear();
            var series2 = new Series("Ödünç Alma Trendi");
            series2.ChartType = SeriesChartType.Spline; // Smooth curve
            series2.BorderWidth = 3;
            series2.Color = Color.FromArgb(0, 184, 212); // Lively cyan
            series2.MarkerStyle = MarkerStyle.Circle;
            series2.MarkerSize = 8;
            
            series2.Points.AddXY("Eyl", 10);
            series2.Points.AddXY("Eki", 5);
            series2.Points.AddXY("Kas", 2);
            series2.Points.AddXY("Ara", 6);
            series2.Points.AddXY("Oca", 14);
            
            chartLine.Series.Add(series2);
            chartLine.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartLine.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        private void pnlBanner_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = pnlBanner.ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            // Vibrant Mor-Mavi gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(156, 39, 176), Color.FromArgb(74, 58, 255), LinearGradientMode.ForwardDiagonal))
            {
                // To achieve smooth edges, although full rectangle
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Draw rounded rectangle background
                int radius = 20;
                GraphicsPath path = CustomPaths.GetRoundedRect(rect, radius);
                e.Graphics.FillPath(brush, path);
            }

            // Draw text over banner to avoid transparency glitches
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            using (Font titleFont = new Font("Segoe UI", 24, FontStyle.Bold))
            using (Font subFont = new Font("Segoe UI", 12, FontStyle.Regular))
            {
                e.Graphics.DrawString("Hoşgeldin, Kitap Sever! 👋", titleFont, Brushes.White, new PointF(30, 25));
                e.Graphics.DrawString("Binlerce kitabı keşfetmek ve ödünç almak için sistemde gezinebilirsin.", subFont, Brushes.White, new PointF(35, 75));
            }
        }

        // Panel custom paint for rounded rect cards
        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            GraphicsPath path = CustomPaths.GetRoundedRect(p.ClientRectangle, 15);
            
            // Draw background
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(Brushes.White, path);

            // Draw subtle border
            using (Pen borderPen = new Pen(Color.FromArgb(236, 240, 241), 1f))
            {
                e.Graphics.DrawPath(borderPen, path);
            }
        }
    }

    public static class CustomPaths
    {
        public static GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
