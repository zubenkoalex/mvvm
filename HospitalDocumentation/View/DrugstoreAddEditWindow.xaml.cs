using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalDocumentation.View
{
    public partial class DrugstoreAddEditWindow : Window
    {
        private readonly DrugstoreEntity _drugstore;

        public DrugstoreAddEditWindow(DrugstoreEntity drugstore)
        {
            InitializeComponent();
            _drugstore = drugstore;
            DataContext = new DrugstoreAddEditViewModel(drugstore);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_drugstore.DrugId == null)
            {
                MessageBox.Show("Выберите препарат", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
