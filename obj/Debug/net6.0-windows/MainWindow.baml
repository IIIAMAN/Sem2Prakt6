   M S B A M L   `   `   `  ����K  GPrakticheskaya_6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Prakticheskaya_6Prakticheskaya_6  5   	   !    Prakticheskaya_6.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Prakticheskaya_6     5   	     � Title$  
MainWindow��5	   	   $	��400��6   $	��600��6)   ��5
      �� 5   
    �� ImageSource$+ %/kandinsky-download-1683053030482.png��6    j� Stretch$
 Fill=�6I   .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5       6   �� 5!      6   �� 5"      6   .+�5$   
   �� $'��!Выберите действие��6   $��	10,4,10,4q�6,   $��9��6?   $	��NaN��6S   
�������$��16(�6s   $��Bradley Hand ITC)�6�   $
��Bold"�6�   $��Center=�6�   $��Center=�6�   $��1��6�   ��5%      �� 5&       �� Color$ 	#FF330338��6"    �� Opacity$	 0.7Q�64   5(      �� 5)   
   $��Ktotamus��6   $��	10,4,10,4q�6#   $��9��66   $	��NaN��6J   
�������$��20(�6j   $��Bradley Hand ITC)�6x   $
��Bold"�6�   $��Center=�6�   ��5*      �� 5+      $ Black��6"   $	 0.7Q�60   5-      �� 5.   
   -   5         ��Name$ NameUser��5.      $��2��6$    �� TextWrapping$
 Wrap=�61   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$%	 Имя пользователя��6E   $��10,22,10,24q�6w   $��9��6�   
�������
 �� SelectionBrush
 �	#FFF3F3F3 �� SelectionTextBrush �	#FFB9B9B9 �� 
CaretBrush
 �����$��2��6   $��16(�6  .��6  ��5/      �� 50      $ 	#FF250F46��6"   $	 0.8Q�64   .��51   "   52      �� 53   
   -   5        $ IpText��53      $��4��6"   $
 Wrap=�6/   $	 IP адрес чата��6C   $��10,10,10,34q�6r   $��9��6�   
�������
 �	#FFF3F3F3 �	#FFB9B9B9
 �����$��2��6�   $��16(�6  .��6  ��54      �� 55      $ 	#FF250F46��6"   $	 0.8Q�64   .��56   "   57      �� 58   
   -   5         ��Name$ NewChat��58      $��New chat��6"   $��2��65   $��6��6F   ���	#FF150433���	#FF9E9AA5$��10,27,10,26q�6�   $��3��6�   6�   �� 59   
   -   5        $ 
JoinToChat��59      $��Join to chat��6%   $��2��6<   $��6��6M   $��3��6Z   ���	#FF150433���	#FF9E9AA5$��6��6�   $��10,27,10,26q�6�   6�   5:      5;      