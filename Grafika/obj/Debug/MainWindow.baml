   M S B A M L   `   `   `  ����B  >Grafika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GrafikaGrafika  5   	       Grafika.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Grafika     5   	     � Title$  Grafika��5   	   $	��450��6   $	��800��6&   .��5      ]� .+�5   
   ]� $��20��6   $
��auto��6    $	��Top=�6.   .+�5      o� .@�5      m� -   5        $��_ellipse��5   q   $��Draw Ellipse��6   {�.  m� IsCheckable . 6�   �� 5      m� 5      -   5        $��_polygon��5   q   $��Draw Polygon��6   {�.  . 6�   �� 5      m� 5      -   5        $��_text��5   i   $��Add Text��6   {�.  . 6x   �� 5      m� 5      -   5        $��_undo��5   G   $
��Undo��6   {�. 6V   �� 5      m� 5      -   5        $��_redo��5   G   $
��Redo��6   {�. 6V   �� 5      m� 5      -   5        $��_clear��5   I   $��Clear��6   {�. 6Y   �� 5      m� 5      -   5        $��_coordinates��5   0   $��Coordinates��6    .  6Z   �� 5      �� 5       -   5        $��coordinates��5    :   $y�Hidden=�6   $	��100��6.    �� 
IsReadOnly . 6a   5!      5"      �� 5$   
   -	   5         ��Name$ slider��5$       � Minimum$ .1Q�6!    � Maximum$ 5Q�6.    � Value$	 0.3Q�6:   $��20��6F   $	��Top=�6S   �� 5%   
   $
��Auto=�6   $
��Auto=�6<   .��5'      �� -
   5         ��Name$ canvas��5'   I   
�������$��10000��6,   $��10000��6:   $��Center=�6p   $��Center=�6�    � LayoutTransform 5(      �� 5)      	 �� ScaleX	 6%   �� 
 �� ElementName$
 slider�� �� Path$ Value� �� ScaleY 5*   !   �� $
 slider��$ Value�5/      52      54      55      