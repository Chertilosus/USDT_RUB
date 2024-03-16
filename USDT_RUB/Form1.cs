using System;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace USDT_RUB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                string apiUrl = "https://api.coingecko.com/api/v3/simple/price?ids=tether&vs_currencies=rub";
                using (WebClient webClient = new WebClient())
                {
                    string response = webClient.DownloadString(apiUrl);


                    JObject json = JObject.Parse(response);

                
                    decimal usdtPrice = (decimal)json["tether"]["rub"];

              
                    decimal amountInRubles = usdtPrice * 1; 
                    label1.Text = $"Текущая цена USDT: {usdtPrice} RUB";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
