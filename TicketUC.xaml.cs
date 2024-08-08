using System.Windows.Controls;

namespace WPF_FlightAppEF
{
    /// <summary>
    /// Interaction logic for TicketUC.xaml
    /// </summary>
    public partial class TicketUC : UserControl
    {
        public TicketUC()
        {
            InitializeComponent();
        }
        public string Info
        {
            get { return DataTextBlock.Text; }
            set { DataTextBlock.Text = value; }
        }

    }
}
