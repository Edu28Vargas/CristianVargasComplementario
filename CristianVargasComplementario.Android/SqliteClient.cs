
using CristianVargasComplementario.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]
namespace CristianVargasComplementario.Droid
{
    public class SqliteClient : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "DBESTUDIANTES.DB");
            return new SQLiteAsyncConnection(path);
        }
    }
}