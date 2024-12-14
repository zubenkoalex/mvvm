using System;
using System.Collections.Generic;
using System.IO;
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
using WPF_FP.ViewModel;

namespace WPF_FP
{
    /// <summary>
    /// Логика взаимодействия для AddPerson.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        // Укажите путь к вашему файлу
        string filePath = @"C:\Users\Александр\Desktop\Учеба\С#\WPF_FP\WPF_FP\Source\Text.txt";




        public AddPerson()
        {
            InitializeComponent();
        }

        private void ButtonAddPerson(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(Text_name.Text);
                    writer.WriteLine(Text_age.Text);
                    writer.WriteLine(Text_Category.Text);
                    writer.WriteLine(Text_PlaceOfBirth.Text);
                    writer.WriteLine(Text_Progress.Text);
                    writer.WriteLine(" ");
                    MessageBox.Show("Успешно!");

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
        }
    }
}
