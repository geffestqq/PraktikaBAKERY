   M S B A M L   `   `   `  ����A  =Bakery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BakeryBakery  5   	       Bakery.Tovar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Bakery     5   	   -   5          � Title$  
Товар��5   	   $	��600��6   $	��800��6$    � WindowStartupLocation$ CenterScreen=�60      CommonBackground#���   6U   .��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5       6!   �� 5!      6!   �� 5"      6!   �� 5#      6!   �� 5$      6!   �� 5%      6!   �� 5&      6!   .+�5*   
   �� -   5        $��	lbl_Tovar��5*   -   $��Times New Roman)�6   $��0��6>   $��1��6K   $��9��6[   $��
Товар��6o   $��Center=�6   $��16(�6�   $��Center=�6�   &   System.Windows.Controls.DataGrid  5+   
   -   5        $��dgTovar��5+   >   $��Times New Roman)�6   $��12(�60      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6M      AutoGenerateColumns .    
IsReadOnly . $��1��6�   $��1��6�   $��9��6�   $��4��6�   6�   �� 5-   
   -   5        $��lbl_Name_Tovar��5-   -   $��Times New Roman)�6   $��5��6C   $��1��6P   $��2��6`   $#��Название товара��6t   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 5.   
   -   5        $��tb_Name_Tovar��5.   /   $��Times New Roman)�6   
�������$��5��6�   $��3��6�   $��2��6�   $��30��6�    �� 	MaxLength$ 30��6�   ��6[   �� *SelectedItem.Name_Tovar+ �� ElementName$ dgTovar��6�   �� 50   
   -   5        $��lbl_Cena��50   -   $��Times New Roman)�6   $��6��6=   $��1��6J   $��2��6Z   $��Цена��6n   $
��Left=�6}   $��14(�6�   $��Center=�6�   �� 51   
   -   5        $��tb_Cena��51   /   $��Times New Roman)�6   
�������$��6��6�   $��3��6�   $��2��6�   $��30��6�   $ 30��6�   ��6U   �� *SelectedItem.Cena+$ dgTovar��6�   �� 53   
   -   5        $��lbl_Data_Proisvodstva��53   -   $��Times New Roman)�6   $��7��6J   $��1��6W   $��2��6g   $(��"Дата производства:��6{   $
��Left=�6�   $��14(�6�   $��Center=�6�   (  "System.Windows.Controls.DatePicker  54   
   -	   5        $��dp_Data_Proisvodstva��54   2   $��Times New Roman)�6   
�������$��7��6�   $��3��6�   $��2��6�   $��30��6�   	   Text	 6e   �� * SelectedItem.Data_Proisvodstva+$ dgTovar��6�   �� 58   
   -
   5        $��lbl_Name_Sirie��58   -   $��Times New Roman)�6   $��5��6C   $��6��6P   $��2��6`   $��Выбор сырья:��6t   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 59   
   -   5        $��cb_Name_Sirie��59      
 �� 
IsReadOnly
 . $��8��6;   $��5��6K   $��2��6X   $��30��6l   6z   �� 5;   
   -   5        $��lbl_Sotrudnik_Info��5;   -   $��Times New Roman)�6   $��6��6G   $��6��6T   $��2��6d   $&�� Выбор сотрудника:��6x   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 5<   
   -   5        $��cb_Sotrudnik_Info��5<      
 . $��8��6?   $��6��6O   $��2��6\   $��30��6p   6~   �� 5>   
   -   5        $��lbl_Type_Tovar��5>   -   $��Times New Roman)�6   $��7��6C   $��6��6P   $��2��6`   $��Тип товара:��6t   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 5?   
   -   5        $��cb_Type_Tovar��5?      
 . $��8��6;   $��7��6K   $��2��6X   $��30��6l   6z   �� 5B   
   -   5        $��lbl_Kolichestvo_Tovar��5B   -   $��Times New Roman)�6   $��8��6J   $��1��6W   $��2��6g   $'��!Количество товара��6{   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 5C   
   -   5        $��tb_Kolichestvo_Tovar��5C   /   $��Times New Roman)�6   
�������$��8��6�   $��3��6�   $��2��6�   $��30��6�   $ 30��6�   ��6b   �� * SelectedItem.Kolichestvo_Tovar+$ dgTovar��6�   �� 5G   
   -   5        $��	tb_Search��5G      
�������$��10��6:   $��1��6H   $��2��6X   $��30��6l   $��Tahoma)�6x   �� 5H   
   -   5        $��bt_Insert_Tovar��5H   .   $��Times New Roman)�6   $!��Добавить товар��6E   $��1��6_   $��11��6o   $��2��6}   $��30��6�   6�   �� 5I   
   -   5        $��bt_Update_Tovar��5I   .   $��Times New Roman)�6   $!��Изменить товар��6E   $��4��6_   $��11��6o   $��3��6}   $��30��6�   6�   �� 5J   
   -   5        $��bt_Delete_Tovar��5J   .   $��Times New Roman)�6   $��Удалить товар��6E   $��8��6^   $��11��6n   $��2��6|   $��30��6�   6�   �� 5K   
   -   5        $��	bt_Cancel��5K   .   $��Times New Roman)�6   $��Сбросить��6?   $��8��6S   $��10��6c   $��2��6q   $��30��6�   6�   �� 5L   
   -   5        $��	bt_Search��5L   .   $��Times New Roman)�6   $��
Поиск��6?   $��4��6P   $��10��6`   $��3��6n   $��30��6�   6�   �� 5M   
   -   5        $��bt_Back��5M   .   $��Times New Roman)�6   $��Главное меню��6=   $��4��6U   $��13��6e   $��3��6s   $��30��6�   6�   5P      5Q      