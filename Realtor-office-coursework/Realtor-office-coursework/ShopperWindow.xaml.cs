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

    public partial class ShopperWindow : Window
    {
        EFContext context = new EFContext();
        Shopper ShopperCopy;
        ObservableCollection<ApartementDTO> apartments;
        public ShopperWindow(Shopper Shopper)
        {
            ShopperCopy = Shopper;
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
                        ShopperId = ShopperCopy.Id,
                        ApartmentId = ap.Id,

                    };
                    ListSA.Add(aprat);
                    context.ShopperApartment.Add(aprat);
                    break;

                }
            }
            context.SaveChanges();
            ShopperWindow WindowProg = new ShopperWindow(ShopperCopy);
            WindowProg.Show();
            this.Close();

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
