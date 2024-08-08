using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
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
        private TicketDto LoadTicketForSelectedSchedule()
        {
            using (var context = new FlightDbEntities())
            {
                var ticket = context.Tickets
                    .Include(t => t.FlightType)
                    .Include(t => t.Schedule)
                    .FirstOrDefault(t => t.ScheduleId == SelectedScheduleId);

                if (ticket == null)
                    return null;

                var flightType = context.FlightTypes
                    .FirstOrDefault(f => f.Id == ticket.FlightTypeId);

                // Map to DTO
                return new TicketDto
                {
                    Id = ticket.Id,
                    ScheduleId = ticket.ScheduleId,
                    FlightTypeId = ticket.FlightTypeId,
                    ScheduleName = ticket.Schedule?.City?.Name,
                    FlightTypeName = flightType?.Type
                };
            }
        }
        private void OpenTicketUC_Click(object sender, RoutedEventArgs e)
        {
            var ticketDto = LoadTicketForSelectedSchedule();
            if (ticketDto != null)
            {
                TicketUC userControl = new TicketUC();
                string info = $"\nT I C K E T   I N F O \n\nFrom New York to {ticketDto.ScheduleName}\nFlight : {ticketDto.FlightTypeName}\nID : {ticketDto.Id}\nSum : {Sum}";
                userControl.Info = info;
                ContentContainer.Content = userControl;
            }
            else
            {
                MessageBox.Show("No ticket found.");
            }
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
        private ObservableCollection<Ticket> tickets;

        public ObservableCollection<Ticket> Tickets
        {
            get { return tickets; }
            set { tickets = value; OnPropertyChanged(); }
        }


        private Pilot _pilot;

        public Pilot Pilot
        {
            get { return _pilot; }
            set
            {
                if (_pilot != value)
                {
                    _pilot = value;
                    OnPropertyChanged(nameof(Pilot));
                }
            }
        }
        private Ticket selectedTicket;

        public Ticket SelectedTicket
        {
            get { return selectedTicket; }
            set
            {
                if (selectedTicket != value)
                {
                    selectedTicket = value;
                    OnPropertyChanged(nameof(SelectedTicket));
                }
            }
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
            using (var context = new FlightDbEntities())
            {
                var city = context.Cities
                           .Include(c => c.Schedules) // Ensure Schedules are loaded
                           .FirstOrDefault(c => c.Id == SelectedCityId);
                Schedules = new ObservableCollection<Schedule>(city.Schedules);
                Sum = city.DistanceFromCurrentCity;
            }
        }


        private int selectedScheduleId;
        public int SelectedScheduleId
        {
            get { return selectedScheduleId; }
            set
            {
                if (selectedScheduleId != value)
                {
                    selectedScheduleId = value;
                    LoadAirplanesForSelectedSchedule();
                    OnPropertyChanged();
                }
            }
        }

        private void LoadAirplanesForSelectedSchedule()
        {
            using (var context = new FlightDbEntities())
            {
                var schedule = context.Schedules
                           .Include(c => c.Airplanes)
                           .FirstOrDefault(c => c.Id == SelectedScheduleId);
                Airplanes = new ObservableCollection<Airplane>(schedule.Airplanes);
            }
        }
        private int selectedAirplaneId;
        public int SelectedAirplaneId
        {
            get { return selectedAirplaneId; }
            set
            {
                if (selectedAirplaneId != value)
                {
                    selectedAirplaneId = value;
                    LoadPilotForSelectedSchedule();
                    OnPropertyChanged();
                }
            }
        }
        private void LoadPilotForSelectedSchedule()
        {
            using (var context = new FlightDbEntities())
            {
                var schedule = context.Schedules
                           .Include(c => c.Pilot)
                           .FirstOrDefault(c => c.Id == SelectedScheduleId);
                Pilot = new Pilot(schedule.Pilot);
            }
        }

        private int selectedFlightTypeId;
        public int SelectedFlightTypeId
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
        public int Sum { get; set; }
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
