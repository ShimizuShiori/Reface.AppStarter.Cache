namespace Reface.AppStarter.Cache.Tests.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Book()
        {

        }

        public Book(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Book : {Id}, {Name}";
        }
    }
}
