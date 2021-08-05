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
    public partial class addSession : Form
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
        public addSession()
        {
            InitializeComponent();
        }

        private void addSession_Load(object sender, EventArgs e)
        {


            for (int i=0;i<manager.getMovies().Count;i++)
            {
                movieDropDown.AddItem(manager.getMovies().ElementAt(i));

            }
            for (int i = 0; i < manager.getHalls().Count; i++)
            {
                hallsDropDown.AddItem(manager.getHalls().ElementAt(i));

            }


        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            ManagerMainPanel mp = new ManagerMainPanel();
            mp.Show();
            this.Close();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            if(movieDropDown.selectedIndex!=-1&&timeDropDown.selectedIndex!=-1&&hallsDropDown.selectedIndex!=-1)
            {
                if (manager.addSession(movieDropDown.selectedValue.ToString(), timeDropDown.selectedValue, hallsDropDown.selectedValue))
                {
                    MessageBox.Show("Seans Başarıyla Kaydedildi");
                    ManagerMainPanel mp = new ManagerMainPanel();

                    mp.Show();
                }
                else MessageBox.Show("Seans eklenirken hata oluştu");
            }
            else MessageBox.Show("Seans eklenirken hata oluştu");
        }
          
    }
}
