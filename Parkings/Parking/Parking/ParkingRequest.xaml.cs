using Owner.DTO;
using Parking.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Parking
{
    /// <summary>
    /// Interaction logic for ParkingRequest.xaml
    /// </summary>
    public partial class ParkingRequest : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Guid idParking;
        private static List<ParkingAccept> pq = new List<ParkingAccept>();
        public Guid IdParking
        {
            get { return idParking; }
            set {
                idParking = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IdParking"));
            }
        }
        private Guid idOwner;

        public Guid IdOwner
        {
            get { return idOwner; }
            set {
                idOwner = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IdOwner"));
            }
        }
        public ParkingRequest()
        {
            this.DataContext = this;
            InitializeComponent();
            GetRequestParkingList();
          
        }


        async void GetRequestParkingList()
        {
            if (pq != null)
            {
                pq.Clear();
            }
            pq= await ParkingDAO.Instance.GetParkingRequestList();
            if (pq != null)
            {
                lvRequest.ItemsSource = pq;
            }
        }

        private void lvRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((ParkingAccept)lvRequest.SelectedItem != null)
            {
                idOwner =  ((ParkingAccept)lvRequest.SelectedItem).IdOwner ;
                idParking =  ((ParkingAccept)lvRequest.SelectedItem).Id; 
            }
        }

        private async void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (pq != null)
            {
                pq.Clear();
            }
            pq= await ParkingDAO.Instance.GetParkingRequestList();
            if (pq != null)
            {
                foreach (var item in pq)
                {
                    if (item.Id.Equals(IdParking))
                    {
                        item.Status = "Active";
                        ParkingDAO.Instance.UpdateParking(item);
                        break;
                    }
                }
                GetRequestParkingList();
            }
        }

        private void btnDenial_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
