import os
import re

forms = ['StudentDashboard', 'AdminDashboard', 'StaffDashboard']
base_dir = r'c:\Users\ismai\Downloads\Grup_7_kaynakKodlar\Grup_7_kaynakKodlar\Gorsel-Programlama-KYS-Projesi\LibraryManagementSystem\Forms'

for form in forms:
    # Update Designer.cs
    designer_path = os.path.join(base_dir, f'{form}.Designer.cs')
    with open(designer_path, 'r', encoding='utf-8') as f:
        content = f.read()

    # Find btnLogout declaration
    content = re.sub(
        r'(private System\.Windows\.Forms\.Button btnLogout;)',
        r'\1\n        private System.Windows.Forms.Button btnChangePassword;',
        content
    )

    # Find btnLogout instantiation
    content = re.sub(
        r'(this\.btnLogout = new System\.Windows\.Forms\.Button\(\);)',
        r'\1\n            this.btnChangePassword = new System.Windows.Forms.Button();',
        content
    )

    # Find target panel additions
    content = re.sub(
        r'(this\.panelMain\.Controls\.Add\(this\.btnLogout\);)',
        r'this.panelMain.Controls.Add(this.btnChangePassword);\n            \1',
        content
    )

    # Find btnLogout properties to extract location X and Y
    match = re.search(r'this\.btnLogout\.Location = new System\.Drawing\.Point\((\d+),\s*(\d+)\);', content)
    if match:
        old_x = int(match.group(1))
        old_y = int(match.group(2))
        new_x = old_x - 160
        new_y = old_y

        btn_props = f"""// 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point({new_x}, {new_y});
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(150, 40);
            this.btnChangePassword.TabIndex = 10;
            this.btnChangePassword.Text = "Şifre Değiştir";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            """

        content = re.sub(
            rf'(// \s*\n\s*// {form}\s*\n\s*// )',
            btn_props + r'\1',
            content
        )

    with open(designer_path, 'w', encoding='utf-8') as f:
        f.write(content)

    # Update .cs
    cs_path = os.path.join(base_dir, f'{form}.cs')
    with open(cs_path, 'r', encoding='utf-8') as f:
        cs_content = f.read()

    click_handler = """private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm();
            form.ShowDialog();
        }

        """

    cs_content = re.sub(
        r'(private void btnLogout_Click\(object sender, EventArgs e\))',
        click_handler + r'\1',
        cs_content
    )

    with open(cs_path, 'w', encoding='utf-8') as f:
        f.write(cs_content)

print("Injected buttons successfully!")
