   M S B A M L   `   `   `  ���� F  BTestatNuGet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TestatNuGet.ViewModelTestatNuGet.ViewModel  %    TestatNuGet.View.LogentriesView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:TestatNuGet.ViewModel     .���   � RowDefinitions  �� $
��auto ��� $
��auto �.+��� $��
Navigation��$��0��.���   �� $��30 ��� $��50 � � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+��� -    ��Name$ txtblock_connection��$��0��$ ��Server Connection String: ��$	��150��$
��Left=�$��Center=��� -    ��Name$ txtbox_connectionString��$
��Left=�$��0��$��1��$��2��$	��450��$��20������  �� Path$ ConnectionString��� -    ��Name$ button_load��$��1��$��0��$
��Load��$
��Left=�$��Center=�$��75������ *LoadButtonCommand+�� -   $ button_confirm��$��1��$��0��$��2��$��Confirm��$��Center=�$��Center=�$��75������ *ConfirmButtonCommand+����  �� ElementName$ logentrie_dataGrid��$ SelectedItems��� -   $ 
button_add��$��1��$��0��$��2��$	��Add��$��Right=�$��Center=�$��75������ *
Navigate+�� $
��Data��$��1��.��&   System.Windows.Controls.DataGrid  -     Name$ logentrie_dataGrid��$��stretch=�$��1��"   VerticalScrollBarVisibility$
 auto=�$	��200������ $ 
Logentries�	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�