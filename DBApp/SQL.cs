using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DBApp
{
    class SQL
    {

        private System.Data.SqlClient.SqlConnection connect;
        readonly string connectionString = "Data Source = DESKTOP-2PTB1O7\\SQLEXPRESS;Initial Catalog = SQLbd; Integrated Security = True";
        SqlCommand cmd;

        public void Connection()
        {
            connect = new System.Data.SqlClient.SqlConnection(connectionString);
            cmd = connect.CreateCommand();
            if (connect.State == System.Data.ConnectionState.Closed)
                connect.Open();
        }

        public void closeConnection()
        {
            if (connect.State == System.Data.ConnectionState.Open)
                connect.Close();
        }

        public SqlDataReader GetTable(string table)
        {
            string sql1 = $"SELECT * FROM {table}";
            cmd.CommandText = sql1;
            SqlDataReader result = cmd.ExecuteReader();
            return result;
        }

        public SqlDataReader Combobox(string table, string index)
        {
            string sql1 = $"SELECT * FROM {table}  WHERE id = {index}";
            cmd.CommandText = sql1;
            SqlDataReader result = cmd.ExecuteReader();
            return result;
        }

        public void Add(string table,string s1, string s2, string cell1,string cell2)
        {
            Connection();
            cmd.CommandText = $"INSERT INTO {table} ({cell1}, {cell2}) values ('{s1}', '{s2}')";
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public void Delete(string table, int index)
        {
            Connection();
            cmd.CommandText = $"DELETE FROM {table} WHERE id = {index}";
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public void Edit(string table, string s1, string s2, int index, string cell1, string cell2)
        {
            Connection();
            cmd.CommandText = $"UPDATE {table} SET {cell1}='{s1}', {cell2}='{s2}' WHERE id = {index}";
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public void AddOneValue(string table, string s1, string cell)
        {
            Connection();
            cmd.CommandText = $"INSERT INTO {table} ({cell}) values ('{s1}')";
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public void EditOneValue(string table, string s1, int index, string cell)
        {
            Connection();
            cmd.CommandText = $"UPDATE {table} SET {cell}='{s1}' WHERE id = {index}";
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public SqlDataReader GetTableInfo(int index)
        {
            Connection();
            string sql1 = $"SELECT * FROM dbo.[Readers] Where reader_id={index}";
            cmd.CommandText = sql1;
            SqlDataReader result = cmd.ExecuteReader();
            return result;
        }

        public void AddValueInfo(string s1, int s2, string s3, string s4, string s5)
        {
            Connection();
            cmd.CommandText = $"INSERT INTO String (reader_id, stringnumber, book_id, dateofissue, returndate) values ('{s1}', '{s2}','{s3}', '{s4}', '{s5}')";
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public void EditValueInfo(int index, string s1, string s2, string s3, string s4)
        {
            Connection();
            cmd.CommandText = $"UPDATE String SET stringnumber='{s1}', book_id='{s2}', dateofissue='{s3}', returndate='{s4}' WHERE id = {index}";
            cmd.ExecuteNonQuery();
            closeConnection();
        }
    }
}
