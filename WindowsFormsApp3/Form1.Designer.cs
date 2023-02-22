namespace WindowsFormsApp3
{
	partial class Form1
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
			this.uiGridView_CSV = new System.Windows.Forms.DataGridView();
			this.uiBtn_ReadCsv = new System.Windows.Forms.Button();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.ResetDataGridView1 = new System.Windows.Forms.Button();
			this.uiBtn_DBInsert = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.uiGridView_CSV)).BeginInit();
			this.SuspendLayout();
			// 
			// uiGridView_CSV
			// 
			this.uiGridView_CSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uiGridView_CSV.Location = new System.Drawing.Point(12, 12);
			this.uiGridView_CSV.Name = "uiGridView_CSV";
			this.uiGridView_CSV.RowTemplate.Height = 23;
			this.uiGridView_CSV.Size = new System.Drawing.Size(459, 328);
			this.uiGridView_CSV.TabIndex = 0;
			// 
			// uiBtn_ReadCsv
			// 
			this.uiBtn_ReadCsv.Location = new System.Drawing.Point(362, 358);
			this.uiBtn_ReadCsv.Name = "uiBtn_ReadCsv";
			this.uiBtn_ReadCsv.Size = new System.Drawing.Size(109, 58);
			this.uiBtn_ReadCsv.TabIndex = 1;
			this.uiBtn_ReadCsv.Text = "button1";
			this.uiBtn_ReadCsv.UseVisualStyleBackColor = true;
			// 
			// ResetDataGridView1
			// 
			this.ResetDataGridView1.Location = new System.Drawing.Point(225, 358);
			this.ResetDataGridView1.Name = "ResetDataGridView1";
			this.ResetDataGridView1.Size = new System.Drawing.Size(111, 58);
			this.ResetDataGridView1.TabIndex = 2;
			this.ResetDataGridView1.Text = "Reset";
			this.ResetDataGridView1.UseVisualStyleBackColor = true;
			// 
			// uiBtn_DBInsert
			// 
			this.uiBtn_DBInsert.Location = new System.Drawing.Point(78, 358);
			this.uiBtn_DBInsert.Name = "uiBtn_DBInsert";
			this.uiBtn_DBInsert.Size = new System.Drawing.Size(111, 58);
			this.uiBtn_DBInsert.TabIndex = 3;
			this.uiBtn_DBInsert.Text = "Reset";
			this.uiBtn_DBInsert.UseVisualStyleBackColor = true;
			this.uiBtn_DBInsert.Click += new System.EventHandler(this.uiBtn_DBInsert_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(483, 450);
			this.Controls.Add(this.uiBtn_DBInsert);
			this.Controls.Add(this.ResetDataGridView1);
			this.Controls.Add(this.uiBtn_ReadCsv);
			this.Controls.Add(this.uiGridView_CSV);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.uiGridView_CSV)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView uiGridView_CSV;
		private System.Windows.Forms.Button uiBtn_ReadCsv;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Button ResetDataGridView1;
		private System.Windows.Forms.Button uiBtn_DBInsert;
	}
}

