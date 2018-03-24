using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows;
using Lab3.Annotations;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _isConnected;
        public bool IsConnected {
            get => _isConnected;
            set {
                _isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }

        private Cabin _currentCabin;
        public Cabin CurrentCabin {
            get => _currentCabin;
            set {
                _currentCabin = value;
                OnPropertyChanged(nameof(CurrentCabin));
            }
        }

        private Passenger _currentPassenger;
        public Passenger CurrentPassenger {
            get => _currentPassenger;
            set {
                _currentPassenger = value;
                OnPropertyChanged(nameof(CurrentPassenger));
            }
        }

        public ObservableCollection<Passenger> Passengers;
        public ObservableCollection<Cabin> Cabins;

        private SqlConnection _connection;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            IsConnected = false;
            CurrentPassenger = new Passenger();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _connection.Open();
            IsConnected = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _connection.Dispose();
        }

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            CurrentPassenger = null;
            CurrentCabin = null;
        }

        private void ButtonBase3_OnClick(object sender, RoutedEventArgs e)
        {
            CurrentPassenger = null;
        }

        private void ButtonBase6_OnClick(object sender, RoutedEventArgs e)
        {
            CurrentCabin = null;
        }


        private void ButtonBase4_OnClick(object sender, RoutedEventArgs e)
        {
            ModalYouSure();
            CurrentPassenger = new Passenger();
        }

        private void ButtonBase5_OnClick(object sender, RoutedEventArgs e)
        {
            ModalYouSure();
            CurrentCabin = new Cabin();
        }

        private void ModalYouSure()
        {
            if (CurrentPassenger == null && CurrentCabin == null) return;
            if (MessageBox.Show(
                    "This action deletes all changes",
                    "Warning",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Warning) == MessageBoxResult.Cancel) return;

            CurrentPassenger = null;
            CurrentCabin = null;
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
