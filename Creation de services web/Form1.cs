using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creation_de_services_web
{
    public partial class Form1 : Form
    {
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

        }
    }
}
