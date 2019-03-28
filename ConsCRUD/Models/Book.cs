using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsCRUD.Models
{
 //   CREATE TABLE [dbo].[Books]
 //   (
 //       [Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
 //       [Title] NVARCHAR(250) NOT NULL, 
 //       [Author] NVARCHAR(250) NOT NULL
 //   )

    class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; }
        public string Title { set; get; }
        public string Author { set; get; }

        public override string ToString() => 
            $"Id= {Id}  Title='{Title}'  Author='{Author}'";
    }
}
