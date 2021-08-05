using SinemaOtomasyonuStaj.Views;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SinemaOtomasyonuStaj.PresentationLayer.Manager
{
    public partial class editStaff : Form
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
        EntityLayer.Manager manager = new EntityLayer.Manager();
        string managerid = Login.uid;
        string selectedstaff;


        public editStaff()
        {
            InitializeComponent();
        }

        private void editStaff_Load(object sender, EventArgs e)
        {
            dgv.DataSource = manager.getPersonelTable().Tables[0].DefaultView;


        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            ManagerMainPanel panel = new ManagerMainPanel();
            panel.Show();
            this.Close();
        }

        private void usernametxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            usernametxtbox.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            pwtextbox.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            nametextbox.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            surnametxtbox.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            selectedstaff = dgv.CurrentRow.Cells[0].Value.ToString();
        }

        private void addstaff_Click(object sender, EventArgs e)
        {
            if (manager.addStaff(usernametxtbox.Text, pwtextbox.Text, nametextbox.Text, surnametxtbox.Text, managerid))
            {
                MessageBox.Show("Yeni Personel Ekleme İşlemi Gerçekleştirildi");
                editStaff staff = new editStaff();
                staff.Show();
                this.Close();

            }
            else MessageBox.Show("Personel Eklenemedi");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (manager.updatetaff(usernametxtbox.Text, pwtextbox.Text, nametextbox.Text, surnametxtbox.Text, selectedstaff))
            {
                MessageBox.Show("Personel Düzenlendi!");
                editStaff staff = new editStaff();
                staff.Show();
                this.Close();

            }
            else MessageBox.Show("Personel Düzenlenemedi");
        }

        private void userSwitch_SwitchStateChanged(object sender, EventArgs e)
        {

        }

        private void dgv_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            if (manager.deleteStaff(selectedstaff))
            {
                MessageBox.Show("Personel Başariyle Silindi");
                editStaff staff = new editStaff();
                staff.Show();
                this.Close();
            }
              
            else MessageBox.Show("Personel Silme Başarısız!");
        }
    }
}
