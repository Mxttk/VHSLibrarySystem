   M S B A M L   `   `   `  ����K  GVHSLibrarySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VHSLibrarySystemVHSLibrarySystem  5   	   !    VHSLibrarySystem.ToMenuLoad   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:VHSLibrarySystem     5   	     � Title$  
ToMenuLoad��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStyle$
 None=�5   	    � WindowState$ 	Maximized=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $	��350 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      .+�5$   
   �� -   5         ��Name$ VHSGIF��5$   6   $��3��6   $��12��6$   $��UniformToFill=�6F   �� 5'   
   -   5         ��Name$ loadingTextReplaceBooks��5(      $��VCR OSD Mono)�5)      $��11��5*      $��0��5+      $��20(�5,      $��	10 0 0 10q�5-      
�������
������ NOW LOADING...51      �� 55   
   -   5        $
��sbar��56      $��Bottom=�57      
�������$��12��59      $��0��5:      $��3��5;      .@�5<      �� .��5=      � -   5        $��progressBarReplaceBooks��5?      $��20��5>      5A      5B      5D      �� 5F   
   -   5        	 ��Name$	 btnBackToMenu��5F      $��2��5G      $��10��5H      $��70��5I      $��70��5J      $��2��5K      $��Right=�5L      $��	0 0 10 10q�5M      
������ 
������ $y�Hidden=�5Q      .��5R      �� .+�5S      �� $��Center=�6   $��Center=�65   $,��&pack://application:,,,/Assets/next.png��6P   $��70��6�   $��70��6�   5T      5U      5Y      5Z      