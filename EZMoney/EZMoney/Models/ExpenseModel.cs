using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZMoney.Models
{
    public class ExpenseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
