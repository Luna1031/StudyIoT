   M S B A M L   `   `   `  ����L  HMqttMonitoringApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MqttMonitoringApp.ViewsMqttMonitoringApp.Views  5      )    #MqttMonitoringApp.Views.HistoryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5      1local%clr-namespace:MqttMonitoringApp.Views  5      .��5
      �   � RowDefinitions  5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� $��IoT History Datas��6      MahApps.Styles.Label#���   6,   $��25(�5      $��Black"�6   � 5   
   $��1��6     5      �� 5      $��40 �6    �� 5       � ColumnDefinitions 5      �� 5      �� 5      $	��100 �6#   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Division��6   $��Center=�6+   �� 5      -   5         ��Name$ 	Divisions��5      $	��150��6.    �� DisplayMemberPath$ DivisionVal��6:   $��Center=�5        �� SelectedItem 5!      �� *SelectedDivision+�� 5"      $��    StartDate��6   $��Center=�60   (  "System.Windows.Controls.DatePicker  5#      -   5          Name$ 	StartDate��5#      $	��100��60      Text$ 
2020-08-24��6<   $��Center=�5$        MahApps.Styles.DatePicker#���  5%      �� 5&      $��
 ~ EndDate��6   #���   6-   $��Center=�6\     5'      -   5        $ EndDate��5'      $	��100��6.   $ 
2020-08-25��6:   $��Center=�5(      #���  5)      �� 5*      $��Total Count��6   #���   6.   $��Center=�6]   �� 5+      -   5         ��Name$ 
TotalCount��5+      #���   6,   $��Center=�6[   5-      �� 5/      -   5        	 ��Name$	 Search��5/      $��1��6%   $��SEARCH��65   $
��10,0q�6F    ( $MahApps.Styles.Button.Dialogs.Accent#���  50      � 51      $��1��6   $��0��6    $��2��60   .+�52        OxyPlot.Wpf.Plot  
   Series
 53        OxyPlot.Wpf.LineSeries  54        OxyPlot.Wpf.Series   Color$ Coral��6)      
MarkerType$
 None=�67      Title$ 
Temprature��6I   $��Center=�55   )   ��56   )   �� *
TempValues+  57      $ GreenYellow��6)   $
 None=�6=   $ Humidity��6O   $��Center=�58   )   ��59   )   �� *HumidValues+  5:      $ 
BlueViolet��6)   $
 None=�6<   $ Presure��6N   $��Center=�5;   )   ��5<   )   �� *PressValues+5>      5?      5@      5A      5B      