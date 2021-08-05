using SinemaOtomasyonuStaj.EntityLayer;
using SinemaOtomasyonuStaj.PresentationLayer.Manager;
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
    public partial class ManagerMainPanel : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        EntityLayer.Manager manager = new EntityLayer.Manager();

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
        public ManagerMainPanel()
        {
            InitializeComponent();
            kullanıcıhead.Text = Login.uid.ToString()+" " +"adlı kullanıcının kontrol paneli";
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagerMainPanel_Load(object sender, EventArgs e)
        {
            numberofManagersValue.Text = manager.countManagers().ToString();
            numberOfStaff.Text = manager.countStaff().ToString();
            ticketvalue.Text = manager.countTickets().ToString();
            customervalue.Text = manager.countCustomers().ToString();
            int erkek = manager.countGenders();
            int kadın = 100 - erkek;
            genderGraph.Percentage =erkek ;

            kadınlabel.Text = "%" + kadın + " Kadın";
            erkeklabel.Text= "%" + erkek + " Erkek";



        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            addHall add = new addHall();
            add.Show();
            this.Close();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            addMovie add= new addMovie();
            add.Show();
            this.Close();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            addSession add = new addSession();
            add.Show();
            this.Close();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            editStaff editStaff = new editStaff();
            editStaff.Show();
            this.Close();
        }

        private void kullanıcıhead_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            editManager editManager = new editManager();
            editManager.Show();
            this.Close();
        }
    }
}
