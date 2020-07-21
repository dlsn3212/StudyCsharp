namespace TESTMyStockSystem.Subitems
{
    partial class SearchItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.SplitPanel = new System.Windows.Forms.SplitContainer();
            this.BtnSearch = new MetroFramework.Controls.MetroButton();
            this.TxtSearch = new MetroFramework.Controls.MetroTextBox();
            this.GrdDataView = new System.Windows.Forms.DataGridView();
            this.BackTile = new MetroFramework.Controls.MetroTile();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GrdDataViewCon = new System.Windows.Forms.DataGridView();
            this.panel = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usehour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.map = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPanel)).BeginInit();
            this.SplitPanel.Panel1.SuspendLayout();
            this.SplitPanel.Panel2.SuspendLayout();
            this.SplitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDataView)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDataViewCon)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(24, 64);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(904, 452);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTabControl1.TabIndex = 1;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.SplitPanel);
            this.metroTabPage1.Font = new System.Drawing.Font("한컴 고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 36);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(896, 412);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "관광지검색";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // SplitPanel
            // 
            this.SplitPanel.Location = new System.Drawing.Point(3, 3);
            this.SplitPanel.Name = "SplitPanel";
            this.SplitPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitPanel.Panel1
            // 
            this.SplitPanel.Panel1.Controls.Add(this.BtnSearch);
            this.SplitPanel.Panel1.Controls.Add(this.TxtSearch);
            // 
            // SplitPanel.Panel2
            // 
            this.SplitPanel.Panel2.Controls.Add(this.GrdDataView);
            this.SplitPanel.Size = new System.Drawing.Size(890, 406);
            this.SplitPanel.SplitterDistance = 34;
            this.SplitPanel.TabIndex = 4;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSearch.Location = new System.Drawing.Point(757, 0);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(133, 34);
            this.BtnSearch.Style = MetroFramework.MetroColorStyle.Black;
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.Text = "검색";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            this.BtnSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BtnSearch_KeyPress);
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.Color.White;
            this.TxtSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.TxtSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxtSearch.Location = new System.Drawing.Point(0, 0);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(745, 34);
            this.TxtSearch.Style = MetroFramework.MetroColorStyle.Black;
            this.TxtSearch.TabIndex = 0;
            this.TxtSearch.Text = "관광지명을 입력하세요";
            // 
            // GrdDataView
            // 
            this.GrdDataView.AllowUserToAddRows = false;
            this.GrdDataView.AllowUserToDeleteRows = false;
            this.GrdDataView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GrdDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.fee,
            this.usehour,
            this.address,
            this.map});
            this.GrdDataView.Location = new System.Drawing.Point(0, 5);
            this.GrdDataView.Name = "GrdDataView";
            this.GrdDataView.ReadOnly = true;
            this.GrdDataView.RowTemplate.Height = 23;
            this.GrdDataView.Size = new System.Drawing.Size(887, 362);
            this.GrdDataView.TabIndex = 0;
            // 
            // BackTile
            // 
            this.BackTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BackTile.Location = new System.Drawing.Point(848, 522);
            this.BackTile.Name = "BackTile";
            this.BackTile.Size = new System.Drawing.Size(80, 35);
            this.BackTile.Style = MetroFramework.MetroColorStyle.Green;
            this.BackTile.TabIndex = 1;
            this.BackTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BackTile.TileImage = global::TESTMyStockSystem.Properties.Resources.back2;
            this.BackTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BackTile.UseTileImage = true;
            this.BackTile.Click += new System.EventHandler(this.BackTile_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.splitContainer1);
            this.metroTabPage2.Font = new System.Drawing.Font("한컴 고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 36);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(896, 412);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "위치조회";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel1.Controls.Add(this.GrdDataViewCon);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.Control;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel);
            this.splitContainer1.Size = new System.Drawing.Size(893, 406);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.TabIndex = 2;
            // 
            // GrdDataViewCon
            // 
            this.GrdDataViewCon.AllowUserToAddRows = false;
            this.GrdDataViewCon.AllowUserToDeleteRows = false;
            this.GrdDataViewCon.AllowUserToOrderColumns = true;
            this.GrdDataViewCon.BackgroundColor = System.Drawing.Color.MediumAquamarine;
            this.GrdDataViewCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdDataViewCon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.content});
            this.GrdDataViewCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdDataViewCon.Location = new System.Drawing.Point(0, 0);
            this.GrdDataViewCon.Name = "GrdDataViewCon";
            this.GrdDataViewCon.ReadOnly = true;
            this.GrdDataViewCon.RowTemplate.Height = 23;
            this.GrdDataViewCon.Size = new System.Drawing.Size(893, 47);
            this.GrdDataViewCon.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(893, 355);
            this.panel.TabIndex = 1;
            // 
            // title
            // 
            this.title.HeaderText = "관광지명";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // fee
            // 
            this.fee.HeaderText = "이용요금";
            this.fee.Name = "fee";
            this.fee.ReadOnly = true;
            // 
            // usehour
            // 
            this.usehour.HeaderText = "이용시간";
            this.usehour.Name = "usehour";
            this.usehour.ReadOnly = true;
            // 
            // address
            // 
            this.address.HeaderText = "주소";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // map
            // 
            this.map.HeaderText = "찾아가는길";
            this.map.Name = "map";
            this.map.ReadOnly = true;
            // 
            // content
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumAquamarine;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.content.DefaultCellStyle = dataGridViewCellStyle1;
            this.content.HeaderText = "상세설명";
            this.content.Name = "content";
            this.content.ReadOnly = true;
            this.content.Width = 850;
            // 
            // SearchItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 580);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.BackTile);
            this.Name = "SearchItemForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "영도구 관광지";
            this.Load += new System.EventHandler(this.SearchItemForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.SplitPanel.Panel1.ResumeLayout(false);
            this.SplitPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitPanel)).EndInit();
            this.SplitPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdDataView)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdDataViewCon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.SplitContainer SplitPanel;
        private MetroFramework.Controls.MetroTile BackTile;
        private System.Windows.Forms.DataGridView GrdDataView;
        private MetroFramework.Controls.MetroTextBox TxtSearch;
        private MetroFramework.Controls.MetroButton BtnSearch;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView GrdDataViewCon;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn usehour;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn map;
        private System.Windows.Forms.DataGridViewTextBoxColumn content;
    }
}