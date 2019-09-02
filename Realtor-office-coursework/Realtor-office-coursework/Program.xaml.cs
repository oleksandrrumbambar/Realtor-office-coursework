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
    /// Interaction logic for Window1.xaml
    /// </summary>
    
    public partial class Window1 : Window
    {
        int index = 0;
        int indexIdDelete;
        EFContext context = new EFContext();
        public Window1()
        {
            InitializeComponent();
            connect();
            ShowList();
        }
        public void connect()
        {
            var List = context.Apartments.Select(p => new
            {
                Number = p.Number,
                Price = p.Price,
                Square = p.Square,
                CountRooms = p.CountRooms,
                Bought = p.Bought
            }).ToList();
            DataGridApartment.ItemsSource = List;
        }
        public void ShowList()
        {
            List<Apartment> apartments = context.Apartments.ToList();
            NumberTextBox.Text = apartments[index].Number.ToString();
            PriceTextBox.Text = apartments[index].Price.ToString();
            SquareTextBox.Text = apartments[index].Square.ToString();
            CountRoomsTextBox.Text = apartments[index].CountRooms.ToString();
            indexIdDelete = apartments[index].Id;
        }

        private void DataGridApartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index = DataGridApartment.SelectedIndex;
            ShowList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            context.Apartments.Remove(
                new Apartment
                {
                    Id = indexIdDelete,
                    Number = NumberTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    RealtorId = ((MainWindow)Owner).idRealtor,
                    Square = double.Parse(SquareTextBox.Text),
                    CountRooms = int.Parse(CountRoomsTextBox.Text),
                    Bought = false
                });
            context.SaveChanges();
            ShowList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            context.Apartments.Add(new Apartment {
                Number = NumberTextBox.Text,
                Price = decimal.Parse(PriceTextBox.Text),
                RealtorId = ((MainWindow)Owner).idRealtor,
                Square=double.Parse(SquareTextBox.Text),
                CountRooms = int.Parse(CountRoomsTextBox.Text),
                Bought = false,
            });
            context.SaveChanges();
            ShowList();

        }
    }
}
