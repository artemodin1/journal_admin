   M S B A M L   `   `   `  ����H  DJournal_Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Journal_AdminJournal_Admin  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 63       Journal_Admin.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Journal_Admin     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     63     � Title$J  DАдминистрирование 'Журнал обращений'��5   	   $	��350��66   $	��530��6C    � WindowStartupLocation$ CenterScreen=�6O   .��5	      � $��0, 0,-0.4,0q�6    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ appeal��5      .@�5      �� -   5         ��Name$ 	activeTab��5      ��5      �� 5       �� Orientation$ 
Horizontal=�6!   .+�5      A� $��10��6"   $��10��6.   
���   �69   �� 5      $��3q�6$   Текущие68   5      ��5      � 5       � RowDefinitions 5      �� 5      �� 5      $
��Auto �6,   .+�5      �� $��	0,5,0.6,5q�6'   $��Visible=�6:   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
activeGrid��5   '      CanUserAddRows . 	   CanUserDeleteRows	 . 
   CanUserSortColumns
 .    CanUserReorderColumns .    
IsReadOnly . ��6;   �� *
Requests+ �� SelectedItem 6\   �� *SelectedPerson+5      5      �� 5       $ 
Horizontal=�6%   $��1��6>   $��30��6K   $��Center=�6W   .+�5!      �� $��Рассмотренно��6%   $��2q�6<   ��6G   �� *DoneRowCommand+�� 5"      $��Удалить��6%   $��2q�67   ��6B   �� *DeleteRowCommand+�� 5#      $��Информация��6%   $��2q�6:   ��6E   �� *GetRowInfoCommand+5$      5%      5'      �� 5(      -   5        $ 
tabletsTab��5(      ��5)      �� 5*      $ 
Horizontal=�6!   .+�5+      �� $��10��6$   $��10��60   
���   �6;   �� 5,      $��3q�6$   Рассмотренные6>   5-      ��5/      � 50       51      �� 52      �� 53      $
��Auto �6,   .+�55      �� $��	0,5,0.6,5q�6'   $��Visible=�6:   .��56        -   5        $ doneGrid��56   '    . 	 . 
 .  .  . ��69   �� *DoneRequests+ 6^   �� *SelectedPerson+58      59      �� 5:      $ 
Horizontal=�6%   $��1��6>   $��30��6K   $��Center=�6W   .+�5;      �� $��Удалить��6%   $��2q�67   ��6B   �� *DeleteRowCommand+�� 5<      $��Экспорт в Excel��6%   $��2q�6?   ��6J   �� *ExportToExcelCommand+�� 5=      $��Информация��6%   $��2q�6:   ��6E   �� *GetRowInfoCommand+5>      5?      5A      5B      5C      5D      