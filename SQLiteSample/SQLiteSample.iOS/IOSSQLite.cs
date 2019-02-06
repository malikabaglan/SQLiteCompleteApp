using System;
using System.IO;
using SQLite;
using SQLiteSample.iOS;
using SQLiteSample.iOS.Implementations;

[assembly: Xamarin.Forms.Dependency(typeof(IOSSQLite))]
namespace SQLiteSample.iOS.Implementations { 


public class IOSSQLite: ISQLite
    {
        public IOSSQLite()
        {
        }

        public SQLiteConnection GetConnection()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder  
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder  
            var path = Path.Combine(libraryPath, DatabaseHelper.DbFileName);
            // Create the connection  
            // var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            // var conn = new SQLiteConnection(plat, path);
            var conn = new SQLiteConnection(path);
            // Return the database connection  
            return conn;
        }
    }
}
