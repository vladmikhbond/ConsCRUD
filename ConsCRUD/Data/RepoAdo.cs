using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ConsCRUD.Models;
using MongoDB.Driver;

namespace ConsCRUD.Data
{
    class RepoAdo: IRepo
    {        
        readonly string _conStr;

        public RepoAdo(string conStr)
        {
            _conStr = conStr;
        }

        public Book Create(Book book)
        {
            string sql = @"INSERT INTO Books (Id, Title, Author) 
                        VALUES (@Id, @Title, @Author) ";

            var con = new SqlConnection(_conStr);
            SqlCommand command = new SqlCommand(sql, con);
            string id = Guid.NewGuid().ToString();
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            con.Open();
            using (con)
            {
                command.ExecuteNonQuery();
            }
            book.Id = id;
            return book;
        }

        public List<Book> Read()
        {
            string sql = "SELECT Id, Title, Author FROM Books";

            var con = new SqlConnection(_conStr);
            SqlCommand command = new SqlCommand(sql, con);
            var books = new List<Book>();
            con.Open();
            using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        Id = (string)reader["Id"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],                        
                    });
                }
            }
            return books;
        }


        public Book Read(string id)
        {
            string sql = "SELECT Id, Title, Author FROM Books WHERE Id = @Id";                     

            var con = new SqlConnection(_conStr);
            SqlCommand command = new SqlCommand(sql, con);           
            command.Parameters.AddWithValue("@Id", id);
            Book book = null;
            con.Open();
            using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
            {                
                if (reader.Read())
                {
                    book = new Book {
                        Id = (string)reader["Id"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                    };
                }
            }
            return book;
        }

        public void Update(string id, Book book)
        {
           
        }

        public void Delete(string id)
        {
            
        }
    }
}
