   M S B A M L   `   `   `  ����?  ;Lab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab2Lab2  5   	       Lab2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab2     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	     � Title$  
MainWindow��5	   	   $
��1000��6   $
��1500��6*   .��5
      � .+�5   
   � $	��400��6   $	��500��6   $
��Left=�6(   $	��Top=�6C   $��
350,50,0,0q�6[   .+�5        OxyPlot.Wpf.Plot  -   5          Name$ Plot1��5         Title$  ��6&   $	��400��6/   $	��500��6<   $��-309,425,309,-425q�6H      Series 5        OxyPlot.Wpf.LineSeries  5        OxyPlot.Wpf.Series   Title$  ��6%      Color$
 Blue��5         
MarkerFill$
 Blue��5         
MarkerType$ Circle=�5      ��5      �� *YearAndPopulation+5         Axes 5        OxyPlot.Wpf.LinearAxis  5        OxyPlot.Wpf.Axis	   Title$	 Года��6%   
   MajorGridlineStyle$

 Dash=�5         Position$ Bottom=�5         AbsoluteMaximum$	 200Q�5         AbsoluteMinimum$ 0Q�5        5      $	 Кол-во людей��6%   $

 Dash=�5      $
 Left=�5      $ 0Q�5      $ 2000000Q�5      5"      5#      �� 5$   
   $	��400��6   $	��300��6    $
��Left=�6T   $	��Top=�6o   $��	20,50,0,0q�6�   ��6,   �� *TablePopAndYear+6�   �� 5%   
   $	��100��6   $	��400��6    $
��Left=�6U   $	��Top=�6p   $��
456,47,0,0q�6�   ��6,   �� *DoublePopulation+6�   �� 5&   
   $	��100��6   $	��400��6    $
��Left=�6e   $	��Top=�6�   $��450,244,0,0q�6�   ��6,   �� *" TablePopAndYearIfMinusTenPercent+6�   �� 5'   
   $	��300��6   $	��400��6    $
��Left=�6O   $	��Top=�6j   $��1000,55,0,0q�6�   ��6,   �� *
TableTask4+6�   � 5(   
   $	��400��6   $	��500��6   $
��Left=�6(   $	��Top=�6C   $��
900,50,0,0q�6[   .+�5)        -   5        $ Plot2��5)      $  ��6&   $	��400��6/   $	��500��6<   $��-5,417,5,-417q�6H    5*        5+      $  ��6%   $
 Blue��5-      $
 Blue��5.      $ Circle=�5/      ��5,      �� *
GraphTask4+5/       52        53      $	 Года��6%   $

 Dash=�54      $ Bottom=�55      $	 200Q�56      $ 0Q�57        58      $	 Кол-во людей��6%   $

 Dash=�59      $
 Left=�5:      $ 0Q�5;      $ 2000000Q�5<      5?      5@      �� 5A   
   $��Задание 1��6   $
��Left=�6$   $��	107,8,0,0q�6?   $	��Top=�6R   $��20(�6j   �� 5B   
   $��Задание 2��6   $
��Left=�6$   $��
603,10,0,0q�6?   $	��Top=�6S   $��20(�6k   �� 5C   
   $��Задание 3��6   $
��Left=�6$   $��603,207,0,0q�6?   $	��Top=�6T   $��20(�6l   �� 5D   
   $��Задание 4��6   $
��Left=�6$   $��1130,13,0,0q�6?   $	��Top=�6T   $��20(�6l   5E      5F      