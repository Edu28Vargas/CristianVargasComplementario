using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CristianVargasComplementario
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
