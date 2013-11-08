﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using The_Wet_Zone.Resources;

namespace The_Wet_Zone.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<placeTry> dataPlaces { get; private set; }

        public ObservableCollection<countryTry> countries { get; private set; }

        public ObservableCollection<tipsInfoTry> tipsData { get; private set; }
        public ObservableCollection<types> typesData{ get; private set; }
        
        public bool IsDataLoaded { get; private set; }

        public MainViewModel()
        {
            this.dataPlaces = new ObservableCollection<placeTry>();
            this.countries = new ObservableCollection<countryTry>();
            this.tipsData = new ObservableCollection<tipsInfoTry>();
            this.typesData = new ObservableCollection<types>();
        }


        public void LoadData()
        {
            //data tips
            tipsData.Add(new tipsInfoTry { name = "Señales SOS con fuego", description = "Hay que preparar tres montones de leña en un lugar claro y elevado cerca de nuestro campamento y tenerlas listas para encender el fuego en caso de que pase un avión o un equipo de rescate. Debemos preparar abundante yesca para que los fuegos prendan con facilidad y rapidez. Para ayudar a encenderlas podemos impregnar un paño en gasolina y añadirlo a la yesca, pero nunca echar ningún líquido inflamable directamente al fuego, pues el riesgo de que las llamas nos alcancen es altísimo. Antes de encenderlo debemos retirar del entorno cualquier recipiente con líquido inflamable. Si es posible, deberemos cubrirlas para que permanezcan secas hasta el momento de utilizarlas. De noche se verán mejor las llamas, pero durante el día es más visible el humo. En función de nuestras necesidades podemos obtener humo negro echando en el fuego paños impregnados en aceite de motor o quemando ruedas u otros objetos de goma. Para obtener humo blanco echaremos sobre el fuego hojas, hierbas verdes, musgo o helechos. El humo negro es más visible e días nublados o si nos encontramos en un lugar nevado o en el desierto; el blanco será más visible en un bosque y en días despejados." });
            tipsData.Add(new tipsInfoTry { name = "Obtener agua por las plantas", description = "En las selvas, las bromelias, que crecen sobre las ramas de los árboles, acumulan una reserva de agua entre sus hojas. Puede tener restos vegetales e insectos, pero es potable. El cacto berrel (Echinocactus grusonii) crece desde el sur de EEUU hasta Sudamérica, puede alcanzar un 120cm de altura y proporcionar un litro de líquido, que en algunas plantas carecerá de sabor y en otras será amargo. Algunas palmeras, como el cocotero, la birí y la nipa, contienen un líquido dulce que se puede beber. Hay que tener cuidado con la leche de los cocos maduros, ya que es un laxante bastante fuerte, y puede hacernos perder líquidos. En las otras palmeras, se doblan los tallos floridos hacia abajo y se corta el extremo para que fluya el líquido. Debemos cortar una rodaja fina del tallo cada 12 horas para que el líquido se renueve, lo que nos permite recoger un cuarto de litro cada día." });
            tipsData.Add(new tipsInfoTry { name = "Alimentarse con raíces y corteza", description = "Raíces y tubérculos: son las partes subterráneas de las plantas, por lo que deberemos escarbar para recolectarlas. Si no son fáciles de arrancar escarba alrededor y haz palanca con un palo. Hojas y tallos: Se recogen cuando son jóvenes, de color más pálido que el resto de la planta, ya que suelen ser más tiernos. No las desgarres ni las marchites en los desplazamientos. En ocasiones pueden ser algo amargos, en ese caso cambiaremos el agua (teñida de verde) y las coceremos de nuevo. Frutos: Los frutos secos son los más nutritivos y ricos en proteínas. También los frutos carnosos, como las moras o los arándanos son una importante fuente de alimento en la naturaleza. Las semillas y granos pueden molerse y mezclarse con agua como las gachas o tostarse. Debemos fijarnos en que las espigas de cereales no lleven cornezuelos (unas protuberancias negras en forma de judía) ya que son alucinógenos y extremadamente venenosos. Las cortezas: las cortezas interiores de algunos árboles, como determinadas especies de pinos, han sido empleadas en épocas de hambruna para hacer una especie de pan." });
            tipsData.Add(new tipsInfoTry { name = "Brújula sin Mapa", description = "Antes que nada, debes saber que las instrucciones que presentamos aquí son sólo para que comiences a aprender a usar una brújula. Entonces, comienza ejercitándote en un local fácil, como un parque o un lugar cerca de tu casa. ¡No te aventures en el bosque cerrado, porque sin gran experiencia existen muchas posibilidades de perderte! Ahora, vamos a las instrucciones. En primer lugar, nunca uses la brújula dentro del auto, cerca de objetos metálicos o circuitos eléctricos, porque interfieren en la medición. Sosteniendo la brújula horizontalmente, apunta la flecha de dirección hacia el lugar donde deseas ir –vamos a imaginar que sea una montaña. Gira el anillo graduado hasta que la flecha orientadora, la flecha guía, esté alineada con la parte roja de la aguja magnética. Anota el valor del azimut, que es el ángulo que aparece al pié de la flecha de dirección. Manteniendo la brújula horizontalmente, y la aguja magnética coincidente con el norte del mostrador, avanza en la dirección indicada por la flecha de dirección. Para regresar, es sólo mantener el mismo valor del azimut, aquel que anotaste a la ida. Después, apuntar la flecha de dirección hacia tí mismo y girar tu cuerpo hasta que la parte roja de la aguja quede alineada nuevamente con la flecha guía. Así, es sólo caminar en la dirección opuesta a la indicada por la flecha de dirección. Bueno, pero todo eso funciona muy bien en la teoría. En la práctica, puede ocurrir que tengas que desviarte del camino indicado por la brújula por causa de algún obstáculo. Por ejemplo: supón que te has desviado 100 metros del camino indicado. Si continúas siguiendo el valor del azimut, ¡pasarás a 100 metros de la montaña! ¡Es por eso que mucha gente se pierde al usar la brújula! Pero, en general, este aparato no se usa solo. Un mapa es fundamental y, muchas veces, sin él la brújula se vuelve realmente inútil…" });
            tipsData.Add(new tipsInfoTry { name = "Ruta de Trenes México", description = "Rutas migratorias utilizadas frecuentemente por los migrantes, dichas rutas pertenencen a diveros trenes que cruzan por todo México, entre las empresas de la ruta son FERROMEX." });

            //data countries
            countries.Add(new countryTry { name = "El Salvador", nationality = "Salvadoreño", latitude = 13.794185, longitude = -88.896530, zoom = 8 });
            countries.Add(new countryTry { name = "Guatemala", nationality = "Guatemalteco", latitude = 15.783471, longitude = -90.230759, zoom = 7 });
            countries.Add(new countryTry { name = "México", nationality = "Mexicano", latitude = 23.634502, longitude = -102.552784, zoom = 4.5 });
            countries.Add(new countryTry { name = "Estados Unidos", nationality = "US Americano", latitude = 37.102259, longitude = -95.712891, zoom = 3.5 });

            //data types
            typesData.Add(new types { type = "Albergue", description = "Lugar de hospedaje para los migrantes." });
            typesData.Add(new types { type = "Parada de Bus", description = "Paradas de diversas rutas de buses." });
            typesData.Add(new types { type = "Centro de Alimentación", description = "Lugares de alimentación para migrantes." });
            typesData.Add(new types { type = "Embajada", description = "Representación de El Salvador en diversos lugares." });
            typesData.Add(new types { type = "Iglesia", description = "Albergues provistos por Iglesias para dormir." });
            typesData.Add(new types { type = "ONG", description = "Organizaciones para apoyo a migrantes." });
            typesData.Add(new types { type = "Lugar Peligroso", description = "Lugares con mayor número de incidencias de peligro." });
            typesData.Add(new types { type = "Tren", description = "Estaciones de tren." });

            //data places
            dataPlaces.Add(new placeTry
            {
                title = "Catholic Relief Services",
                descripcion = "Ciudad de Guatemala",
                telephone = "50222565784",
                idcountry = 2,
                latitude = 14.479317,
                longitude = -89.640029,
                idtype = 1
            });

            dataPlaces.Add(new placeTry
            {
                title = "Casa del Inmigrante en Tecún Human",
                descripcion = "",
                telephone = "",
                idcountry = 2,
                latitude = 14.594474,
                longitude = -89.749241,
                idtype = 1
            });

            dataPlaces.Add(new placeTry
            {
                title = "Casa del Inmigrante, Ciudad de Guatemala",
                descripcion = "",
                telephone = "50222560084",
                idcountry = 2,
                latitude = 14.538613,
                longitude = -90.387807,
                idtype = 1
            });

            dataPlaces.Add(new placeTry
            {
                title = "Parroquia de Jesús de la Buena Esperanza",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.597222,
                longitude = -93.968056,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante Albergue Belén en Tapachula",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.563889,
                longitude = -94.201111,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Albergue de Jesús El Buen Pastor del Pobre y el Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.781111,
                longitude = -93.323056,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante Hogar de La Misericordia de Arriaga",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.439722,
                longitude = -98.006389,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Albergue Hermanos del Camino",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.712222,
                longitude = -96.405,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante Hermanos en el Camino",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.513611,
                longitude = -96.237222,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante Jesucristo Resucitado",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 17.5625,
                longitude = -91.238889,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa de Refugio para Migrantes La 72",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 17.536667,
                longitude = -91.149722,
                idtype = 1
            });

            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante Macuspana",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 18.266944,
                longitude = -95.349444,
                idtype = 1
            });

            dataPlaces.Add(new placeTry
            {
                title = "Albergue Decanal Guadalupano",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 18.358333,
                longitude = -95.557778,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Albergue La Sagrada Familia",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 19.521944,
                longitude = -97.011389,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Albergue Ejército de Salvación",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 19.209444,
                longitude = -97.238611,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante San Juan Diego",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 19.544722,
                longitude = -97.573333,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Emigrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 21.740278,
                longitude = -99.372222,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Albergue Parroquial de la Capilla Cristo Resucitado",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 22.475833,
                longitude = -98.417222,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa San Juan Diego y San Francisco de Asís",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 25.749167,
                longitude = -97.413333,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = " Albergue Nuestra Señora de Guadalupe ",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 25.901111,
                longitude = -97.8675,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante Nazareth",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 27.181389,
                longitude = -99.798889,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Centro de Apostolado San Nicolás Tolentino",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 23.046389,
                longitude = -99.754722,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante Mexicano Santa Martha",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 23.528611,
                longitude = -99.709444,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Asistencia Social y Juvenil",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 23.269722,
                longitude = -99.368611,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Frontera con Justicia",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 25.845556,
                longitude = -100.705278,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa Nazareth",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 30.956944,
                longitude = -111.071944,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Frontera y Dignidad de Acuña",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 26.322222,
                longitude = -101.843889,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Albergue Ejército de Salvación",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 24.099444,
                longitude = -106.532778,
                idtype = 1
            });

            //            29. Casa del Migrante en Juárez
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante en Juárez",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 31.53944,
                longitude = -106.65027,
                idtype = 1
            });
            // Centro de Atención al Migrante
            dataPlaces.Add(new placeTry
            {
                title = "Centro de Atención al Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 31.10611,
                longitude = -108.65138,
                idtype = 1
            });
            //31. Frontera Digna
            dataPlaces.Add(new placeTry
            {
                title = "Frontera Digna",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 26.54638,
                longitude = -101.6761,
                idtype = 1
            });
            //32. Centro Comunitario de atención al migrante y necesitado "CCAMyN"
            dataPlaces.Add(new placeTry
            {
                title = "Centro Comunitario de atención al migrante y necesitado CCAMyN",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 31.46361,
                longitude = -112.35972,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Casa Betania",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 32.25,
                longitude = -114.5975,
                idtype = 1
            });
            dataPlaces.Add(new placeTry
            {
                title = "Centro Pastoral Mana de Mexicali",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 32.22916,
                longitude = -114.7833,
                idtype = 1
            });
            //35. Albergue San Vicente
            dataPlaces.Add(new placeTry
            {
                title = "Albergue San Vicente",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 31.495,
                longitude = -115.58916,
                idtype = 1
            });
            //36. Instituto Madre Assunta (mujeres y niños migrantes)
            dataPlaces.Add(new placeTry
            {
                title = "Instituto Madre Assunta (mujeres y niños migrantes)",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 32.46027,
                longitude = -116.1794,
                idtype = 1
            });
            //37. Casa del Migrante 
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 32.44472,
                longitude = -116.56083,
                idtype = 1
            });
            //38. Casa del Migrante 
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 20.185,
                longitude = -100.71611,
                idtype = 1
            });
            //39. Albergue San Juan de Dios
            dataPlaces.Add(new placeTry
            {
                title = "Albergue San Juan de Dios",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 20.29805,
                longitude = -101.04972,
                idtype = 1
            });
            //40. Comedor del Migrante
            dataPlaces.Add(new placeTry
            {
                title = "Comedor del Migrante",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 19.43361,
                longitude = -103.35138,
                idtype = 1
            });
            //41. Casa del Migrante San Rafael
            dataPlaces.Add(new placeTry
            {
                title = "Casa del Migrante San Rafael",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 17.24666,
                longitude = -94.6866,
                idtype = 1
            });
            //42. Parroquia San Francisco de Asís
            dataPlaces.Add(new placeTry
            {
                title = "Parroquia San Francisco de Asís",
                descripcion = "Mexico",
                telephone = "",
                idcountry = 3,
                latitude = 16.86638,
                longitude = -92.69416,
                idtype = 1
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 2,
                latitude = 14.582204,
                longitude = -91.955443,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 15.566916,
                longitude = -92.608886,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 16.143814,
                longitude = -92.884957,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 16.756554,
                longitude = -92.990523,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 16.457623,
                longitude = -93.227974,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.352285,
                longitude = -93.618242,
                idtype = 7
            });


            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.483144,
                longitude = -94.179880,
                idtype = 7
            });


            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.990747,
                longitude = -94.426339,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.086096,
                longitude = -94.612392,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 16.434284,
                longitude = -94.336660,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.715944,
                longitude = -95.951886,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 17.352285,
                longitude = -93.618242,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 18.618366,
                longitude = -97.819789,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 19.088279,
                longitude = -98.519505,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 20.271176,
                longitude = -98.977036,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 23.757614,
                longitude = -100.654372,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 24.106394,
                longitude = -97.909698,
                idtype = 7
            });


            dataPlaces.Add(new placeTry
            {
                title = "Zona de Peligro",
                descripcion = "El Gobierno de El Salvador hace un llamado a sus ciudadanos de abstenerse de viajar de forma indocumentada hacia Estados Unidos, ya que es sumamente peligroso.",
                telephone = "",
                idcountry = 3,
                latitude = 25.528907,
                longitude = -98.551674,
                idtype = 7
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 2,
                latitude = 14.157367,
                longitude = -90.297458,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 15.181986,
                longitude = -90.297458,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 16.368089,
                longitude = -92.077066,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 15.907846,
                longitude = -93.779609,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 17.086592,
                longitude = -94.62629,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 17.791499,
                longitude = -94.915472,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 19.196731,
                longitude = -98.634884,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 3,
                latitude = 25.610753,
                longitude = -100.511585,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 29.162145,
                longitude = -95.539828,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 33.275324,
                longitude = -98.251679,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 31.587189,
                longitude = -110.454834,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 36.022075,
                longitude = -115.255998,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 32.702959,
                longitude = -116.410545,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 33.497534,
                longitude = -116.869778,
                idtype = 4
            });


            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 25.287188,
                longitude = -80.492027,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 32.266681,
                longitude = -83.637088,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 37.804401,
                longitude = -77.709425,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 38.007154,
                longitude = -78.294958,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 40.051536,
                longitude = -74.426710,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 40.676183,
                longitude = -74.720778,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 40.907549,
                longitude = -72.363091,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 42.122151,
                longitude = -70.950421,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 41.289861,
                longitude = -87.095699,
                idtype = 4
            });

            dataPlaces.Add(new placeTry
            {
                title = "Embajada de El Salvador",
                descripcion = "Representación de El Salvador en el Extranjero.",
                telephone = "",
                idcountry = 4,
                latitude = 38.420662,
                longitude = -122.303311,
                idtype = 4
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