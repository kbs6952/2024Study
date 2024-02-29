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

namespace DataBase_Test
{
    public partial class Form1 : Form
    {
        // 데이터들을 자료구조 collection으로 묶어서 사용을 해볼겁니다.
        // 클래스 내부에서 직접 값을 설정하고 데이터 처리하는 대부분 방식은 하드코딩으로 처리됨

        // 생성 버튼 입력시 데이터그리드뷰인포에 데이터가 나오는 기능을 만들겠다.
        // datatable 데이터집합이 어디에 들어가야 할지 파악을 해야합니다.지역
        // row에는 숫자 1,2,3,4
        DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }
        


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            IDText.Text = "";
            NameText.Text = "";
            RaceText.Text = "";
            RegionSelectBox.Text = "";
        }

        private void button_create_Click(object sender, EventArgs e)
        {

            bool checkIsTable = false;

            if(ds.Tables.Contains(RegionSelectBox.Text)) // 키값이 이미 존재합니다.
            {
                checkIsTable = true;
            }

            // bool이 true이면 이미 생성한 데이터가 있으니까 그 데이터를 불러와서 추가로 데이터를 만들어주면되고
            // bool이 false이면 처음 생성한 데이터이기때문에 새롭게 데이터를 생성해주면 된다.

            // DataSet - DataTable - DataRow, DataColumn 생성

            DataTable dt = null;
            
            if (!checkIsTable)
                {
                    // 데이터가 없을 경우에는 새롭게 데이터를 만들어 준다
                    dt = new DataTable(listBox.Text);

                    DataColumn columnID = new DataColumn("ID", typeof(string));
                    DataColumn columnName = new DataColumn("Name", typeof(string));
                    DataColumn columnRace = new DataColumn("Race", typeof(string));
                    DataColumn columnRegion = new DataColumn("Region", typeof(string));

                    dt.Columns.Add(columnID);
                    dt.Columns.Add(columnName);
                    dt.Columns.Add(columnRace);
                    dt.Columns.Add(columnRegion);

                }
                else
                {
                    dt = ds.Tables[RegionSelectBox.Text];
                }

            // 생성할 데이터를 Row에 입력을 한 후 
            
                DataRow row = dt.NewRow();
                row["ID"] = IDText.Text;
                row["Name"] = NameText.Text;
                row["Race"] = RaceText.Text;
                row["Region"] = RegionSelectBox.Text;


                // 데이터 테이블이 이미 존재한다면 기존 테이블을 불러온 후 새로운 데이터를 이어서 추가 해주고
                if (checkIsTable)
                {
                    ds.Tables[RegionSelectBox.Text].Rows.Add(row);
                }
                else
                {
                    dt.Rows.Add(row);
                    ds.Tables.Add(dt);
                }
                ViewRefresh();
            }
            //listBox_SelectedIndexChanged(this, null);
            // 테이블이 존재 하지 않는다면 밑에 있는 코드를 실행



            // 생성한 데이터를 볼수 있게 view


        

        private void button_remove_Click(object sender, EventArgs e)
        {
            int selectRow = dataGridViewInfo.SelectedRows[0].Index;
            ds.Tables[RegionSelectBox.Text].Rows.RemoveAt(selectRow);

            ViewRefresh();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 데이터를 보여줄수 있게 바인딩
            dataGridViewInfo.DataSource = ds.Tables[listBox.Text];

            foreach(DataGridViewRow row in dataGridViewInfo.Rows )
            {
                row.HeaderCell.Value=row.Index.ToString();
            }
        }
        private void ViewRefresh()
        {
            dataGridViewInfo.DataSource = ds.Tables[listBox.Text];

            foreach (DataGridViewRow row in dataGridViewInfo.Rows)
            {
                row.HeaderCell.Value = row.Index.ToString();
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\새 폴더.Test.txt");
            for (int i = 0; i<dataGridViewInfo.Rows.Count-1; i++)
            {
                for (int j = 0; j < dataGridViewInfo.Columns.Count; j++)
                {
                    writer.Write("\t" + dataGridViewInfo.Rows[i].Cells[j].Value.ToString() + "\t"+"|");
                }
                writer.WriteLine();
            }
            writer.Close();
            MessageBox.Show("데이터가 출력되었음");
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(@"C:\새 폴더.Test.txt");
            string[] lines = File.ReadAllLines(@"C:\새 폴더.Test.txt");

            // Seperator 어떤 것으로 하냐에 따라서 Format형식이 바뀐다.
            dataGridViewInfo.ColumnCount = lines[0].Split('|').Length;

            DataTable dt = new DataTable("1지역");
            dt = new DataTable(listBox.Text);

            DataColumn columnID = new DataColumn("ID", typeof(string));
            DataColumn columnName = new DataColumn("Name", typeof(string));
            DataColumn columnRace = new DataColumn("Race", typeof(string));
            DataColumn columnRegion = new DataColumn("Region", typeof(string));

            dt.Columns.Add(columnID);
            dt.Columns.Add(columnName);
            dt.Columns.Add(columnRace);
            dt.Columns.Add(columnRegion);

            ds.Tables.Add(dt);
            foreach(string line in lines)
            {
                string[] values = line.Split('|');
                DataRow row = dt.NewRow();
                row["ID"] = values[0];
                row["Name"] = values[1];
                row["Race"] = values[2];
                row["Reigon"] = values[3];

                ds.Tables[listBox.Text].Rows.Add(row);



            }
            ViewRefresh();
        }
    }
}
