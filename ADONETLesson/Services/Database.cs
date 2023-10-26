using ADONETLesson.Models;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace ADONETLesson.Services;

public class Database
{
    public static void CreateTable(string TableName, string DatabaseName, List<ColumnModel> columns)
    {
        using (SqlConnection connect = new SqlConnection($"Server=.;Database={DatabaseName};Trusted_Connection=True;"))
        {
            
            //connect.ConnectionString = ;
            connect.Open();

            //string ustunlar = String.Empty;

            //string linq = String.Join(",", columns.Select(x => x.Name + " " + x.Typelari).ToList());

            //string query = $"create table {TableName}(Id int not null, " +
            //                                        $"Name varchar(30)," +
            //                                        $"Age int not null)";


            string nimadur = $"create table {TableName}(";

            string query = columns.Aggregate(nimadur, (x1, x2) => x1 += x2.Name + " " + x2.Typelari + ","
                                            , (x) => x.Substring(0, x.Length - 1) + ");");

            SqlCommand cmd = new SqlCommand(query, connect);

            cmd.ExecuteNonQuery();

            Console.WriteLine("Succesfully table created");

        }
    }

    public static void GetAll(string TableName, string DatabaseName)
    {
        using(SqlConnection connect = new SqlConnection($"Server=.;Database={DatabaseName};Trusted_Connection=True;"))
        {
            connect.Open();

            string query = $"select * from {TableName}";

            SqlCommand sqlCommand = new SqlCommand(query, connect);

            using (SqlDataReader reader =  sqlCommand.ExecuteReader())
            {
                int count = reader.FieldCount;

                reader.GetColumnSchema().Select(x => x.ColumnName);
                reader.GetColumnSchema().Select(x => x.DataTypeName);

                //int i = 0;
                while (reader.Read())
                {
                    for (int j = 0; j < count; j++)
                    {
                        Console.Write($"Col{j} {reader[j]} \t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }


}

