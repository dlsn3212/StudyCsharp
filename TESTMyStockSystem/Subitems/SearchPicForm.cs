using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MetroFramework.Forms;

namespace TESTMyStockSystem.Subitems
{
    public partial class SearchPicForm : MetroForm
    {
        public SearchPicForm()
        {
            InitializeComponent();
        }

        private void SearchItemForm_Load(object sender, EventArgs e)
        {
            GrdDataView.Font = new Font(@"NanumGothic", 9, FontStyle.Regular);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            WebClient wc = null;
            XmlDocument doc = null;

            wc = new WebClient() { Encoding = Encoding.UTF8 };
            doc = new XmlDocument();
            StringBuilder str = new StringBuilder();
            str.Append("http://openapi.yeongdo.go.kr:8081/openapi-data/service/rest/tour/imagelist");
            str.Append("?serviceKey=s1rgHWnQK8nox%2FpmSgOQTrGoD8DqilO164IlzS76sUM9IaJJmpr3L3gXS0bu4IeYgy4T%2FM6TtZABaISIwFZI3g%3D%3D");
            str.Append("&title=" + TxtSearch.Text);
            str.Append("&pageNo=1");
            str.Append("&numOfRows=1000");

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            GrdDataView.Rows.Clear();

            try
            {
                foreach (XmlNode item in items)
                {
                    GrdDataView.Rows.Add(item["name"].InnerText, item["fee"].InnerText,
                                         item["address"].InnerText, item["map"].InnerText);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"에러발생 : {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            GrdDataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void BtnSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BtnSearch_Click(sender, new EventArgs());
            }
        }

        private void BackTile_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            MainForm main = new MainForm(); //main으로 돌아가는
            main.Location = this.Location;
            main.ShowDialog();

            this.Close();   //현재 form닫음

        }
    }
}
