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
using System.Windows.Shapes;

namespace Realtor_office_coursework
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    

    public partial class AddWindow : Window
    {
        int IdRealtor;
        EFContext context = new EFContext();
        public AddWindow(int idRealtorCopy)
        {
            IdRealtor = idRealtorCopy;
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Apartment aprat = new Apartment
            {
                Number = NumberTextBox.Text,
                Price = decimal.Parse(PriceTextBox.Text),
                RealtorId = IdRealtor,
                Square = double.Parse(SquareTextBox.Text),
                CountRooms = int.Parse(CountRoomsTextBox.Text),
                Bought = false,
            };
            context.Apartments.Add(aprat);
            context.SaveChanges();

            Window1 menuWindow = new Window1(IdRealtor);
            this.Close();
            menuWindow.Show();

        }
    }
}
