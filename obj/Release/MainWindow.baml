   M S B A M L   `   `   `  ���� H  DJournal_Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Journal_AdminJournal_Admin  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections     Journal_Admin.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:Journal_Admin     Bcol2clr-namespace:System.Collections;assembly=mscorlib       � Title$J  DАдминистрирование 'Журнал обращений'��$	��350��$	��530�� � WindowStartupLocation$ CenterScreen=�.��� $��0, 0,-0.4,0q� � ColumnDefinitions �� .+��� -    ��Name$ appeal��.@��� -    ��Name$ 	activeTab������  �� Orientation$ 
Horizontal=�.+�A� $��10��$��10��
���   ��� $��3q�Текущие���  � RowDefinitions �� �� $
��Auto �.+��� $��	0,5,0.6,5q�$��Visible=�.��&   System.Windows.Controls.DataGrid  -     Name$ 
activeGrid��   CanUserAddRows . 	   CanUserDeleteRows	 . 
   CanUserSortColumns
 .    CanUserReorderColumns .    
IsReadOnly . ���� *
Requests+ �� SelectedItem �� *SelectedPerson+�� $ 
Horizontal=�$��1��$��30��$��Center=�.+��� $��Рассмотренно��$��2q����� *DoneRowCommand+�� $��Удалить��$��2q����� *DeleteRowCommand+�� $��Информация��$��2q����� *GetRowInfoCommand+�� -   $ 
tabletsTab������ $ 
Horizontal=�.+��� $��10��$��10��
���   ��� $��3q�Рассмотренные���  �� �� $
��Auto �.+��� $��	0,5,0.6,5q�$��Visible=�.��  -   $ doneGrid�� . 	 . 
 .  .  . ���� *DoneRequests+ �� *SelectedPerson+�� $ 
Horizontal=�$��1��$��30��$��Center=�.+��� $��Удалить��$��2q����� *DeleteRowCommand+�� $��Экспорт в Excel��$��2q����� *ExportToExcelCommand+�� $��Информация��$��2q����� *GetRowInfoCommand+