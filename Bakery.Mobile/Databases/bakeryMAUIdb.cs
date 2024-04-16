
using Microsoft.EntityFrameworkCore;
using SQLite;
using Bakery.WebApp.Data;

namespace Bakery.Mobile.Databases;

public class bakeryMAUIdb : DbContext
{
    public SQLiteConnection Connection { get; set; }
    public string? baseDataDirectory { get; set; }
    public string databaseName { get; set; }
    Type[] tables { get; set; }
    public bakeryMAUIdb()
    {
        baseDataDirectory = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "JC", "LocalDataStorage", "Data");

        databaseName = "BakeryDb";

        tables = new Type[]{
            typeof(User),
            typeof(Category),
            typeof(Itempurchase),
            typeof(Itemtype),
            typeof(Role),
            typeof(WebApp.Data.Size),
            typeof(Topping),
            typeof(Purchase),
            typeof(Favoriteitem),
            typeof(Customitem),
            typeof(Customitemtopping)
            };

        InitializeLocalDatabase();
    }

    public SQLiteConnection InitializeLocalDatabase()
    {
        try
        {
            if (Connection == null)
            {
                if (!Directory.Exists(baseDataDirectory)) Directory.CreateDirectory(baseDataDirectory);

                Connection = new SQLiteConnection(Path.Combine(baseDataDirectory, databaseName));
            }
            foreach (var t in tables)
            {
                Connection.CreateTable(t);
            }
        }
        catch
        {
            throw new Exception("Error while initializing SQLite database");
        }


        return Connection;
    }
}
