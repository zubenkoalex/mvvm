using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.Model;
using HospitalDocumentation.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HospitalDocumentation.ViewModel
{
    public class LaboratoryTestViewModel : NotifyProperty
    {
        private ObservableCollection<LaboratoryTestEntity> _laboratoryTests;
        private LaboratoryTestEntity? _selectedLaboratoryTest;

        public ObservableCollection<LaboratoryTestEntity> LaboratoryTests
        {
            get => _laboratoryTests;
            set
            {
                _laboratoryTests = value;
                OnPropertyChanged();
            }
        }

        public LaboratoryTestEntity? SelectedLaboratoryTest
        {
            get => _selectedLaboratoryTest;
            set
            {
                _selectedLaboratoryTest = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public LaboratoryTestViewModel()
        {
            _laboratoryTests = new ObservableCollection<LaboratoryTestEntity>();

            AddCommand = new RelayCommand(AddLaboratoryTest);
            EditCommand = new RelayCommand(EditLaboratoryTest, () => SelectedLaboratoryTest != null);
            DeleteCommand = new RelayCommand(DeleteLaboratoryTest, () => SelectedLaboratoryTest != null);

            LoadLaboratoryTests();
        }

        private void LoadLaboratoryTests()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var laboratoryTests = context.LaboratoryTestEntities.ToList();
                    LaboratoryTests = new ObservableCollection<LaboratoryTestEntity>(laboratoryTests);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void AddLaboratoryTest()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var maxId = context.LaboratoryTestEntities.Max(l => l.Id);

                    var laboratoryTest = new LaboratoryTestEntity
                    {
                        Id = maxId + 1, 
                        Type = "",
                        Date = DateOnly.FromDateTime(DateTime.Today),
                        Result = ""
                    };

                    var window = new LaboratoryTestAddEditWindow(laboratoryTest);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(laboratoryTest.Type))
                        {
                            MessageBox.Show("Тип анализа обязателен для заполнения", "Ошибка");
                            return;
                        }


                        context.LaboratoryTestEntities.Add(laboratoryTest);
                        context.SaveChanges();
                        LoadLaboratoryTests();
                        MessageBox.Show("Анализ успешно добавлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditLaboratoryTest()
        {
            if (SelectedLaboratoryTest == null) return;

            try
            {
                using (var context = new HospContext())
                {
                    var laboratoryTestToEdit = context.LaboratoryTestEntities.Find(SelectedLaboratoryTest.Id);
                    if (laboratoryTestToEdit == null)
                    {
                        MessageBox.Show("Анализ не найден в базе данных", "Ошибка");
                        return;
                    }

        
                    var editedLaboratoryTest = new LaboratoryTestEntity
                    {
                        Id = laboratoryTestToEdit.Id,
                        Type = laboratoryTestToEdit.Type,
                        Date = laboratoryTestToEdit.Date,
                        Result = laboratoryTestToEdit.Result
                    };

                    var window = new LaboratoryTestAddEditWindow(editedLaboratoryTest);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(editedLaboratoryTest.Type))
                        {
                            MessageBox.Show("Тип анализа обязателен для заполнения", "Ошибка");
                            return;
                        }


                        context.Entry(laboratoryTestToEdit).CurrentValues.SetValues(editedLaboratoryTest);
                        context.SaveChanges();
                        LoadLaboratoryTests();
                        MessageBox.Show("Анализ успешно обновлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при обновлении: {innerMessage}", "Ошибка");
            }
        }

        private void DeleteLaboratoryTest()
        {
            if (SelectedLaboratoryTest == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранный анализ?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new HospContext())
                    {
                        var laboratoryTestToDelete = context.LaboratoryTestEntities.Find(SelectedLaboratoryTest.Id);
                        if (laboratoryTestToDelete != null)
                        {
                            context.LaboratoryTestEntities.Remove(laboratoryTestToDelete);
                            context.SaveChanges();
                            LoadLaboratoryTests();
                            MessageBox.Show("Анализ успешно удален!", "Успешный успех");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
                }
            }
        }
    }
}
