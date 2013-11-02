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
            countries.Add(new country { idcountry = 1, name = "El Salvador" });
            countries.Add(new country { idcountry = 2, name = "Guatemala" });
            countries.Add(new country { idcountry = 3, name = "México" });

            hostals.Add(new place
            {
                idplace = 1,
                photo = new BitmapImage(new Uri("/Imagenes/comidas/pupusas.jpg", UriKind.Relative)),
                title = "Catholic Relief Services",
                descripcion = "Ciudad de Guatemala",
                telephone = "",
                idcountry = 2,
                latitude = 14.479317,
                longitude = -89.640029
            });

            hostals.Add(new place
            {
                idplace = 2,
                photo = new BitmapImage(new Uri("/Imagenes/comidas/pupusas.jpg", UriKind.Relative)),
                title = "Casa del Inmigrate en Tecún Human",
                descripcion = "",
                telephone = "",
                idcountry = 2,
                latitude = 14.594474,
                longitude = -89.749241
            });

            hostals.Add(new place
            {
                idplace = 3,
                photo = new BitmapImage(new Uri("/Imagenes/comidas/pupusas.jpg", UriKind.Relative)),
                title = "Casa del Inmigrate, Ciudad de Guatemala",
                descripcion = "",
                telephone = "",
                idcountry = 2,
                latitude = 14.538613,
                longitude = -90.387807
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