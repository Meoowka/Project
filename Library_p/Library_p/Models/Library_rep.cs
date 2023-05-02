using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Library_p.Models
{
   
        public interface ILibrary
        {
            void Create(Library library);
            void Delete(int id);
            Library Get(int id);
            List<Library> GetLibrary();
            void Update(Library library);
        }

    public class Library_rep : ILibrary
    {
        string connectionString = null;

        public Library_rep(string conn)
        {
            connectionString = conn;
        }

        public List<Library> GetLibrary()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Library>("SELECT * FROM Library").ToList();
            }
        }
        public Library Get(int Lib_ID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Library>("SELECT * FROM Library WHERE Lib_ID = @Lib_ID", new { Lib_ID }).FirstOrDefault();
            }
        }
        public void Create(Library library)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                // если мы хотим получить id добавленного книги
                var sqlQuery = "INSERT INTO Library (Name_Lib, Adress_Lib , Department_lib) VALUES(@Name_Lib, @Adress_Lib,@Department_lib); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? Lib_ID = db.Query<int>(sqlQuery, library).FirstOrDefault();
                library.Lib_ID = Lib_ID.Value;
            }
        }

        public void Update(Library library)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Library SET Name_Lib = @Name_Lib,  Department_lib = @Department_lib, Department_lib = @Department_lib WHERE Lib_ID = @Lib_ID";
                db.Execute(sqlQuery, library);
            }
        }
        public void Delete(int Lib_ID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Lib_ID = @Lib_ID";
                db.Execute(sqlQuery, new { Lib_ID });
            }
        }
       
    }
}
