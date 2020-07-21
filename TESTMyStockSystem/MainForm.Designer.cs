namespace TESTMyStockSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.MtlSearchItem = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // MtlSearchItem
            // 
            this.MtlSearchItem.BackColor = System.Drawing.Color.Azure;
            this.MtlSearchItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MtlSearchItem.Location = new System.Drawing.Point(36, 63);
            this.MtlSearchItem.Name = "MtlSearchItem";
            this.MtlSearchItem.Size = new System.Drawing.Size(246, 270);
            this.MtlSearchItem.Style = MetroFramework.MetroColorStyle.Green;
            this.MtlSearchItem.TabIndex = 0;
            this.MtlSearchItem.Text = "영도구";
            this.MtlSearchItem.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.MtlSearchItem.TileImage = global::TESTMyStockSystem.Properties.Resources.images;
            this.MtlSearchItem.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlSearchItem.UseTileImage = true;
            this.MtlSearchItem.Click += new System.EventHandler(this.MtlSearchItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 372);
            this.Controls.Add(this.MtlSearchItem);
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "부산광역시 관광";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile MtlSearchItem;
    }
}

