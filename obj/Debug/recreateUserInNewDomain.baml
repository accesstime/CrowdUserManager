   M S B A M L   `   `   `  ����L  HCrowdUserManager, Version=2.12.1.1, Culture=neutral, PublicKeyToken=null3clr-namespace:CrowdUserManagerCrowdUserManager  5   	   .    (CrowdUserManager.recreateUserInNewDomain   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CrowdUserManager     5   	     � Title$  recreateUserInNewDomain��5   	   $��226.331��6)   $��458.876��6:   ���	#FF46B9D1 � 
ResizeMode$ NoResize=�6b    � Icon$ media/index.ico��6x    � ShowInTaskbar .  4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ Onscreen=�6�    � WindowStyle$
 None=�6�    � WindowStartupLocation$ CenterScreen=�6�   $��1q�6  .��5	      � ���	#FF3F3D41.+�5
   
   �� -   5         ��Name$ recreateButton��5
      $��Recreate��6)   $
��Left=�6<   $��
53,168,0,0q�6W   $	��Top=�6k   $��78��6�   $��2q�6�   ���	#FFF54343���	#FFF54343$��29��6�   $
��Bold"�6�   ��6�   Z� 6  �� 5   
   -   5        $ 
exitButton��5      $
��Exit��6%   $
��Left=�64   $��332,168,0,0q�6O   $	��Top=�6d   $��83��6|   $��2q�6�   ���	#FF46B9D1���	#FF46B9D1$��29��6�   $
��Bold"�6  ��6�   Z� 6  �� 5   
   -   5         ��Name$ userNameLabel��5      $��UserName��6'   $
��Left=�6:   $��
108,28,0,0q�6U   $	��Top=�6i   $	��235��6�   
�������$��Center=�6�   $
��Bold"�6�   $��16(�6�   
�������$��1q�6�   �� 5   
   -   5        $ currentDomainLabel��5      $��Label��6,   $
��Left=�6<   $��	95,99,0,0q�6W   $	��Top=�6j   ���	#FF46B9D1$��2q�6�   $��80��6�   $��Center=�6�   
�������$
��Bold"�6�   �� 5   
   -   5        	 ��Name$	 targetDomainComboBox��5      $
��Left=�61   $��301,101,0,0q�6L   $	��Top=�6a   $	��102��6y   $��26��6�   ���	#FF46B9D1���	#FF46B9D1$
��Bold"�6�   �� 5   
   -   5        $ label��5      $
��To :��6   $
��Left=�6.   $��257,101,0,0q�6I   $	��Top=�6^   $
��Bold"�6v   ���	#FF46B9D16�   �� 5   
   -   5        $ label1��5      $��From :��6    $
��Left=�61   $��
44,101,0,0q�6L   $	��Top=�6`   ���	#FF46B9D1$
��Bold"�6�   5      5      