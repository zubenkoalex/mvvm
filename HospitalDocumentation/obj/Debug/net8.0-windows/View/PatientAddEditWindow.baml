   M S B A M L   `   `   `  ����P  LHospitalDocumentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HospitalDocumentation.ViewHospitalDocumentation.View  5   	   Q-clr-namespace:HospitalDocumentation.ViewModelHospitalDocumentation.ViewModel  5   	   5    /HospitalDocumentation.View.PatientAddEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:HospitalDocumentation.View     5   	   <vm-clr-namespace:HospitalDocumentation.ViewModel     5   	     � Title$  PatientAddEditWindow��5	   	   $	��450��6&   $	��800��63    � WindowStartupLocation$ CenterOwner=�6?   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��ФИО:��6   $��0��6    $��0��6-   $��5q�6=   $��Center=�6H   �� 5   
   $��0��6   $��1��6   $��5q�6/   ��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5!   
   $ ��Дата рождения:��6   $��1��6*   $��0��67   $��5q�6G   $��Center=�6R   (  "System.Windows.Controls.DatePicker  5"   
   $��1��6   $��1��6"   $��5q�62      SelectedDate 5#      �� *DateOfBirth+�� 5&   
   $��Пол:��6   $��2��6    $��0��6-   $��5q�6=   $��Center=�6H   �� 5'   
   $��2��6   $��1��6   $��5q�6/   ��5(   
   �� *Sex+$ PropertyChanged=��� 5+   
   $��Адрес:��6   $��3��6"   $��0��6/   $��5q�6?   $��Center=�6J   �� 5,   
   $��3��6   $��1��6   $��5q�6/   ��5-      �� *	Address+$ PropertyChanged=��� 50   
   $��Телефон:��6   $��4��6$   $��0��61   $��5q�6A   $��Center=�6L   �� 51   
   $��4��6   $��1��6   $��5q�6/   ��52      �� *PhoneNumber+$ PropertyChanged=��� 55   
   $��Email:��6   $��5��6"   $��0��6/   $��5q�6?   $��Center=�6J   �� 56   
   $��5��6   $��1��6   $��5q�6/   ��57      �� *Email+$ PropertyChanged=��� 5:   
   $��7��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�5;      $��Right=�6.   .+�5<      �� -   5        $��Сохранить��5<      $	��100��5=      $��30��6!   $��5q�6-   �� 5>      $��Отмена��6    �� IsCancel$
 True��6&   $	��100��5?      $��30��6!   $��5q�6-   5@      5A      5B      