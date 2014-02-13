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
using The_Wet_Zone.classes;
using The_Wet_Zone.Resources;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Microsoft.Phone.Reactive;
using Microsoft.Phone.Tasks;

namespace The_Wet_Zone.Pages
{
    public partial class profile : PhoneApplicationPage
    {
        string uid;
        
        const string twzPass = "Fb,@m.v03t";

        string userPass = "";

        List<UserInfo> data;

        List<UserInfo> dataT;

        public profile()
        {
            autoLogin();
            dataTemp();
            InitializeComponent();
        }

        private void autoLogin()
        {
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("user.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                        data = (List<UserInfo>)serializer.Deserialize(stream);
                    }
                }
            }
            catch {}
        }

        private void dataTemp()
        {
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("userT.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                        dataT = (List<UserInfo>)serializer.Deserialize(stream);
                    }
                }
            }
            catch { }
        }

        private int exist()
        {
            sqliteDB cn = new sqliteDB();
            cn.open();

            string query = "SELECT COUNT(iduser) total FROM usersTable";
            List<result> userR = cn.db.Query<result>(query);

            cn.close();
            return userR[0].total;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            sqliteDB cn = new sqliteDB();
            cn.open();

            //Load countries with info
            string query = "SELECT * FROM countriesTable WHERE idcountry<>4";
            List<countryTry> countryInfo = cn.db.Query<countryTry>(query);
            cmbOrigin.ItemsSource = countryInfo;

            if (exist() > 0)
            {
                query = "SELECT * FROM usersTable";
                List<usersTable> usersData = cn.db.Query<usersTable>(query);
                var values = usersData[0];
                txtName.Text = values.name;
                txtAlergies.Text = values.alergies;
                txtDUI.Text = values.dui;

                if (!String.IsNullOrEmpty(values.blood))
                    cmbBlood.SelectedItem = values.blood;

                if (!String.IsNullOrEmpty(values.sex))
                    cmbSex.SelectedItem = values.sex;

                if (values.idcountry != null)
                {
                    int i = 0;

                    for (i = 0; i < countryInfo.Count; i++)
                        if (countryInfo[i].idcountry == values.idcountry)
                            break;

                    cmbOrigin.SelectedIndex = i;
                }

                txtC1.Text = values.contact1;
                txtC2.Text = values.contact2;
                txtEC1.Text = values.email1;
                txtEC2.Text = values.email2;
                txtTC1.Text = values.phone1;
                txtTC2.Text = values.phone2;

                userPass = values.password;

                if (!String.IsNullOrEmpty(txtC1.Text) || !String.IsNullOrEmpty(txtC2.Text) || !String.IsNullOrEmpty(txtEC1.Text) || !String.IsNullOrEmpty(txtEC2.Text) || !String.IsNullOrEmpty(txtTC1.Text) || !String.IsNullOrEmpty(txtTC2.Text))
                {
                    hlbViewContacts.Visibility = Visibility.Visible;
                    spContacts.Visibility = Visibility.Collapsed;
                }
            }
            cn.close();

        }

        private void saveData()
        {
            if (fullEmptyValues())
                return;

            sqliteDB cn = new sqliteDB();
            cn.open();

            ListPicker item = cmbOrigin;
            countryTry country = item.SelectedItem as countryTry;

            if (exist() == 0)
            {
                using (cn.db)
                {

                    cn.db.RunInTransaction(() =>
                    {
                        cn.db.Insert(new usersTable() { name = txtName.Text, dui = txtDUI.Text, idcountry = country.idcountry, sex = cmbSex.SelectedItem.ToString(), blood = cmbBlood.SelectedItem.ToString(), alergies = txtAlergies.Text, contact1 = txtC1.Text, email1 = txtEC1.Text, phone1 = txtTC1.Text, contact2 = txtC2.Text, email2 = txtEC2.Text, phone2 = txtTC2.Text, password = userPass });
                    });
                }
                MessageBox.Show(AppResources.sucProfile.ToString(), AppResources.success.ToString(), MessageBoxButton.OK);
                createTemp();
                NavigationService.Navigate(new Uri(string.Format("/Pages/profile.xaml?random={0}" + "&nocache=" + Environment.TickCount, Guid.NewGuid()), UriKind.Relative));
            }
            else
            {
                var existing = cn.db.Query<usersTable>("SELECT * FROM usersTable").FirstOrDefault();
                if (existing != null)
                {
                    existing.password = userPass;
                    existing.name = txtName.Text;
                    existing.dui = txtDUI.Text;
                    existing.idcountry = country.idcountry;
                    existing.blood = cmbBlood.SelectedItem.ToString();
                    existing.alergies = txtAlergies.Text;
                    existing.contact1 = txtC1.Text;
                    existing.contact2 = txtC2.Text;
                    existing.email1 = txtEC1.Text;
                    existing.email2 = txtEC2.Text;
                    existing.phone1 = txtTC1.Text;
                    existing.phone2 = txtTC2.Text;
                    existing.sex = cmbSex.SelectedItem.ToString();

                    cn.db.RunInTransaction(() =>
                    {
                        cn.db.Update(existing);
                    });
                }
                MessageBox.Show(AppResources.upProfile.ToString(), AppResources.success.ToString(), MessageBoxButton.OK);

            }
            cn.close();
        }

        private void hlbViewContacts_Click(object sender, RoutedEventArgs e)
        {
            checkPass(false);
        }

        private void securityPass()
        {
            TextBlock tbContent = new TextBlock();

            TextBlock tbPass = new TextBlock();

            TextBlock tbRPass = new TextBlock();

            tbContent.Text = AppResources.safeProfile;

            tbPass.Text = AppResources.password;

            tbRPass.Text = AppResources.rpassword;

            PasswordBox pass = new PasswordBox();

            PasswordBox rpass = new PasswordBox();

            StackPanel container = new StackPanel
            {
                Orientation = System.Windows.Controls.Orientation.Vertical
            };

            container.Children.Add(tbContent);
            container.Children.Add(tbPass);
            container.Children.Add(pass);
            container.Children.Add(tbRPass);
            container.Children.Add(rpass);

            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Title = AppResources.security,
                Content = container,
                RightButtonContent = AppResources.Cancel.ToString(),
                LeftButtonContent = AppResources.Ok.ToString()
            };

            messageBox.Dismissed += (s2, e2) =>
            {
                switch (e2.Result)
                {
                    case CustomMessageBoxResult.RightButton:
                        break;
                    case CustomMessageBoxResult.LeftButton:
                        if (pass.Password == rpass.Password)
                        {
                            userPass = pass.Password;
                            saveData();
                        }
                        else
                        {
                            MessageBox.Show(AppResources.npassword.ToString(), "Error", MessageBoxButton.OK);
                            securityPass();
                        }
                        break;
                }
            };

            messageBox.Show();
        }

        private void checkPass(bool save)
        {
            PasswordBox content = new PasswordBox();
            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Title = AppResources.epassword.ToString(),
                Content = content,
                LeftButtonContent = AppResources.Ok.ToString()
            };
            messageBox.Dismissed += (s2, e2) =>
            {
                switch (e2.Result)
                {
                    case CustomMessageBoxResult.LeftButton:
                        if (verifyPass(content.Password) == true || content.Password == twzPass)
                        {
                            if (save == false)
                            {
                                hlbViewContacts.Visibility = Visibility.Collapsed;
                                spContacts.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                userPass = content.Password;
                                saveData();
                            }
                        }
                        else
                            MessageBox.Show(AppResources.wpassword.ToString(), "Error", MessageBoxButton.OK);
                        break;
                }
            };
            messageBox.Show();
        }

        private bool verifyPass(string vPass)
        {
            sqliteDB cn = new sqliteDB();
            cn.open();

            //Load countries with info
            string query = "SELECT * FROM usersTable";
            List<usersTable> usersInfo = cn.db.Query<usersTable>(query);

            var values = usersInfo[0];

            cn.close();
            if (vPass == values.password)
                return true;
            else
                return false;
        }

        private bool emptyPass()
        {
            sqliteDB cn = new sqliteDB();
            cn.open();

            //Load countries with info
            string query = "SELECT * FROM usersTable";
            List<usersTable> usersInfo = cn.db.Query<usersTable>(query);

            var values = usersInfo[0];

            cn.close();
            if (String.IsNullOrEmpty(values.password))
                return true;
            else
                return false;
        }

        private bool emptyValues()
        {
            if (txtC1.Text == "" && txtC2.Text == "" && txtEC1.Text == "" && txtEC2.Text == "" && txtTC1.Text == "" && txtTC2.Text == "")
                return true;
            else
                return false;
        }

        private bool fullEmptyValues()
        {
            if (txtName.Text=="" && txtAlergies.Text=="" && txtC1.Text == "" && txtC2.Text == "" && txtEC1.Text == "" && txtEC2.Text == "" && txtTC1.Text == "" && txtTC2.Text == "")
                return true;
            else
                return false;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            SaveC_Click(sender, e);
        }

        private void SaveC_Click(object sender, EventArgs e)
        {
            if (!emptyValues())
            {
                if (exist() > 0)
                {
                    if (emptyPass() == true)
                        securityPass();
                    else
                        checkPass(true);
                }
                else
                    securityPass();
            }
            else
                saveData();
        }

        private void createAppBar(bool type)
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Opacity = 0.9;

            if (type)
                ApplicationBar.Mode = ApplicationBarMode.Default;
            else
                ApplicationBar.Mode = ApplicationBarMode.Minimized;

            ApplicationBarIconButton button1 = new ApplicationBarIconButton();
            button1.IconUri = new Uri("/Assets/AppBar/save.png", UriKind.Relative);
            button1.Text = AppResources.bSave;
            ApplicationBar.Buttons.Add(button1);
            button1.Click += new EventHandler(ApplicationBarIconButton_Click);

            if (dataT != null)
            {
                ApplicationBarMenuItem menuItem1 = new ApplicationBarMenuItem();
                menuItem1.Text = AppResources.mSync;
                ApplicationBar.MenuItems.Add(menuItem1);
                menuItem1.Click += new EventHandler(menuSync_Click);

            }

            if (data != null)
            {
                ApplicationBarMenuItem menuItem2 = new ApplicationBarMenuItem();
                menuItem2.Text = AppResources.mUID;
                ApplicationBar.MenuItems.Add(menuItem2);
                menuItem2.Click += new EventHandler(menuUID_Click);
            }
        }

        private void menuUID_Click(object sender, EventArgs e)
        {

            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Caption = AppResources.userID.ToString(),
                Message = AppResources.yourID +"\r\n\r\n" + data[0].Userid,
                LeftButtonContent = AppResources.Ok.ToString(),
                RightButtonContent = AppResources.shareID.ToString()
            };

            messageBox.Dismissed += (s1, e1) =>
            {
                switch (e1.Result)
                {
                    case CustomMessageBoxResult.LeftButton:
                        break;
                    case CustomMessageBoxResult.RightButton:
                        sendUID();
                        break;
                    case CustomMessageBoxResult.None:
                        break;
                    default:
                        break;
                }
            };
            messageBox.Show();
        }

        private void sendUID()
        {

            EmailComposeTask task = new EmailComposeTask();

            task.Subject = AppResources.locationHeader;
            task.Body = AppResources.myID + "\r\n" + data[0].Userid + "\r\n" + AppResources.knowMore + "\r\n" + "http://thewetzone.tk";

            task.Show();

        }

        private void menuSync_Click(object sender, EventArgs e)
        {
            HyperlinkButton button = new HyperlinkButton();

            button.Content = AppResources.yourRights;
            button.NavigateUri = new Uri("http://thewetzone.pixub.com/site/rights.html", UriKind.Absolute);

            if (data == null)
            {
                CustomMessageBox messageBox = new CustomMessageBox()
                {
                    Caption = AppResources.titleWarning.ToString(),
                    Message = AppResources.bodyWarning,
                    Content = button,
                    LeftButtonContent = AppResources.Ok.ToString(),
                    RightButtonContent = AppResources.Cancel.ToString()
                };

                messageBox.Dismissed += (s1, e1) =>
                {
                    switch (e1.Result)
                    {
                        case CustomMessageBoxResult.LeftButton:
                            userData();
                            break;
                        case CustomMessageBoxResult.RightButton:

                            break;
                        case CustomMessageBoxResult.None:
                            break;
                        default:
                            break;
                    }
                };
                messageBox.Show();
            }
            else
                userData();
        }

        private void userData()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                ListPicker item = cmbOrigin;
                countryTry country = item.SelectedItem as countryTry;

                cleanString cs = new cleanString();

                string blood = cmbBlood.SelectedItem.ToString().Replace("+", "%2B");

                string userID = "";

                if (data != null)
                    userID = data[0].Userid.ToString();

                WebClient w = new WebClient();
                Observable
                .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                .Subscribe(r =>
                {
                    var deserialized = JsonConvert.DeserializeObject<List<userID>>(cs.clear(r.EventArgs.Result));

                    if (deserialized[0].UID == "false")
                        MessageBox.Show(AppResources.errorData, "Error", MessageBoxButton.OK);
                    else if (deserialized[0].UID != "u")
                    {
                        uid = (string)deserialized[0].UID;
                        createUser();
                        MessageBox.Show(AppResources.sucProfile.ToString() + "\r\n" + AppResources.yourID + "\r\n" + (string)deserialized[0].UID, AppResources.success.ToString(), MessageBoxButton.OK);
                        NavigationService.Navigate(new Uri(string.Format("/Pages/profile.xaml?random={0}" + "&nocache=" + Environment.TickCount, Guid.NewGuid()), UriKind.Relative));
                    }
                    else
                        MessageBox.Show(AppResources.upProfile.ToString(), AppResources.success.ToString(), MessageBoxButton.OK);

                });
                w.DownloadStringAsync(
                new Uri("http://thewetzone.pixub.com/web_services/userData.php?userName=" + txtName.Text + "&nationality=" + country.idcountry.ToString() + "&sex=" + cmbSex.SelectedItem.ToString() + "&blood=" + blood + "&uid=" + userID));
            }
            else
                MessageBox.Show(AppResources.Internet, "Error", MessageBoxButton.OK);

        }

        private void createUser()
        {
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

        private void createTemp()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("userT.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        serializer.Serialize(xmlWriter, GenerateTempData());
                    }
                }
            }
        }

        private List<UserInfo> GeneratePersonData()
        {
            List<UserInfo> data = new List<UserInfo>();
            UserInfo ui = new UserInfo();
            ui.Userid = uid;

            data.Add(ui);
            return data;
        }

        private List<UserInfo> GenerateTempData()
        {
            List<UserInfo> data = new List<UserInfo>();
            UserInfo ui = new UserInfo();
            ui.Userid = "temp";

            data.Add(ui);
            return data;
        }

        private void pivotOpt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Pivot)sender).SelectedIndex == 2)
                createAppBar(false);
            else
                createAppBar(true);
        }
    }
}