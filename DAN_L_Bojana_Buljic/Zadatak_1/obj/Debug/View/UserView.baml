   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Zadatak_1.ViewZadatak_1.View  5   	       Zadatak_1.View.UserView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Zadatak_1.View     5   	     � Title$  	User View��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6:   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��6 �6   �� 5      $
��auto �6   �� 5      $��6 �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5      $��1��5      $��1��5      .+�5      �� $	��Add��6   $��90��5      $
��Left=�5      ��5       �� *	AddSong+ �� UpdateSourceTrigger$ PropertyChanged=��� 5!      $��Delete��6   $��90��5"      $��Right=�5#      $��5,0,0,0q�5%      ��5$      �� *
DeleteSong+$ PropertyChanged=�5%      5&      �� 5'   
   $ Vertical=�6   $��Right=�5(      $��2��5)      $��3��5*      $��3��5+      .+�5,      �� $��Duration Asc��6   $	��5,5q�5.      ��5-      �� *DurationAsc+$ PropertyChanged=�5.      �� 5/      $��Duration Desc��6   $	��5,5q�51      ��50      �� *DurationDesc+$ PropertyChanged=�51      �� 52      $��Name Asc��6   $	��5,5q�54      ��53      �� *	NameAsc+$ PropertyChanged=�54      �� 55      $��	Name Desc��6   $	��5,5q�56      ��57      �� *
NameDesc+$ PropertyChanged=�58      � 59   
   $��1��6   $��3��5:      .+�5;      &   System.Windows.Controls.DataGrid     
IsReadOnly .    HeadersVisibility$ Column=�5>      	   AutoGenerateColumns	 .  ��5;      �� *
SongList+$ PropertyChanged=�
 �� SelectedItem
 5<      �� *Song+$ PropertyChanged=�   Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5B   )   �� *
SongName+  5C      $ Author��6)    5D   )   �� *
SongAuthor+  5E      $ Duration��6)    5F   )   �� *SongDuration+4  .System.Windows.Controls.DataGridTemplateColumn  5G         CellTemplate 5H      �� 5I      .R�5J   "   �� $
��Play��6)   ��5K   )   ��  �� RelativeSource ��  �� AncestorType"   �� Path$ DataContext.PlaySong�5L      5N      5P      5Q      5R      5S      