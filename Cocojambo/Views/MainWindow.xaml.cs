using Cocojambo.Models.Entities;
using System.Text;
using System.Windows;
using Cocojambo.Views;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cocojambo.ViewModels;

namespace Cocojambo.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public MainWindow(MainViewModel viewModel) : this()
        {
            _mainViewModel = viewModel;
            DataContext = viewModel;
        }
    }
}