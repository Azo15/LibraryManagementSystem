using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem.Utils
{
    public static class ThemeManager
    {
        // Light Theme Colors
        private static readonly Color FormBackColor = Color.FromArgb(248, 249, 250); // Soft Light Gray/White
        private static readonly Color PrimaryTextColor = Color.FromArgb(45, 52, 54);
        private static readonly Color SecondaryTextColor = Color.FromArgb(99, 110, 114);
        private static readonly Color GridBackColor = Color.White;
        private static readonly Color GridHeaderBackColor = Color.FromArgb(236, 240, 241);
        private static readonly Color HoverColorMultiplier = Color.FromArgb(20, 0, 0, 0); // Used to darken buttons on hover

        private static readonly Font BaseFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(162)));
        private static readonly Font TitleFont = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));

        public static void ApplyTheme(Form form)
        {
            if (form == null) return;

            form.BackColor = FormBackColor;
            form.ForeColor = PrimaryTextColor;
            // Try to set Segoe UI globally, but respect existing sizes where possible
            
            ApplyRecursively(form.Controls);
        }

        private static void ApplyRecursively(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                // Update font family but keep size and style
                if (ctrl.Font.Name != "Segoe UI")
                {
                    ctrl.Font = new Font("Segoe UI", ctrl.Font.Size, ctrl.Font.Style, ctrl.Font.Unit);
                }

                if (ctrl is Button btn)
                {
                    ApplyButtonTheme(btn);
                }
                else if (ctrl is DataGridView dgv)
                {
                    ApplyDataGridViewTheme(dgv);
                }
                else if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.White;
                    txt.ForeColor = PrimaryTextColor;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is Label lbl)
                {
                    if (lbl.ForeColor == SystemColors.ControlText || lbl.ForeColor == Color.Black)
                    {
                        lbl.ForeColor = PrimaryTextColor;
                    }
                }
                
                // Recursively apply to children (Panels, GroupBoxes, etc)
                if (ctrl.HasChildren)
                {
                    ApplyRecursively(ctrl.Controls);
                }
            }
        }

        private static void ApplyButtonTheme(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            
            // If the button has default system control color, give it a premium blue
            if (btn.BackColor == SystemColors.Control)
            {
                btn.BackColor = Color.FromArgb(52, 152, 219);
                btn.ForeColor = Color.White;
            }

            // Hover effect event handlers
            btn.MouseEnter -= Btn_MouseEnter;
            btn.MouseLeave -= Btn_MouseLeave;
            btn.MouseEnter += Btn_MouseEnter;
            btn.MouseLeave += Btn_MouseLeave;
        }

        private static void Btn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // Darken slightly
                btn.BackColor = ControlPaint.Dark(btn.BackColor, 0.05f);
            }
        }

        private static void Btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // Lighten slightly to go back (Wait, Dark/Light isn't perfect toggle, we can store tags, but for simple effect we just Lighten back)
                btn.BackColor = ControlPaint.Light(btn.BackColor, 0.05f);
            }
        }

        private static void ApplyDataGridViewTheme(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = GridBackColor;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(223, 228, 234);

            // Default Cell Style
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = PrimaryTextColor;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(116, 185, 255); // Soft blue selection
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = BaseFont;
            dgv.DefaultCellStyle.Padding = new Padding(5);

            // Header Style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBackColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = SecondaryTextColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeaderBackColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 40;

            // Row Style
            dgv.RowTemplate.Height = 35;
            dgv.RowHeadersVisible = false; // Hide annoying left arrow empty column
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeRows = false;
            
            // Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 253);
        }
    }
}
