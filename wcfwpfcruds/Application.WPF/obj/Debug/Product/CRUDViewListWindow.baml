   M S B A M L   `   `   `  ����I  EApplicationWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ApplicationWPF.ProductsApplicationWPF.Products  5   	   0    *ApplicationWPF.Products.CRUDViewListWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ApplicationWPF.Products     5   	   -   5          � Title$'  !Product List Window CRUDView Form��5   	   $	��500��63   $	��600��6@   #��� ��5
   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        0   *ApplicationWPF.Products.CRUDViewListWindow   StaticCreateCommand   Command# Z 5      5        5   
   -   5           StaticReadCommand# Z 5      5        5   
   -   5           StaticEditCommand# Z 5      5        5   
   -   5           StaticDeleteCommand# Z 5      5        5   
   -   5           StaticListCommand# Z 5      5        5   
   -   5           StaticNextCommand# Z 5      5        5   
   -   5        	   StaticPrevCommand# Z	 5      5         5!   
   -	   5        
   StaticCloseCommand# Z
 5!      5#      .��5&      ]� -
   5         ]�Name$ DockListWindowForm��5&      ��. .+�5'   
   �� $	��Top=�6   $��80��6.   $
��Auto��6:   .��5(      ]� -   5        $ DockListWindowFormTop��5(      ��. .+�5)      �� $��Bottom=�6   $��1��61   $
��Auto��6<   #��� ��6I   6�   �� 5*      .+�5+      �� $0��*Product Management (Listing) CRUDView Form��6   
 �� Top$ 10��6Q   $��18(�6a   $
��Bold"�6o   6�   �� 5,      $ 40��6   $��12(�6,   6<   5-      5.      5/      �� 50   
   $��Bottom=�6   $��90��61   $
��Auto��6=   .��51      ]� -   5        $ DockListWindowFormBottom��51      ��. .+�52      �� $	��Top=�6   $��1��6.   $
��Auto��69   #��� ��6F   6�   �� 53      $��Bottom=�6   $��30��61   .+�54      �� .@�55      �� .��56      �� -   5         ��Name$ StatusTextBlock��56   (   $
��Auto��6]   ��6A   �� *
ViewStatus+6l   57      58      59      �� 5:      .+�5;      �� -   5         ��Name$ 
EditButton��5;   *   $��4��6   $��_Edit��6>   #��Z 6N    �� Left$ 10��6�   $ 29��6�   $��75��6�   �� 5<      -   5        $ DeleteButton��5<   *   $��5��6   $��_Delete��6@   #��Z 6R   $ 90��6�   $ 29��6�   $��75��6�   �� 5=      -   5        $ CloseButton��5=   *   $��9��6   $��_Close��6?   #��Z
 6P    �� Right$ 10��6�   $ 29��6�   $��75��6�   �� 5>      -   5        $ 
PrevButton��5>   *   $��6��6   $
��Prev��6>   #��Z	 6M   $	 209��6�   $ 29��6�   $��75��6�   �� 5?      -   5         ��Name$ ListNumberTextBox��5?   +   $��7��6   $��20��6r   $	 289��6~    �� TextWrapping$
 Wrap=�6�    �� TextAlignment$ Center=�6�   $ 29��6�   $��40��6�   ��6�   �� *ViewInput.Page+6�   �� 5@      -   5         ��Name$ TotalListsTextBox��5@      $	 334��6V   $ 29��6h   $��27��6x   $��50��6�   ��67   �� *
TotalLists+6�   �� 5A      -   5        $ 
NextButton��5A   *   $��8��6   $
��Next��6>   #��Z 6M   $	 389��6�   $ 29��6�   $��75��6�   5B      5C      5D      �� 5E   
   $
��Auto��6   .��5F      ]� -   5        $# DockListWindowFormListActions��5F      ��. .+�5G      �� $��33��6!   $	��Top=�6-   .��5H      ]� ��. .+�5I      �� $
��Left=�6!   $	��140��67   .+�5J      �� -   5        $ 	NewButton��5J   2   $��0��6%   $
��_New��6E   #��Z 6T   $ 10��6�   $ 7��6�   $��75��6�   5K      �� 5L      $��Right=�6!   $	��140��68   .+�5M      �� -   5        $ 
ListButton��5M   2   $��2��6%   $��_List��6F   #��Z 6V   $ 10��6�   $ 7��6�   $��75��6�   5N      �� 5O      .��5P      �� -   5        $ KeywordTextBox��5P   3   $��1��6&   $ NoWrap=�6K   $
��Auto��6�   $��23��6�   ��6a   �� *ViewInput.Keyword+6�   5Q      5R      5S      �� 5T      $	��Top=�6   $��1��6.   $
��Auto��69   #��� ��6F   6�   �� 5U      .��5V      ]� ��. .+�5W      &   System.Windows.Controls.DataGrid  -   5          Name$ ProductsDataGrid��5W   0   $��3��6#   $
��Auto��6v   $��Stretch=�6�   $
��Auto��6�   ��6J   �� *ContentsListModel+5X      5Y      5Z      5[      5\      5]      5^      