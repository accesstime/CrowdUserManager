   M S B A M L   `   `   `  ����L  HCrowdUserManager, Version=2.12.1.1, Culture=neutral, PublicKeyToken=null3clr-namespace:CrowdUserManagerCrowdUserManager  5   	        CrowdUserManager.DialogBox   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CrowdUserManager     5   	   -   5          �Name$  Warning��5   	    � Title$ Warning��5   	   $��134.023��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�66   ���	#FF080808
���   � � 
ResizeMode$ NoResize=�6�    � SizeToContent$ Height=�6�   ���	#FF3754D7$��1q�6�    � Icon$ media/index.ico��6�    � WindowStyle$
 None=�6�    � Topmost . .��5	      � ���	#FF3F3D41 J� OpacityMask
 �   �.+�5
   
   �� -   5        	 ��Name$	 messageTextBlock��5
      $��Center=�6.   $��	0,40,0,60q�6K   $
��Wrap=�6^   $	��Top=�6r   $��warning��6�   $	��272��6�   $
��Bold"�6�   
 �� TextAlignment$
 Center=�6�   
�������6�   �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $��35��6:   $��	250,0,0,0q�6F   $	��Top=�6Y   $��38��6q   $��media/epam_logo_2.png��6|   �� 5   
   -   5         ��Name$ cancelButton��5      $��No��6'   $��Right=�64   $��Bottom=�6P   $��75��6k   $��29��6�   $
��Bold"�6�   ���	#FF3754D7$��2q�6�   
������� �� 	IsDefault . $��0,0,6,5q�6  ��6�   Z� 6  �� 5   
   -   5        $ OKbutton��5      $	��Yes��6#   $
��Left=�61   $��Bottom=�6L   $��75��6g   ���	#FF3754D7
�������$��2q�6�   $��29��6�   $
��Bold"�6�   $��5,0,0,5q�6�   ��6r   Z� 6�   5      5      