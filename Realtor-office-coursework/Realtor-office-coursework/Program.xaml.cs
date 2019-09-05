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

    
    public partial class Window1 : Window
    {

        EFContext context = new EFContext();
        ObservableCollection<ApartementDTO> apartments;
        int IdRealtorCopy;

        public Window1(int id)
        {
            InitializeComponent();
            connect();
            IdRealtorCopy = id;
        }
        public void connect()
        {
            apartments = new ObservableCollection<ApartementDTO>(
                context.Apartments.Where(t=>t.Bought==false).Select(t=>
                new ApartementDTO() {
                    Id=t.Id,
                    CountRooms=t.CountRooms,
                    Number=t.Number,
                    Price=t.Price,
                    Square=t.Square
                }).ToList());


            DataGridApartment.ItemsSource = apartments;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ApartementDTO apart = (ApartementDTO)DataGridApartment.SelectedItem;

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

            AddWindow menuWindow = new AddWindow(IdRealtorCopy);
            this.Close();
            menuWindow.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ApartementDTO apart = (ApartementDTO)DataGridApartment.SelectedItem;

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
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {

            StatisticsWindow WindowProg = new StatisticsWindow();
            WindowProg.Owner = this;
            WindowProg.Show();

        }
    }
}
