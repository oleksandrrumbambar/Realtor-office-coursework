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
            List<Ap>
            NumberTextBox.Text =

        }
    }
}
