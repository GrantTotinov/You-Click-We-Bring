using GrantFoods6.Models;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(GrantFoods6.Droid.SQLite_Android))]
namespace GrantFoods6.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "MyDatabase.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var cn = new SQLiteConnection(path);
            return cn;
        }
    }
}