   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Zadatak_1.ViewZadatak_1.View  5   	   =#clr-namespace:Zadatak_1.ValidationsZadatak_1.Validations  5   	       Zadatak_1.View.AddView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Zadatak_1.View     5   	   :
Validation#clr-namespace:Zadatak_1.Validations     5   	     � Title$  Add Song��5	   	   $	��100��5
   	   $	��200��5   	    � SizeToContent$ WidthAndHeight=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5       $
��auto �6   �� 5!      $��20 �6   .+�5#   
   �� $��
Song Name:��6   $��1��5$      $��1��5%      �� 5&   
   $��Author:��6   $��1��5'      $��3��5(      �� 5)   
   $��Song Duration:��6   $��1��5*      $��5��5+      �� 5,   
   $��3��5-      $��1��5.      $	��200��5/      ��5,      �� *Song.SongName+ �� UpdateSourceTrigger$ PropertyChanged=�5/      �� 50   
   $��3��51      $��3��52      ��50      �� *Song.SongAuthor+$ PropertyChanged=�52      �� 53   
   -   5         ��Name$ btnDuration��53         errorTemplate =� ErrorTemplate# [  54      $��3��55      $��5��56      .��6   ��57      �� 58       �� Path$ Song.SongDuration�6   $ PropertyChanged=�59      	 �� ValidatesOnDataErrors	 . 
 �� NotifyOnValidationError
 .  �� ValidationRules 5<      *  $Zadatak_1.Validations.SongValidation  5=      5?      .��5@      5A      �� 5B   
   $��3��6   $��7��5C      $
��Save��5D      $��90��5E      $
��Left=�5F      ��5G      �� *Save+��5H      �� 5I       �� 
TargetType" ��6   .�5J      ��  �� Property � {� �� Value .  5K       �� Triggers 5L      ^� 5M       ^� 
Conditions 5N      �� 5O   "    �� Binding 6,   �� $ (Validation.HasError)� �� ElementName$ btnDuration�� �� Value	 False5P   ,   .0�5R      ��  � {� . 5S   %   5T      5V      5X      �� 5Y   
   $��3��6   $��7��5Z      $��Cancel��5[      $��90��5]      $��Right=�5^      ��5\      �� *Cancel+5^      5_      5`      