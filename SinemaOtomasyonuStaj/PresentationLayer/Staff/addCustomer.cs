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

namespace SinemaOtomasyonuStaj.PresentationLayer.Staff
{
    public partial class addCustomer : Form
    {
        int usertype = 0;//-1 null 0 standart 1 ogrenci
        int gender = 0;
        EntityLayer.Staff staff = new EntityLayer.Staff();

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
        public addCustomer()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            StaffMainPanel mp = new StaffMainPanel();
            mp.Show();
            this.Close();
            
        }

        private void addCustomer_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked == false)
                usertype = 0;
            else
                usertype = 1;
        }

        private void genderDropdown_onItemSelected(object sender, EventArgs e)
        {
            if (genderDropdown.selectedIndex == 0)
                gender = 0;
            else
                gender = 1;
      
        }

        private void addstaff_Click(object sender, EventArgs e)
        {
        if(staff.addCustomer(nametextbox.Text + " " + surnametxtbox.Text, gender, usertype))
            {

                MessageBox.Show("Yeni Üye Eklendi!");
                StaffMainPanel staffMainPanel = new StaffMainPanel();
                staffMainPanel.Show();
                this.Close();

            }
            else MessageBox.Show("Kullanıcı eklerken hata oluştu");
        }
    }
}
