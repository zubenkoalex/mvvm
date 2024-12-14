using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_FP.ViewModel;
using MaterialDesignColors;
using System.Security.Cryptography.X509Certificates;

namespace WPF_FP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string filePath = @"C:\Users\Александр\Desktop\Учеба\С#\WPF_FP\WPF_FP\Source\Text.txt";
        public static List<Person> peopleList = new List<Person>();


        public MainWindow()
        {
            InitializeComponent();
            check();
            GridName.ItemsSource = peopleList;

        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchTextBox.Text = "";
            }
        }




        private void check()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    // Откройте файл для чтения с использованием StreamReader
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                         string line;
                        // Читайте файл построчно
                        while ((line = sr.ReadLine()) != null)
                        {
                            Person person = new Person();
                            if (line == " ")
                            {
                                continue;
                            }
                            else
                            {
                                person.Name = line;
                                line = sr.ReadLine();
                                person.Age = line;
                                line = sr.ReadLine();
                                person.Category = line;
                                line = sr.ReadLine();
                                person.PlaceOfBirth = line;
                                line = sr.ReadLine();
                                person.Progress = line;
                                peopleList.Add(person);
                            }
                        }
                    }
                }
                catch (IOException ex)
                {
                    // Обработка исключений ввода-вывода
                    Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("The specified file does not exist.");
            }
        }

        private void ButtonAddPerson(object sender, RoutedEventArgs e)
        {
            AddPerson addPerson = new AddPerson();
            addPerson.Show();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            File.WriteAllLines(filePath, lines);
            check();
            GridName.ItemsSource = peopleList;
        }

        private void DeletePerson(object sender, RoutedEventArgs e)
        {
            var DeletePersonButton = GridName.SelectedItem as Person;

            // Чтение всех строк из файла
            List<string> lines = File.ReadAllLines(filePath).ToList();

            // Удаление строк, содержащих указанное слово
            lines = lines.Where(line => !line.Contains(DeletePersonButton.Name)).ToList();
            File.WriteAllLines(filePath, lines);
            lines = lines.Where(line => !line.Contains(DeletePersonButton.Age)).ToList();
            File.WriteAllLines(filePath, lines);
            lines = lines.Where(line => !line.Contains(DeletePersonButton.Category)).ToList();
            File.WriteAllLines(filePath, lines);
            lines = lines.Where(line => !line.Contains(DeletePersonButton.Progress)).ToList();
            File.WriteAllLines(filePath, lines);
            lines = lines.Where(line => !line.Contains(DeletePersonButton.PlaceOfBirth)).ToList();
            File.WriteAllLines(filePath, lines);
        }
    }
}
