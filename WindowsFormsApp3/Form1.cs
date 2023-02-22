using WindowsFormsApp3.ConnectClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
	public partial class Form1 : Form
	{
		public enum COLUMNS { NAME, AGE, GRADE, PHONENUMBER }

		List<string> csvList = null;
		List<STUDENT> stuList = new List<STUDENT>();


		public Form1()
		{
			InitializeComponent();

			//CSV read Button Click Event
			//uiBtn_ReadCsv.Click += uiBtn_ReadCsv_Click;
			InitEvent();
		}

		private void InitEvent()
		{
			this.Load += FormLoad_Event;

			uiBtn_ReadCsv.Click += uiBtn_ReadCsv_Click;

			uiBtn_ReadCsv.Click += uiBtn_ReadCsv_Click;
		}

		private void FormLoad_Event(object sender, EventArgs e)
		{
			this.Cursor= Cursors.WaitCursor;

			ConnectDatabase();

			this.Cursor = Cursors.Default;
		}

		private void UiBtn_ReadCsv_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void uiBtn_ReadCsv_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();

			if (fbd.ShowDialog() == DialogResult.OK)
			{
				string[] fileName = Directory.GetFiles(fbd.SelectedPath);

				csvList = fileName.Where(x => x.IndexOf(".csv", StringComparison.OrdinalIgnoreCase) >= 0).Select(x => x).ToList();

				try
				{
					GetCSVData(csvList); // CSV 파일 내용 읽어오기
					DataSouceGridView(); //DataGridView에 csv 내용 바인딩
				}
				catch { }
			}
		}
		private void uiBtn_DBInsert_Click(object sender, EventArgs e)
		{
			DBInsert();
		}
		private void GetCSVData(List<string> csvList)
		{
			for (int idx = 0; idx < csvList.Count; idx++)
			{
				using (var sr = new System.IO.StreamReader(csvList[idx], Encoding.Default, true))
				{
					while (!sr.EndOfStream)
					{
						string array = sr.ReadLine();
						string[] values = array.Split(',');

						if (array.Contains("NAME"))
							continue;

						STUDENT stu = new STUDENT();
						stuList.Add(SetData(stu, values));
					}
				}
			}
		}

		private void ConnectDatabase()
		{
			if (SqlDBManager.Instance.GetConnection() == false)
			{
				string msg = $"Failed to Connect to Database";
				MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
		private STUDENT SetData(STUDENT stu, string[] values)
		{
			stu.NAME = values[(int)COLUMNS.NAME].ToString();
			stu.AGE = values[(int)COLUMNS.AGE].ToString();
			stu.GRADE = values[(int)COLUMNS.GRADE].ToString();
			stu.PHONENUMBER = values[(int)COLUMNS.PHONENUMBER].ToString();

			return stu;
		}

		private void DataSouceGridView()
		{
			uiGridView_CSV.DataSource = GetDataTable();
		}

		private DataTable GetDataTable()
		{
			DataTable dt = new DataTable();

			CreateColumn(dt);

			CreateRow(dt);

			return dt;
		}

		private void CreateColumn(DataTable dt)
		{
			dt.Columns.Add("Name");
			dt.Columns.Add("Age");
			dt.Columns.Add("Grade");
			dt.Columns.Add("PHONENUMBER");
		}
		private void CreateRow(DataTable dt)
		{
			for (int idx = 0; idx < stuList.Count; idx++)
			{
				dt.Rows.Add(new string[] {stuList[idx].NAME,
					stuList[idx].AGE, stuList[idx].GRADE , stuList[idx].PHONENUMBER });
			}
		}

		private void DBInsert()
		{
			string name = string.Empty;
			string age = string.Empty;
			string grade = string.Empty;
			string phonenumber = string.Empty;

			string query = string.Empty;

			for (int idx = 0; idx < stuList.Count; idx++)
			{
				name = stuList[idx].NAME.ToString();
				age = stuList[idx].AGE.ToString();
				grade = stuList[idx].GRADE.ToString();
				phonenumber = stuList[idx].PHONENUMBER.ToString();

				query = @"
			INSERT INTO student
			VALUES ( '#NAME', '#AGE', '#GRADE', '#PHONENUMER')
			";

				query = query.Replace("#NAME", name);
				query = query.Replace("#AGE", age);
				query = query.Replace("#GRADE", grade);
				query = query.Replace("#PHONENUMBER", phonenumber);

				int result = SqlDBManager.Instance.ExecuteNonQuery(query);

				if (result < 0)
				{
					MessageBox.Show("DB Insert 실패");
				}
			}

			MessageBox.Show("데이터베이스 Insert 성공");
		}
		
		public class STUDENT
		{
			public string NAME { get; set; }
			public string AGE { get; set; }
			public string GRADE { get; set; }
			public string PHONENUMBER { get; set; }
		}

	}
}
