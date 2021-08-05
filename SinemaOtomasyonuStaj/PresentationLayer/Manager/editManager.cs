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

namespace SinemaOtomasyonuStaj.PresentationLayer.Manager
{
    public partial class editManager : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        string selectedmanager;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        EntityLayer.Manager manager = new EntityLayer.Manager();

        private void Login_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public editManager()
        {
            InitializeComponent();
            dgv.DataSource = manager.getManagerTable().Tables[0].DefaultView;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            ManagerMainPanel managerMainPanel = new ManagerMainPanel();
            managerMainPanel.Show();
            this.Close();

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            usernametxtbox.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            pwtextbox.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            nametextbox.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            surnametxtbox.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            selectedmanager = dgv.CurrentRow.Cells[0].Value.ToString();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (manager.updateManager(usernametxtbox.Text, pwtextbox.Text, nametextbox.Text, surnametxtbox.Text, selectedmanager))
            {
                MessageBox.Show("Yönetici Düzenlendi!");
                editManager editManager = new editManager();
                editManager.Show();
                this.Close();

            }
            else MessageBox.Show("Yönetici Düzenlenemedi");
        }

        private void addmanager_Click(object sender, EventArgs e)
        {
            if (manager.addManager(usernametxtbox.Text, pwtextbox.Text, nametextbox.Text, surnametxtbox.Text))
            {
                MessageBox.Show("Yeni Yönetici Ekleme İşlemi Gerçekleştirildi");
                editManager editManager = new editManager();
                editManager.Show();
                this.Close();

            }
            else MessageBox.Show("Yönetici Eklenemedi");
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            if (manager.deleteManager(selectedmanager))
            {
                MessageBox.Show("Yönetici Başariyle Silindi");
                editManager editManager = new editManager();
                editManager.Show();
                this.Close();

            }
               
            else MessageBox.Show("Yönetici Silme Başarısız!");
        }

        private void editManager_Load(object sender, EventArgs e)
        {

        }
    }
}
