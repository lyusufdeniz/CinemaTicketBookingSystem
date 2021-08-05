using SinemaOtomasyonuStaj.PresentationLayer.Staff;
using SinemaOtomasyonuStaj.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaOtomasyonuStaj.PresentationLayer
{
    public partial class StaffMainPanel : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
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
        public StaffMainPanel()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {

        }

        private void StaffMainPanel_Load(object sender, EventArgs e)
        {

            systemClockLabel.Text = DateTime.Now.ToString("dd:MM:yyyy HH:mm");
            kullanıcıhead.Text = Login.uid + " adli kullanıcının kontrol paneli";
            osLabel.Text = Environment.OSVersion.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            systemClockLabel.Text = DateTime.Now.ToString("dd:MM:yyyy HH:mm");
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            addCustomer addCustomer = new addCustomer();
            addCustomer.Show();
            this.Close();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            customerList cl = new customerList();
            cl.Show();
            this.Close();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            sellTicket sell = new sellTicket();
            sell.Show();
            this.Close();       
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            ticketControl ticket = new ticketControl();
            ticket.Show();
            this.Close();
        }
    }
}
