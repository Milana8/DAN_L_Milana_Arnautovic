   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Zadatak_1	Zadatak_1  5   	       Zadatak_1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Zadatak_1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      � $��0q�6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$ 
btnAddSong��5   (   $��80��6   $��20��6   $��Add Song��6<   $��685,284.2,28.6,-303.4q�5   Y   $
��Bold"�6x   $��4��6�   ��6   �� *
AddNewSong+ �� UpdateSourceTrigger$ PropertyChanged=�6�   � 5   
   $��1��6   $��1��6   $
��auto��6,   $
��auto��6:   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��DataGridSong��5         
IsReadOnly .    HeadersVisibility$ Column=�5   l      AutoGenerateColumns .     HorizontalGridLinesBrush
 �   �
���   �
���   �$
��Bold"�5      $��20q�6)   ��5   +   �� *AllCurrentUsersSongs+$ PropertyChanged=� �� SelectedItem 5      �� *Song+$ PropertyChanged=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 	Song Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.1* 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
SongName+6Y     5      $
 Author��6)   $
 0.1* 6T    69   �� *Author+6T     5      $
 Duration��6)   $ 0.125* 6X    6;   �� *
Duration+6X   4  .System.Windows.Controls.DataGridTemplateColumn  5          CellTemplate 5!      �� 5"      .R�5#   "   �� $��btnDeleteSong��6)   $��Delete��6>   $��4q�5%   )   $
��Bold"�64   ��5$   !   �� *DataContext.DeleteSong+$ PropertyChanged=� �� RelativeSource �� *FindAncestor+ �� AncestorType" �5%   4   5&      5(      5*      5+      5,      5-      