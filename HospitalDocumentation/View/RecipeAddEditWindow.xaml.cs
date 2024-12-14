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
    public partial class RecipeAddEditWindow : Window
    {
        private readonly RecipeEntity _recipe;

        public RecipeAddEditWindow(RecipeEntity recipe)
        {
            InitializeComponent();
            _recipe = recipe;
            DataContext = new RecipeAddEditViewModel(recipe);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_recipe.DrugId == null)
            {
                MessageBox.Show("Выберите препарат", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_recipe.Duration))
            {
                MessageBox.Show("Введите длительность приёма", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
