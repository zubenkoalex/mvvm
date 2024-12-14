using HospitalDocumentation.Model;
using HospitalDocumentation.Model.Enities;
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
    public class DrugViewModel : NotifyProperty
    {
        private ObservableCollection<DrugEntity> _drugs;
        private DrugEntity? _selectedDrug;

        public ObservableCollection<DrugEntity> Drugs
        {
            get => _drugs;
            set
            {
                _drugs = value;
                OnPropertyChanged();
            }
        }

        public DrugEntity? SelectedDrug
        {
            get => _selectedDrug;
            set
            {
                _selectedDrug = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public DrugViewModel()
        {
            _drugs = new ObservableCollection<DrugEntity>();

            AddCommand = new RelayCommand(AddDrug);
            EditCommand = new RelayCommand(EditDrug, () => SelectedDrug != null);
            DeleteCommand = new RelayCommand(DeleteDrug, () => SelectedDrug != null);

            LoadDrugs();
        }

        private void LoadDrugs()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var drugs = context.DrugEntities.ToList();
                    Drugs = new ObservableCollection<DrugEntity>(drugs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void AddDrug()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var maxId = context.DrugEntities.Max(d => d.Id);

                    var drug = new DrugEntity
                    {
                        Id = maxId + 1, 
                        Name = "",
                        Dosage = "", 
                        StartDate = DateOnly.FromDateTime(DateTime.Today),
                        EndDate = DateOnly.FromDateTime(DateTime.Today)
                    };

                    var window = new DrugAddEditWindow(drug);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(drug.Name))
                        {
                            MessageBox.Show("Название препарата обязательно для заполнения", "Ошибка");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(drug.Dosage))
                        {
                            MessageBox.Show("Дозировка препарата обязательна для заполнения", "Ошибка");
                            return;
                        }


                        context.DrugEntities.Add(drug);
                        context.SaveChanges();
                        LoadDrugs();
                        MessageBox.Show("Препарат успешно добавлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditDrug()
        {
            if (SelectedDrug == null) return;

            try
            {
                using (var context = new HospContext())
                {
                    var drugToEdit = context.DrugEntities.Find(SelectedDrug.Id);
                    if (drugToEdit == null)
                    {
                        MessageBox.Show("Препарат не найден в базе данных", "Ошибка");
                        return;
                    }


                    var editedDrug = new DrugEntity
                    {
                        Id = drugToEdit.Id,
                        Name = drugToEdit.Name,
                        Dosage = drugToEdit.Dosage,
                        StartDate = drugToEdit.StartDate,
                        EndDate = drugToEdit.EndDate
                    };

                    var window = new DrugAddEditWindow(editedDrug);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(editedDrug.Name))
                        {
                            MessageBox.Show("Название препарата обязательно для заполнения", "Ошибка");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(editedDrug.Dosage))
                        {
                            MessageBox.Show("Дозировка препарата обязателеньна для заполнения", "Ошибка");
                            return;
                        }

             
                        context.Entry(drugToEdit).CurrentValues.SetValues(editedDrug);
                        context.SaveChanges();
                        LoadDrugs();
                        MessageBox.Show("Препарат успешно обновлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при обновлении: {innerMessage}", "Ошибка");
            }
        }

        private void DeleteDrug()
        {
            if (SelectedDrug == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранный препарат?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new HospContext())
                    {
                        var drugToDelete = context.DrugEntities.Find(SelectedDrug.Id);
                        if (drugToDelete != null)
                        {
                            context.DrugEntities.Remove(drugToDelete);
                            context.SaveChanges();
                            LoadDrugs();
                            MessageBox.Show("Препарат успешно удален!", "Успешный успех");
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
