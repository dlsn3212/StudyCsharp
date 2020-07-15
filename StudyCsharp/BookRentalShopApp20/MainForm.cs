﻿using System;
using BookRentalShopApp20.Subitems;
using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace BookRentalShopApp20
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MetroMessageBox.Show(this, "종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)//프로그램종료 x누르면
            {
                e.Cancel = false;
                Environment.Exit(0);     //완전 종료
            }
            else
            {
                e.Cancel = true;         //종료안함
            }
        }

        private void MnuItemCodeMng_Click(object sender, EventArgs e)
        {
            DivMngForm form = new DivMngForm();
            ShowFormControl(form,"구분코드관리");      //만든 form을 넘겨준다!
        }

        private void MnuItemExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MnuItemBooksMng_Click(object sender, EventArgs e)
        {
            BooksMngform form = new BooksMngform();
            ShowFormControl(form,"도서관리");
        }

        private void ShowFormControl(Form form,string title) //form받고 맞춰서 해준다,한번이상나오는거 메소드만들기
        {
            form.MdiParent = this;
            form.Text = title;
            form.Dock = DockStyle.Fill;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }
    }
}
