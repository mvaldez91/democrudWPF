   M S B A M L   `   `   `  ����?  ;CRUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRUDCRUD  5   	       CRUD.UpdateWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:CRUD     5   	     � Title$  UpdateWindow��5   	   $	��450��6   $	��513��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      $	��70* �6   �� 5      $
��443* �6    � RowDefinitions 5   
   �� 5      $
��146* �6   �� 5      $	��71* �6   .+�5   
   �� -   5         ��Name$ textBox��5      $
��Left=�6%   $��	34,54,0,0q�6@   $
��Wrap=�6S   $��Nombre��6g   $	��Top=�6u   $	��113��6�   $��3��6�   �� 5   
   -   5        $ textBox_Copy��5      $
��Left=�6*   $��	34,97,0,0q�6E   $
��Wrap=�6X   $��Curso��6l   $	��Top=�6y   $	��113��6�   $��3��6�   �� 5   
   -   5        $ textBox_Copy1��5      $
��Left=�6+   $��
34,141,0,0q�6F   $
��Wrap=�6Z   $
��Edad��6n   $	��Top=�6z   $	��113��6�   $��3��6�   �� 5   
   -   5         ��Name$ 
comboCurso��5      $
��Left=�6'   $��	95,95,0,0q�6B   $	��Top=�6U   $	��120��6m    �� DisplayMemberPath$ Nombre��5       �� SelectedValuePath$ Id��5      $��2��6*    �� SelectedValue 5      �� *Curso+ �� Mode$ OneWay=�5   *   �� 5   
   -   5        	 ��Name$	 	txtNombre��5      $
��Left=�6%   $��	95,54,0,0q�6@   
 �� TextWrapping$

 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   $��2��6�   �� 5   
   -   5        $	 txtEdad��5      $
��Left=�6#   $��
95,141,0,0q�6>   $

 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�   $��2��6�   �� 5   
   -   5         ��Name$ 
btnGuardar��5      $��Update��6%   $��20(�66   $
��Left=�6D   $��130,202,0,0q�6_   $	��Top=�6t    J� RenderTransformOrigin$ -4.501,-3.034&�6�   $��2��6�   5      5       