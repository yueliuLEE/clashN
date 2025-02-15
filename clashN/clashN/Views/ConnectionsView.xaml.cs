using ClashN.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace ClashN.Views
{
    /// <summary>
    /// Interaction logic for ConnectionsView.xaml
    /// </summary>
    public partial class ConnectionsView
    {
        public ConnectionsView()
        {
            InitializeComponent();
            ViewModel = new ConnectionsViewModel();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, vm => vm.ConnectionItems, v => v.lstConnections.ItemsSource).DisposeWith(disposables);
                this.Bind(ViewModel, vm => vm.SelectedSource, v => v.lstConnections.SelectedItem).DisposeWith(disposables);
                this.OneWayBind(ViewModel, vm => vm.ConnectionItems.Count, v => v.chipCount.Content).DisposeWith(disposables);


                this.BindCommand(ViewModel, vm => vm.ConnectionCloseCmd, v => v.menuConnectionClose).DisposeWith(disposables);
                this.BindCommand(ViewModel, vm => vm.ConnectionCloseAllCmd, v => v.menuConnectionCloseAll).DisposeWith(disposables);

                this.Bind(ViewModel, vm => vm.SortingSelected, v => v.cmbSorting.SelectedIndex).DisposeWith(disposables);
                this.BindCommand(ViewModel, vm => vm.ConnectionCloseAllCmd, v => v.btnConnectionCloseAll).DisposeWith(disposables);
                this.Bind(ViewModel, vm => vm.AutoRefresh, v => v.togAutoRefresh.IsChecked).DisposeWith(disposables);
            });
        }

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel?.ClashConnectionClose(false);
        }
    }
}
