using Owner.DTO;
using Parking.DAO;
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

namespace Parking
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private static List<ParkingAccept> pq = new List<ParkingAccept>();
        private static List<DTO.Owner> listOwner = new List<DTO.Owner>();
        private string requestList;

        public string RequestList
        {
            get { return requestList; }
            set { requestList = value; }
        }

        public Home()
        {
            this.DataContext = this;
            InitializeComponent();
            LoadNoti();
        }
        async void LoadNoti()
        {
            if (pq != null)
            {
                pq.Clear();
            }
            pq = await ParkingDAO.Instance.GetParkingRequestList();
            if (pq != null)
            {
                lbNotiRequest.Content = $"({pq.Count})";
            }
            if (listOwner != null)
            {
                listOwner.Clear();
            }
            listOwner = await OwnerDAO.Instance.GetOwnerStatusRequest();
            if (listOwner != null)
            {
                lbNotiOwnerRequest.Content = $"({listOwner.Count})";
            }
          
        }
        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            ParkingRequest parkingRequest = new ParkingRequest();
            parkingRequest.WindowStartupLocation= WindowStartupLocation.CenterScreen;
            parkingRequest.ShowDialog();
            LoadNoti();
        }

        private void btnOwnerRequest_Click(object sender, RoutedEventArgs e)
        {
            OwnerRequest parkingRequest = new OwnerRequest();   
            parkingRequest.WindowStartupLocation=WindowStartupLocation.CenterScreen;
            parkingRequest.ShowDialog();
            LoadNoti();
        }
    }
}
