   M S B A M L   `   `   `  ����K  GVHSLibrarySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VHSLibrarySystemVHSLibrarySystem  5   	       VHSLibrarySystem.About   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:VHSLibrarySystem     5   	     � Title$  About��5   	   $	��450��6   $	��800��6$    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStyle$
 None=�5   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5         
hoverStyle �� 
TargetType �� Triggers P� Property	 P� Value
 �� Property �� Value T� Y��%�   &	        �� 5   
   " ��6#    5      P� 5       �@J�IsMouseOver$
	 True��61   . �5      �� 
 � z� 5      T� 5      $ -5Q�61   5      5      5      5      .��5      �� $��5q�6   
���   �._�5   
   �  � ColumnDefinitions 5      �� 5      �� 5       $	��350 �6#   �� 5!       � RowDefinitions 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      �� 5*      �� 5+      �� 5,      �� 5-      �� 5.      �� 5/      �� 50      .+�53      �� -   5         ��Name$ VHSGIF��53   :   $��3��6   $��12��6(   $��UniformToFill=�6J   �� 55      $��Center=�6   $	��Top=�56      $��	0 40 0 0 q�57      
�������$��45(�59      $
��Bold"�5:      
������ $��1��5<      $��0��5=      $��4��5>       �� Padding$ 5 5 5 5q�5?      $
��Wrap=�5@       �� TextAlignment$ Center=�5A      $��VCR OSD Mono)�5B      About5D      �� 5G      $��Center=�6   $	��Top=�5H      $��	0 40 0 0 q�5I      
�������$��25(�5K      $
��Bold"�5L      
������ $��1��5N      $��2��5O      $��3��5P      $ 5 5 5 5q�5Q      $
��Wrap=�5R      $ Center=�5S      $��VCR OSD Mono)�5T      6  0System.Windows.Controls.Ribbon.RibbonTwoLineText   HasTwoLines$
 True��5U      ��The VHS Library software has been designed with the aim of providing new employees with an easy and efficient training tutorial that helps the user familiarise themseleves with:5Y      �� 5\      $��Center=�6   $	��Top=�5]      $��	0 40 0 0 q�5^      
�������$��25(�5`      $
��Bold"�5a      
������ $��1��5c      $��5��5d      $��2��5e      $ 5 5 5 5q�5f      $
��Wrap=�5g      $ Center=�5h      $��VCR OSD Mono)�5i      - Replacing books on shelves5k      �� 5m      $��Center=�6   $	��Top=�5n      $��	0 40 0 0 q�5o      
�������$��25(�5q      $
��Bold"�5r      
������ $��1��5t      $��6��5u      $��2��5v      $ 5 5 5 5q�5w      $
��Wrap=�5x      $ Center=�5y      $��VCR OSD Mono)�5z      - Locating areas for books5|      �� 5}      $��Center=�6   $	��Top=�5~      $��	0 40 0 0 q�5      
�������$��25(�5�      $
��Bold"�5�      
������ $��1��5�      $��7��5�      $��2��5�      $ 5 5 5 5q�5�      $
��Wrap=�5�      $ Center=�5�      $��VCR OSD Mono)�5�      - Locating call numbers5�      �� 5�      $��Center=�6   $	��Top=�5�      $��	0 40 0 0 q�5�      
�������$��25(�5�      $
��Bold"�5�      
������ $��1��5�      $��8��5�      $��4��5�      $ 5 5 5 5q�5�      $
��Wrap=�5�      $ Center=�5�      $��VCR OSD Mono)�5�      wuEmployees are recommended to use this software to bolster their knowledge of how to be a stellar VHS Library trainee!5�      �� 5�      -   5         ��Name$ btnBack��5�      $��0��5�      $��0��5�      $��70��5�      $��70��5�      $��3��5�      $
��Left=�5�      $��35 0 0 0q�5�      
������ 
������ ��5�      �� 5�      " ��6    �� BasedOn# [  60   .��5�      �� .+�5�      �� $��Center=�6   $��Center=�69   $0��*pack://application:,,,/Icons/backArrow.png��6T   $��68��6�   $��68��6�   5�      5�      �� 5�      $
��Left=�6   $	��Top=�5�      $��
10 40 0 0 q�5�      
�������$��20(�5�      $
��Bold"�5�      
������ $��0��5�      $��12��5�      $ 5 5 5 5q�5�      $
��Wrap=�5�      $ Center=�5�      $��VCR OSD Mono)�5�      GITHUB: MXTTK5�      �� 5�      $��Right=�6   $	��Top=�5�      $��
0 40 10 0 q�5�      
�������$��20(�5�      $
��Bold"�5�      
������ $��2��5�      $��12��5�      $ 5 5 5 5q�5�      $
��Wrap=�5�      $ Center=�5�      $��VCR OSD Mono)�5�      LINKEDIN: MATTHEW KIDWELL5�      5�      5�      5�      