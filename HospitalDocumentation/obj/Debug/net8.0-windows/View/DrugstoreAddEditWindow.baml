   M S B A M L   `   `   `  ����P  LHospitalDocumentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HospitalDocumentation.ViewHospitalDocumentation.View  5   	   Q-clr-namespace:HospitalDocumentation.ViewModelHospitalDocumentation.ViewModel  5   	   7    1HospitalDocumentation.View.DrugstoreAddEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:HospitalDocumentation.View     5   	   <vm-clr-namespace:HospitalDocumentation.ViewModel     5   	     � Title$  DrugstoreAddEditWindow��5	   	   $	��450��6(   $	��800��65    � WindowStartupLocation$ CenterOwner=�6A   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Препарат:��6   $��0��6%   $��5q�62   $��Center=�6=   �� 5   
   $��0��6   $��1��6    $��5q�60    �� SelectedValuePath$ Id��5       �� DisplayMemberPath$
 Name��5      ��5      �� *Drugs+ �� SelectedValue 5      �� *Drugstore.DrugId+5      �� 5   
   $��2��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�5       $��Right=�6.   .+�5!      �� -   5        $��Сохранить��5!      $	��100��5"      $��30��6!   $��5q�6-   �� 5#      $��Отмена��6    �� IsCancel$
 True��6&   $	��100��5$      $��30��6!   $��5q�6-   5%      5&      5'      