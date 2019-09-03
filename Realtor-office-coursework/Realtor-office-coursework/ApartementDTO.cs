using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor_office_coursework
{
    public class ApartementDTO:INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private double square;
        public double Square
        {
            get { return square; }
            set
            {
                square = value;
                OnPropertyChanged("Square");
            }
        }

        private int countRooms;
        public int CountRooms
        {
            get { return countRooms; }
            set
            {
                countRooms = value;
                OnPropertyChanged("CountRooms");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
