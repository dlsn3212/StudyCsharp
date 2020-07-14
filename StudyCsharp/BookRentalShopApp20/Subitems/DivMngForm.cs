using System;
using System.Data;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace BookRentalShopApp20.Subitems
{
    public partial class DivMngForm : MetroForm
    {
        readonly string strTblName = "divtbl";
        public DivMngForm()
        {
            InitializeComponent();
        }

        private void DivMngForm_Load(object sender, EventArgs e)
        {
            UpdataData();
        }

        private void UpdataData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"select Division,Names from {strTblName};";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = strQuery;

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                //adapter가 connand parameter DataReader 다 가능
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrdDivTbl.DataSource = ds;
                GrdDivTbl.DataMember = strTblName;

            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
