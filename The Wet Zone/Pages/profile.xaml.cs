using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using The_Wet_Zone.ViewModels;

namespace The_Wet_Zone.Pages
{
    public partial class profile : PhoneApplicationPage
    {
        public profile()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Initialize the session here
            // Write to the Isolated Storage
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("user.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        serializer.Serialize(xmlWriter, GeneratePersonData());
                    }
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Initialize the session here
            // Write to the Isolated Storage
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("medicine.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<UserMedicine>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        serializer.Serialize(xmlWriter, GenerateMedicineData());
                    }
                }
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Initialize the session here
            // Write to the Isolated Storage
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("contacts.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<UserContacts>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        serializer.Serialize(xmlWriter, GenerateContactsData());
                    }
                }
            }

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("user.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                        List<UserInfo> data = (List<UserInfo>)serializer.Deserialize(stream);
                        txtName.Text = data[0].Username;
                        txtDUI.Text = data[0].DUI;
                        cmbOrigin.SelectedItem = data[0].Place;
                        cmbBlood.SelectedItem = data[0].Blood;
                        cmbSex.SelectedItem = data[0].Sex;
                    }
                }
            }
            catch
            {
                txtName.Text = "";
                txtDUI.Text = "";
            }

            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("medicine.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<UserMedicine>));
                        List<UserMedicine> data = (List<UserMedicine>)serializer.Deserialize(stream);
                        txtAlergies.Text = data[0].Alergies;
                    }
                }
            }
            catch
            {
                txtAlergies.Text = "";
            }

            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("contacts.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<UserContacts>));
                        List<UserContacts> data = (List<UserContacts>)serializer.Deserialize(stream);
                        txtC1.Text = data[0].Name1;
                        txtEC1.Text = data[0].Email1;
                        txtTC1.Text = data[0].Telephone1;

                        txtC2.Text = data[0].Name2;
                        txtEC2.Text = data[0].Email2;
                        txtTC2.Text = data[0].Telephone2;
                    }
                }
            }
            catch
            {
                txtC1.Text = "";
                txtEC1.Text = "";
                txtTC1.Text = "";

                txtC2.Text = "";
                txtEC2.Text = "";
                txtTC2.Text = "";
            }
        }

        private List<UserInfo> GeneratePersonData()
        {
            List<UserInfo> data = new List<UserInfo>();
            UserInfo ui = new UserInfo();

            ui.Username = txtName.Text;
            ui.DUI = txtDUI.Text;
            ui.Place = cmbOrigin.SelectedItem.ToString();
            ui.Sex = cmbSex.SelectedItem.ToString();
            ui.Blood = cmbBlood.SelectedItem.ToString();

            data.Add(ui);
            return data;
        }

        private List<UserMedicine> GenerateMedicineData()
        {
            List<UserMedicine> data = new List<UserMedicine>();
            UserMedicine ui = new UserMedicine();

            ui.Alergies = txtAlergies.Text;

            data.Add(ui);
            return data;
        }

        private List<UserContacts> GenerateContactsData()
        {
            List<UserContacts> data = new List<UserContacts>();
            UserContacts ui = new UserContacts();

            ui.Name1 = txtC1.Text;
            ui.Email1 = txtEC1.Text;
            ui.Telephone1 = txtTC1.Text;

            ui.Name2 = txtC2.Text;
            ui.Email2 = txtEC2.Text;
            ui.Telephone2 = txtTC2.Text;

            data.Add(ui);
            return data;
        }
    }
}