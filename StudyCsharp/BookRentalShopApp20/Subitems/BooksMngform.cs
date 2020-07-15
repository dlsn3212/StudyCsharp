﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace BookRentalShopApp20.Subitems
{
    public partial class BooksMngform : MetroForm
    {
        readonly string strTblName = "bookstbl";
        BaseMode myMode = BaseMode.NONE;        //commons의 enum,최초는 기본상태
        public BooksMngform()
        {
            InitializeComponent();
        }

        private void DivMngForm_Load(object sender, EventArgs e)
        {
            InitControls();
            UpdateComboDivision();
            UpdataData();
        }

        private void UpdateComboDivision()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT Division, Names FROM divTbl ";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();   //where절같은게 없으니 바로날림

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", ""); //첫번째 들어가서 값 제대로 나옴

                while (reader.Read())
                {
                    temps.Add(reader[1].ToString(), reader[0].ToString());
                }

                CboDivision.DataSource = new BindingSource(temps, null);
                CboDivision.DisplayMember = "Key";
                CboDivision.ValueMember = "Value";
                //CboDivision.SelectedIndex = -1;
            }
        }

        private void UpdataData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT b.Idx, " +     //길게해놓으면 불편하기때문에 하나씩 잘라서쓰기
                                   "      b.Author, " +
                                   "      b.Division, " +
                                   "      d.Names AS DivisionName, " +
                                   "      b.Names, " +
                                   "      b.ReleaseDate, " +
                                   "      b.ISBN, " +
                                   "      b.Price " +
                                   "   FROM bookstbl AS b" +
                                   "  INNER JOIN divtbl AS d " +
                                   "    ON b.Division = d.Division ";   

                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = strQuery;

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                //adapter가 connand parameter DataReader 다 가능
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrdBooksTbl.DataSource = ds;
                GrdBooksTbl.DataMember = strTblName;
            }
            SetColumnHeaders();     //열 제목줄 수정!
        }

        private void SetColumnHeaders() 
        {
            DataGridViewColumn column;
            column = GrdBooksTbl.Columns[0];
            column.Width = 50;
            column.HeaderText = "번호";

            column = GrdBooksTbl.Columns[1];
            column.Width = 150;
            column.HeaderText = "저자명";

            column = GrdBooksTbl.Columns[2];
            column.Visible = false;

            column = GrdBooksTbl.Columns[3];
            column.Width = 100;
            column.HeaderText = "장르";

            column = GrdBooksTbl.Columns[4];
            column.Width = 200;
            column.HeaderText = "이름";

            column = GrdBooksTbl.Columns[5];
            column.Width = 150;
            column.HeaderText = "출간일";

            column = GrdBooksTbl.Columns[6];
            column.Width = 150;
            column.HeaderText = "ISBN";

            column = GrdBooksTbl.Columns[7];
            column.Width = 100;
            column.HeaderText = "가격";


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(myMode != BaseMode.UPDATE)   //데이터열누르면 수정모드가 되므로!
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요", "알림");
                return;
            }
            myMode = BaseMode.DELETE;
            SaveData();
            InitControls();
        }

        private void InitControls()
        {
            TxtID.Text = TxtAuthor.Text = string.Empty;
            TxtID.Focus();

            myMode = BaseMode.NONE;

            ////콤보 박스 데이터 바인딩
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("선택", "00");
            //dic.Add("서울특별시", "11");//key value
            //dic.Add("부산광역시", "21");
            //dic.Add("대구광역시", "22");
            //dic.Add("인천광역시", "23");
            //dic.Add("광주광역시", "24");
            //dic.Add("대전광역시", "25");

            //CboDivision.DataSource = new BindingSource(dic,null); //폼의 데이터 소스 캡슐화
            //CboDivision.DisplayMember = "key";
            //CboDivision.ValueMember = "Value";

        }


        #region 삭제처리제거
        //private void DeleteProcess()
        //{
        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
        //        {
        //            conn.Open(); //using문사용시 자동으로 conn.close해줌 원래는 conn.close해줘야함!
        //            MySqlCommand cmd = new MySqlCommand();
        //            cmd.Connection = conn;
        //            cmd.CommandText = "DELETE FROM divtbl " +
        //                              "  WHERE Division = @Division ";
        //            MySqlParameter paramDivision = new MySqlParameter(@"Division", MySqlDbType.VarChar);
        //            paramDivision.Value = TxtDivision.Text;
        //            cmd.Parameters.Add(paramDivision);

        //            var result = cmd.ExecuteNonQuery();


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MetroMessageBox.Show(this, $"에러발생 {ex.Message}", "에러",
        //                         MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        UpdataData();
        //    }
        //}
        #endregion

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtID.Text = TxtAuthor.Text = string.Empty;
            TxtID.ReadOnly = false;
            myMode = BaseMode.INSERT;   //신규 입력 모드 변경

        }

        /// <summary>
        /// DB 업데이트 및 입력 처리
        /// </summary>
        private void SaveData()
        {
            if (string.IsNullOrEmpty(TxtID.Text) || string.IsNullOrEmpty(TxtAuthor.Text))
            {
                MetroMessageBox.Show(this, "빈값은 넣을 수 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(myMode == BaseMode.NONE)
            {
                MetroMessageBox.Show(this, "신규 등록시 신규 버튼을 눌러주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open(); //using문사용시 자동으로 conn.close해줌 원래는 conn.close해줘야함!
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    if (myMode == BaseMode.UPDATE)
                    {
                        cmd.CommandText = "UPDATE divtbl " +
                                          "     SET Names = @Names " +
                                          " WHERE Division = @Division ";
                    }
                    else if(myMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = " INSERT INTO " +
                                          " divtbl (Division, Names) " +
                                          " VALUES (@Division, @Names) ";
                    }
                    
                    else if(myMode == BaseMode.DELETE)
                    {
                        cmd.CommandText = "DELETE FROM divtbl " +
                                          "  WHERE Division = @Division ";
                    }

                    if(myMode == BaseMode.INSERT || myMode == BaseMode.UPDATE)
                    {
                        MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45);
                        paramNames.Value = TxtAuthor.Text;
                        cmd.Parameters.Add(paramNames);//delete문은 names가 없으므로 따로분기!
                    }

                   
                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar);
                    paramDivision.Value = TxtID.Text;
                    cmd.Parameters.Add(paramDivision);

                    var result = cmd.ExecuteNonQuery();
                    if(myMode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규 입력되었습니다.", "신규입력");
                    }
                    else if(myMode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정되었습니다", "수정");
                    }
                    else if(myMode == BaseMode.DELETE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 삭제되었습니다", "삭제");
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"에러발생 {ex.Message}", "에러",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdataData();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            InitControls();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            InitControls();
        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdBooksTbl.Rows[e.RowIndex];
                TxtID.Text = data.Cells[0].Value.ToString();
                TxtAuthor.Text = data.Cells[1].Value.ToString();

                TxtID.ReadOnly = true;
                myMode = BaseMode.UPDATE;   //수정 모드 변경
            }
        }

        //콤보박스 기본 이벤트
        private void CboDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CboDivision.SelectedIndex > 0)   //맨처음에 뜨지않게해주는 ..
            {
               MessageBox.Show(CboDivision.SelectedValue.ToString());
            }
            
        }
    }
}
