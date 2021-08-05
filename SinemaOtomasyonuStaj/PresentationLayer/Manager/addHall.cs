using SinemaOtomasyonuStaj.EntityLayer;
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
    public partial class addHall : Form
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
        public addHall()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            ManagerMainPanel panel = new ManagerMainPanel();
            panel.Show();
            this.Close();

        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
          if(manager.addHall(hallNameTxtbox.Text, Int32.Parse(hallseat.selectedValue)))
            {
                MessageBox.Show("Yeni Salon Eklendi");
     
                ManagerMainPanel panel = new ManagerMainPanel();
                panel.Show();
                this.Close();

            }

            else MessageBox.Show("Salon eklenirken hata oluştu");
        }

        private void addHall_Load(object sender, EventArgs e)
        {

        }
    }
}
