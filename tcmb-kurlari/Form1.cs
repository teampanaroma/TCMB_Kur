using System;
using System.Data;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Xml;

namespace tcmb_kurlari
{
    public partial class FrmTcmbKurlari : Form
    {
        public FrmTcmbKurlari()
        {
            InitializeComponent();
        }

        // İnternet bağlantısının olup olmadığını Google'a ping atarak test et
        private static bool BaglantiVarMi()
        {
            PingReply pingCevabi = new Ping().Send("www.google.com", 1000);
            return pingCevabi != null && pingCevabi.Status == IPStatus.Success;
        }

        private Library l = new Library();
        private string tcmbWebSiteAdresi = "http://www.tcmb.gov.tr/kurlar/today.xml";
        private string anydays = "http://www.tcmb.gov.tr/kurlar/";

        private void FrmTcmbKurlari_Load(object sender, System.EventArgs e)
        {
            if (BaglantiVarMi())
                tsDurum.Text = @"İnternet bağlantınız var. TCMB'nin internet sitesine bağlanarak güncel kurları indirebilirsiniz.";
            else
                tsDurum.Text = @"Maalesef internet bağlantınız yok. TCMB'nin internet sitesine bağlanarak güncel kurları indiremezsiniz.";
        }

        private void dovizKurlariIndir_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataSet dataSet = new DataSet();

                dataSet.Clear();
                dataSet.ReadXml(tcmbWebSiteAdresi);

                dataGridGorunumu.DataSource = dataSet.Tables[1];

                // İşe yaramayan, kalabalık yapan sütun ve satırları uçur
                dataGridGorunumu.Columns["CurrencyName"].Visible = false;
                dataGridGorunumu.Columns["CurrencyCode"].Visible = false;
                dataGridGorunumu.Columns["CrossOrder"].Visible = false;
                dataGridGorunumu.Columns["CrossRateOther"].Visible = false;

                dataGridGorunumu.Rows.RemoveAt(18);
                dataGridGorunumu.RowHeadersVisible = false;

                // Sıralama işlemleri
                dataGridGorunumu.Columns[0].DisplayIndex = 0;
                dataGridGorunumu.Columns[10].DisplayIndex = 0;

                // Sütunları Türkçeleştir (Biraz sıkıcı)
                dataGridGorunumu.Columns["Unit"].HeaderText = @"Birim";
                dataGridGorunumu.Columns["Isim"].HeaderText = @"İsim";
                dataGridGorunumu.Columns["CurrencyName"].HeaderText = @"Döviz Cinsi";
                dataGridGorunumu.Columns["ForexBuying"].HeaderText = @"Döviz Alış";
                dataGridGorunumu.Columns["ForexSelling"].HeaderText = @"Döviz Satış";
                dataGridGorunumu.Columns["BanknoteBuying"].HeaderText = @"Efektif Alış";
                dataGridGorunumu.Columns["BanknoteSelling"].HeaderText = @"Efektif Satış";
                dataGridGorunumu.Columns["CrossRateUSD"].HeaderText = @"Çapraz Kur";

                // Sorunlu ve farklı hücrelerde çıkan çapraz kur değerlerini olması gereken yerlere kopyala
                dataGridGorunumu.Rows[3].Cells[7].Value = dataGridGorunumu.Rows[3].Cells[8].Value;
                dataGridGorunumu.Rows[4].Cells[7].Value = dataGridGorunumu.Rows[4].Cells[8].Value;
                dataGridGorunumu.Rows[8].Cells[7].Value = dataGridGorunumu.Rows[8].Cells[8].Value;

                // Para birimleri olan hücreleri sağa hizala
                dataGridGorunumu.Columns["ForexBuying"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridGorunumu.Columns["ForexSelling"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridGorunumu.Columns["BanknoteBuying"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridGorunumu.Columns["BanknoteSelling"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridGorunumu.Columns["CrossRateUSD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Sütunların aralıklarını şekillendir
                dataGridGorunumu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridGorunumu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Fare ile tıklandığında tüm satırı seç
                dataGridGorunumu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Durum çubuğunda günü ve bülten numarasını göster
                XmlReader xmlOku = XmlReader.Create(tcmbWebSiteAdresi);

                while (xmlOku.Read())
                {
                    if ((xmlOku.NodeType == XmlNodeType.Element) && (xmlOku.Name == "Tarih_Date"))
                    {
                        if (xmlOku.HasAttributes)
                        {
                            tsDurum.Text = xmlOku.GetAttribute("Tarih") + @" günü saat 15:30'da belirlenen gösterge niteliğindeki TCMB kurları (Bülten No: " + xmlOku.GetAttribute("Bulten_No") + @")";
                            //textBox1.Text = xmlOku.GetAttribute("Tarih");
                            dateTimePicker1.Text = xmlOku.GetAttribute("Tarih");
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message + @" tipinde çok tuhaf hatalar mevcut. Olmadı bir kapatıp açın.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TCMBSayfasinaGit_Click(object sender, System.EventArgs e)
        {
            // TCMB'nin kurlar sayfasına git
            Process.Start(tcmbWebSiteAdresi);
        }

        private void cikis_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void hakkindaTSM_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(@"Bu program ile Türkiye Cumhuriyeti Merkez Bankası'nın (TCMB) resmi web sitesinden güncel döviz ve çapraz kurları otomatik olarak indirerek görebilirsiniz.
                               Bu programın tüm hakları Panaroma Bilişim firmasına aittir.", @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value <= DateTime.Now)
                {
                    if (dateTimePicker1.Value.DayOfWeek != DayOfWeek.Saturday && dateTimePicker1.Value.DayOfWeek != DayOfWeek.Sunday)
                    {
                        //string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

                        string gun = dateTimePicker1.Value.Day.ToString();
                        string ay = dateTimePicker1.Value.Month.ToString();
                        if (gun.Length == 1)
                        {
                            gun = "0" + gun;
                        }
                        if (ay.Length == 1)
                        {
                            ay = "0" + ay;
                        }
                        string adres = "http://www.tcmb.gov.tr/kurlar/" + dateTimePicker1.Value.Year.ToString() + ay + "/" + gun + ay + dateTimePicker1.Value.Year.ToString() + ".xml";
                        string Tarihli = adres;

                        DataSet dataSet = new DataSet();

                        dataSet.Clear();
                        dataSet.ReadXml(Tarihli);
                        dataGridGorunumu.DataSource = dataSet.Tables[1];

                        // İşe yaramayan, kalabalık yapan sütun ve satırları uçur
                        dataGridGorunumu.Columns["CurrencyName"].Visible = false;
                        dataGridGorunumu.Columns["CurrencyCode"].Visible = false;
                        dataGridGorunumu.Columns["CrossOrder"].Visible = false;
                        dataGridGorunumu.Columns["CrossRateOther"].Visible = false;

                        dataGridGorunumu.Rows.RemoveAt(18);
                        dataGridGorunumu.RowHeadersVisible = false;

                        // Sıralama işlemleri
                        dataGridGorunumu.Columns[0].DisplayIndex = 0;
                        dataGridGorunumu.Columns[10].DisplayIndex = 0;

                        // Sütunları Türkçeleştir (Biraz sıkıcı)
                        dataGridGorunumu.Columns["Unit"].HeaderText = @"Birim";
                        dataGridGorunumu.Columns["Isim"].HeaderText = @"İsim";
                        dataGridGorunumu.Columns["CurrencyName"].HeaderText = @"Döviz Cinsi";
                        dataGridGorunumu.Columns["ForexBuying"].HeaderText = @"Döviz Alış";
                        dataGridGorunumu.Columns["ForexSelling"].HeaderText = @"Döviz Satış";
                        dataGridGorunumu.Columns["BanknoteBuying"].HeaderText = @"Efektif Alış";
                        dataGridGorunumu.Columns["BanknoteSelling"].HeaderText = @"Efektif Satış";
                        dataGridGorunumu.Columns["CrossRateUSD"].HeaderText = @"Çapraz Kur";

                        // Sorunlu ve farklı hücrelerde çıkan çapraz kur değerlerini olması gereken yerlere kopyala
                        dataGridGorunumu.Rows[3].Cells[7].Value = dataGridGorunumu.Rows[3].Cells[8].Value;
                        dataGridGorunumu.Rows[4].Cells[7].Value = dataGridGorunumu.Rows[4].Cells[8].Value;
                        dataGridGorunumu.Rows[8].Cells[7].Value = dataGridGorunumu.Rows[8].Cells[8].Value;

                        // Para birimleri olan hücreleri sağa hizala
                        dataGridGorunumu.Columns["ForexBuying"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridGorunumu.Columns["ForexSelling"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridGorunumu.Columns["BanknoteBuying"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridGorunumu.Columns["BanknoteSelling"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridGorunumu.Columns["CrossRateUSD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        // Sütunların aralıklarını şekillendir
                        dataGridGorunumu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dataGridGorunumu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        // Fare ile tıklandığında tüm satırı seç
                        dataGridGorunumu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        //var xmlDoc = new XmlDocument();
                        //xmlDoc.Load(Tarihli);
                        // DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
                        // Durum çubuğunda günü ve bülten numarasını göster
                        XmlReader xmlOku = XmlReader.Create(Tarihli);

                        while (xmlOku.Read())
                        {
                            if ((xmlOku.NodeType == XmlNodeType.Element) && (xmlOku.Name == "Tarih_Date"))
                            {
                                if (xmlOku.HasAttributes)
                                {
                                    tsDurum.Text = xmlOku.GetAttribute("Tarih") + @" günü saat 15:30'da belirlenen gösterge niteliğindeki TCMB kurları (Bülten No: " + xmlOku.GetAttribute("Bulten_No") + @")";
                                }
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hafta Sonu seçilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Bugünden ileri bir tarih seçemezsiniz.");
                }
            }
            catch (Exception ex)
            {
                dovizKurlariIndir.PerformClick();
                if (ex.Message == "The remote server returned an error: (404) Not Found.")
                {
                    DialogResult dresult = MessageBox.Show("Bugün için daha tanımlanmış kur bilgisi bulunmamaktadır. En yakın mesai günü seçildi...", "Server Erişim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void FrmTcmbKurlari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.Alt == true && e.Shift == true && e.KeyCode == Keys.C)
            {
                DialogResult dresult = MessageBox.Show("Tebrikler adına oluşturulmuş kısayolu buldun...", "Çağrı ÇAKA", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}