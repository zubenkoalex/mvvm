   M S B A M L   `   `   `  ����P  LHospitalDocumentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HospitalDocumentation.ViewHospitalDocumentation.View  5   	   8    2HospitalDocumentation.View.CarDoctorsAddEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:HospitalDocumentation.View     5   	     � Title$  CarDoctorsAddEditWindow��5   	   $	��450��6)   $	��800��66   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Марка:��6   $��0��6"   $��0��6/   $��5q�6?   $��Center=�6J   �� 5   
   $��0��6   $��1��6   $��5q�6/   ��5      �� *Mark+ �� UpdateSourceTrigger$ PropertyChanged=��� 5    
   $��Модель:��6   $��1��6#   $��0��60   $��5q�6@   $��Center=�6K   �� 5!   
   $��1��6   $��1��6   $��6,0,4,0q�6/   ��5"      �� *Model+$ PropertyChanged=��� 5&   
   $��Поколение:��6   $��2��6&   $��0��63   $��5q�6C   $��Center=�6N   �� 5'   
   $��2��6   $��1��6   $��5q�6/   ��5(      �� *
Generation+$ PropertyChanged=��� 5+   
   $��Год выпуска:��6   $��3��6(   $��0��65   $��5q�6E   $��Center=�6P   �� 5,   
   $��3��6   $��1��6   $��5q�6/   ��5-      �� *ReleaseYear+$ PropertyChanged=��� 50   
   $"��Примерная цена:��6   $��4��6+   $��0��68   $��5q�6H   $��Center=�6S   �� 51   
   $��4��6   $��1��6   $��5q�6/   ��52      �� *ApproximatePrice+$ PropertyChanged=��� 55   
   $��7��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�56      $��Right=�6+   .+�57      �� -   5        $��Сохранить��57      $	��100��58      $��30��6   $��5q�6*   �� 59      $��Отмена��6    �� IsCancel$
 True��6&   $	��100��5:      $��30��6   $��5q�6*   5;      5<      5=      