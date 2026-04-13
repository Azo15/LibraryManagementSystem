using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

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
        
        // TopNav Colors
        private static readonly Color TopNavBackColor = Color.White;
        private static readonly Color TopNavHoverColor = Color.FromArgb(245, 246, 250);
        private static readonly Color NavTextColor = Color.FromArgb(99, 110, 114);
        private static readonly Color NavActiveTextColor = Color.FromArgb(74, 58, 255); // BOOKA Blue

        private static readonly Font BaseFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(162)));
        private static readonly Font TitleFont = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));

        // To keep track of the currently active sidebar button per form
        private static Dictionary<Form, Button> ActiveSidebarButtons = new Dictionary<Form, Button>();

        public static void ApplyTheme(Form form)
        {
            if (form == null) return;

            form.BackColor = FormBackColor;
            form.ForeColor = PrimaryTextColor;
            
            ApplyRecursively(form.Controls, form);
        }

        private static void ApplyRecursively(Control.ControlCollection controls, Form parentForm)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl.Font.Name != "Segoe UI")
                {
                    ctrl.Font = new Font("Segoe UI", ctrl.Font.Size, ctrl.Font.Style, ctrl.Font.Unit);
                }

                if (ctrl is Panel pnl && pnl.Name == "panelTopNav")
                {
                    SetupTopNav(pnl, parentForm);
                }
                else if (ctrl is Button btn)
                {
                    // Don't override topnav buttons if already processed
                    if (btn.Parent != null && btn.Parent.Name == "panelTopNav")
                    {
                        // handled in SetupTopNav
                    }
                    else
                    {
                        ApplyButtonTheme(btn);
                    }
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
                
                if (ctrl.HasChildren)
                {
                    ApplyRecursively(ctrl.Controls, parentForm);
                }
            }
        }

        private static void SetupTopNav(Panel navbar, Form parentForm)
        {
            foreach (Control ctrl in navbar.Controls)
            {
                if (ctrl is Button btn)
                {
                    if (btn.Name.Contains("Logout")) continue; // Custom styled in Designer

                    btn.BackColor = TopNavBackColor;
                    btn.ForeColor = NavTextColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;

                    btn.MouseEnter += (s, e) => 
                    {
                        if (!IsActiveButton(parentForm, btn)) 
                            btn.ForeColor = NavActiveTextColor; 
                    };
                    
                    btn.MouseLeave += (s, e) => 
                    {
                        if (!IsActiveButton(parentForm, btn)) 
                            btn.ForeColor = NavTextColor; 
                    };
                    
                    btn.Click += (s, e) => 
                    {
                        SetActiveButton(parentForm, btn, navbar);
                    };
                }
            }
        }

        private static bool IsActiveButton(Form form, Button btn)
        {
            if (ActiveSidebarButtons.ContainsKey(form))
            {
                return ActiveSidebarButtons[form] == btn;
            }
            return false;
        }

        private static void SetActiveButton(Form form, Button activeBtn, Panel navbar)
        {
            foreach (Control ctrl in navbar.Controls)
            {
                if (ctrl is Button btn)
                {
                    if (btn.Name.Contains("Logout")) continue;

                    if (btn == activeBtn)
                    {
                        btn.ForeColor = NavActiveTextColor;
                    }
                    else
                    {
                        btn.ForeColor = NavTextColor;
                    }
                }
            }

            if (!activeBtn.Name.Contains("Logout") && !activeBtn.Name.Contains("ChangePassword"))
            {
                ActiveSidebarButtons[form] = activeBtn;
            }
        }

        private static void ApplyButtonTheme(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            
            if (btn.BackColor == SystemColors.Control)
            {
                btn.BackColor = Color.FromArgb(52, 152, 219);
                btn.ForeColor = Color.White;
            }

            // Normal button hover
            Color originalColor = btn.BackColor;
            btn.MouseEnter += (s, e) => { btn.BackColor = ControlPaint.Dark(originalColor, 0.05f); };
            btn.MouseLeave += (s, e) => { btn.BackColor = originalColor; };
        }

        private static void ApplyDataGridViewTheme(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = GridBackColor;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(223, 228, 234);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = PrimaryTextColor;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(116, 185, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = BaseFont;
            dgv.DefaultCellStyle.Padding = new Padding(5);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBackColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = SecondaryTextColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeaderBackColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 40;

            dgv.RowTemplate.Height = 35;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeRows = false;
            
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 253);
        }
    }
}
