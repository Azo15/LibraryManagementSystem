using System;
using System.Windows.Forms;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class UpdateStatusForm : Form
    {
        private int requestId;
        private BorrowStatus currentStatus;

        public UpdateStatusForm(int requestId, BorrowStatus currentStatus)
        {
            InitializeComponent();
            this.requestId = requestId;
            this.currentStatus = currentStatus;
            LoadStatuses();
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();
            
            // Add available status transitions based on current status
            switch (currentStatus)
            {
                case BorrowStatus.Beklemede:
                    cmbStatus.Items.Add("Onaylandı");
                    cmbStatus.Items.Add("Reddedildi");
                    break;
                case BorrowStatus.Onaylandı:
                    cmbStatus.Items.Add("Teslim Edildi");
                    break;
                case BorrowStatus.TeslimEdildi:
                    cmbStatus.Items.Add("İade Edildi");
                    break;
                case BorrowStatus.İadeEdildi:
                    cmbStatus.Items.Add("İade Edildi (Zaten)");
                    break;
                case BorrowStatus.Gecikmiş:
                    cmbStatus.Items.Add("İade Edildi");
                    break;
            }

            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem == null)
            {
                Validators.InputValidator.ShowError("Lütfen bir durum seçin.");
                return;
            }

            string selectedStatus = cmbStatus.SelectedItem.ToString();
            BorrowStatus newStatus = currentStatus;

            // Map text to enum
            switch (selectedStatus)
            {
                case "Onaylandı":
                    newStatus = BorrowStatus.Onaylandı;
                    break;
                case "Teslim Edildi":
                    newStatus = BorrowStatus.TeslimEdildi;
                    break;
                case "Reddedildi":
                    newStatus = BorrowStatus.Reddedildi;
                    break;
                case "İade Edildi":
                case "İade Edildi (Zaten)":
                    newStatus = BorrowStatus.İadeEdildi;
                    break;
            }

            string notes = txtNotes.Text.Trim();
            BorrowService.UpdateBorrowStatus(requestId, newStatus, notes);
            Validators.InputValidator.ShowSuccess("Durum başarıyla güncellendi.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

