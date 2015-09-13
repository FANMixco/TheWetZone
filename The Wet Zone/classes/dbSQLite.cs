using SQLite;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace The_Wet_Zone.classes
{
    public class countriesTable
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int idcountry { get; set; } 
        public string name { get; set; } 
        public string nationality { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double zoom { get; set; }
    }

    public class placesTable
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int idplace { get; set; }
        public string title { get; set; }
        public string descripcion { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
        public int idstate { get; set; } 
        public double latitude{ get; set; } 
        public double longitude{ get; set; } 
        public int idtype{ get; set; } 
    }

    public class tipsTable
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int idtip { get; set; }
        public string tip { get; set; }
        public string description { get; set; }
    }

    public class statesTable
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int idstate { get; set; }
        public string state { get; set; }
        public int idcountry { get; set; }
    }

    public class typesTable
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int idtype{ get; set; } 
        public string type{ get; set; } 
        public string description{ get; set; } 
    }

    public class usersTable
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int iduser { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string dui { get; set; } 
        public string sex { get; set; }
        public int idcountry { get; set; }
        public string blood { get; set; } 
        public string alergies { get; set; } 
        public string contact1 { get; set; } 
        public string phone1 { get; set; } 
        public string email1 { get; set; } 
        public string contact2 { get; set; } 
        public string phone2 { get; set; } 
        public string email2 { get; set; } 
    }

    public class sqliteDB
    {
        private string dbPath;
        public SQLiteConnection db;

        public sqliteDB()
        {
            this.dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
        }

        public void close()
        {
            db.Close();
        }

        public void createDB()
        {
            if (!FileExists("db.sqlite").Result)
            {
                open();
                using (this.db)
                {
                    this.db.CreateTable<countriesTable>();
                    this.db.CreateTable<placesTable>();
                    this.db.CreateTable<typesTable>();
                    this.db.CreateTable<usersTable>();
                    this.db.CreateTable<tipsTable>();
                    this.db.CreateTable<statesTable>();
                }
                setData();
            }
        }

        public void open() 
        {
            this.db = new SQLiteConnection(dbPath);
        }

        private void setData()
        {
            using (this.db = new SQLiteConnection(dbPath))
            {
                this.db.RunInTransaction(() =>
                {
                    for (int i = 0; i < App.ViewModel.countries.Count; i++)
                    {
                        var values = App.ViewModel.countries[i];
                        this.db.Insert(new countriesTable() { name = values.name, nationality = values.nationality, latitude = values.latitude, longitude = values.longitude, zoom = values.zoom });
                    }

                    for (int i = 0; i < App.ViewModel.typesData.Count; i++)
                    {
                        var values = App.ViewModel.typesData[i];
                        this.db.Insert(new typesTable() { type = values.type, description = values.description });
                    }

                    for (int i = 0; i < App.ViewModel.dataPlaces.Count; i++)
                    {
                        var values = App.ViewModel.dataPlaces[i];
                        this.db.Insert(new placesTable() { address=values.address, title = values.title, descripcion = values.descripcion, telephone = values.telephone, idstate = values.idstate, latitude = values.latitude, longitude = values.longitude, idtype = values.idtype });
                    }

                    for (int i = 0; i < App.ViewModel.tipsData.Count; i++)
                    {
                        var values = App.ViewModel.tipsData[i];
                        this.db.Insert(new tipsTable() { tip = values.name, description = values.description });
                    }

                    for (int i = 0; i < App.ViewModel.statesData.Count; i++)
                    {
                        var values = App.ViewModel.statesData[i];
                        this.db.Insert(new statesTable() { state = values.state, idcountry = values.idcountry });
                    }
                });
            }
        }

        private async Task<bool> FileExists(string fileName)
        {
            var result = false;
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                result = true;
            }
            catch
            {

            }

            return result;
        }
    }
}
