using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace The_Wet_Zone.ViewModels
{
    public class iconsHelp
    {
        public int idicon { get; set; }
        public ImageSource icon { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public iconsHelp(int ID, ImageSource Icon, string Title, string Descrition)
        {
            this.idicon = ID;
            this.icon = Icon;
            this.title = Title;
            this.description = Descrition;
        }
    }

    public class tipsInfo
    {
        public int idtip { get; set; }
        public string name { get; set; }
        public ImageSource photo { get; set; }
        public string description { get; set; }
    }

    public class country
    {
        public int idcountry { get; set; }
        public string name { get; set; }
        public ImageSource photo { get; set; }
    }

    public class place
    {
        public int idplace { get; set; }
        public ImageSource photo { get; set; }
        public string title { get; set; }
        public string descripcion { get; set; }
        public string telephone { get; set; }
        public int idcountry { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int idtype { get; set; }

/*        public place(int IdPlace, ImageSource Photo, string Title, string Description, string Telephone, int IdCountry, double Latitude, double Longitude, int IdType)
        {
            this.idplace = IdPlace;
            this.photo = Photo;
            this.title = Title;
            this.descripcion = Description;
            this.telephone = Telephone;
            this.idcountry = IdCountry;
            this.latitude = Latitude;
            this.longitude = Longitude;
            this.idtype = IdType;
        }*/
    }

    public class UserInfo {
        string name;
        string dui;
        string place;
        string sex;
        string blood;

        public string Username
        {
            get { return name; }
            set { name = value; }
        }
        public string DUI
        {
            get { return dui; }
            set { dui = value; }
        }
        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Blood
        {
            get { return blood; }
            set { blood = value; }
        }
    }

    public class UserMedicine {
        string alergies;
        public string Alergies
        {
            get { return alergies; }
            set { alergies = value; }
        }
    }

    public class UserContacts
    {
        string name1;
        string email1;
        string telephone1;
        string name2;
        string email2;
        string telephone2;

        public string Name1
        {
            get { return name1; }
            set { name1 = value; }
        }
        public string Email1
        {
            get { return email1; }
            set { email1 = value; }
        }
        public string Telephone1
        {
            get { return telephone1; }
            set { telephone1 = value; }
        }

        public string Name2
        {
            get { return name2; }
            set { name2 = value; }
        }
        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }
        public string Telephone2
        {
            get { return telephone2; }
            set { telephone2 = value; }
        }

    }

    public class FirstTime {
        bool activate;

        public bool Activate
        {
            get { return activate; }
            set { activate = value; }
        }
    }
}