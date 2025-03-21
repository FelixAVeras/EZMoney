using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EZMoney.Interfaces
{
    public interface IFileHelper
    {
        SQLiteConnection DbConnection();
    }
}
