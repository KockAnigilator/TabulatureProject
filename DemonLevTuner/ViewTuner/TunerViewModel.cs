using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using TunerLibrary;
using TunerLibrary.DataSource;
using ViewTuner.Core;
using ViewTuner.Repo;

namespace ViewTuner
{
    public class TunerViewModel : ObservableObject
    {
        SongsDataSource _songRepository;
        private List<Song> _songList;
        private Song _selectedSong;
        private Tabulature _tabulature;
        ObservableCollection<string> strings;
        public bool Started { get; private set; }
        public ObservableCollection<string> Strings { get => strings; set { strings = value; OnPropertyChanged("Strings"); } }

        public TunerViewModel(SongsDataSource songRepository) {
            _songRepository = songRepository;
            Init();
        }
        public async void Init()
        {
            SongList = await _songRepository.GetSong();
        }

        public List<Song> SongList { get => _songList; set { _songList = value; OnPropertyChanged("SongList"); } }

        public Song SelectedSong { get => _selectedSong; 
            set 
            { 
                _selectedSong = value;
                Tabulature = TabulatureHelper.GetTabulature(_selectedSong.Id);
                Strings = new ObservableCollection<string>(Tabulature.Strings);
                OnPropertyChanged("SelectedSong"); 
            }
        }

        public Tabulature Tabulature { get => _tabulature; set { 
                _tabulature = value;
                OnPropertyChanged("Tabulature"); } }


        private RelayCommand forButtonStartS;

        public RelayCommand ForButtonStartS
        {

            get
            {
                return forButtonStartS ??
                    (forButtonStartS = new RelayCommand(obj =>
                    {
                        if (Strings != null && IsAllowed)
                        {
                            Started = true;
                            List<string> tmp = new List<string>(Strings);
                            for (int i = 0; i < tmp.Count; i++)
                            {
                                if (tmp[i].Length > 0)
                                {
                                    tmp[i] = tmp[i].Substring(1);
                                }
                            }
                            Strings = new ObservableCollection<string>(tmp);
                            OnPropertyChanged("Strings");
                            Thread.Sleep(200);
                            Started = false;
                        }
                    }
                    ));
            }
        }



        private RelayCommand startSongCommand;
        public RelayCommand StartSongCommand
        {
            get
            {
                return startSongCommand ??
                  (startSongCommand = new RelayCommand(obj =>
                  {

                      if (Strings != null)
                      {
                          IsAllowed = true;
                      }

                  }));
            }
        }

        public Boolean CanGetWeather()
        {
            return Started;
        }

        private RelayCommand stopSongCommand;
        public RelayCommand StopSongCommand
        {
            get
            {
                return stopSongCommand ??
                  (stopSongCommand = new RelayCommand(obj =>
                  {
                      if (Strings != null)
                      {
                          IsAllowed = false;
                      }
                  }));
            }
        }

        public bool IsAllowed { get;  set; }
    }
}
