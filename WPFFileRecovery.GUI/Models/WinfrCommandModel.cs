using System.ComponentModel;

namespace WPFFileRecovery.GUI.Models
{
    public class WinfrCommandModel
    {
        private string? source;
        private string? destination;
        private bool isExtensive;
        private char? fileMode;

        public string? Source
        {
            get => source; set
            {
                source = value;
                OnPropertyChanged(nameof(Source));
            }
        }
        public string? Destination
        {
            get => destination; set
            {
                destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }
        public bool IsExtensive
        {
            get => isExtensive; set
            {
                isExtensive = value;
                OnPropertyChanged(nameof(Destination));
            }
        }
        public char? FileMode
        {
            get => fileMode; set
            {
                fileMode = value;
                OnPropertyChanged(nameof(Destination));
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
