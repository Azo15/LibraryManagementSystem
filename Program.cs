using System;
using System.Windows.Forms;
using LibraryManagementSystem.Database;
using LibraryManagementSystem.Forms;

namespace LibraryManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize database
            try
            {
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı başlatılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Start with login form
            Application.Run(new LoginForm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Sistemde beklenmeyen bir hata oluştu.\nDetay: {e.Exception.Message}\nUygulama arka planda durumu kurtarmaya çalışarak devam edecek.", "Güvenlik Uyarısı (Crash Handler)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            string message = ex != null ? ex.Message : "Bilinmeyen kritik hata";
            MessageBox.Show($"Çok kritik bir hata oluştu ve uygulamanın çökmesi engellendi.\nDetay: {message}\nLütfen uygulamayı yeniden başlatın.", "Kritik Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

