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
        int indexIdDeleteEdit;
        EFContext context = new EFContext();
        public Window1()
        {
            InitializeComponent();
            connect();
            ShowList(index);
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
        public void ShowList(int ind)
        {
            List<Apartment> apartments = context.Apartments.ToList();
            NumberTextBox.Text = apartments[ind].Number.ToString();
            PriceTextBox.Text = apartments[ind].Price.ToString();
            SquareTextBox.Text = apartments[ind].Square.ToString();
            CountRoomsTextBox.Text = apartments[ind].CountRooms.ToString();
            indexIdDeleteEdit = apartments[ind].Id;
            
        }

        private void DataGridApartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            index = DataGridApartment.SelectedIndex;
            ShowList(index);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            foreach (var p in context.Apartments)
            {
                
                if (p.Id == indexIdDeleteEdit)
                {
                    index = 1;
                    context.Apartments.Remove(p);
                    break;
                }
                
            }

            context.SaveChanges();
            connect();
            ShowList(index);
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
            connect();
            ShowList(index);

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int i = index;
            Apartment ap = context.Apartments.FirstOrDefault(t => t.Id == indexIdDeleteEdit);
            ap.Number = NumberTextBox.Text;
            ap.Price = decimal.Parse(PriceTextBox.Text);
            ap.RealtorId = ((MainWindow)Owner).idRealtor;
            ap.Square = double.Parse(SquareTextBox.Text);
            ap.CountRooms = int.Parse(CountRoomsTextBox.Text);
            context.SaveChanges();
            connect();
            ShowList(i);
        }
    }
}
