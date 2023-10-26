


using ADONETLesson.Models;
using ADONETLesson.Services;
/**
using ADONETLesson;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;


using (SqlConnection connect = new SqlConnection())
{
connect.ConnectionString = "Server=.;Database=Lesson;Trusted_Connection=True;";

connect.Open();

int findId = 2;

string query = $"Select * from odamlar where ID = {findId}";

SqlCommand sqlCommand = new SqlCommand(query, connect);

//List<Fruit> fruits = new List<Fruit>();

using (SqlDataReader reader = sqlCommand.ExecuteReader())
{
Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
while (reader.Read())
{
// column indexi bo'yicha ko'rvolish
Console.Write($"ID: {reader[0]} ");

// column name bo'yicha ko'rib olish
Console.WriteLine($"Name: {reader["lastname"]} ");

}

//while (reader.Read())
//{
//    fruits.Add(new Fruit()
//    {
//        Id = (int)reader[0],
//        Name = (string)reader[1],
//        Count = (int)reader[2],
//        Price = (float)reader[3]
//    });
//}

}
}

*/


string tableName = "Fruits";
string databaseName = "Lesson";

//Database.CreateTable(tableName, databaseName);

List<ColumnModel> columns = new List<ColumnModel>() 
{ 
    new ColumnModel(){Name = "Id", Typelari = "int not null identity(1,1)"},
    new ColumnModel(){Name = "Name", Typelari = "varchar(40)"},
    new ColumnModel(){Name = "Age", Typelari = "int"},
};

//Database.CreateTable(tableName, databaseName, columns);
Database.GetAll(tableName, databaseName);
