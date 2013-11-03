using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using The_Wet_Zone.Resources;

namespace The_Wet_Zone.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<place> hostals { get; private set; }
        public ObservableCollection<place> warnings { get; private set; }
        public ObservableCollection<place> embassies { get; private set; }
        public ObservableCollection<place> trains { get; private set; }
        public ObservableCollection<place> water { get; private set; }

        public ObservableCollection<country> countries { get; private set; }
        public bool IsDataLoaded { get; private set; }

        public MainViewModel()
        {
            this.hostals = new ObservableCollection<place>();
            this.countries = new ObservableCollection<country>();
        }


        public void LoadData()
        {
            countries.Add(new country { idcountry = 1, name = "El Salvador" ,photo = new BitmapImage(new Uri("/Img/flags/sv.png", UriKind.Relative))});
            countries.Add(new country { idcountry = 2, name = "Guatemala", photo = new BitmapImage(new Uri("/Img/flags/gt.png", UriKind.Relative)) });
            countries.Add(new country { idcountry = 3, name = "México", photo = new BitmapImage(new Uri("/Img/flags/mx.png", UriKind.Relative)) });
            countries.Add(new country { idcountry = 4, name = "Estados Unidos", photo = new BitmapImage(new Uri("/Img/flags/us.png", UriKind.Relative)) });

            hostals.Add(new place
            {
                idplace = 1,
                photo = new BitmapImage(new Uri("/Img/hostels/1.jpg", UriKind.Relative)),
                title = "Catholic Relief Services",
                descripcion = "Ciudad de Guatemala",
                telephone = "",
                idcountry = 2,
                latitude = 14.479317,
                longitude = -89.640029,
                idtype = 0
            });

            hostals.Add(new place
            {
                idplace = 2,
                photo = new BitmapImage(new Uri("/Img/hostels/2.jpg", UriKind.Relative)),
                title = "Casa del Inmigrante en Tecún Human",
                descripcion = "",
                telephone = "",
                idcountry = 2,
                latitude = 14.594474,
                longitude = -89.749241,
                idtype = 0
            });

            hostals.Add(new place
            {
                idplace = 3,
                photo = new BitmapImage(new Uri("/Img/hostels/3.jpg", UriKind.Relative)),
                title = "Casa del Inmigrante, Ciudad de Guatemala",
                descripcion = "",
                telephone = "",
                idcountry = 2,
                latitude = 14.538613,
                longitude = -90.387807,
                idtype = 0
            });

            hostals.Add(new place
            {
                idplace = 4,
                photo = new BitmapImage(new Uri("/Img/hostels/4.jpg", UriKind.Relative)),
                title = "Parroquia de Jesús de la Buena Esperanza",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =  16.597222,
                longitude =  -93.968056
            });
            hostals.Add(new place
            {
                idplace = 5,
                photo = new BitmapImage(new Uri("/Img/hostels/5.jpg", UriKind.Relative)),
                title = "Casa del Migrante Albergue Belén en Tapachula",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =   16.563889,
                longitude =   -94.201111
            });
            hostals.Add(new place
            {
                idplace = 6,
                photo = new BitmapImage(new Uri("/Img/hostels/6.jpg", UriKind.Relative)),
                title = "Albergue de Jesús El Buen Pastor del Pobre y el Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =    16.781111,
                longitude =    -93.323056
            });
            hostals.Add(new place
            {
                idplace = 7,
                photo = new BitmapImage(new Uri("/Img/hostels/7.jpg", UriKind.Relative)),
                title = "Casa del Migrante Hogar de La Misericordia de Arriaga",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     16.439722,
                longitude =     -98.006389
            });
            hostals.Add(new place
            {
                idplace = 8,
                photo = new BitmapImage(new Uri("/Img/hostels/8.jpg", UriKind.Relative)),
                title = "Albergue Hermanos del Camino",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =      16.712222,
                longitude =     -96.405
            });
            hostals.Add(new place
            {
                idplace = 9,
                photo = new BitmapImage(new Uri("/Img/hostels/9.jpg", UriKind.Relative)),
                title = "Casa del Migrante Hermanos en el Camino",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =  16.513611,
                longitude =  -96.237222
            });
            hostals.Add(new place
            {
                idplace = 10,
                photo = new BitmapImage(new Uri("/Img/hostels/10.jpg", UriKind.Relative)),
                title = "Casa del Migrante Jesucristo Resucitado",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =   17.5625,
                longitude =   -91.238889
            });
            hostals.Add(new place
            {
                idplace = 11,
                photo = new BitmapImage(new Uri("/Img/hostels/11.jpg", UriKind.Relative)),
                title = "Casa de Refugio para Migrantes La 72",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =    17.536667,
                longitude =    91.149722
            });

                        hostals.Add(new place
            {
                idplace = 12,
                photo = new BitmapImage(new Uri("/Img/hostels/12.jpg", UriKind.Relative)),
                title = "Casa del Migrante Macuspana",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =    18.266944,
                longitude =   - 95.349444
            });

            hostals.Add(new place
            {
                idplace = 13,
                photo = new BitmapImage(new Uri("/Img/hostels/13.jpg", UriKind.Relative)),
                title = "Albergue Decanal Guadalupano",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =    18.358333,
                longitude =    -95.557778
            });
            hostals.Add(new place
            {
                idplace = 14,
                photo = new BitmapImage(new Uri("/Img/hostels/14.jpg", UriKind.Relative)),
                title = "Albergue La Sagrada Familia",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =    19.521944,
                longitude =    -97.011389
            });
            hostals.Add(new place
            {
                idplace = 15,
                photo = new BitmapImage(new Uri("/Img/hostels/15.jpg", UriKind.Relative)),
                title = "Albergue Ejército de Salvación",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =    19.209444,
                longitude =    - 97.238611
            });
            hostals.Add(new place
            {
                idplace = 16,
                photo = new BitmapImage(new Uri("/Img/hostels/16.jpg", UriKind.Relative)),
                title = "Casa del Migrante San Juan Diego",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =    19.544722,
                longitude =     -97.573333
            });
            hostals.Add(new place
            {
                idplace = 17,
                photo = new BitmapImage(new Uri("/Img/hostels/17.jpg", UriKind.Relative)),
                title = "Casa del Emigrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     21.740278,
                longitude =     -99.372222
            });
            hostals.Add(new place
            {
                idplace = 18,
                photo = new BitmapImage(new Uri("/Img/hostels/18.jpg", UriKind.Relative)),
                title = "Albergue Parroquial de la Capilla Cristo Resucitado",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     22.475833,
                longitude =     -98.417222
            });
            hostals.Add(new place
            {
                idplace = 19,
                photo = new BitmapImage(new Uri("/Img/hostels/19.jpg", UriKind.Relative)),
                title = "Casa San Juan Diego y San Francisco de Asís",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     25.749167,
                longitude =     -97.413333
            });
            hostals.Add(new place
            {
                idplace = 20,
                photo = new BitmapImage(new Uri("/Img/hostels/20.jpg", UriKind.Relative)),
                title = " Albergue Nuestra Señora de Guadalupe ",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     25.901111,
                longitude =     -97.8675
            });
            hostals.Add(new place
            {
                idplace = 21,
                photo = new BitmapImage(new Uri("/Img/hostels/21.jpg", UriKind.Relative)),
                title = "Casa del Migrante Nazareth",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =       27.181389,
                longitude =        -99.798889
            });
            hostals.Add(new place
            {
                idplace = 22,
                photo = new BitmapImage(new Uri("/Img/hostels/22.jpg", UriKind.Relative)),
                title = "Centro de Apostolado San Nicolás Tolentino",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =       23.046389,
                longitude =        -99.754722
            });
            hostals.Add(new place
            {
                idplace = 23,
                photo = new BitmapImage(new Uri("/Img/hostels/23.jpg", UriKind.Relative)),
                title = "Casa del Migrante Mexicano Santa Martha",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =       23.528611,
                longitude =       -99.709444
            });
            hostals.Add(new place
            {
                idplace = 24,
                photo = new BitmapImage(new Uri("/Img/hostels/24.jpg", UriKind.Relative)),
                title = "Asistencia Social y Juvenil",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =      23.269722,
                longitude =      -99.368611
            });
            hostals.Add(new place
            {
                idplace = 25,
                photo = new BitmapImage(new Uri("/Img/hostels/25.jpg", UriKind.Relative)),
                title = "Frontera con Justicia",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =      25.845556,
                longitude =     -100.705278
            });
            hostals.Add(new place
            {
                idplace = 26,
                photo = new BitmapImage(new Uri("/Img/hostels/26.jpg", UriKind.Relative)),
                title = "Casa Nazareth",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     30.956944,
                longitude =     -111.071944
            });
            hostals.Add(new place
            {
                idplace = 27,
                photo = new BitmapImage(new Uri("/Img/hostels/27.jpg", UriKind.Relative)),
                title = "Frontera y Dignidad de Acuña",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =      26.322222,
                longitude =     -101.843889
            });
            hostals.Add(new place
            {
                idplace = 28,
                photo = new BitmapImage(new Uri("/Img/hostels/28.jpg", UriKind.Relative)),
                title = "Albergue Ejército de Salvación",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     24.099444,
                longitude =     -106.532778
            });

//            29. Casa del Migrante en Juárez
            hostals.Add(new place
            {
                idplace = 29,
                photo = new BitmapImage(new Uri("/Img/hostels/29.jpg", UriKind.Relative)),
                title = "Casa del Migrante en Juárez",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     31.53944,
                longitude =     - 106.65027
            });
// Centro de Atención al Migrante
            hostals.Add(new place
            {
                idplace = 30,
                photo = new BitmapImage(new Uri("/Img/hostels/30.jpg", UriKind.Relative)),
                title = "Centro de Atención al Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     31.10611,
                longitude =     - 108.65138
            });
//31. Frontera Digna
            hostals.Add(new place
            {
                idplace = 31,
                photo = new BitmapImage(new Uri("/Img/hostels/31.jpg", UriKind.Relative)),
                title = "Frontera Digna",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =      26.54638,
                longitude =     - 101.6761
            });
//32. Centro Comunitario de atención al migrante y necesitado "CCAMyN"
            hostals.Add(new place
            {
                idplace = 32,
                photo = new BitmapImage(new Uri("/Img/hostels/32.jpg", UriKind.Relative)),
                title = "Centro Comunitario de atención al migrante y necesitado CCAMyN",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     31.46361,
                longitude =     - 112.35972
            });
//33. "Casa Betania" 
            hostals.Add(new place
            {
                idplace = 33,
                photo = new BitmapImage(new Uri("/Img/hostels/33.jpg", UriKind.Relative)),
                title = "Casa Betania",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     32.25,
                longitude =     - 114.5975
            });
//34. Centro Pastoral Mana de Mexicali 
            hostals.Add(new place
            {
                idplace = 34,
                photo = new BitmapImage(new Uri("/Img/hostels/34.jpg", UriKind.Relative)),
                title = "Centro Pastoral Mana de Mexicali",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     32.22916,
                longitude =     - 114.7833
            });
//35. Albergue San Vicente
            hostals.Add(new place
            {
                idplace = 35,
                photo = new BitmapImage(new Uri("/Img/hostels/35.jpg", UriKind.Relative)),
                title = "Albergue San Vicente",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     31.495,
                longitude =     -115.58916
            });
//36. Instituto Madre Assunta (mujeres y niños migrantes)
            hostals.Add(new place
            {
                idplace = 36,
                photo = new BitmapImage(new Uri("/Img/hostels/36.jpg", UriKind.Relative)),
                title = "Instituto Madre Assunta (mujeres y niños migrantes)",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     32.46027,
                longitude =     -116.1794
            });
//37. Casa del Migrante 
            hostals.Add(new place
            {
                idplace = 37,
                photo = new BitmapImage(new Uri("/Img/hostels/37.jpg", UriKind.Relative)),
                title = "Casa del Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     32.44472,
                longitude =     - 116.56083
            });
//38. Casa del Migrante 
            hostals.Add(new place
            {
                idplace = 38,
                photo = new BitmapImage(new Uri("/Img/hostels/38.jpg", UriKind.Relative)),
                title = "Casa del Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     20.185,
                longitude =     - 100.71611
            });
//39. Albergue San Juan de Dios
            hostals.Add(new place
            {
                idplace = 39,
                photo = new BitmapImage(new Uri("/Img/hostels/39.jpg", UriKind.Relative)),
                title = "Albergue San Juan de Dios",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     20.29805,
                longitude =     - 101.04972
            });
//40. Comedor del Migrante
            hostals.Add(new place
            {
                idplace = 40,
                photo = new BitmapImage(new Uri("/Img/hostels/40.jpg", UriKind.Relative)),
                title = "Comedor del Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =      19.43361,
                longitude =     -103.35138
            });
//41. Casa del Migrante San Rafael
            hostals.Add(new place
            {
                idplace = 41,
                photo = new BitmapImage(new Uri("/Img/hostels/41.jpg", UriKind.Relative)),
                title = "Casa del Migrante San Rafael",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     17.24666,
                longitude =     - 94.6866
            });
//42. Parroquia San Francisco de Asís
            hostals.Add(new place
            {
                idplace = 42,
                photo = new BitmapImage(new Uri("/Img/hostels/42.jpg", UriKind.Relative)),
                title = "Parroquia San Francisco de Asís",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude =     16.86638,
                longitude =     - 92.69416
            });	


            this.IsDataLoaded = true;
        }

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}