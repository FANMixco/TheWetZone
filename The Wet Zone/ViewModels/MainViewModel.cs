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

        public ObservableCollection<tipsInfo> tipsData { get; private set; }
        
        public bool IsDataLoaded { get; private set; }

        public MainViewModel()
        {
            this.hostals = new ObservableCollection<place>();
            this.warnings = new ObservableCollection<place>();
            this.embassies = new ObservableCollection<place>();
            this.trains = new ObservableCollection<place>();
            this.water = new ObservableCollection<place>();
            this.countries = new ObservableCollection<country>();
            this.tipsData = new ObservableCollection<tipsInfo>();
        }


        public void LoadData()
        {
            tipsData.Add(new tipsInfo {idtip=1, name="Señales SOS con fuego", photo = new BitmapImage(new Uri("/Img/tips/01.jpg", UriKind.Relative)), description= "Hay que preparar tres montones de leña en un lugar claro y elevado cerca de nuestro campamento y tenerlas listas para encender el fuego en caso de que pase un avión o un equipo de rescate. Debemos preparar abundante yesca para que los fuegos prendan con facilidad y rapidez. Para ayudar a encenderlas podemos impregnar un paño en gasolina y añadirlo a la yesca, pero nunca echar ningún líquido inflamable directamente al fuego, pues el riesgo de que las llamas nos alcancen es altísimo. Antes de encenderlo debemos retirar del entorno cualquier recipiente con líquido inflamable. Si es posible, deberemos cubrirlas para que permanezcan secas hasta el momento de utilizarlas. De noche se verán mejor las llamas, pero durante el día es más visible el humo. En función de nuestras necesidades podemos obtener humo negro echando en el fuego paños impregnados en aceite de motor o quemando ruedas u otros objetos de goma. Para obtener humo blanco echaremos sobre el fuego hojas, hierbas verdes, musgo o helechos. El humo negro es más visible e días nublados o si nos encontramos en un lugar nevado o en el desierto; el blanco será más visible en un bosque y en días despejados." });
            tipsData.Add(new tipsInfo { idtip = 2, name = "Obtener agua por las plantas", photo = new BitmapImage(new Uri("/Img/tips/02.jpg", UriKind.Relative)), description = "En las selvas, las bromelias, que crecen sobre las ramas de los árboles, acumulan una reserva de agua entre sus hojas. Puede tener restos vegetales e insectos, pero es potable. El cacto berrel (Echinocactus grusonii) crece desde el sur de EEUU hasta Sudamérica, puede alcanzar un 120cm de altura y proporcionar un litro de líquido, que en algunas plantas carecerá de sabor y en otras será amargo. Algunas palmeras, como el cocotero, la birí y la nipa, contienen un líquido dulce que se puede beber. Hay que tener cuidado con la leche de los cocos maduros, ya que es un laxante bastante fuerte, y puede hacernos perder líquidos. En las otras palmeras, se doblan los tallos floridos hacia abajo y se corta el extremo para que fluya el líquido. Debemos cortar una rodaja fina del tallo cada 12 horas para que el líquido se renueve, lo que nos permite recoger un cuarto de litro cada día." });
            tipsData.Add(new tipsInfo { idtip = 3, name = "Alimentarse con raíces y corteza", photo = new BitmapImage(new Uri("/Img/tips/03.jpg", UriKind.Relative)), description = "Raíces y tubérculos: son las partes subterráneas de las plantas, por lo que deberemos escarbar para recolectarlas. Si no son fáciles de arrancar escarba alrededor y haz palanca con un palo. Hojas y tallos: Se recogen cuando son jóvenes, de color más pálido que el resto de la planta, ya que suelen ser más tiernos. No las desgarres ni las marchites en los desplazamientos. En ocasiones pueden ser algo amargos, en ese caso cambiaremos el agua (teñida de verde) y las coceremos de nuevo. Frutos: Los frutos secos son los más nutritivos y ricos en proteínas. También los frutos carnosos, como las moras o los arándanos son una importante fuente de alimento en la naturaleza. Las semillas y granos pueden molerse y mezclarse con agua como las gachas o tostarse. Debemos fijarnos en que las espigas de cereales no lleven cornezuelos (unas protuberancias negras en forma de judía) ya que son alucinógenos y extremadamente venenosos. Las cortezas: las cortezas interiores de algunos árboles, como determinadas especies de pinos, han sido empleadas en épocas de hambruna para hacer una especie de pan." });

            countries.Add(new country { idcountry = 1, name = "El Salvador", photo = new BitmapImage(new Uri("/Img/flags/sv.png", UriKind.Relative)) });
            countries.Add(new country { idcountry = 2, name = "Guatemala", photo = new BitmapImage(new Uri("/Img/flags/gt.png", UriKind.Relative)) });
            countries.Add(new country { idcountry = 3, name = "México", photo = new BitmapImage(new Uri("/Img/flags/mx.png", UriKind.Relative)) });
            countries.Add(new country { idcountry = 4, name = "Estados Unidos", photo = new BitmapImage(new Uri("/Img/flags/us.jpg", UriKind.Relative)) });

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
                latitude = 16.597222,
                longitude = -93.968056,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 5,
                photo = new BitmapImage(new Uri("/Img/hostels/5.jpg", UriKind.Relative)),
                title = "Casa del Migrante Albergue Belén en Tapachula",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.563889,
                longitude = -94.201111,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 6,
                photo = new BitmapImage(new Uri("/Img/hostels/6.jpg", UriKind.Relative)),
                title = "Albergue de Jesús El Buen Pastor del Pobre y el Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.781111,
                longitude = -93.323056,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 7,
                photo = new BitmapImage(new Uri("/Img/hostels/7.jpg", UriKind.Relative)),
                title = "Casa del Migrante Hogar de La Misericordia de Arriaga",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.439722,
                longitude = -98.006389,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 8,
                photo = new BitmapImage(new Uri("/Img/hostels/8.jpg", UriKind.Relative)),
                title = "Albergue Hermanos del Camino",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.712222,
                longitude = -96.405,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 9,
                photo = new BitmapImage(new Uri("/Img/hostels/9.jpg", UriKind.Relative)),
                title = "Casa del Migrante Hermanos en el Camino",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.513611,
                longitude = -96.237222,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 10,
                photo = new BitmapImage(new Uri("/Img/hostels/10.jpg", UriKind.Relative)),
                title = "Casa del Migrante Jesucristo Resucitado",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 17.5625,
                longitude = -91.238889,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 11,
                photo = new BitmapImage(new Uri("/Img/hostels/11.jpg", UriKind.Relative)),
                title = "Casa de Refugio para Migrantes La 72",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 17.536667,
                longitude = 91.149722,
                idtype = 0
            });

            hostals.Add(new place
{
    idplace = 12,
    photo = new BitmapImage(new Uri("/Img/hostels/12.jpg", UriKind.Relative)),
    title = "Casa del Migrante Macuspana",
    descripcion = "Mexico",
    telephone = "",
    idcountry = 3,
    latitude = 18.266944,
    longitude = -95.349444,
    idtype = 0
});

            hostals.Add(new place
            {
                idplace = 13,
                photo = new BitmapImage(new Uri("/Img/hostels/13.jpg", UriKind.Relative)),
                title = "Albergue Decanal Guadalupano",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 18.358333,
                longitude = -95.557778,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 14,
                photo = new BitmapImage(new Uri("/Img/hostels/14.jpg", UriKind.Relative)),
                title = "Albergue La Sagrada Familia",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 19.521944,
                longitude = -97.011389,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 15,
                photo = new BitmapImage(new Uri("/Img/hostels/15.jpg", UriKind.Relative)),
                title = "Albergue Ejército de Salvación",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 19.209444,
                longitude = -97.238611,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 16,
                photo = new BitmapImage(new Uri("/Img/hostels/16.jpg", UriKind.Relative)),
                title = "Casa del Migrante San Juan Diego",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 19.544722,
                longitude = -97.573333,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 17,
                photo = new BitmapImage(new Uri("/Img/hostels/17.jpg", UriKind.Relative)),
                title = "Casa del Emigrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 21.740278,
                longitude = -99.372222,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 18,
                photo = new BitmapImage(new Uri("/Img/hostels/18.jpg", UriKind.Relative)),
                title = "Albergue Parroquial de la Capilla Cristo Resucitado",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 22.475833,
                longitude = -98.417222,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 19,
                photo = new BitmapImage(new Uri("/Img/hostels/19.jpg", UriKind.Relative)),
                title = "Casa San Juan Diego y San Francisco de Asís",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 25.749167,
                longitude = -97.413333,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 20,
                photo = new BitmapImage(new Uri("/Img/hostels/20.jpg", UriKind.Relative)),
                title = " Albergue Nuestra Señora de Guadalupe ",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 25.901111,
                longitude = -97.8675,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 21,
                photo = new BitmapImage(new Uri("/Img/hostels/21.jpg", UriKind.Relative)),
                title = "Casa del Migrante Nazareth",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 27.181389,
                longitude = -99.798889,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 22,
                photo = new BitmapImage(new Uri("/Img/hostels/22.jpg", UriKind.Relative)),
                title = "Centro de Apostolado San Nicolás Tolentino",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 23.046389,
                longitude = -99.754722,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 23,
                photo = new BitmapImage(new Uri("/Img/hostels/23.jpg", UriKind.Relative)),
                title = "Casa del Migrante Mexicano Santa Martha",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 23.528611,
                longitude = -99.709444,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 24,
                photo = new BitmapImage(new Uri("/Img/hostels/24.jpg", UriKind.Relative)),
                title = "Asistencia Social y Juvenil",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 23.269722,
                longitude = -99.368611,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 25,
                photo = new BitmapImage(new Uri("/Img/hostels/25.jpg", UriKind.Relative)),
                title = "Frontera con Justicia",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 25.845556,
                longitude = -100.705278,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 26,
                photo = new BitmapImage(new Uri("/Img/hostels/26.jpg", UriKind.Relative)),
                title = "Casa Nazareth",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 30.956944,
                longitude = -111.071944,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 27,
                photo = new BitmapImage(new Uri("/Img/hostels/27.jpg", UriKind.Relative)),
                title = "Frontera y Dignidad de Acuña",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 26.322222,
                longitude = -101.843889,
                idtype = 0
            });
            hostals.Add(new place
            {
                idplace = 28,
                photo = new BitmapImage(new Uri("/Img/hostels/28.jpg", UriKind.Relative)),
                title = "Albergue Ejército de Salvación",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 24.099444,
                longitude = -106.532778,
                idtype = 0
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
                latitude = 31.53944,
                longitude = -106.65027,
                idtype = 0
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
                latitude = 31.10611,
                longitude = -108.65138,
                idtype = 0
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
                latitude = 26.54638,
                longitude = -101.6761,
                idtype = 0
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
                latitude = 31.46361,
                longitude = -112.35972,
                idtype = 0
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
                latitude = 32.25,
                longitude = -114.5975,
                idtype = 0
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
                latitude = 32.22916,
                longitude = -114.7833,
                idtype = 0
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
                latitude = 31.495,
                longitude = -115.58916,
                idtype = 0
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
                latitude = 32.46027,
                longitude = -116.1794,
                idtype = 0
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
                latitude = 32.44472,
                longitude = -116.56083,
                idtype = 0
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
                latitude = 20.185,
                longitude = -100.71611,
                idtype = 0
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
                latitude = 20.29805,
                longitude = -101.04972,
                idtype = 0
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
                latitude = 19.43361,
                longitude = -103.35138,
                idtype = 0
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
                latitude = 17.24666,
                longitude = -94.6866,
                idtype = 0
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
                latitude = 16.86638,
                longitude = -92.69416,
                idtype = 0
            });

            warnings.Add(new place
            {
                idplace = 1,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 2,
                latitude = 14.582204,
                longitude = -91.955443,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 2,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 15.566916,
                longitude = -92.608886,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 3,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 16.143814,
                longitude = -92.884957,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 4,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 16.756554,
                longitude = -92.990523,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 5,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 16.457623,
                longitude = -93.227974,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 6,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.352285,
                longitude = -93.618242,
                idtype = 6
            });


            warnings.Add(new place
            {
                idplace = 7,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.483144,
                longitude = -94.179880,
                idtype = 6
            });


            warnings.Add(new place
            {
                idplace = 8,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.990747,
                longitude = -94.426339,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 9,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.086096,
                longitude = -94.612392,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 10,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 16.434284,
                longitude = -94.336660,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 11,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.715944,
                longitude = -95.951886,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 12,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.352285,
                longitude = -93.618242,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 13,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 18.618366,
                longitude = -97.819789,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 14,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 19.088279,
                longitude = -98.519505,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 15,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 20.271176,
                longitude = -98.977036,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 16,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 23.757614,
                longitude = -100.654372,
                idtype = 6
            });

            warnings.Add(new place
            {
                idplace = 17,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 24.106394,
                longitude = -97.909698,
                idtype = 6
            });


            warnings.Add(new place
            {
                idplace = 18,
                photo = new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)),
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 25.528907,
                longitude = -98.551674,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 1,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 2,
                latitude = 14.157367,
                longitude = -90.297458,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 2,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 15.181986,
                longitude = -90.297458,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 3,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 16.368089,
                longitude = -92.077066,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 4,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 15.907846,
                longitude = -93.779609,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 5,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 17.086592,
                longitude = -94.62629,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 6,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 17.791499,
                longitude = -94.915472,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 7,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 19.196731,
                longitude = -98.634884,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 8,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 25.610753,
                longitude = -100.511585,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 9,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 29.162145,
                longitude = -95.539828,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 10,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 33.275324,
                longitude = -98.251679,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 11,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 31.587189,
                longitude = -110.454834,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 12,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 36.022075,
                longitude = -115.255998,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 13,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 32.702959,
                longitude = -116.410545,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 14,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 33.497534,
                longitude = -116.869778,
                idtype = 6
            });


            embassies.Add(new place
            {
                idplace = 15,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 25.287188,
                longitude = -80.492027,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 16,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 32.266681,
                longitude = -83.637088,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 17,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 37.804401,
                longitude = -77.709425,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 18,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 38.007154,
                longitude = -78.294958,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 19,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 40.051536,
                longitude = -74.426710,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 20,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 40.676183,
                longitude = -74.720778,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 21,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 40.907549,
                longitude = -72.363091,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 22,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 42.122151,
                longitude = -70.950421,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 14,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 41.289861,
                longitude = -87.095699,
                idtype = 6
            });

            embassies.Add(new place
            {
                idplace = 23,
                photo = new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)),
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 38.420662,
                longitude = -122.303311,
                idtype = 6
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