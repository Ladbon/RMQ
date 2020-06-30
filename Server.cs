using System.Data;
using System.Data.SqlClient;
using System;

namespace Subscriber
{
    class Server
    {
        //Initiera alla variabler 
        public void Init_SQL_Connection()
        {
            DBConnection = new SqlConnection();

            DBConnection.ConnectionString = 
            "Data Source=(LocalDb)\\Ladbondb;" +
            "Initial Catalog=RabbitLadbon;" +
            "Integrated Security = True;";

            SetData = new SqlCommand("lfSP_Setdata", DBConnection);
            GetData = new SqlCommand("lfSP_GetData", DBConnection);

            SetData.CommandType = CommandType.StoredProcedure;
            GetData.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(GetData);
        }
        //Öppna anslutning vid begäran
        private void OpenConnection()
        {
            try
            {
                if (DBConnection.State != ConnectionState.Open)
                {
                    DBConnection.Close();
                    DBConnection.Open();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
        }
        //Stäng anslutningen till databasen 
        private void CloseConnection()
        {
            try
            {
                if (DBConnection.State == ConnectionState.Open)
                {
                    DBConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
        }
        //Spara data AKA kalla till Setdata SP
        public bool Save_Data(string data)
        {
            try
            {
                SetData.Parameters.Add("@Param1", SqlDbType.NVarChar).Value = data;
                OpenConnection();
                SetData.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return false;
            }
        }
        //Ta fram hela tabellen med GetData
        public void Load_Table_Form()
        {
            using (DBConnection)
            {
                OpenConnection();
                reader = GetData.ExecuteReader();
                while (reader.Read())
                {
                    //dataGrid.Rows.Add(reader[0].ToString(), reader[1].ToString());
                    Console.WriteLine(reader[0].ToString() + "    "  + reader[1].ToString());
                }
                reader.Close();
            }
            CloseConnection();
           // return dataGrid;
        }


        //Variabler
        SqlConnection DBConnection;
        SqlCommand SetData;
        SqlCommand GetData;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        //DataGridView dataGrid;
    }

}

