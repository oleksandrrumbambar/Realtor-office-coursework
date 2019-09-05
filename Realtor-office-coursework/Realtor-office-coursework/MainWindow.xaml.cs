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


            foreach (var item in Context.Realtors.ToList())
            {

                if (item.Name == TextBoxUserName.Text &&
                   item.Password == TextBoxPassword.Text)
                {
                    Window1 WindowProg = new Window1(item.Id);
                    WindowProg.Show();

                }
            }
            foreach (var item in Context.Shoppers.ToList())
            {

                if (item.Name == TextBoxUserName.Text &&
                   item.Password == TextBoxPassword.Text)
                {
                    
                    ShopperWindow WindowProg = new ShopperWindow(item);
                    WindowProg.Show();

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
