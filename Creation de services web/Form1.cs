using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Security.Policy;

namespace Creation_de_services_web
{
    public partial class Form1 : Form
    {

        String link = "http://www.meteorestservice.lab3il.fr/ServiceRest.svc/meteo/1";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WSMeteo.meteo3ilSoapClient soapClient = new WSMeteo.meteo3ilSoapClient("meteo3ilSoap");
            String date = "";
            String description = "";
            String temperature = soapClient.Get_Value(1, out date, out description);
            textBox1.Text = "Temperature : " + temperature + " °C mesuree le : " + date;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WCFMeteo.Service1Client sr = new WCFMeteo.Service1Client();
            WCFMeteo.MeteoData md = sr.Get_MeteoData();
            textBox2.Text = "Temperature : " + md.d_Temp.ToString() + "°C mesuree le : " + md.dt_Releve.ToString("dd/MM/yyy HH:mm") + Environment.NewLine;
            textBox2.Text += "Pression : " + md.d_Pres.ToString() + "hPa mesuree le : " + md.dt_Releve.ToString("dd/MM/yyy HH:mm") + Environment.NewLine;
            textBox2.Text += "Humidite : " + md.i_Hum.ToString() + "% mesuree le : " + md.dt_Releve.ToString("dd/MM/yyy HH:mm") + Environment.NewLine;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(link);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            WebResponse result = httpWebRequest.GetResponse();
            StreamReader stream = new StreamReader(result.GetResponseStream());
            String str = stream.ReadLine();
            str = str.Substring(str.IndexOf(">") + 1, str.Length - str.IndexOf(">") - 1);
            str = str.Substring(0, str.IndexOf("<"));
            textBox3.Text = "Temperature actuelle : " + str + "°C";
        }
    }
}
