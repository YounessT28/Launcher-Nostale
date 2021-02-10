using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherNostale
{
    public partial class Form1 : Form
    {
        private String region;
        bool mousedown;
        private Point offset;

        public Form1()
        {
            InitializeComponent();
            region = "EN";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // D'abord checker si il a le launcher dans le dossier, si il a pas il le dl ensuite il lance avec les arguments en fonction de la region
            string curFile = @".\ServeurDeBg.exe";
            if(File.Exists(curFile))
            {
                Console.WriteLine("Le fichier existe");
                switch (region)
                {
                    case "EN":
                        try{ Process.Start("ServeurDeBg.exe", "EntwellNostaleLoadFromIni 0"); } catch (Win32Exception e) { }
                        break;
                    case "DE":
                        try { Process.Start("ServeurDeBg.exe", "EntwellNostaleLoadFromIni 1"); } catch (Win32Exception e) { }
                        break;
                    case "FR":
                        try { Process.Start("ServeurDeBg.exe", "EntwellNostaleLoadFromIni 2"); } catch (Win32Exception e) { }
                        break;
                    case "IT":
                        try { Process.Start("ServeurDeBg.exe", "EntwellNostaleLoadFromIni 3"); } catch (Win32Exception e) { }
                        break;
                    case "PL":
                        try { Process.Start("ServeurDeBg.exe", "EntwellNostaleLoadFromIni 4"); } catch (Win32Exception e) { }
                        break;
                    case "ES":
                        try { Process.Start("ServeurDeBg.exe", "EntwellNostaleLoadFromIni 5"); } catch (Win32Exception e) { }
                        break;
                    case "CS":
                        try { Process.Start("ServeurDeBg.exe", "EntwellNostaleLoadFromIni 6"); } catch (Win32Exception e) { }
                        break;
                    case "TR":
                        try { Process.Start("ServeurDeBg.exe", "EntwellNostaleLoadFromIni 7"); } catch (Win32Exception e) { }
                        break;
                    case "RU":
                        try { Process.Start("ServeurDeBg.exe", "EntwellNostaleLoadFromIni 8"); } catch (Win32Exception e) { }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas");
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile("http://86.105.212.17/ServeurDeBg.exe", @".\ServeurDeBg.exe");
                    Console.WriteLine("Le fichier est télécharger");
                }
                catch (WebException ex)
                {
                    // Traitement des erreurs
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            region = listBox1.SelectedItem.ToString();
            Console.WriteLine(region);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mouseDown_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mousedown = true;
        }

        private void mouseMove_Event(object sender, MouseEventArgs e)
        {
            if (mousedown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void mouseUp_Event(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }
    }
}
