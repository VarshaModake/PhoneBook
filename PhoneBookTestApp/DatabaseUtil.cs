using System;
using System.Data.SQLite;
using System.IO;

namespace PhoneBookTestApp
{
    public class DatabaseUtil
    {
        public static void initializeDatabase()
        {
                var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
                dbConnection.Open();

                try
                {
                    SQLiteCommand command =
                        new SQLiteCommand(
                            "create table PHONEBOOK (NAME varchar(255), PHONENUMBER varchar(255), ADDRESS varchar(255))",
                            dbConnection);
                    command.ExecuteNonQuery();

                    command =
                        new SQLiteCommand(
                            "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Chris Johnson','(321) 231-7876', '452 Freeman Drive, Algonac, MI')",
                            dbConnection);
                    command.ExecuteNonQuery();

                    command =
                        new SQLiteCommand(
                            "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Dave Williams','(231) 502-1236', '285 Huron St, Port Austin, MI')",
                            dbConnection);
                    command.ExecuteNonQuery();

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    dbConnection.Close();
                }
            }

        

        public static SQLiteConnection GetConnection()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            return dbConnection;
        }

        public static void CleanUp()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        "drop table If EXISTS PHONEBOOK",
                        dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public static void InsertPhoneBook(string sql, SQLiteConnection dbconnection)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, dbconnection);
                command.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                dbconnection.Close();
            }
        }
        public static SQLiteDataReader GetPersonDetail(string sql,SQLiteConnection dbConnection)
        {
            try
            {
                SQLiteCommand sCommand = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader sQLiteData = sCommand.ExecuteReader();
                return sQLiteData;
            }
            catch(Exception)
            {
                throw;
            }
           
        }
    }
}