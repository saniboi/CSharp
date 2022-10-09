using System.ComponentModel;

namespace _15_Validierung
{
    public class CredentialsViewModel : INotifyPropertyChanged
    {
        private Credentials credentials;

        public Credentials Credentials
        {
            get { return credentials; }
            set { credentials = value; }
        }

        public string User
        {
            get { return credentials.User; }
            set
            {
                credentials.User = value;
                RaisePropertyChanged("User");
            }
        }

        public string Password 
        {
            get { return credentials.Password; }
            set
            {
                credentials.Password = value;
                RaisePropertyChanged("Password");
            }
        }
        public CredentialsViewModel()
        {
            credentials = new Credentials() {User = "", Password = "" };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}