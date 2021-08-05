using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SinemaOtomasyonuStaj.PresentationLayer.Staff
{
    public partial class sellTicket : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        EntityLayer.Staff staff = new EntityLayer.Staff();

        int seatcapacity;
        int sessionID=-1;
        int selectedseat = -1;
        int customerid = -1;
        int price = -1;


        private void Login_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public sellTicket()
        {
            InitializeComponent();

        }
    
        private void sellTicket_Load(object sender, EventArgs e)
        {
            //TABLO DÜZENLEMELERİ
            dgv.DataSource = staff.getSessions().Tables[0].DefaultView;
            dgv.Columns["hallID"].Visible = false;
            dgv.Columns["hallName"].HeaderText = "Salon Adı";
            dgv.Columns["seatCapacity"].HeaderText = "Koltuk Sayısı";
            dgv.Columns["movieName"].HeaderText = "Film";
            dgv.Columns["time"].HeaderText = "Saat";
            //TABLO DÜZENLEMELERİ
            dgv.Columns["sessionID"].Visible = false;
            dgv.Columns["movieID"].Visible = false;
            dgv2.DataSource = staff.getCustomerTable().Tables[1].DefaultView;
            dgv2.Columns["customerGender"].HeaderText = "Cinsiyet";
            dgv2.Columns["customerID"].Visible = false;
            dgv2.Columns["customerType"].HeaderText = "Öğrenci";
            dgv2.Columns["customerFullName"].HeaderText = "Ad Soyad";
            dgv2.Columns["customerGender"].Width = 123;
            dgv2.Columns["customerType"].Width = 123;
            dgv2.Columns["customerFullName"].Width = 123;
 
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //SEANS KOLTUK FİLM SEÇME 
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //koltuk düzeni tasarımı
             seatcapacity = int.Parse(dgv.CurrentRow.Cells[2].Value.ToString());
             sessionID = int.Parse(dgv.CurrentRow.Cells[4].Value.ToString());
            var columnCount = 5;
            var rowCount = seatcapacity / columnCount;
            tableLayoutPanel1.Controls.Clear();
            this.tableLayoutPanel1.ColumnCount = columnCount;
            this.tableLayoutPanel1.RowCount = rowCount;
            //


            //textboxlara atama işlemleri
            //sessionID =4
            //SEATCAPACİTY=2
            salontxt.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            movietxt.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            saattxt.Text= dgv.CurrentRow.Cells[6].Value.ToString();
            //

            //farklı bir seans seçildiğinde mevcut olan düzeni sıfırlar
            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();
            //koltukları tabloya ekler
            for (int i = 1; i <= columnCount; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20));
            }
            for (int i = 1; i <= rowCount; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }
            //koltuk butonlarının tasarımı
            for (int i = 1; i <= rowCount * columnCount; i++)
            {

                var b = new Button();
                b.Text = (i + 1).ToString();
                b.Name = i.ToString();
                b.Height = 50;
                b.Width = 50;
                b.Text = i.ToString();
                b.FlatStyle = FlatStyle.Flat;
              if (staff.seatisEmpty(i,sessionID)==false)
                {
                    b.ForeColor = Color.White;
                    b.BackColor = Color.FromArgb(255, 106, 176, 76);
                    b.Enabled = true;
                }
              else if(staff.seatisEmpty(i, sessionID) ==true)
                {
                    
                    b.ForeColor = Color.White;
                    b.BackColor = Color.FromArgb(255, 235, 77, 75); ;
                    b.Enabled = false;

                    
                }
               
                b.Click += b_Click;
                b.Dock = DockStyle.Fill;
                this.tableLayoutPanel1.Controls.Add(b);
            }
        }
        //koltuk butonları click eventi
        void b_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                MessageBox.Show(b.Name+". "+"Koltuk Seçildi");
                koltuktxt.Text = b.Text.ToString();
                selectedseat=int.Parse( b.Text.ToString());
            }
              
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //ÜYE SEÇME
        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //0 user id
            // 1 customer name
            //2 gender
            //3 is student
            //fiyat ataması
            if(dgv2.CurrentRow.Cells[3].Value.ToString()=="True")
            {
                price = 15;
                priceTxt.Text = "15.00";
            }
            else
            {
                priceTxt.Text = "30.00";
                price = 30;
            }

            customerid = int.Parse(dgv2.CurrentRow.Cells[0].Value.ToString());
            adtxt.Text = dgv2.CurrentRow.Cells[1].Value.ToString();
        }

        private void sellTicketButton_Click(object sender, EventArgs e)
        {
            if (sessionID!=-1&&selectedseat!=-1&&customerid!=-1&&price!=-1)
            {
                //bilet kes
                if (staff.sellTicket(customerid, sessionID, selectedseat, price) == true)
                {
                    MessageBox.Show("Bilet Kesildi!");
                    sellTicket sellTicket = new sellTicket();
                    sellTicket.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("bilet kesilirken hata oluştu");
            }
            else
            {
                //    hata döndür
                MessageBox.Show("Bilet Kesilemedi SEANS-FİLM-KOLTUK VE ÜYE SEÇİLDİĞİNDEN EMİN OLUN!");
            }
          
        }
    }
}
