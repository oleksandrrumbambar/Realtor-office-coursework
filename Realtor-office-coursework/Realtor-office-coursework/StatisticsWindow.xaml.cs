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

    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
            connect();
            ShowStatistics();
        }

        EFContext context = new EFContext();
        ObservableCollection<ApartementDTO> apartments;

        public void connect()
        {
            apartments = new ObservableCollection<ApartementDTO>(
                context.Apartments.Where(t=>t.Bought==true).Select(t =>
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

        public void ShowStatistics()
        {
            decimal TotalPrice =0;
            double TotalArea = 0;
            int Count = 0;
            int CountRoom02 = 0;
            int CountRoom34 = 0;
            int CountRoom5 = 0;
            foreach (var item in apartments)
            {

                TotalPrice += item.Price;
                TotalArea += item.Square;
                Count++;
                if (item.CountRooms >= 0 || item.CountRooms == 2)
                    CountRoom02++;
                if (item.CountRooms == 3 || item.CountRooms == 4)
                    CountRoom34++;
                if (item.CountRooms > 4)
                    CountRoom5++;

            }

            TotalPriceTextBlock.Text = TotalPrice.ToString();
            AllSoldTextBlock.Text = Count.ToString();
            TotalAreaTextBlock.Text = TotalArea.ToString();
            Rooms02TextBlock.Text = CountRoom02.ToString();
            Rooms34TextBlock.Text = CountRoom34.ToString();
            Rooms5TextBlock.Text = CountRoom5.ToString();

        }

    }
}
