   M S B A M L   `   `   `  ����L  HTwitterClient.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TwitterClient.WPFTwitterClient.WPF  5   	   "    TwitterClient.WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TwitterClient.WPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��Right=�6   $	��780��6(   $��	0,0,5,0.5q�64    � RowDefinitions 5
   
   �� 5      $
��115* �6   �� 5      $
��307* �6   .+�5   
   �� -   5        $��	btnSearch��5      $��Search��6"   $��Right=�63   $��	0,26,78,0q�6O   $	��Top=�6b   $��22��6�   $��65��6�   �� 5   
   -   5        $��	btnFilter��5      $��Filter��6"   $��Right=�63   $��	0,73,78,0q�6O   $	��Top=�6b   $��65��6z   6�   �� 5   
   -   5        $��	TxtSearch��5      $��128,26,167,0q�6$   $��#nasa��6:   $	��Top=�6G   $��32��6_   �� 5   
   -   5        $��lstData��5      $��45,44,109,10q�6"   $��1��68    �� View 5      �� 5      .P�5      ��  �� CellTemplate 5      �� 5      .R�5   "   � .+�5   &   �� $��Center=�6/    d� 	IsChecked 6L   �� *	Checked+ �� Mode$ TwoWay=�5   #   5      5      �� 5       �� DisplayMemberBinding 6%   �� *
Username+5       �� 5!       �� Width$
 Auto��6K    6%   �� *Text+5"      5#      5&      �� 5'   
   -   5         ��Name$ 	txtFilter��5'      $��128,73,167,0q�6%   $�� ��6;   $	��Top=�6C   $��32��6[   �� 5(   
   $��	48,32,0,0q�6   $��Search��6'   $
��Wrap=�65   $	��Top=�6I   $
��Left=�6a   $��66��6|   �� 5)   
   $��	48,73,0,0q�6   $��Filter��6'   $
��Wrap=�65   $	��Top=�6I   $��32��6a   $
��Left=�6m   $��61��6�   �� 5*   
   -   5        $��lblCount��5*      $
��Left=�6$   $��	62,23,0,0q�6?   $��click a button��6R   $
��Wrap=�6h   $	��Top=�6|   $��1��6�   �� 5+   
   -   5        $��	btnExport��5+      $��Export��6"   $��
0,261,12,0q�63   $��1��6G   $	��Top=�6T   $��Right=�6l   $��75��6�   6�   5-      5.      