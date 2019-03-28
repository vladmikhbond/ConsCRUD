using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ConsCRUD.Models;

namespace ConsCRUD.Data
{
    class RepoAdoNet: IRepo
    {        
        readonly string _conStr;

        public RepoAdoNet(string conStr)
        {
            _conStr = conStr;
        }

        public Book Create(Book book)
        {
            string sql = @"INSERT INTO Books (Id, Title, Author) 
                        VALUES (@Id, @Title, @Author) ";

            using (var con = new SqlConnection(_conStr) )
            {                
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    string id = Guid.NewGuid().ToString();
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    con.Open();
                    command.ExecuteNonQuery();
                    book.Id = id;
                }
            }            
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
            string sql = "UPDATE Books SET Id=@Id, Title=@Title, Author=@Author WHERE Id = @Id";
            
            using (var con = new SqlConnection(_conStr))
            {
                using (var command = new SqlCommand(sql, con))
                {                    
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }            
        }

        public void Delete(string id)
        {
            string sql = "DELETE FROM Books WHERE Id = @Id";

            using (var con = new SqlConnection(_conStr))
            {
                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
