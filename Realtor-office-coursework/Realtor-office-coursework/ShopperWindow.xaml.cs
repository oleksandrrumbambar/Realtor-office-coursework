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
    /// Interaction logic for Shopper.xaml
    /// </summary>
    public partial class ShopperWindow : Window
    {
        EFContext context = new EFContext();
        ObservableCollection<ApartementDTO> apartments;
        public ShopperWindow()
        {
            InitializeComponent();
            connect(); 
        }

        public List<ShopperApartment> ListSA = new List<ShopperApartment>();

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            ApartementDTO apart = (ApartementDTO)DataGridApartment.SelectedItem;

            Apartment ap = context.Apartments.FirstOrDefault(t => t.Id == apart.Id);



            foreach (var p in context.Apartments.ToList())
            {

                if (p.Id == apart.Id)
                {


                    ap.Bought = true;

                    ShopperApartment aprat = new ShopperApartment
                    {
                        ShopperId = ((MainWindow)Owner).Shopper.Id,
                        ApartmentId = ap.Id,

                    };
                    ListSA.Add(aprat);
                    context.ShopperApartment.Add(aprat);
                    break;

                }
            }
            context.SaveChanges();
            

        }



        public void connect()
        {
            apartments = new ObservableCollection<ApartementDTO>(
                context.Apartments.Where(t=>t.Bought==false).Select(t => 
                new ApartementDTO()
                {
                    Id = t.Id,
                    CountRooms = t.CountRooms,
                    Number = t.Number,
                    Price = t.Price,
                    Square = t.Square
                }).ToList());

            DataGridApartment.ItemsSource = apartments;
        }

    }
}
