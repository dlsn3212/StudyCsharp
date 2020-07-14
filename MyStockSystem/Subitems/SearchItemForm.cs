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

namespace MyStockSystem.Subitems
{
    public partial class SearchItemForm : MetroForm
    {
        public SearchItemForm()
        {
            InitializeComponent();
        }

        private void SearchItemForm_Load(object sender, EventArgs e)
        {
            dataGridView2.Font = new Font(@"NanumGothic", 9, FontStyle.Regular);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            WebClient wc = null;
            XmlDocument doc = null;

            wc = new WebClient() { Encoding = Encoding.UTF8 };
            doc = new XmlDocument();
            StringBuilder str = new StringBuilder();
            str.Append("http://api.seibro.or.kr/openapi/service/StockSvc/getStkIsinByNmN1");
            str.Append("?serviceKey=s1rgHWnQK8nox%2FpmSgOQTrGoD8DqilO164IlzS76sUM9IaJJmpr3L3gXS0bu4IeYgy4T%2FM6TtZABaISIwFZI3g%3D%3D");
            str.Append("&secnNm=" + TxtSearchItem.Text);//종목명
            str.Append("&pageNo=1");//페이지 수
            str.Append("&numOfRows=200");//읽어올 데이터 수
            str.Append("&martTpcd=11");//주식시장종류 : 11은 유가증권시장

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            dataGridView2.Rows.Clear();

            try
            {
                foreach (XmlNode item in items)
                {
                    dataGridView2.Rows.Add(item["isin"].InnerText, item["korSecnNm"].InnerText, item["secnKacdNm"].InnerText, item["shotnIsin"].InnerText);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"에러발생 : {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            MainForm main = new MainForm();
            main.Location = this.Location;
            main.ShowDialog();

            this.Close();

        }

        private void TxtSearchItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                metroButton1_Click(sender, new EventArgs());
            }

        }
    }
}
