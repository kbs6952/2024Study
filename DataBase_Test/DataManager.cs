﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_Test
{
    public class DataManager
    {
        // Json 저장하는 기능 -> Button Save
        public static void SaveToJson(DataGridView dataGridView,string filePath,string tableName)
        {
            DataTable dataTable = new DataTable();

            foreach(DataGridViewColumn col in dataGridView.Columns)
            {
                dataTable.Columns.Add(col.HeaderText, col.ValueType);
            }
            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach(DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }
                dataTable.Rows.Add(dataRow);
            }
            DataJson dataJson = new DataJson();
            dataJson.dt = dataTable;
            dataJson.tableName= tableName;

            string jsonData = JsonConvert.SerializeObject(dataJson);
            File.WriteAllText(filePath, jsonData );

        }

        // Json 불러오는 기능 -> Button Load
        public static DataJson LoadToJson(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            DataJson dataJson = JsonConvert.DeserializeObject<DataJson>(jsonData);

            return dataJson;
        }


    }
    [Serializable]
    public class DataJson
    {
        public DataJson dt;
        public string tableName;
    }
   
}
