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
    public class AppointmentRecordViewModel : NotifyProperty
    {
        private ObservableCollection<AppointmentRecordEntity> _appointmentRecords;
        private AppointmentRecordEntity? _selectedAppointmentRecord;

        public ObservableCollection<AppointmentRecordEntity> AppointmentRecords
        {
            get => _appointmentRecords;
            set
            {
                _appointmentRecords = value;
                OnPropertyChanged();
            }
        }

        public AppointmentRecordEntity? SelectedAppointmentRecord
        {
            get => _selectedAppointmentRecord;
            set
            {
                _selectedAppointmentRecord = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public AppointmentRecordViewModel()
        {
            _appointmentRecords = new ObservableCollection<AppointmentRecordEntity>();

            AddCommand = new RelayCommand(AddAppointmentRecord);
            EditCommand = new RelayCommand(EditAppointmentRecord, () => SelectedAppointmentRecord != null);
            DeleteCommand = new RelayCommand(DeleteAppointmentRecord, () => SelectedAppointmentRecord != null);

            LoadAppointmentRecords();
        }

        private void LoadAppointmentRecords()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var appointmentRecords = context.AppointmentRecordEntities.ToList();
                    AppointmentRecords = new ObservableCollection<AppointmentRecordEntity>(appointmentRecords);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void AddAppointmentRecord()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var maxId = context.AppointmentRecordEntities.Max(a => a.Id);

                    var appointmentRecord = new AppointmentRecordEntity
                    {
                        Id = maxId + 1, 
                        Date = DateOnly.FromDateTime(DateTime.Today),
                        Reason = ""
                    };

                    var window = new AppointmentRecordAddEditWindow(appointmentRecord);
                    if (window.ShowDialog() == true)
                    {

                        if (string.IsNullOrWhiteSpace(appointmentRecord.Reason))
                        {
                            MessageBox.Show("Причина анализа обязательна для заполнения", "Ошибка");
                            return;
                        }

                      
                        context.AppointmentRecordEntities.Add(appointmentRecord);
                        context.SaveChanges();
                        LoadAppointmentRecords();
                        MessageBox.Show("Запись на приём успешно добавлна!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditAppointmentRecord()
        {
            if (SelectedAppointmentRecord == null) return;

            try
            {
                using (var context = new HospContext())
                {
                    var appointmentRecordToEdit = context.AppointmentRecordEntities.Find(SelectedAppointmentRecord.Id);
                    if (appointmentRecordToEdit == null)
                    {
                        MessageBox.Show("Запись на приём не найдена в базе данных", "Ошибка");
                        return;
                    }

   
                    var editedAppointmentRecord = new AppointmentRecordEntity
                    {
                        Id = appointmentRecordToEdit.Id,
                        Date = appointmentRecordToEdit.Date,
                        Reason = appointmentRecordToEdit.Reason
                    };

                    var window = new AppointmentRecordAddEditWindow(editedAppointmentRecord);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(editedAppointmentRecord.Reason))
                        {
                            MessageBox.Show("Причина записи на приём обязательна для заполнения", "Ошибка");
                            return;
                        }

                        // Обновляем значения
                        context.Entry(appointmentRecordToEdit).CurrentValues.SetValues(editedAppointmentRecord);
                        context.SaveChanges();
                        LoadAppointmentRecords();
                        MessageBox.Show("Запись на приём успешно обновлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при обновлении: {innerMessage}", "Ошибка");
            }
        }

        private void DeleteAppointmentRecord()
        {
            if (SelectedAppointmentRecord == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранную запись на приём?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new HospContext())
                    {
                        var appointmentRecordToDelete = context.AppointmentRecordEntities.Find(SelectedAppointmentRecord.Id);
                        if (appointmentRecordToDelete != null)
                        {
                            context.AppointmentRecordEntities.Remove(appointmentRecordToDelete);
                            context.SaveChanges();
                            LoadAppointmentRecords();
                            MessageBox.Show("Запись на приём успешно удалена!", "Успешный успех");
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
