   M S B A M L   `   `   `  ����D  @PRAKTIKA5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PRAKTIKA5	PRAKTIKA5  5   	       PRAKTIKA5.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PRAKTIKA5     5   	     � Title$  
UserWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 
ExitButton��5      $��
Выйти��6%   $��8��65   $��5��6E    � Cursor$
 Hand��6k   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ТоварDataGrid��5      ���	#FFE5E5E5$��4��6A   $��5��6U   6f     5    
   -   5        $ ЧекDataGrid��5       ���	#FFE5E5E5$��5��6?   $��4��6O   $��5��6c   �� 5!   
   -   5        $ 	AddButton��5!      $��	В чек��6$   $��4��64   $��1��6D   �� 5"   
   -   5        $ 	DelButton��5"      $��Убрать��6$   $��4��65   $��2��6E   5#      5$      