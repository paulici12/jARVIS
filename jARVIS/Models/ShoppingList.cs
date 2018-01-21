using System;
using System.Data.Entity;

namespace jARVIS.Models
{
    public class ShoppingList
    {
        public int ID { get; set; }
        public DateTime Timestamp { get; set; }
        public string ItemName { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }

    public class ShoppingListDBContext : DbContext
    {
        public DbSet<ShoppingList> ShoppingList { get; set; }
    }
}