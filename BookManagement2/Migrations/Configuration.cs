namespace BookManagement2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookManagement2.DAL.BookstoreDBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BookManagement2.DAL.BookstoreDBEntities";
        }

        protected override void Seed(BookManagement2.DAL.BookstoreDBEntities context)
        {
        }
    }
}
