using Microsoft.Phone.Reactive;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using The_Wet_Zone.ViewModels;

namespace The_Wet_Zone.classes
{
    public class copyData
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int idcopy { get; set; }
        public DateTime dataDate { get; set; } 
    }

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
                    this.db.CreateTable<copyData>();
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

                    this.db.Insert(new copyData() { dataDate = Convert.ToDateTime("11/10/2013 08:10") });
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
            catch { }

            return result;
        }

        private void dataChanged()
        {
            WebClient wD = new WebClient();

            Observable
                .FromEvent<DownloadStringCompletedEventArgs>(wD, "DownloadStringCompleted")
                .Subscribe(r =>
                {

                    var dateCopy = JsonConvert.DeserializeObject<copyData>(r.EventArgs.Result);

                    sqliteDB tempDB = new sqliteDB();
                    tempDB.open();

                    string query = "SELECT * FROM copyData";
                    List<copyData> dataInside = tempDB.db.Query<copyData>(query);
                    tempDB.close();

                    //Check the actual copy of the data with the Online Copy
                    //If it's different it's going to update
                    if (dateCopy.dataDate != dataInside[0].dataDate)
                        checkData(dateCopy.dataDate);
                });
            wD.DownloadStringAsync(new Uri("http://thewetzone.tk/getDateCopy.php"));

        }

        private void checkData(DateTime dataDate)
        {
            WebClient w = new WebClient();

            Observable
                .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                .Subscribe(r =>
                {
                    var deserialized = JsonConvert.DeserializeObject<List<placesTable>>(r.EventArgs.Result);

                    sqliteDB tempDB = new sqliteDB();
                    tempDB.open();

                    string query = "SELECT * FROM placesTable";
                    List<placesTable> dataInside = tempDB.db.Query<placesTable>(query);
                    tempDB.close();

                    //Checks all the values that come from the Web Service
                    for (int i = 0; i < deserialized.Count; i++)
                    {
                        //Check if the idplace of both values is the same
                        if (deserialized[i].idplace == dataInside[i].idplace)
                        {
                            //If any of the values has changed, it updates the data inside
                            if (deserialized[i].address != dataInside[i].address || deserialized[i].descripcion != dataInside[i].descripcion || deserialized[i].idstate != dataInside[i].idstate || deserialized[i].idtype != dataInside[i].idtype || deserialized[i].latitude != dataInside[i].latitude || deserialized[i].longitude != dataInside[i].longitude || deserialized[i].title != dataInside[i].title || deserialized[i].telephone != dataInside[i].telephone)
                            {
                                updatePlace(deserialized[i], 1);

                                //Updates the copy of the Data
                                updateDate(dataDate);
                            }
                        }
                        else
                        {
                            sqliteDB checkPlace = new sqliteDB();
                            checkPlace.open();

                            List<result> exist = checkPlace.db.Query<result>("SELECT COUNT(idplace) total FROM placesTable WHERE idplace=" + deserialized[i].idplace);

                            //Check if the result is positive so it's going to delete the old data.
                            if (exist[0].total > 0)
                                deletePlace(deserialized[i].idplace);
                            //If the data doesn't exist, it register the newest values
                            else
                                updatePlace(deserialized[i], 0);

                            //Updates the copy of the Data
                            updateDate(dataDate);
                        }
                    }

                });
            w.DownloadStringAsync(new Uri("http://thewetzone.tk/checkAllData.php"));
        }

        private void updateDate(DateTime newDate)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                var existing = db.Query<copyData>("SELECT * FROM copyData").FirstOrDefault();
                if (existing != null)
                {
                    existing.dataDate = newDate;

                    this.db.RunInTransaction(() =>
                    {
                        db.Update(existing);
                    });
                }
            }
        }

        private void deletePlace(int idplace)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                var existing = db.Query<placesTable>("SELECT * FROM placesTable WHERE idplace=" + idplace).FirstOrDefault();
                if (existing != null)
                {
                    this.db.RunInTransaction(() =>
                    {
                        db.Delete(existing);
                    });
                }
            }
        }

        private void updatePlace(placesTable values, int action)
        {
            //Insert Data
            if (action == 0)
            {
                using (this.db = new SQLiteConnection(dbPath))
                {
                    this.db.RunInTransaction(() =>
                    {
                        this.db.Insert(new placesTable() { address = values.address, title = values.title, descripcion = values.descripcion, telephone = values.telephone, idstate = values.idstate, latitude = values.latitude, longitude = values.longitude, idtype = values.idtype });
                    });
                }
            }
            // Update Data
            else
            {
                using (var db = new SQLiteConnection(dbPath))
                {
                    var existing = db.Query<placesTable>("SELECT * FROM placesTable WHERE idplace=" + values.idplace).FirstOrDefault();
                    if (existing != null)
                    {
                        existing.address = values.address;
                        existing.descripcion = values.descripcion;
                        existing.idstate = values.idstate;
                        existing.idtype = values.idtype;
                        existing.latitude = values.latitude;
                        existing.longitude = values.longitude;
                        existing.telephone = values.telephone;
                        existing.title = values.title;

                        this.db.RunInTransaction(() =>
                        {
                            db.Update(existing);
                        });
                    }
                }
            }
        }
    }
}
