   M S B A M L   `   `   `  ����  TeamView"    TeamView.View.TeamViewWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hi:http://schemas.microsoft.com/expression/2010/interactivity     5   	   Iint9http://schemas.microsoft.com/expression/2010/interactions     5   	   -   5          �Name$  MainApplicationWindow��5	   	   $
��Auto��5
   	   $
��1000��5   	   $	��600��5   	   $	��400��5   	   $
��1000��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��175 �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   �� 5      $��5 �6   .+�5   
   �� -   5         ��Name$ 
imgMGoBlue��5      $1��+/TeamView;component/Resources/Images/M1.jpg��6$   $y�Visible=�6Y   $��Stretch=�6n   $��Stretch=�6�   $
��Fill=�6�   $��5��6�   $��6��6�    J� Opacity$
 0.10Q�6�   �� 5   
   $��6��6   $��65��6)    �� Orientation$ 
Horizontal=�65   $	��Top=�6O   
����  � K� ZIndex$ 1��6y   .+�5      �� -   5         ��Name$ txtTopMenuBar��5"      
��� ���$��10,0,0,0q�5       $��Stretch=�5!      $
��Wrap=�5#      $��28(�5$      $��Helvetica Neue LT Std)�5%      $
��Bold"�5&      $��NCAAF Top 25��5'      $��Center=�5(      $
��Auto��5)       �� Padding$ 10q�5*      5+      �� 5,   
   $��3��6   $��65��6%   $ 
Horizontal=�61   $��Right=�6J   $	��Top=�6g   
����  �$ 1��6�   .+�5-      �� -   5        $ txtRepository��5/      $��3��5-      
������$��NoWrap=�50      $��18(�51      $��Helvetica Neue LT Std)�52      $
��Bold"�53      $��Center=�55      $
��Auto��56      $
��Auto��57      $ 10q�58      ��54      �� *
Repository+58      59      � 5;   
   -   5        	 �Name$	 gdBackground��5;      $��1��5<      $��1��5=      .+�5>      �� -   5        
 ��Name$
 LeftBackgroundLabels��5>       �� CornerRadius$ 8��5?      ���	#3B555555$	 .75Q�5A      $ 0��5B      5C      �� 5E   
   -   5         ��Name$ TeamListTemplate��5E      $��3��5F      $��1��6&   $��5q�5G      
����  �$��1q�5H   )   
������ $��Disabled=�5I         TeamListTemplate#��[  5K      ��5J      �� *Teams+��5L      �� 5M      .R�5N      � 5O      5Q      �� 5S   
   $��1��6   $��1��6%   $ 
Horizontal=�62   $��	10,20,0,0q�6K   $	��Top=�6^   
������ .+�5T      � .+�5U      �� $ Vertical=�6   $	��Top=�64   $	��150��6L   .+�5V      �� $ 8��6   $��60��6.   
����  �$��0,0,0,10q�6P   ._�5W      ��   GoButtonStyle#��[ 6H   
������ $��12q�6�   $��Center=�6�   ��6!   �� *RefreshTeamCommand+.��6�   	Top Teams6�   5X      �� 5Y      $ 8��6   $��60��6.   
�������._�5Z      ��   ClearButtonStyle#��[ 6F   $��Center=�6p   $��Center=�6�   
������ $��12q�6�   $��5,0,5,0q�6�   ��6!   �� *ClearTeamCommand+.��6�   
Clear Data6�   5[      5\      5]      5^      5`      5a      