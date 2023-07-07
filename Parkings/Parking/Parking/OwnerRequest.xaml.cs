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
    /// Interaction logic for OwnerRequest.xaml
    /// </summary>
    public partial class OwnerRequest : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Guid idOwner;

        public Guid IdOwner
        {
            get { return idOwner; }
            set { idOwner = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IdOwner"));
            }
        }
        private string username;

      

        public string Username
        {
            get { return username; }
            set { username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Username"));
            }
        }

        public OwnerRequest()
        {
            this.DataContext = this;    
            InitializeComponent();
            LoadOwnerRequest();
        }
        async void LoadOwnerRequest()
        {
            List<DTO.Owner> ll= await OwnerDAO.Instance.GetOwnerStatusRequest();
            lvOwnerRequest.ItemsSource= await OwnerDAO.Instance.GetOwnerStatusRequest();
        }
        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DTO.Owner oo =lvOwnerRequest.SelectedItem as DTO.Owner;
            if (oo != null) {
                oo.Status = "Active";
                OwnerDAO.Instance.UpdateOwner(oo);
                LoadOwnerRequest();
            }
        }

        private void btnDenial_Click(object sender, RoutedEventArgs e)
        {
            DTO.Owner oo= lvOwnerRequest.SelectedItem as DTO.Owner;
            if (oo != null)
            {
                oo.Status = "Ban";
                OwnerDAO.Instance.UpdateOwner(oo); 
                LoadOwnerRequest();
            }
        }

        private void lvOwnerRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvOwnerRequest.SelectedItem != null)
            {
                IdOwner = ((DTO.Owner)lvOwnerRequest.SelectedItem).Id;
                Username= ((DTO.Owner)lvOwnerRequest.SelectedItem).Username;
            }
        }
    }
}
