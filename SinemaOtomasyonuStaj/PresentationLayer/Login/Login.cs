using SinemaOtomasyonuStaj.EntityLayer;
using SinemaOtomasyonuStaj.PresentationLayer;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SinemaOtomasyonuStaj.Views
{

    public partial class Login : Form
    {
       public static string uid = "";
        private string pw = "";
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        static Manager manager = new Manager();
        Staff Staff = new Staff();

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Login_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public Login()
        {
            InitializeComponent();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Button_Click(object sender, EventArgs e)
        {
            uid = userid_txtBox.Text;
            pw = pw_TxtBox.Text;
            if(manager_radio.Checked==true)
            {
               if(manager.managerLogin(uid, pw))
                {
                    MessageBox.Show("YONETICI GİRİŞİ BAŞARILI!");
                    ManagerMainPanel mainPanel = new ManagerMainPanel();
                    mainPanel.Show();
                    this.WindowState= FormWindowState.Minimized;


                }
               else MessageBox.Show("YONETICI GİRİŞİ BAŞARISIZ!");

            }
            else if(staff_radio.Checked == true)
            {
                if (Staff.staffLogin(uid, pw))
                {
                    MessageBox.Show("PERSONEL GİRİŞİ BAŞARILI!");
                    StaffMainPanel staffMain = new StaffMainPanel();
                    staffMain.Show();
                    this.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    MessageBox.Show("PERSONEL GİRİŞİ BAŞARISIZ!");
                   
                }

            }
            else MessageBox.Show("Kullanıcı türü seçilmelidir.");

        }



        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }
    }
}
