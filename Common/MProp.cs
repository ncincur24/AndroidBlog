using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AndroidBlog.Common
{
    public class MProp<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private T _value;
        private string _error;
        private Action _onValueChange;

        public Action OnValueChange
        {
            set
            {
                _onValueChange = value;
            }
        }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
                _onValueChange?.Invoke();
            }
        }

        public bool HasError => !string.IsNullOrEmpty(_error);

        public string Error
        {
            get => _error;
            set
            {
                _error = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasError));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
