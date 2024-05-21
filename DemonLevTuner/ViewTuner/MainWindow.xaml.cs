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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TunerLibrary;

namespace ViewTuner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SongRepository songRepository = new SongRepositoryImpl();
        TunerViewModel tunerViewModel;
        DispatcherTimer dispatcherTimer { get; set; }
        public MainWindow()
        {
            tunerViewModel = new TunerViewModel(songRepository);
            DataContext = tunerViewModel;
            InitializeComponent();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (tunerViewModel.SelectedSong != null)
            {
                //
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, (60000 / tunerViewModel.SelectedSong.BPM));
                
            }
            Function();
        }
        public void Function()
        {
            var viewModel = (TunerViewModel)DataContext;
                viewModel.ForButtonStartS.Execute(null);
        }

        private void ListBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tunerViewModel.IsAllowed = false;
        }
    }
}
