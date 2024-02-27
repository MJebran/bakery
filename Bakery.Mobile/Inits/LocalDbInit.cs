using Bakery.ClassLibrary.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Mobile.Inits;

public class LocalDbInit(IDbLocation dbLocation)
{
    // TODO
    //private Type[] tables = [typeof(), typeof()] //// we put tabels in side typeof(), as many as we have. 

    public async Task<SQLiteAsyncConnection> InitializeLocalDatabase()
    {
        var database = EstablishConnection();

        await database.CreateTablesAsync(CreateFlags.None/*, tables*/);

        return database;
    }

    public SQLiteAsyncConnection EstablishConnection()
    {
        if(!Directory.Exists(dbLocation.BaseDataDirecory)) Directory.CreateDirectory(dbLocation.BaseDataDirecory);

        var database = new SQLiteAsyncConnection(Path.Combine(dbLocation.BaseDataDirecory, dbLocation.DbName));

        return database;
    }

    public async Task EmptyDatabase()
    {
        var db = EstablishConnection();

        // TODO we need to give our table name in the <> parts, we need to give all the tables that we have.
        //await db.DeleteAllAsync<>();
        //await db.DeleteAllAsync<>();
        //await db.DeleteAllAsync<>();
        //await db.DeleteAllAsync<>();
        //await db.DeleteAllAsync<>();
        //await db.DeleteAllAsync<>();
        //await db.DeleteAllAsync<>();
        //await db.DeleteAllAsync<>();
        //await db.DeleteAllAsync<>();
        //await db.DeleteAllAsync<>();
    }

}
