   M S B A M L   `   `   `  ����O  KOG.CC.Client.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:OG.CC.Client.Desktop.ViewsOG.CC.Client.Desktop.Views  5      *    $OG.CC.Client.Desktop.Views.InputView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:OG.CC.Client.Desktop.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      $	��Top=�5	         BorderDarkGray#��[  5        � DataContext  5      �� *Input+  ViewModelLocator �� Source# [ .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��34(�6   
�������From:6<   %  Xceed.Wpf.Toolkit.DecimalUpDown  5   
   $��1��5      $��5q�5      ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ Enter value��5      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5      �� *BaseCurrencyAmount+ �� Delay$ 40���� 5   
   $��2��5      $��5q�5      ��5      �� *
Currencies+ �� SelectedItem 5       �� *BaseCurrency+�� 5!   
   $��3��5"      $��5q�5#      
���������5%      �� *LastUpdateDate+5&      5'      