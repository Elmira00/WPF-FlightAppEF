using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_FlightAppEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            GetCitiesAsync();
            GetSchedulesAsync();
            GetAirplaneAsync();
            GetFlightTypeAsync();
            this.DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region ObservableCollections
        private ObservableCollection<City> cities;

        public ObservableCollection<City> Cities
        {
            get { return cities; }
            set { cities = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Pilot> pilots;

        public ObservableCollection<Pilot> Pilots
        {
            get { return pilots; }
            set { pilots = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Ticket> tickets;

        public ObservableCollection<Ticket> Tickets
        {
            get { return tickets; }
            set { tickets = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Airplane> airplanes;

        public ObservableCollection<Airplane> Airplanes
        {
            get { return airplanes; }
            set { airplanes = value; OnPropertyChanged(); }
        }
        private ObservableCollection<FlightType> flightTypes;

        public ObservableCollection<FlightType> FlightTypes
        {
            get { return flightTypes; }
            set { flightTypes = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Schedule> schedules;

        public ObservableCollection<Schedule> Schedules
        {
            get { return schedules; }
            set { schedules = value; OnPropertyChanged(); }
        }
        #endregion

        #region SELECTED ITEMs COMBOBOX


        private int selectedCityId;
        public int SelectedCityId
        {
            get { return selectedCityId; }
            set
            {
                if (selectedCityId != value)
                {
                    selectedCityId = value;
                    LoadSchedulesForSelectedCity();
                    OnPropertyChanged(nameof(SelectedCityId));

                }
            }
        }
        private void LoadSchedulesForSelectedCity()
        {
            MessageBox.Show("ok");

        }


        private Schedule selectedScheduleId;
        public Schedule SelectedScheduleId
        {
            get { return selectedScheduleId; }
            set
            {
                if (selectedScheduleId != value)
                {
                    selectedScheduleId = value;
                    OnPropertyChanged();
                }
            }
        }
        private Airplane selectedAirplaneId;
        public Airplane SelectedAirplaneId
        {
            get { return selectedAirplaneId; }
            set
            {
                if (selectedAirplaneId != value)
                {
                    selectedAirplaneId = value;
                    OnPropertyChanged();
                }
            }
        }
        private FlightType selectedFlightTypeId;
        public FlightType SelectedFlightTypeId
        {
            get { return selectedFlightTypeId; }
            set
            {
                if (selectedFlightTypeId != value)
                {
                    selectedFlightTypeId = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion


        private async Task GetCitiesAsync()
        {
            using (var context = new FlightDbEntities())
            {
                var cities = await context.Cities.ToListAsync();

                Cities = new ObservableCollection<City>(cities);
            }
        }
        private async Task GetSchedulesAsync()
        {
            using (var context = new FlightDbEntities())
            {
                var schedules = await context.Schedules.ToListAsync();

                Schedules = new ObservableCollection<Schedule>(schedules);
            }
        }
        private async Task GetAirplaneAsync()
        {
            using (var context = new FlightDbEntities())
            {
                var airplanes = await context.Airplanes.ToListAsync();

                Airplanes = new ObservableCollection<Airplane>(airplanes);
            }
        }
        private async Task GetFlightTypeAsync()
        {
            using (var context = new FlightDbEntities())
            {
                var flightTypes = await context.FlightTypes.ToListAsync();

                FlightTypes = new ObservableCollection<FlightType>(flightTypes);
            }
        }


    }
}
