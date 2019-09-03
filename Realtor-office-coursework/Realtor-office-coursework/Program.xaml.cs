using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<ApartementDTO> apartments;
        public Window1()
        {
            InitializeComponent();
            connect();
            //ShowList();
        }
        public void connect()
        {
            apartments = new ObservableCollection<ApartementDTO>(
                context.Apartments.Select(t=>
                new ApartementDTO() {
                    Id=t.Id,
                    CountRooms=t.CountRooms,
                    Number=t.Number,
                    Price=t.Price,
                    Square=t.Square
                }).ToList());
            //var List = context.Apartments.Select(p => new
            //{
            //    Number = p.Number,
            //    Price = p.Price,
            //    Square = p.Square,
            //    CountRooms = p.CountRooms,
            //    Bought = p.Bought
            //}).ToList();

            DataGridApartment.ItemsSource = apartments;
        }
        public void ShowList()
        {
            List<Apartment> apartments = context.Apartments.ToList();
            NumberTextBox.Text = apartments[index].Number.ToString();
            PriceTextBox.Text = apartments[index].Price.ToString();
            SquareTextBox.Text = apartments[index].Square.ToString();
            CountRoomsTextBox.Text = apartments[index].CountRooms.ToString();
            indexIdDeleteEdit = apartments[index].Id;
        }

        private void DataGridApartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //index = DataGridApartment.SelectedIndex;
            //ShowList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Apartment apart = (Apartment)DataGridApartment.SelectedItem;

            foreach (var p in context.Apartments)
            {
                
                if (p.Id == apart.Id)
                {
                    context.Apartments.Remove(p);
                    apartments.Remove(apartments.FirstOrDefault(t=>t.Id==apart.Id));
                    break;
                }
                
            }

            context.SaveChanges();
           
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Apartment aprat = new Apartment
            {
                Number = NumberTextBox.Text,
                Price = decimal.Parse(PriceTextBox.Text),
                RealtorId = ((MainWindow)Owner).idRealtor,
                Square = double.Parse(SquareTextBox.Text),
                CountRooms = int.Parse(CountRoomsTextBox.Text),
                Bought = false,
            };
            context.Apartments.Add(aprat);
            context.SaveChanges();

            apartments.Add(new ApartementDTO() {
                Number = aprat.Number,
                Price = aprat.Price,
                Square = aprat.Square,
                CountRooms = aprat.CountRooms,
            });
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Apartment apart = (Apartment)DataGridApartment.SelectedItem;

            Apartment ap = context.Apartments.FirstOrDefault(t => t.Id == apart.Id);

           

            foreach (var p in context.Apartments)
            {

                if (p.Id == apart.Id)
                {
                    var temp = apartments.First(t => t.Id == apart.Id);
                    temp.Number = NumberTextBox.Text;

                    ap.Number = NumberTextBox.Text;
                    ap.Price = decimal.Parse(PriceTextBox.Text);
                    ap.Square = double.Parse(SquareTextBox.Text);
                    ap.CountRooms = int.Parse(CountRoomsTextBox.Text);

                    
                    break;
                    
                }
            }
            context.SaveChanges();

            

            //connect();
            //ShowList();
        }
    }
}
