using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Management; // !!!! NUGET PAKET YÖNETİCİSİNDEN MANAGEMENT YÜKLEYİNİZ !!!!!!
using System.Text.Json;
using System.Text.Json.Serialization;



namespace softwareHome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GetLocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        private string GetIpAddress()
        {
            string ipAddress = "?";
            WebRequest request = WebRequest.Create("https://ipinfo.io/ip");
            WebResponse response = request.GetResponse();
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                ipAddress = streamReader.ReadToEnd();
            }
            return ipAddress;
        }

        public string scriptID = "66716351446e28035842628f"; // Script ID
        public string domain = "http://localhost:80/api/v1"; // Domain

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null || textBox1.Text == " ")
            {
                MessageBox.Show("Lütfen bir anahtar giriniz.");
                return;
            }

            string json = JsonSerializer.Serialize(new
            {
                computerName = Environment.MachineName,
                processorName = GetManagementObject("Win32_Processor", "Name"),
                osName = GetManagementObject("Win32_OperatingSystem", "Caption"),
                diskName = GetManagementObject("Win32_DiskDrive", "Model"),
                localIP = GetLocalIPAddress(),
                ip = GetIpAddress(),
                action = "check",
                key = textBox1.Text,
                script = scriptID
            });

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(domain);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = json.Length;

            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                MessageBox.Show(result);
            }

        }

        private void ListSystemInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Operating System Information:");
            sb.AppendLine(GetManagementObject("Win32_OperatingSystem", "Caption"));
            sb.AppendLine(GetManagementObject("Win32_OperatingSystem", "Version"));
            sb.AppendLine(GetManagementObject("Win32_OperatingSystem", "Manufacturer"));
            sb.AppendLine();

            sb.AppendLine("Processor Information:");
            sb.AppendLine(GetManagementObject("Win32_Processor", "Name"));
            sb.AppendLine(GetManagementObject("Win32_Processor", "Manufacturer"));
            sb.AppendLine(GetManagementObject("Win32_Processor", "Description"));
            sb.AppendLine();

            sb.AppendLine("Memory Information:");
            sb.AppendLine(GetManagementObject("Win32_PhysicalMemory", "Capacity"));
            sb.AppendLine(GetManagementObject("Win32_PhysicalMemory", "Speed"));
            sb.AppendLine();

            sb.AppendLine("Disk Drive Information:");
            sb.AppendLine(GetManagementObject("Win32_DiskDrive", "Model"));
            sb.AppendLine(GetManagementObject("Win32_DiskDrive", "InterfaceType"));
            sb.AppendLine(GetManagementObject("Win32_DiskDrive", "MediaType"));
            sb.AppendLine();

            sb.AppendLine("Network Adapter Information:");
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                sb.AppendLine($"Name: {ni.Name}");
                sb.AppendLine($"Description: {ni.Description}");
                sb.AppendLine($"Status: {ni.OperationalStatus}");
                sb.AppendLine($"Speed: {ni.Speed}");
                sb.AppendLine();
            }

        }

        private string GetManagementObject(string query, string property)
        {
            StringBuilder sb = new StringBuilder();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT {property} FROM {query}");
            foreach (ManagementObject obj in searcher.Get())
            {
                sb.AppendLine($"{obj[property]}");
            }
            return sb.ToString();
        }
    }
}
