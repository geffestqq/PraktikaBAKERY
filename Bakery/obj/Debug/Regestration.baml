   M S B A M L   `   `   `  ����A  =Bakery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BakeryBakery  5   	       Bakery.Regestration   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Bakery     5   	     � Title$  Регистрация��5   	   $	��400��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�66      CommonBackground#���   6[   .��5	      �  � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   .+�5"   
   �� -   5        $��lbl_Regestration��5"   -   $��Times New Roman)�6   $��0��6E   $��1��6R   $��9��6b   $��Регистрация��6v   $��Center=�6�   $��16(�6�   $��Center=�6�   �� 5$   
   -   5        $��lbl_Familiya_Sotrudnik��5$   .   $��Times New Roman)�6   $��1��6L   $��1��6Y   $��2��6i   $*��$Фамилия сотрудника:��6}   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 5%   
   -   5        $��tb_Familiya_Sotrudnik��5%   /   $��Times New Roman)�6   
�������$��1��6�   $��3��6�   $��2��6�   $��30��6�    �� 	MaxLength$ 30��6�   ��6c   �� *!SelectedItem.Familiya_Sotrudnik+ �� ElementName$ dgSotrudnik��6�   �� 5'   
   -   5        $��lbl_Name_Sotrudnik��5'   -   $��Times New Roman)�6   $��2��6G   $��1��6T   $��2��6d   $"��Имя сотрудника:��6x   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 5(   
   -   5        $��tb_Name_Sotrudnik��5(   /   $��Times New Roman)�6   
�������$��2��6�   $��3��6�   $��2��6�   $��30��6�   $ 30��6�   ��6_   �� *SelectedItem.Name_Sotrudnik+$ dgSotrudnik��6�   �� 5*   
   -   5        $��lbl_Otchestvo_Sotrudnik��5*   -   $��Times New Roman)�6   $��3��6L   $��1��6Y   $��2��6i   $,��&Отчесвто сотрудника:��6}   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 5+   
   -   5        $��tb_Otchestvo_Sotrudnik��5+   /   $��Times New Roman)�6   
�������$��3��6�   $��3��6�   $��2��6�   $��30��6�   $ 30��6�   ��6d   �� *" SelectedItem.Otchestvo_Sotrudnik+$ dgSotrudnik��6�   �� 5-   
   -   5        $��
lbl_LoginS��5-   -   $��Times New Roman)�6   $��1��6?   $��6��6L   $��2��6\   $��Логин:��6p   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 5.   
   -	   5        $��	tb_LoginS��5.   /   $��Times New Roman)�6   
�������$��1��6�   $��7��6�   $��2��6�   $��30��6�   $ 6��6�   ��6W   �� *SelectedItem.LoginS+$ dgSotrudnik��6�   �� 50   
   -
   5        $��lbl_PasswordS��50   -   $��Times New Roman)�6   $��2��6B   $��6��6O   $��2��6_   $��Пароль:��6s   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 51   
   -   5        $��tb_PasswordS��51   /   $��Times New Roman)�6   
�������$��2��6�   $��7��6�   $��2��6�   $��30��6�   $ 6��6�   ��6Z   �� *SelectedItem.PasswordS+$ dgSotrudnik��6�   �� 53   
   -   5        $��bt_Reg_Sotr��53   .   $��Times New Roman)�6   $&�� Зарегестрировать��6A   $��1��6]   $��4��6m   $��2��6z   $��30��6�   6�   �� 54   
   -   5        $��	bt_Cancel��54   .   $��Times New Roman)�6   $��Отменить��6?   $��7��6S   $��4��6c   $��2��6p   $��30��6�   6�   57      58      