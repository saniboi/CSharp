   M S B A M L   `   `   `  ????  16_Commands    _16_Commands.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     ? Title$  
MainWindow??5   	   $??120.608??6   $??579.97??6-   .??5      ?  ? 	Resources 5	   
    ?? 
TargetType ?? Property ?? Value??%?   '??       ?? 5
      " ??6   .?5      ??  ? ??$ 10,10,10,10q?6+   6A   ?? 5       ? ??$ 75??6*   ?? 5       ? ??$ 23??6+   5      5       ? ColumnDefinitions 5   
   ?? 5      ?? 5      $
??Auto ?6   .+?5   
   ?? -   5         ??Name$ 	MyTextBox??5      $??Stretch=?6%   $	??200??6C   $
??Auto??6?   $??10q?6?   ??6R   ??  ?? ElementName$ MyButton?? ?? Path$ Height?6?   ?? 5   
   	 ?? Orientation$	 
Horizontal=?6   $??1??6.   .+?5      ?? -   5        
 ??Name$
 MyButton??5   a   $	??Cut??6   $	??Cut??6#   ??61   ?? $ 	MyTextBox??6a   ?? 5      $
??Copy??6   $
??Copy??6$   ??63   ?? $ 	MyTextBox???? 5      $??Paste??6   $??Paste??6%   ??65   ?? $ 	MyTextBox??5      ?? 5   
   $e??_Beachte: Die Cut- und Copy-Knöpfe werden erst aktiv,
wenn Text in der TextBox selektiert ist.??6   $
??Left=?6?   $	??Top=?6?   $??1??6?   $??	10,56,0,0q?6?   $	??168??6?   $??6(?6?   $??26??6?   5      5      