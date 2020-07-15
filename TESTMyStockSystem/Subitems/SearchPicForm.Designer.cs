namespace TESTMyStockSystem.Subitems
{
    partial class SearchPicForm
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.SplitPanel = new System.Windows.Forms.SplitContainer();
            this.BtnSearch = new MetroFramework.Controls.MetroButton();
            this.TxtSearch = new MetroFramework.Controls.MetroTextBox();
            this.GrdDataView = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.map = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackTile = new MetroFramework.Controls.MetroTile();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPanel)).BeginInit();
            this.SplitPanel.Panel1.SuspendLayout();
            this.SplitPanel.Panel2.SuspendLayout();
            this.SplitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Location = new System.Drawing.Point(24, 64);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(904, 452);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTabControl1.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.SplitPanel);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 36);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(896, 412);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "관광지위치";
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
            this.SplitPanel.Size = new System.Drawing.Size(890, 409);
            this.SplitPanel.SplitterDistance = 35;
            this.SplitPanel.TabIndex = 4;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSearch.Location = new System.Drawing.Point(757, 0);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(133, 35);
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
            this.TxtSearch.Size = new System.Drawing.Size(745, 35);
            this.TxtSearch.Style = MetroFramework.MetroColorStyle.Black;
            this.TxtSearch.TabIndex = 0;
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
            this.addr,
            this.map});
            this.GrdDataView.Location = new System.Drawing.Point(0, 5);
            this.GrdDataView.Name = "GrdDataView";
            this.GrdDataView.ReadOnly = true;
            this.GrdDataView.RowTemplate.Height = 23;
            this.GrdDataView.Size = new System.Drawing.Size(887, 362);
            this.GrdDataView.TabIndex = 0;
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
            // addr
            // 
            this.addr.HeaderText = "주소";
            this.addr.Name = "addr";
            this.addr.ReadOnly = true;
            // 
            // map
            // 
            this.map.HeaderText = "찾아가는길";
            this.map.Name = "map";
            this.map.ReadOnly = true;
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
            // SearchPicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 580);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.BackTile);
            this.Name = "SearchPicForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "관광지 위치조회";
            this.Load += new System.EventHandler(this.SearchItemForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.SplitPanel.Panel1.ResumeLayout(false);
            this.SplitPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitPanel)).EndInit();
            this.SplitPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdDataView)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn map;
    }
}