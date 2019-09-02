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
        public int idRealtor;

        private void ClickSignIn(object sender, RoutedEventArgs e)
        {

            EFContext Context = new EFContext();
            //for (int i = 0; i < Context.Realtors.Count(); i++)
            //{
            //    Realtor realtor = Context.Realtors[i];
            //    if (TextBoxUserName.Text == Context.Realtors.)
            //}

            foreach (var item in Context.Realtors.ToList())
            {

                if (item.Name == TextBoxUserName.Text &&
                   item.Password == TextBoxPassword.Text)
                {
                    idRealtor = item.Id;
                    Window1 WindowProg = new Window1();
                    WindowProg.Owner = this;
                    WindowProg.Show();
                    //this.Close();
                }
                else
                {

                    string error = "Pomilka";
                    MessageBox.Show(error);

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
    }
}
