   M S B A M L   `   `   `  ����  Sharkey    Sharkey.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   m iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah	 dMahApps.Metro.IconPacks.RemixIcon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj
 fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a@Icon-http://metro.mahapps.com/winfx/xaml/iconpacks    	 
 5   	   $	��720��5   	   $
��1080��6     � WindowStartupLocation$  CenterScreen=�6#    � AllowsTransparency$
 True��6H   
������  � WindowStyle$
 None=�5   "    � 	Resources 5         	BoolToVis��%   &	        �� 5	   
   6'   5
      .��5      �� -   5         �� CornerRadius$ 30��5      ���#EFF2F7._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   .+�5      ��   	topButton#��[ 6   $
��Left=�6<   $��
20 28 0 35q�6W   .��5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Menu=�6,   $��15��68   $��15��6C   5      �� 5      $��1��6   ���#623ED0$ 	0 50 0 30��6;   ._�5       ]� .+�5"      �� $��80��6!   $��80��6,    �� Padding$ 3q�68   
�������$	 100��6W   $	��Top=�6j   $
��Left=�6   $��
20 -30 0 0q�6�   5(      �� 5+      $��Михаил��6$   
�������$��22(�6E   $��SemiBold"�6S   $	��Top=�6i   $��	5 25 0 10q�6~   	 �� TextAlignment$	 Center=�6�   �� 5,      $-��'простой пользователь��6$   ���#D0BFFF$��14(�6U   $��SemiBold"�6c   $	��Top=�6y   $	 Center=�6�   �� 5/      $��25q�6$   ���#7E5FDC$	��Top=�6E   $	��0.8��6Z   �� 52      $	��Top=�6%   .+�53      ��   
menuButton#��[ 6%   .��54   "   �� 
 �� Orientation$
 
Horizontal=�6-   .+�55   &     $ HomeVariant=�6<     menuButtonIcon#��[ 6O   �� 56   &   $��Главная��60   57   #   58      �� 5:      #��[ 6%   ���#7B5CD6
�������.��5;   "   �� $
 
Horizontal=�6-   .+�5<   &     $ 
AccountKey=�6<   #��[ 6N   �� 5=   &   $��Пароли��60   5>   #   5?      �� 5A      #��[ 6%   .��5B   "   �� $
 
Horizontal=�6-   .+�5C   &     $ CreditCardPlus=�6<   #��[ 6R   �� 5D   &   $��Подписка��60   5E   #   5F      �� 5H      -   5        $��ImportButton��5H   %   #��[ 6^   .��5I   "   �� $
 
Horizontal=�6-   .+�5J   &     $ FileDownload=�6<   #��[ 6P   �� 5K   &   $��Импорт��60   5L   #   5M      �� 5O      -   5        $��ExportButton��5O   %   #��[ 6^   .��5P   "   �� $
 
Horizontal=�6-   .+�5Q   &     $ 
FileUpload=�6<   #��[ 6O   �� 5R   &   $��Экспорт��60   5S   #   5T      5V      �� 5X      -   5        $��CloseWindowButton��5X   !   #��[ 6\   $��Bottom=�6�   $��Bottom=�6�   $��
15 0 15 20q�6�   .��5Y      �� $
 
Horizontal=�6)   .+�5Z   "     $ Logout=�68   #��[ 6F   �� 5[   "   $��
Выйти��6,   5\      5]      5_      5`      5b      � 5e      $��1��6   $��30 20 20 20q�6#    5f      �� 5g      $
��auto �6$   �� 5h      $
��auto �6$   �� 5i      $
��auto �6$   �� 5j      $
��auto �6$   �� 5k      $
��auto �6$   �� 5l      $��* �6$   �� 5m      $
��auto �6$   .+�5p      �� #��[ 6   $��0 0 20 0q�6<   .��5q      / 	 )MahApps.Metro.IconPacks.PackIconRemixIcon     Kind$ MoonFill=�6-   5r      �� 5t      #��[ 6   $��0 0 55 0q�6<   .��5u        $
 Bell=�6,   5v      �� 5y      $��Пароли��6   $��1��6*   $��32(�67   $��SemiBold"�6E   $��0 20 0 0q�6[   ���#121518$
��Left=�6�   �� 5|      -   5        $��AddProfileButton��5|        	addButton#��[ 6R   .��5}      �� $
 
Horizontal=�6!   .+�5~        $
 Plus=�60   $��Center=�6<   $��0 1 8 0q�6W   $��11��6h   $��11��6s   �� 5      $��Новый профиль��6$   5�      5�      �� 5�      $��1��6   $��3��6'   ���#DAE2EA$��	0 -1 0 10q�6I   �� 5�      $��2��6   $
 
Horizontal=�6+   $��0 10 0 0q�6D   .+�5�      ��   	tabButton#��[ 6   $��Все��6@   ���#784FF26N   �� 5�      #��[ 6   $��
Сайты��6@   �� 5�      #��[ 6   $��Приложения��6@   5�      �� 5�      $��Профили��6   $��4��6+   $��18(�68   $��SemiBold"�6F   ���#121518$
��Left=�6q   $��Center=�6�   �� 5�      $��
Поиск��6   $��4��6)   $��13(�66   $��SemiBold"�6D   $��	0 0 215 0q�6Z   ���#121518$��Right=�6�   $��Center=�6�   � 5�      $	��200��6   $��Right=�6#   $��4��6?   .+�5�      �� $
��15 0q�6    $��Center=�6.   ���#B0B9C6 J� IsHitTestVisible$ False��6^    K� ZIndex$ 1��5�      $,��&Искать по названию ...��6-   y�5�      ��  �� ElementName$ textBoxFilter�� �� Path$ Text.IsEmpty� �� 	Converter# [  �� 5�      -   5        $��textBoxFilter��5�        filterTextBox#��[ 63   5�      &   System.Windows.Controls.DataGrid  5�      -   5          Name$ profilesDataGrid��5�   �     DataGridRowStyle1   RowStyle# �  6     DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  6J    	 DataGridCellStyle1   	CellStyle# � 	 6�    
 DataGridStyle1#��� 
 6�      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6-      
IsReadOnly$
 True��6<      CanUserResize$ False��6N      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6q   �� *Number+  5�      $ Название��6-   $
 True��6X   $ * 6j    6?   �� *Name+6j     5�      $ Категория��6-   $
 True��6]   $ * 6o    6@   �� *
Category+6o     5�      $ 
Логин��6-   $
 True��6V   $ * 6h    6<   �� *Login+6h     5�      $ Пароль��6-   $
 True��6V   $ * 6h    6=   �� *Hash+6h   4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ Действия��61   $
 True��6C   $
 auto 6U      CellTemplate 5�      �� 5�   "   .R�5�   &   �� $
 
Horizontal=�61   .+�5�   *   �� $��EditProfileButton��61   -   5          gridEditButton#��[ 5�   l   .��5�   .     $ PencilOutline=�6D     gridButtonIcon#��[ 6Y   5�   +   �� 5�   *   $��DeleteProfileButton��61   -	   5        $��5 0 0 0q�5�   p     gridRemoveButton#��[ 6�   .��5�   .     $ DeleteOutline=�6D   #��[ 6Y   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      