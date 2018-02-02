using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BankApplication.DataManagementService;

namespace DataManagementLibrary
{
    public class DataManagerHelper
    {
        /// <summary>
        /// Records to list of list.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <returns></returns>
        public List<List<string>> RecordsToListOfList(List<Record> records)
        {
            List<List<string>> outputList = new List<List<string>>();

            foreach (Record record in records)
            {
                List<string> row = new List<string>();

                if (record.Columns != null)
                {
                    foreach (string value in record.Columns.Values)
                    {
                        row.Add(value);
                    }
                }
                outputList.Add(row);
            }

            return outputList;
        }

        /// <summary>
        /// Rocords to data table.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <param name="columnNames">The list of column names. If column name list is null or empty then it will add all columns to Datatable.</param>
        /// <returns></returns>
        public DataTable RecordsToDataTable(List<Record> records,List<string> columnNames)
        {
            DataTable dataTable = new DataTable();
            List<string> tempColNames = new List<string>();

            if (records != null && records.Count > 0)
            {
                if (records[0].Columns != null)
                {
                    // If there are column names then adding those in datatable otherwise adding all.
                    if (columnNames != null && columnNames.Count > 0)
                    {
                        tempColNames = columnNames;
                        foreach (string key in tempColNames)
                        {
                            dataTable.Columns.Add(key);
                        }
                    }
                    else
                    {
                        foreach (string key in records[0].Columns.Keys)
                        {
                            dataTable.Columns.Add(key);
                            tempColNames.Add(key);
                        }
                    }

                    foreach (Record record in records)
                    {
                        DataRow dataRow = dataTable.NewRow();

                        foreach (KeyValuePair<string, string> item in record.Columns)
                        {
                            if(tempColNames.Contains(item.Key))
                                dataRow[item.Key] = item.Value;
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }

            return dataTable;
        }

        /// <summary>
        /// Records to column name list.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <returns></returns>
        public List<string> RecordToColumnNameList(Record record)
        {
            List<string> columnNames = new List<string>();

            if (record != null && record.Columns != null)
            {
                foreach (string key in record.Columns.Keys)
                {
                    columnNames.Add(key);
                }
            }

            return columnNames;
        }

        /// <summary>
        /// Lists to records.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        public List<Record> ListsToRecords(List<List<string>> rows, List<string> columns)
        {
            List<Record> recordList = new List<Record>();

            if (rows != null && columns != null && rows.Count > 0 && columns.Count > 0)
            {
                foreach (List<string> row in rows)
                {
                    Record record = new Record();

                    Dictionary<string, string> dict = new Dictionary<string, string>();

                    for(int index=0;index < columns.Count;index++)
                    {
                        if (index < row.Count)
                        {
                            dict.Add(columns[index], row[index]);
                        }

                    }
                    record.Columns = dict;
                }
            }

            return recordList;
        }

        /// <summary>
        /// Datatable to list of records.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public List<Record> DataTableToRecords(DataTable dataTable)
        {
            List<Record> recordList = new List<Record>();

            // getting all column names
            List<string> columnNames = (from col in dataTable.Columns.Cast<DataColumn>()
                                        select col.ColumnName).ToList();

            foreach (DataRow row in dataTable.Rows)
            {
                Record record = new Record();

                Dictionary<string, string> dict = new Dictionary<string, string>();

                foreach (string columnName in columnNames)
                {
                    dict.Add(columnName, row[columnName].ToString());
                }

                record.Columns = dict;

                recordList.Add(record);
            }

            return recordList;
        }
    }
}
