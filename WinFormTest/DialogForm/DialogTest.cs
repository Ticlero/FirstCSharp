using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;
using System.IO;

namespace WinFormTest.DialogForm
{
    public partial class DialogTest : Form
    {
        private List<string> result;
        private DialogTest _instance;
        public DialogTest()
        {
           
            InitializeComponent();
            result = new List<string>();
            bwLoad.RunWorkerAsync();
        }

        public DialogTest GetInstance()
        {
            if(_instance == null)
                _instance = new DialogTest();
            return _instance;
        }

        private void BwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDoc = web.Load("https://www.naver.com");
            HtmlAgilityPack.HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//ul[@class='ah_l']");
            HtmlAgilityPack.HtmlNode[] node = bodyNode.SelectNodes(".//span[@class='ah_k']").ToArray();
           
            foreach(HtmlNode n in node)
            {
                this.result.Add(n.InnerText);
            }          
        }

        private void BwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error ==null)
            {
                foreach (string s in result)
                    cbListBox.Items.Add(s);
                cbListBox.SelectedIndex = 0;
            }
        }

        private string JsonTextToString(string path)
        {
            string result = null;
            StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open));
            result = sr.ReadToEnd();

            return result;
        }

        private JObject StringToJObject(string jsonstring)
        {
            JObject jo = JObject.Parse(jsonstring);
            return jo;
        }

        private void CbListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbResult.Text = cbListBox.SelectedItem.ToString();
        }
    }
}
