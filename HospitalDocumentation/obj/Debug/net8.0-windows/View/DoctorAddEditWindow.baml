   M S B A M L   `   `   `  ����P  LHospitalDocumentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HospitalDocumentation.ViewHospitalDocumentation.View  5   	   Q-clr-namespace:HospitalDocumentation.ViewModelHospitalDocumentation.ViewModel  5   	   4    .HospitalDocumentation.View.DoctorAddEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:HospitalDocumentation.View     5   	   <vm-clr-namespace:HospitalDocumentation.ViewModel     5   	     � Title$  DoctorAddEditWindow��5	   	   $	��450��6%   $	��800��62   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��ФИО:��6   $��0��6    $��0��6-   $��5q�6=   $��Center=�6H   �� 5   
   $��0��6   $��1��6   $��5q�6/   ��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5!   
   $!��Специальность:��6   $��1��6*   $��0��67   $��5q�6G   $��Center=�6R   �� 5"   
   $��1��6   $��1��6   $��5q�6/   ��5#      �� *
Speciality+$ PropertyChanged=��� 5&   
   $��Телефон:��6   $��2��6$   $��0��61   $��5q�6A   $��Center=�6L   �� 5'   
   $��2��6   $��1��6   $��5q�6/   ��5(      �� *PhoneNumber+$ PropertyChanged=��� 5+   
   $��Email:��6   $��3��6"   $��0��6/   $��5q�6?   $��Center=�6J   �� 5,   
   $��3��6   $��1��6   $��5q�6/   ��5-      �� *Email+$ PropertyChanged=��� 5/   
   $��Марка:��6   $��4��6"   $��5q�6/   $��Center=�6:   �� 50   
   $��4��6   $��1��6    $��5q�60    �� SelectedValuePath$ Id��52       �� DisplayMemberPath$
 Mark��53       �� SelectedValue 51      �� *Doctors.CarId+53      �� 55   
   $��Модель:��6   $��5��6#   $��5q�60   $��Center=�6;   �� 56   
   $��5��6   $��1��6    $��5q�60   $ Id��59      $ Model��5:      ��57      �� *CarDoctorEntities+ 58      �� *Doctors.CarId+5:      �� 5=   
   $��7��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�5>      $��Right=�6*   .+�5?      �� -   5        $��Сохранить��5?      $	��100��5@      $��30��6   $��5q�6)   �� 5A      $��Отмена��6    �� IsCancel$
 True��6&   $	��100��5B      $��30��6   $��5q�6)   5C      5D      5E      