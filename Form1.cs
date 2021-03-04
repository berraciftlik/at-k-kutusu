using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{

    public partial class Form1 : Form
    {   //Atık sınıfından nesneleri oluşturduk.
        Atik domates = new Atik(150, Image.FromFile("domates.jpg"));
        Atik salatalık = new Atik(120, Image.FromFile("salatalık.jpg"));
        Atik dergi = new Atik(200, Image.FromFile("dergi.jpg"));
        Atik gazete = new Atik(250, Image.FromFile("gazete.jpg"));
        Atik camsise = new Atik(600, Image.FromFile("camsise.jpg"));
        Atik bardak = new Atik(250, Image.FromFile("bardak.jpg"));
        Atik salca = new Atik(550, Image.FromFile("salça.jpg"));
        Atik kola = new Atik(350, Image.FromFile("kola.jpg"));
        //Atık kutuları sınıfından nesneleri ürettik.
        AtikKutulari organikKutusu = new AtikKutulari(0, 700, 525, 0);
        AtikKutulari camKutusu = new AtikKutulari(600, 2200, 1650, 0);
        AtikKutulari metalKutusu = new AtikKutulari(800, 2300, 1725, 0);
        AtikKutulari kagitKutusu = new AtikKutulari(1000, 1200, 900, 0);

        public Form1()
        {
            InitializeComponent();

        }
        int rastgele = 0;//rastgele sayı atanacak olan bir değişken oluşturduk.
        int labeldegeri;//Puan yazdırılacak olan label değişkeni
        public void buttonkontrol()//Butonların gelen resimlere göre kontrolü
        {
            if (pictureBox1.Image == salatalık.Image || pictureBox1.Image == domates.Image)//Resim salatalık veya domates olursa sadece buton2 çalışacak.
            {
                button2.Enabled = true;
                button4.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
            }
            if (pictureBox1.Image == dergi.Image || pictureBox1.Image == gazete.Image)//Resim dergi veya gazete olursa sadece buton4 çalışacak.
            {
                button4.Enabled = true;
                button2.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;

            }
            if (pictureBox1.Image == bardak.Image || pictureBox1.Image == camsise.Image)//Resim bardak veya cam şişe olursa sadece buton6 çalışacak.
            {
                button2.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = true;
                button7.Enabled = false;
            }
            if (pictureBox1.Image == kola.Image || pictureBox1.Image == salca.Image)//Resi kola veya salça ise sadece buton7 çalışacak.
            {
                button2.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        { //Yeni oyun butonuna tıklanığında 
            label3.Text = labeldegeri.ToString();//Puan kısmı 0
            sayi = 60;//Süre 60an başlıyor
            timer1.Interval = 1000;
            timer1.Enabled = true;
            button2.Enabled = true;//Butonlar aktif
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            progressBar1.Value = 0;//Progressbarlar 0 
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            listBox1.Items.Clear();//Listboxlar boş
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            Random rnd = new Random();//Rastgele resim atanyor.
            Image[] ımages = { domates.Image, salatalık.Image, bardak.Image, camsise.Image, salca.Image, kola.Image, dergi.Image, gazete.Image };//Resimler dizisi oluşturuyoruz.
            rastgele = rnd.Next(0, ımages.Length);
            pictureBox1.Image = ımages[rastgele];
            buttonkontrol();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = organikKutusu.Kapasite;//Progressbar kapasitesi 700
            progressBar1.Minimum = 0;
          
            Image[] ımages = { domates.Image, salatalık.Image, bardak.Image, camsise.Image, salca.Image, kola.Image, dergi.Image, gazete.Image };//Resimler dizisi
         
            if (ımages[rastgele] == domates.Image)
            {
                progressBar1.Step = domates.Hacim;//Progressbar değerini domates hacmi kadar arttır.
                progressBar1.PerformStep();
                listBox1.Items.Add("Domates (150)");//Listboxa domatesi ekle.
                label3.Text = labeldegeri.ToString();//Label1in içindeki değeri başta tanımladığımız label1değerine eşitledik.
                labeldegeri = labeldegeri + domates.Hacim;//Label1 değerine puan olarak domatesin hacmini ekledik.
                label3.Text = labeldegeri.ToString();
            }
            if (ımages[rastgele] == salatalık.Image)
            {
                progressBar1.Step = salatalık.Hacim;
                progressBar1.PerformStep();
                listBox1.Items.Add("Salatalık (120)");
                label3.Text = labeldegeri.ToString();//Label1in içindeki değeri başta tanımladığımız label1değerine eşitledik.
                labeldegeri = labeldegeri + salatalık.Hacim;//Label1 değerine puan olarak salatalığın hacmini ekledik.
                label3.Text = labeldegeri.ToString();//Label1değerindeki değeri label1e atadık.
            }
           
            Random rnd = new Random();
            rastgele = rnd.Next(0, ımages.Length);// Rastgele resim atama kısmı
            pictureBox1.Image = ımages[rastgele];
            buttonkontrol();

        }

             private void button4_Click(object sender, EventArgs e)
          {

            Image[] ımages = { domates.Image, salatalık.Image, bardak.Image, camsise.Image, salca.Image, kola.Image, dergi.Image, gazete.Image };


            progressBar2.Maximum = kagitKutusu.Kapasite;//Progressbar maximum değeri
            progressBar2.Minimum = 0;
            if (ımages[rastgele] == gazete.Image)//Gelen resim gazeteyse adını ve hacmini yazdırıyoruz.
            {
                label3.Text = labeldegeri.ToString();
                labeldegeri = labeldegeri + gazete.Hacim;
                label3.Text = labeldegeri.ToString();
                progressBar2.Step = gazete.Hacim;
                progressBar2.PerformStep();
                listBox2.Items.Add("Gazete (250)");
            }
            if (ımages[rastgele] == dergi.Image)//gelen resim dergiyse ad ve hacmini yazdırıyoruz.
            {
                label3.Text = labeldegeri.ToString();
                labeldegeri = labeldegeri + domates.Hacim;
                label3.Text = labeldegeri.ToString();
                progressBar2.Step = dergi.Hacim;
                progressBar2.PerformStep();
                listBox2.Items.Add("Dergi (200)");
            }
            
            Random rnd = new Random();
            rastgele = rnd.Next(0, ımages.Length); //Yeni bir resim atanmasını sağlıyoruz.
            pictureBox1.Image = ımages[rastgele];
            buttonkontrol();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            progressBar3.Maximum = camKutusu.Kapasite;
            progressBar3.Minimum = 0;
            Image[] ımages = { domates.Image, salatalık.Image, bardak.Image, camsise.Image, salca.Image, kola.Image, dergi.Image, gazete.Image };

            if (ımages[rastgele] == bardak.Image)//Gelen resim bardaksa 
            {
                label3.Text = labeldegeri.ToString();
                labeldegeri = labeldegeri + bardak.Hacim;
                label3.Text = labeldegeri.ToString();
                progressBar3.Step = bardak.Hacim;
                progressBar3.PerformStep();
                listBox3.Items.Add("Bardak (250)");//Ad ve hacmi listboxa yazdırma

            }
            if (ımages[rastgele] == camsise.Image)
            {
                label3.Text = labeldegeri.ToString();
                labeldegeri = labeldegeri + bardak.Hacim;
                label3.Text = labeldegeri.ToString();
                progressBar3.Step = camsise.Hacim;
                progressBar3.PerformStep();
                listBox3.Items.Add("Cam Şişe (600)");

            }
            
            Random rnd = new Random();
            rastgele = rnd.Next(0, ımages.Length);
            pictureBox1.Image = ımages[rastgele];
            buttonkontrol();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            progressBar4.Maximum = metalKutusu.Kapasite;
            progressBar4.Minimum = 0;

            Image[] ımages = { domates.Image, salatalık.Image, bardak.Image, camsise.Image, salca.Image, kola.Image, dergi.Image, gazete.Image };
                        
            if (ımages[rastgele] == salca.Image)
            {
                label3.Text = labeldegeri.ToString();
                labeldegeri = labeldegeri + salca.Hacim;
                label3.Text = labeldegeri.ToString();
                progressBar4.Step = salca.Hacim;
                progressBar4.PerformStep();
                listBox4.Items.Add("Salça Kutusu (550)");

            }
            if (ımages[rastgele] == kola.Image)
            {
                label3.Text = labeldegeri.ToString();
                labeldegeri = labeldegeri + kola.Hacim;
                label3.Text = labeldegeri.ToString();
                progressBar4.Step = kola.Hacim;
                progressBar4.PerformStep();
                listBox4.Items.Add("Kola Kutusu (350)");
            }

            Random rnd = new Random();
            rastgele = rnd.Next(0, ımages.Length);
            pictureBox1.Image = ımages[rastgele];
            buttonkontrol();// Buton kontrolü

        }
        int sayi = 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayi >= 0)//Timer ayarları
            {
                timer1.Interval = 1000;
                timer1.Enabled = true;
                int sayac = sayi--;
                label1.Text = sayac.ToString();
            }
            else
            {//Süre bittiğinde butonları pasif hale getiriyoruz.
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (progressBar1.Value >= organikKutusu.DoluHacim)//Progressbar değeri kapasitenin %75ine eşit veya büyükse
            {
                button3.Enabled = true;//Boşalt butonu aktif.
                progressBar1.Value = 0;//Progressbarı boşalt.
                listBox1.Items.Clear();//Listboxi temizle.
                sayi = sayi + 3;//Süreyi 3 arttır.
            }
            else
            button3.Enabled = false;
                    
        }
        private void button5_Click(object sender, EventArgs e)
        {
           
            if (progressBar2.Value >= kagitKutusu.DoluHacim)//progressbar doluluğu kapasitenin %75ine eşit ya da büyükse
            {
                
                button5.Enabled = true;//Boşaltma butonu aktifleşiyor
                progressBar2.Value = 0;//Progressbar boşaltılıyor
                listBox2.Items.Clear();//Listbox temizleniyor.
                sayi = sayi + 3;//Kutu boşaltıldığında saniye 3 artacak.
                labeldegeri = labeldegeri + kagitKutusu.BosaltmaPuani;//Kağıt kutusu boşaltıldığında 1000 puan ekleniyor.
                label3.Text = labeldegeri.ToString();

            }
            else
                button5.Enabled = false;//Kapasitenin %75i dolu değilse buton aktif olmayacak.
        
        }
        private void button8_Click(object sender, EventArgs e)
        {
                 
            if (progressBar3.Value >= camKutusu.DoluHacim)
            {
                button8.Enabled = true;
                progressBar3.Value = 0;
                listBox3.Items.Clear();
                sayi = sayi + 3;
                labeldegeri = labeldegeri + camKutusu.BosaltmaPuani;//Cam kutusu boşaltıldığında 600 puan eklenecek.
                label3.Text = labeldegeri.ToString();
            }
            else
                button8.Enabled = false;
          

        }
        private void button9_Click(object sender, EventArgs e)
        {
             if (progressBar4.Value >= metalKutusu.DoluHacim)
            {//Kapasitenin en az %75i doluysa kutunun boşaltılmasını ve puan eklenmesini sağlıyoruz.
                button9.Enabled = true;
                progressBar4.Value = 0;
                listBox4.Items.Clear();
                sayi = sayi + 3;
                labeldegeri = labeldegeri + metalKutusu.BosaltmaPuani;//Metal kutusu boşaltıldığında 600 puan eklenecek.
                label3.Text = labeldegeri.ToString();
            }
            else
                button9.Enabled = false;
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Oyun başlamadan önce butonlar pasif halde.
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

        }
        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();//Çıkış butonuna basıldığında program kapanıyor.
            Application.Exit();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void progressBar2_Click(object sender, EventArgs e)
        {
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {
        }
        //İnterface Kısımları

        public interface IAtik
        {
            int Hacim { get; }
            System.Drawing.Image Image { get; }
        }
        class Atik : IAtik
        {
            private int hacim_;
            public int Hacim
            {
                get { return hacim_; }
            }

            private Image resim;
            public Image Image
            {
                get { return resim; }
            }

            public Atik(int hacim, Image ımage)
            {
                hacim_ = hacim;
                resim = ımage;
            }
        }
        public interface IDolabilen
        {
            int Kapasite { get; set; }
            int DoluHacim { get; }
            int DolulukOrani { get; }
        }
        public interface IAtikKutusu : IDolabilen
        {
            int BosaltmaPuani { get; }
            bool Ekle();
            bool Bosalt();
        }
        class AtikKutulari : IAtikKutusu
        {
            int bosaltmaPuani_;
            public int BosaltmaPuani
            {
                get { return bosaltmaPuani_; }
            }

            int kapasite_;
            public int Kapasite
            {
                get { return kapasite_; }
                set { kapasite_ = value; }
            }

            int doluHacim_;
            public int DoluHacim
            {
                get { return doluHacim_; }
            }

            int dolulukOrani_;
            public int DolulukOrani
            {
                get { return dolulukOrani_; }
                set { dolulukOrani_ = value; }
            }
            public AtikKutulari(int bosaltmaPuani, int kapasite, int doluHacim, int dolulukOrani)
            {
                bosaltmaPuani_ = bosaltmaPuani;
                kapasite_ = kapasite;
                doluHacim_ = doluHacim;
                dolulukOrani_ = dolulukOrani;
            }

            public bool Bosalt()
            {
                throw new NotImplementedException();
            }

            public bool Ekle()
            {
                throw new NotImplementedException();
            }
        }
    }
      
 

}
    



