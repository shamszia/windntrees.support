   M S B A M L   `   `   `  ����N  JApplicationWPF.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ApplicationWPFCore.ProductsApplicationWPFCore.Products  5   	   +    %ApplicationWPFCore.Products.NewWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ApplicationWPFCore.Products     5   	     � Title$  New Product Form��5   	   $	��500��6"   $	��600��6/   .��5	      ]� -   5         ]�Name$ DockListWindowForm��5	      $
��True��6,   .+�5
   
   �� $	��Top=�6   $��80��6.   $
��Auto��6:   .��5      ]� -   5        $ DockListWindowFormTop��5      $
��True��67   .+�5      �� $��Bottom=�6   $��1��61   $
��Auto��6<   #��� ��6I   6�   �� 5      .+�5      �� $��New Product Form��6   
 �� Top$ 10��67   $��18(�6G   $
��Bold"�6U   6i   �� 5      $ 40��6   $��12(�6,   6<   5      5      5      �� 5   
   $��Bottom=�6   $��60��61   $
��Auto��6=   .��5      ]� -   5        $ DockListWindowFormBottom��5      $
��True��6:   .+�5      �� $	��Top=�6   $��1��6.   $
��Auto��69   #��� ��6F   6�   �� 5      .+�5      �� -   5         ��Name$ 
SaveButton��5   +   $��10��6   $��_Save��6?    �� 	IsDefault$
 True��6O    �� Left$ 10��6y   $ 29��6�   $��75��6�   �� 5      -   5        $ CancelButton��5   +   $��11��6   $��_Cancel��6A    �� IsCancel$
 True��6S    �� Right$ 10��6c   $ 29��6u   $��75��6�   5      5      5      �� 5   
   $
��Auto��6   .��5      �  � ColumnDefinitions 5      �� 5      $
��0.5* �6'   66   �� 5       $��1* �6'   64   �� 5!      $��2* �6'   64   �� 5"      $��1* �6'   64   �� 5#      $��2* �6'   64   �� 5$      $
��0.5* �6'   66   	 � RowDefinitions	 5&      �� 5'      6&   �� 5(      6&   �� 5)      6&   �� 5*      6&   �� 5+      6&   �� 5,      6&   �� 5-      6&   �� 5.      6&   .+�50      �� $
��Name��6   $��1��6'   $��1��64   6F   �� 51      $��0��6   $��1��6=   $��2��6J   $��3��6Z   ��6'   �� *Name+6p   �� 52      $��Description��6   $��2��6.   $��1��6;   6M   �� 53      $��1��6   $��2��6D   $��2��6Q   $��3��6a   ��6'   �� *Description+6w   �� 54      $
��Code��6   $��3��6'   $��1��64   6F   �� 55      $��2��6   $��3��6=   $��2��6J   ��6'   �� *Code+6]   �� 56      $��
Legal Code��6   $��3��6-   $��3��6:   6L   �� 57      $��3��6   $��3��6B   $��4��6O   ��6'   �� *	LegalCode+6b   �� 58      $��Version��6   $��4��6*   $��1��67   6I   �� 59      $��4��6   $��4��6@   $��2��6M   ��6'   �� *	Version+6`   �� 5:      $
��Year��6   $��4��6'   $��3��64   6F   �� 5;      $��5��6   $��4��6D   $��4��6Q   ��6'   �� *ProductYear+6d   �� 5<      $��Category��6   $��5��6+   $��1��68   6J   �� 5=      $��6��6   $��5��6A   $��2��6N   ��6'   �� *
Category+6a   �� 5>      $
��Unit��6   $��5��6'   $��3��64   6F   �� 5?      $��7��6   $��5��6=   $��4��6J   ��6'   �� *Unit+6]   �� 5@      $��Color��6   $��6��6(   $��1��65   6G   �� 5A      $��8��6   $��6��6>   $��2��6K   ��6'   �� *Color+6^   �� 5B      $��Manufacturer��6   $��6��6/   $��3��6<   6N   �� 5C      $��9��6   $��6��6E   $��4��6R   ��6'   �� *Manufacturer+6e   5D      5E      5F      5G      