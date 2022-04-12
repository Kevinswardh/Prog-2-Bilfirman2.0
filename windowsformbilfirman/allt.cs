using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;



namespace windowsformbilfirman
{
    public partial class Form1 : Form
    {
        public static string Useronline;
        public static string carsell;
        public static int årsmodellsell;
        public static int miltalsell;

        public Form1()
        {
            InitializeComponent();
        }

        private void test_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            this.Hide();
            var f2 = new register();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = this.Location;
            f2.Size = this.Size;
            f2.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel5.Visible = true;
            this.säljbilpanel.Visible = false;
            this.välkommenpanel.Visible = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel5.Visible = false;
            this.säljbilpanel.Visible = true;
            this.välkommenpanel.Visible = false;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            this.Hide();
            var f2 = new register();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = this.Location;
            f2.Size = this.Size;
            f2.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
        public string GenerateOrderNumber()
        {
            string OrderNumber;

            Random rnd = new Random();
            long orderPart1 = rnd.Next(100000, 9999999);
            int orderPart2 = rnd.Next(1000, 9999);

            OrderNumber = "ORDER - " + orderPart1 + " - " + orderPart2;
            


            return OrderNumber;
        }
        
        public void button9_Click(object sender, EventArgs e)
        {
           
            string orderNumber = GenerateOrderNumber();

            if (personalform.bilköp.Contains(orderNumber))
            {
                GenerateOrderNumber();
            }
            else if (!personalform.bilköp.Contains(orderNumber))
            {
                personalform.bilköp.Add(orderNumber);
                MessageBox.Show("Du har valt att köpa en Mustang \n en order har nu skapats \n Och en säljare kommer kantakta dig inom kort.");
            }

            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            openmustang();
            void openmustang()
            {
                var uri = "https://www.ford.com/cars/mustang/models/ecoboost-premium-fastback/";
                var psi = new ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                Process.Start(psi);
            }
        }

        private void infobil2_Click(object sender, EventArgs e)
        {
            opentesla();
             void opentesla()
            {
                var uri = "https://www.tesla.com/en_eu/model3";
                var psi = new ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                Process.Start(psi);
            }
        }

        private void infobil3_Click(object sender, EventArgs e)
        {
            openbmw();
             void openbmw()
            {
                var uri = "https://www.bmw.se/sv/alla-modeller/x-serie/x5/2021/overblick.html";
                var psi = new ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                Process.Start(psi);
            }
        }

        private void infobil4_Click(object sender, EventArgs e)
        {
            openvolvo();
            void openvolvo()
            {
                var uri = "https://www.volvocars.com/se/cars/c40-electric/";
                var psi = new ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                Process.Start(psi);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stängnedbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel5.Visible = false;
            this.säljbilpanel.Visible = false;
            this.välkommenpanel.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string bilnamn = bilnamntext.Text;
            int årsmodell = Convert.ToInt32(årsmodelltext.Text);
            int miltal = Convert.ToInt32(miltaltext.Text);
            int volvopris = 160000; // 150.000
            int bmwpris = 120000; // 120.000
            int teslapris = 230000; // 230.000
            int mustangpris = 300000; // 300.000
            decimal procentåtta = 0.8m;
            decimal procentsju = 0.7m;
            decimal procentsex = 0.6m;                                          //------------------------------------------------------------------------------------------------------------------
            decimal procentfem = 0.5m;                                          // Detta fungerar sålänge svaret blir jämnt annars printar den ut .99999999 troligtvis pga double och inte decimal l
            decimal procentfyra = 0.4m;                                         // Fungerar överallt förutom på volvo miltal mellan 1000-5000 och beroende på årtal som ändras pga int variablerna
            int årsmodelltjugoett = 40000;  //startsumma                      // Update - Decimal ska fungera i annat program så ändrar.
            int årsmodelltjugotjugo = 30000;  //startsumma                    //------------------------------------------------------------------------------------------------------------------
            int årsmodelltjugonitton = 20000;  //startsumma
            int årsmodelltjugoarton = 10000;  //startsumma     fick lägga till en tvåa 14302 vid double

        
            Useronline = register.usersave;
            carsell = bilnamn;
            årsmodellsell = årsmodell;
            miltalsell = miltal;
            string orderNumber = GenerateOrderNumber();

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kevin Swärdh\source\repos\windowsformbilfirman\windowsformbilfirman\Database5.mdf;Integrated Security=True;Connect Timeout=30;";
            SqlConnection connection = new SqlConnection(@connectionString);
            string query = $"INSERT INTO [dbo].[orders] (CustomerName,Bilnamn,årsmodell,miltal,OrderNumber) VALUES(@användare,@bil,@årsmodell,@miltal,@ordernummer)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@användare", $"{Useronline}");
            command.Parameters.AddWithValue("@bil", $"{carsell}");
            command.Parameters.AddWithValue("@årsmodell", $"{årsmodellsell}");
            command.Parameters.AddWithValue("@miltal", $"{miltalsell}");
            command.Parameters.AddWithValue("@ordernummer", $"{orderNumber}");
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Records Inserted Successfully");
            }
            catch (SqlException test)
            {
                MessageBox.Show("Error Generated. Details: " + test.ToString());
            }
            finally
            {
                connection.Close();
            }


            if (bilnamn == "volvo" || bilnamn == "Volvo")                                   //Volvo
            {
                if(årsmodell == 2021)                                                      //Volvo 2021
                {
                    kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} ";
                    if (miltal < 1000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugoett) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugoett) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugoett) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugoett) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (volvopris + årsmodelltjugoett) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2020)                                                //Volvo 2020
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugotjugo) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugotjugo) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugotjugo) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugotjugo) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (volvopris + årsmodelltjugotjugo) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2019)                                                //Volvo 2019
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugonitton) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugonitton) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugonitton) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugonitton) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (volvopris + årsmodelltjugonitton) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if(årsmodell == 2018)                                                 //Volvo 2018
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugoarton) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugoarton) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugoarton) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (volvopris + årsmodelltjugoarton) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (volvopris + årsmodelltjugoarton) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else
                {
                    MessageBox.Show("Ange Årsmodell mellan 2018-2021");
                }
            }
            else if (bilnamn == "bmw" || bilnamn == "Bmw")                                 //BMW
            {
                if (årsmodell == 2021)                                                      //BMW 2021
                {
                    kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} ";
                    if (miltal < 1000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugoett) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugoett) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugoett) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugoett) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugoett) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2020)                                                //BMW 2020
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugotjugo) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugotjugo) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugotjugo) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugotjugo) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugotjugo) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2019)                                                //BMW 2019
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugonitton) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugonitton) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugonitton) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugonitton) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugonitton) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2018)                                                 //BMW 2018
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugoarton) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugoarton) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugoarton) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugoarton) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (bmwpris + årsmodelltjugoarton) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else
                {
                    MessageBox.Show("Ange Årsmodell mellan 2018-2021");
                }
            }
            else if(bilnamn == "tesla" || bilnamn == "Tesla")                              //Tesla
            {
                if (årsmodell == 2021)                                                      //TESLA 2021
                {
                    kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} ";
                    if (miltal < 1000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugoett) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugoett) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugoett) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugoett) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (teslapris + årsmodelltjugoett) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2020)                                                //TESLA 2020
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugotjugo) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugotjugo) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugotjugo) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugotjugo) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (teslapris + årsmodelltjugotjugo) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2019)                                                //TESLA 2019
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugonitton) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugonitton) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugonitton) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugonitton) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (teslapris + årsmodelltjugonitton) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2018)                                                 //TESLA 2018
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugoarton) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugoarton) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugoarton) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (teslapris + årsmodelltjugoarton) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (teslapris + årsmodelltjugoarton) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else
                {
                    MessageBox.Show("Ange Årsmodell mellan 2018-2021");
                }
            }
            else if(bilnamn == "Mustang" || bilnamn == "mustang" || bilnamn == "ford mustang" || bilnamn == "Ford mustang" || bilnamn == "Ford Mustang")    // MUSTANG
            {
                if (årsmodell == 2021)                                                      //MUSTANG 2021
                {
                    kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} ";
                    if (miltal < 1000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugoett) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugoett) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugoett) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugoett) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugoett) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2020)                                                //MUSTANG 2020
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugotjugo) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugotjugo) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugotjugo) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugotjugo) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugotjugo) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2019)                                                //MUSTANG 2019
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugonitton) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugonitton) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugonitton) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugonitton) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugonitton) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else if (årsmodell == 2018)                                                 //MUSTANG 2018
                {
                    if (miltal < 1000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugoarton) * procentåtta;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 999 && miltal < 5000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugoarton) * procentsju;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 4999 && miltal < 10000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugoarton) * procentsex;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 9999 && miltal < 20000)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugoarton) * procentfem;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                    if (miltal > 19999)
                    {
                        decimal kombination = (mustangpris + årsmodelltjugoarton) * procentfyra;
                        kalkylatorlabel.Text = $"Total summan för bilen {bilnamn} \n Som har årsmodell {årsmodell} \n Och miltalet {miltal} \n Blir summan: {kombination}";
                    }
                }
                else
                {
                    MessageBox.Show("Ange Årsmodell mellan 2018-2021");
                }
            }
            else
            {
                MessageBox.Show("Antigen har du skrivit fel eller \nså är vi tyvärr inte intresserade av den typen av bil");
            }

        }

        private void bilnamntext_TextChanged(object sender, EventArgs e)
        {

        }

        private void miltaltext_TextChanged(object sender, EventArgs e)
        {

        }

        private void miltaltext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button5_Click(this, new EventArgs());
            }
        }

        private void årsmodelltext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button5_Click(this, new EventArgs());
            }
        }

        private void bilnamntext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button5_Click(this, new EventArgs());
            }
        }

        private void köpbil2button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Du har valt att köpa en Tesla \n annan authorisering kommer ske i framtiden.");
        }

        private void köpbil3button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Du har valt att köpa en BMW \n annan authorisering kommer ske i framtiden.");
        }

        private void köpbil4button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Du har valt att köpa en Volvo \n annan authorisering kommer ske i framtiden.");
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void välkommenlabel2_Click(object sender, EventArgs e)
        {

        }

        private void köpbil2button_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Du har valt att köpa en Tesla \n annan authorisering kommer ske i framtiden.");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Du har valt att köpa en BMW \n annan authorisering kommer ske i framtiden.");
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Du har valt att köpa en Volvo \n annan authorisering kommer ske i framtiden.");
        }
    }
}
