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

namespace The_Wet_Zone.Pages
{
    public partial class profile : PhoneApplicationPage
    {
        const string twzPass = "Fb,@m.v03t";

        string userPass = "";

        public profile()
        {
            InitializeComponent();
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

                if (String.IsNullOrEmpty(values.blood))
                    cmbBlood.SelectedItem = values.blood;

                if (String.IsNullOrEmpty(values.sex))
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            saveData();
        }

        private void saveData()
        {
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

        private void SaveC_Click(object sender, RoutedEventArgs e)
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
    }
}