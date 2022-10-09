using System.ComponentModel;
using System.Linq;
using Corona_Tracing_App.Data;
using Corona_Tracing_App.ViewModel;

namespace Corona_Tracing_App
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new FileData());
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            MainViewModel vm = (MainViewModel) DataContext;
            var persons = vm.Persons.Select(p => p.Person).ToList();
            vm.Data.SetPersons(persons);
            base.OnClosing(e);
        }
    }
}
