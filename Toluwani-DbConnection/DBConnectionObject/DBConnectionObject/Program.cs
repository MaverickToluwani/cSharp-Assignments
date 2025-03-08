using DBConnectionObject;
using System;

class Program
{
    static void Main()
    {
        // Using SqlConnection
        var sqlConnection = new SqlConnection("Server=myServer;Database=myDB;");
        var sqlCommand = new DbCommand(sqlConnection, "SELECT * FROM Users");
        sqlCommand.Execute();

        Console.WriteLine();

        // Using OracleConnection
        var oracleConnection = new OracleConnection("Server=myOracleServer;Database=myOracleDB;");
        var oracleCommand = new DbCommand(oracleConnection, "SELECT * FROM Customers");
        oracleCommand.Execute();
    }
}
