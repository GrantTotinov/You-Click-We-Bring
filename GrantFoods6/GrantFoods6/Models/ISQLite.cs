using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrantFoods6.Models
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
