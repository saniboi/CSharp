using Prämienrechner.ViewModel;

namespace Prämienrechner.Model
{
    public class GesamteinnahmenMonatlich : ViewModelBase
    {
        private string januar;

        public string Januar
        {
            get => januar;
            set => SetProperty(ref januar, value);
        }

        private string februar;

        public string Februar
        {
            get => februar;
            set => SetProperty(ref februar, value);
        }

        private string maerz;

        public string Maerz
        {
            get => maerz;
            set => SetProperty(ref maerz, value);
        }

        private string april;

        public string April
        {
            get => april;
            set => SetProperty(ref april, value);
        }

        private string mai;

        public string Mai
        {
            get => mai;
            set => SetProperty(ref mai, value);
        }

        private string juni;

        public string Juni
        {
            get => juni;
            set => SetProperty(ref juni, value);
        }

        private string juli;

        public string Juli
        {
            get => juli;
            set => SetProperty(ref juli, value);
        }

        private string august;

        public string August
        {
            get => august;
            set => SetProperty(ref august, value);
        }

        private string september;

        public string September
        {
            get => september;
            set => SetProperty(ref september, value);
        }

        private string oktober;

        public string Oktober
        {
            get => oktober;
            set => SetProperty(ref oktober, value);
        }

        private string november;

        public string November
        {
            get => november;
            set => SetProperty(ref november, value);
        }

        private string dezember;

        public string Dezember
        {
            get => dezember;
            set => SetProperty(ref dezember, value);
        }

        private string monatspraemie;

        public string Monatspraemie
        {
            get => monatspraemie;
            set => SetProperty(ref monatspraemie, value);
        }

    }
}
