   M S B A M L   `   `   `  ����  VideoPlayerApp(    "VideoPlayerApp.Views.VideoItemView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $
��Auto��5      $	��280��6   .��5      �� 
�������  �� CornerRadius$  4��6   
�������$��1q�5   #    �� Padding$ 8q�5      $��5q�6   ._�5      �� .+�5      r� -   5         r�Name$ mediaElement��5       r� LoadedBehavior$ Manual=�5       r� UnloadedBehavior$ Manual=�5      $	��160��5       r� Stretch$ UniformToFill=�5       r� Source 5      �� *
FilePath+ r� IsMuted 5      �� *IsAudioSource+   InverseBoolConverter �� 	Converter# [  5      �� 5      -   5        	 ��Name$	 PositionSlider��5      $	��0,6q�5      $��Stretch=�5      5      A� 5      
 A� Columns$
 3��6   $	��0,6q�6    .+�5   
   �� -   5        $
��Play��5      $��2q�6;   �� 5   
   -   5        $��Pause��5      $��2q�6;   �� 5   
   -   5        $
��Stop��5      $��2q�6;   5   	   A� 5!      $
 1��6   $	��0,6q�6    .+�5"   
   �� $��Delete��6   $��2q�5&      ��5#      �� * DataContext.RemoveVideoCommand+ �� RelativeSource ��  �� AncestorType
 Window��5%      �� 5&      5'   	   �� 5*      $��Audio Source��6   $��0,6,0,0q�5.      ��5+      �� *#!DataContext.SetAudioSourceCommand+ �� 
 Window��5-      �� 5.      5/      50      51      