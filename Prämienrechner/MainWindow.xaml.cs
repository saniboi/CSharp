using System.ComponentModel;
using Prämienrechner.ViewModel;

namespace Prämienrechner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel vm = (MainViewModel)TryFindResource("Vm");
            if (vm == null) return;
            CommandBindings.Add(vm.NewCommandBinding);
            CommandBindings.Add(vm.DeleteCommandBinding);
            CommandBindings.Add(vm.SaveCommandBinding);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            MainViewModel vm = (MainViewModel)TryFindResource("Vm");
            vm.DbContext.SaveChanges();
            // (Close?) klären für kerim
            base.OnClosing(e);
        }

    }
}
