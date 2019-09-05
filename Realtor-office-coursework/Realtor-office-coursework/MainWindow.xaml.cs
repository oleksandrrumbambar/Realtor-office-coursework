using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Realtor_office_coursework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

            EFContext Context = new EFContext();

        private void ClickSignIn(object sender, RoutedEventArgs e)
        {

            int RealtorCheck = 0;
            int ShopperCheck = 0;
            foreach (var item in Context.Realtors.ToList())
            {

                if (item.Name == TextBoxUserName.Text &&
                   item.Password == TextBoxPassword.Text)
                {
                    Window1 WindowProg = new Window1(item.Id);
                    WindowProg.Show();
                    MessageBox.Show($"Welcom {item.Name}");
                    RealtorCheck = 3;
                    break;
                }
                if (item.Name == TextBoxUserName.Text &&
                   item.Password != TextBoxPassword.Text)
                {
                    RealtorCheck = 2;
                    break;
                }
            }
            if (RealtorCheck == 2)
            {

                MessageBox.Show($"Invalid password");
                RealtorCheck = 3;
            }
            if (RealtorCheck != 3)
            {
                foreach (var item in Context.Shoppers.ToList())
                {

                    if (item.Name == TextBoxUserName.Text &&
                       item.Password == TextBoxPassword.Text)
                    {

                        ShopperWindow WindowProg = new ShopperWindow(item);
                        WindowProg.Show();
                        MessageBox.Show($"Welcom {item.Name}");
                        ShopperCheck = 3;
                        break;
                    }
                    if (item.Name == TextBoxUserName.Text &&
                       item.Password != TextBoxPassword.Text)
                    {
                        ShopperCheck = 2;
                        break;
                    }
                }
                if (ShopperCheck == 2)
                {

                    MessageBox.Show($"Invalid password");

                }
                if (ShopperCheck == 0)
                {

                    MessageBox.Show($"{TextBoxUserName.Text} there is no such user");

                }
            }
        }



        private void TextBoxUserName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBoxUserName.Clear();
        }

        private void TextBoxPassword_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBoxPassword.Clear();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            int CountShopper = 0;
            int CountRealtor = 0;
            foreach (var p in Context.Shoppers.ToList())
            {
                if (p.Name != TextBoxUserName.Text)
                {
                    CountShopper++;
                }
                
            }
            foreach (var p in Context.Realtors.ToList())
            {
                if (p.Name != TextBoxUserName.Text)
                {
                    CountRealtor++;
                }

            }

            if (CountShopper == Context.Shoppers.Count() && CountRealtor == Context.Realtors.Count())
            {
                Context.Shoppers.Add(
             new Shopper
             {
                 Name = TextBoxUserName.Text,
                 Password = TextBoxPassword.Text
             });
                MessageBox.Show("!!!!!!!!!!!!!!!!!!!!!HURRAY, YOU HAVE REGISTERED, HURRAY!!!!!!!!!!!!!!!!!!!!!");

                Context.SaveChanges();
            }
            else if (CountShopper == Context.Shoppers.Count() - 1 && CountRealtor == Context.Realtors.Count() - 1)
            {
                MessageBox.Show("This user already exists");
                
            }

        }
    }
}
