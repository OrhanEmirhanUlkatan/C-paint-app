using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cakmaPaint
{
    public partial class Form1 : Form
    { //Uygulamada ne kadar değişken kullanacağımıza karar verip bir kısmını burada tanımlıyoruz.
        bool isMouseDown = false;
        int basX;
        int basY;
        Color renk = Color.Black;
        Color arkaPlanRenk = Color.White;
        Graphics g;
        Pen kalem;
        Pen silgi;
        int kalinlik;

        public Form1()
        {//derlenen derlemede bulunur ve XAML ayrıştırma zamanında XAML kullanıcı arabirimi içeriğini yüklemek için WPF uygulama modelinde bir rol oynar.
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {//Başlangıçta tanımladığım değişkenlerin bazılarına gerekli olan atamaları yapıyoruz.
            g = panel1.CreateGraphics();
            kalinlik = int.Parse(toolStripComboBox2.Text);
            kalem = new Pen(renk, kalinlik);
            silgi = new Pen(arkaPlanRenk, kalinlik);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {//Fareye basılı tutup bıraktığımız zaman ölçülü (X ve Y eksenine göre) şekilde dikdörtgen çizmemizi sağlayan kodları yazıyoruz..
            isMouseDown = true;
            basX = e.X;
            basY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                if (toolStripComboBox1.SelectedIndex == 0)
                {//Kalemle noktalar halinde işaretleme yapamaya yarayan komutlar.
                    Point nokta1 = new Point(basX, basY);
                    Point nokta2 = new Point(e.X, e.Y);
                    g.DrawLine(kalem, nokta1, nokta2);
                    basX = e.X;
                    basY = e.Y;
                }
                if (toolStripComboBox1.SelectedIndex == 5)
                {//Fareyi kullanrak silgi aracını kullanmamızı ve silme işlemini yapmamızı sağlar.
                    Point nokta1 = new Point(basX, basY);
                    Point nokta2 = new Point(e.X, e.Y);
                    g.DrawLine(silgi, nokta1, nokta2);
                    basX = e.X;
                    basY = e.Y;
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                if (toolStripComboBox1.SelectedIndex == 1)
                {//Tanımladığımız şartlar altında fareye basılı tutup uzattığımız boyuta göre(ölçülü) dikdörtgen çizmemizi sağlar.
                    Point nokta1 = new Point(basX, basY);
                    Point nokta2 = new Point(e.X, e.Y);
                    if (nokta2.X < basX)
                    {
                        int deger = nokta2.X;
                        nokta2.X = basX;
                        basX = deger;
                    }
                    if (nokta2.Y < basY)
                    {
                        int deger = nokta2.Y;
                        nokta2.Y = basY;
                        basY = deger;
                    }
                    int genislik = nokta2.X - basX;
                    int yukseklik = nokta2.Y - basY;
                    g.DrawRectangle(kalem, basX, basY, genislik, yukseklik);
                }
                if (toolStripComboBox1.SelectedIndex == 2)
                {//Çizdiğimiz dikdörtgenin içini ölçülü (X ve Y eksenine göre)  boyammamıza yararayan aracın komutlarını atıyoruz.
                    Point nokta1 = new Point(basX, basY);
                    Point nokta2 = new Point(e.X, e.Y);
                    if (nokta2.X < basX)
                    {
                        int deger = nokta2.X;
                        nokta2.X = basX;
                        basX = deger;
                    }
                    if (nokta2.Y < basY)
                    {
                        int deger = nokta2.Y;
                        nokta2.Y = basY;
                        basY = deger;
                    }
                    int genislik = nokta2.X - basX;
                    int yukseklik = nokta2.Y - basY;
                    SolidBrush firca = new SolidBrush(renk);
                    g.FillRectangle(firca, new Rectangle(basX, basY, genislik, yukseklik));
                }
                if (toolStripComboBox1.SelectedIndex == 3)
                {//Tanımladığımız şartlar altında fareye basılı tutup uzattığımız boyuta göre ölçülü (X ve Y eksenine göre) Elip çizmemizi sağlar.
                    Point nokta1 = new Point(basX, basY);
                    Point nokta2 = new Point(e.X, e.Y);
                    if (nokta2.X < basX)
                    {
                        int deger = nokta2.X;
                        nokta2.X = basX;
                        basX = deger;
                    }
                    if (nokta2.Y < basY)
                    {
                        int deger = nokta2.Y;
                        nokta2.Y = basY;
                        basY = deger;
                    }
                    int genislik = nokta2.X - basX;
                    int yukseklik = nokta2.Y - basY;
                    g.DrawEllipse(kalem, new Rectangle(basX, basY, genislik, yukseklik));
                }
                if (toolStripComboBox1.SelectedIndex == 4)
                {//Çizdiğimiz Elipsin içini boyammamıza yararayan aracın komutlarını atıyoruz.
                    Point nokta1 = new Point(basX, basY);
                    Point nokta2 = new Point(e.X, e.Y);
                    if (nokta2.X < basX)
                    {
                        int deger = nokta2.X;
                        nokta2.X = basX;
                        basX = deger;
                    }
                    if (nokta2.Y < basY)
                    {
                        int deger = nokta2.Y;
                        nokta2.Y = basY;
                        basY = deger;
                    }
                    int genislik = nokta2.X - basX;
                    int yukseklik = nokta2.Y - basY;
                    SolidBrush firca = new SolidBrush(renk);
                    g.FillEllipse(firca, new Rectangle(basX, basY, genislik, yukseklik));
                }
            }
            isMouseDown = false;
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {//Değişkenlere değer atamalarını yapıyoruz.
            kalinlik = int.Parse(toolStripComboBox2.Text);
            silgi.Width = kalinlik;
            kalem.Width = kalinlik;
        }

        public bool BoyutDegistir(int x, int y)
        {//Seçtiğimiz form(panel) ekranının boyutunu ayarlamak için bellirli aralıklarda değer girip şekillendirmemizi sağlıyor.
            bool isDone = false;

            if (x < 8 || y < 8)
            {//Çok küçük değer girildiğinde program çalışırken kötü çözükmemesi için boyutu sınırlandırıyoruz ve eğer çok küçük değer girilirse ekrana mesaj gönderiyoruz kullanıcının görebilmesi için.
                MessageBox.Show("Çok küçük değer girdiniz. Değerleriniz 8 veya daha fazlası olmalıdır.", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (x <= 550)
            {
                panel1.Width = x;
                this.Width = 590;
                isDone = true;
            }
            else if (x > 1880)
            {//Çok büyük değer girildiğinde program çalışırken kötü çözükmemesi için boyutu sınırlandırıyoruz ve eğer çok büyük değer girilirse ekrana mesaj gönderiyoruz kullanıcının görebilmesi için.
                MessageBox.Show("Çok büyük değer girdiniz. Değerleriniz 1880 veya daha düşüğü olmalıdır.", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
            {
                panel1.Width = x;
                this.Width = x + 40;
                isDone = true;
            }
            if (y <= 100)
            {
                panel1.Height = y;
                this.Height = 203;
                isDone = true;
            }
            else if (y > 977)
            {//Çok küçük değer girildiğinde program çalışırken çöznürlük bozulmaması için 977 veya daha düşük değerlerin ideal olduğunu kullanıcıya mesaj göndererek çözüyoruz.
                MessageBox.Show("Çok büyük değer girdiniz. Değerleriniz 977 veya daha düşüğü olmalıdır.", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
            {
                panel1.Height = y;
                this.Height = y + 103;
                isDone = true;
            }
            if (isDone == true)
            {
                g = panel1.CreateGraphics();
            }
            return isDone;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {//Değişkenlere değer atamalarını yapıyoruz.
            boyutForm f = new boyutForm(this);
            f.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {//Kalemle herhangi bir çizim yaparken renk paletinden renk seçmemize olanak sağlıyor.
            ColorDialog colordialog1 = new ColorDialog();
            if (colordialog1.ShowDialog() == DialogResult.OK)
            {
                renk = colordialog1.Color;
                kalem.Color = renk;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {//Arka plan rengini değiştirebilmek için renk paletine erişip renk değiştirmemize olanak sağlıyor.
            ColorDialog colordialog1 = new ColorDialog();
            if (colordialog1.ShowDialog() == DialogResult.OK)
            {
                arkaPlanRenk = colordialog1.Color;
                panel1.BackColor = arkaPlanRenk;
                silgi.Color = arkaPlanRenk;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

