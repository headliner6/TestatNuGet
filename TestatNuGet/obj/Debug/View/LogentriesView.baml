   M S B A M L   `   `   `  ����F  BTestatNuGet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TestatNuGet.ViewModelTestatNuGet.ViewModel  5      %    TestatNuGet.View.LogentriesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:TestatNuGet.ViewModel     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��
Navigation��6   $��0��6'   .��5      �   5      �� 5      $��30 �6$   �� 5      $��50 �6$    � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   .+�5      �� -   5         ��Name$ txtblock_connection��5      $��0��5      $ ��Server Connection String: ��6)   $	��150��5      $
��Left=�5      $��Center=�5      �� 5      -   5         ��Name$ txtbox_connectionString��5      $
��Left=�5       $��0��5!      $��1��5"      $��2��5#      $	��450��5$      $��20��5%      ��5      ��  �� Path$ ConnectionString�5%      �� 5&      -   5         ��Name$ button_load��5&      $��1��5(      $��0��5)      $
��Load��5*      $
��Left=�5+      $��Center=�5,      $��75��5-      ��5'      �� *LoadButtonCommand+5-      �� 5.      -   5        $ button_confirm��5.      $��1��51      $��0��52      $��2��53      $��Confirm��54      $��Center=�55      $��Center=�56      $��75��57      ��5/      �� *ConfirmButtonCommand+��50      ��  �� ElementName$ logentrie_dataGrid��$ SelectedItems�57      �� 58      -   5        $ 
button_add��58      $��1��5:      $��0��5;      $��2��5<      $	��Add��5=      $��Right=�5>      $��Center=�5?      $��75��5@      ��59      �� *
Navigate+5@      5A      5B      �� 5C   
   $
��Data��6   $��1��6!   .��5D      &   System.Windows.Controls.DataGrid  -   5          Name$ logentrie_dataGrid��5D         
IsReadOnly . $��stretch=�5G      $��1��5H      "	   VerticalScrollBarVisibility$
	 auto=�5I      $	��200��5J      ��5F      �� $ 
Logentries�
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5J      5K      5L      5M      