using SQLite;
using System.Collections.ObjectModel;

namespace MobileCW1
{
    class SQLiteDatabase
    {
        private SQLiteConnection dbConnection;
        public const string DB_FILENAME = "MyDB.db3";
        public const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
        public string dbPath = "";

        public const string HIKE_TABLE = "hike_details";
        public const string ID_COL = "id";
        public const string NAME_COL = "name";
        public const string LOCATION_COL = "location";
        public const string DATE_COL = "date";
        public const string PARKING_COL = "parking_available";
        public const string LENGTH_COL = "length";
        public const string DIFFICULTY_COL = "difficulty";
        public const string DESCRIPTION_COL = "description";

        public SQLiteDatabase()
        {
            init();
        }

        private void init()
        {
            dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, DB_FILENAME);
            dbConnection = new SQLiteConnection(dbPath);
            dbConnection.CreateTable<Hike>();
        }
        public Hike getHike(int hikeId)
        {
            return dbConnection.Get<Hike>(hikeId);
        }
        public void insertHike(Hike hike)
        {
            dbConnection.Insert(hike);
        }
        public void deleteHike(Hike hike)
        {
            var targetHike = dbConnection.Table<Hike>().FirstOrDefault(h => h.Id == hike.Id);
            dbConnection.Delete(targetHike);
        }

        public void updateHike(Hike hike)
        {
            dbConnection.Update(hike);
        }
        public void deleteAllHike()
        {
            var hikeList = dbConnection.Table<Hike>().ToList();
            foreach (var hike in hikeList)
            {
                dbConnection.Delete<Hike>(hike.Id);
            }
        }

        public ObservableCollection<Hike> getHikeList()
        {
            return new ObservableCollection<Hike>(dbConnection.Table<Hike>().ToList());
        }

    }
}
