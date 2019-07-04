using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace KarliCards_GUI
{
    [Serializable]
    //public class GameOptions
    //{
    //    public bool PlayAgainstComputer { get; set; }
    //    public int NumberOfPlayers { get; set; }
    //    public int MinutesBeforeLoss { get; set; }
    //    public ComputerSkillLevel ComputerSkill { get; set; }
    //}
    public class GameOptions : INotifyPropertyChanged
    {
        public GameOptions()
        {
            SelectedPlayers = new List<string>();
        }
        private ObservableCollection<string> _playerNames = new ObservableCollection<string>();
        public List<string> SelectedPlayers { get; set; }
        private bool _playAgainstComputer = false;
        public int _numberOfPlayers = 4;
        private ComputerSkillLevel _computerSkill = ComputerSkillLevel.Dumb;
        public ObservableCollection<string> PlayerNames
        {
            get
            {
                return _playerNames;
            }
            set
            {
                _playerNames = value;
                OnPropertyChanged("PlayerNames");
            }
        }
        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set
            {
                _numberOfPlayers = value;
            }
        }
        public bool PlayAgainstComputer
        {
            get { return _playAgainstComputer; }
            set
            {
                _playAgainstComputer = value;
                OnPropertyChanged(nameof(PlayAgainstComputer));
            }
        }
        public ComputerSkillLevel ComputerSkill
        {
            get { return _computerSkill; }
            set
            {
                _computerSkill = value;
                OnPropertyChanged(nameof(ComputerSkill));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void AddPlayer(string playerName)
        {
            if (_playerNames.Contains(playerName))
            {
                return;
            }
            _playerNames.Add(playerName);
            OnPropertyChanged("PlayerNames");
        }
    }
    [Serializable]
    public enum ComputerSkillLevel
    {
        Dumb,
        Good,
        Cheats
    }
}
