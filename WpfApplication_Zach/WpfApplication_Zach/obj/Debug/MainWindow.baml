   M S B A M L   `   `   `  ????N  JWpfApplication_Zach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfApplication_ZachWpfApplication_Zach  5   	   $    WpfApplication_Zach.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfApplication_Zach     5   	     ? Title$  LoginWindow??5   	   $	??400??6   $	??600??6*   ??5
      ?? 5   
    ?? ImageSource$ 
/Login.jpg??6   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $	??27* ?6   ?? 5      $
??133* ?6   .+?5   
   ?? -   5         ??Name$ usernameBox??5      $??1??5      $
??Left=?5      $??232,139,0,0q?5       ?? TextWrapping$
 Wrap=?5      $	??Top=?5      $	??134??5       ? ToolTip$ key in your username??5      $??25??5      5      ?? 5    
   -   5        $ passwordTextBox??5       $??1??5!      $
??Left=?5"      $??232,164,0,0q?5#      $
 Wrap=?5$      $	??Top=?5%      $	??134??5&      $??25??5'      $y?Hidden=?5)      5*      G? 5.   
   -   5         G?Name$ passwordBox??5.      $??1??5/      $
??Left=?50      $??232,164,0,0q?51      $	??Top=?52      $	??134??53      $??25??54      $ key in your password??55      57      ?? 5:   
   -   5         ??Name$ loginButton??5:      $??1??5;      $??Login??6!   $??Center=?5<      $??	0,211,0,0q?5=      $	??Top=?5>      $??80??5?      5@      ?? 5C   
   -   5        $ cancelButton??5C      $??1??5D      $??Cancel??5E      $
??Left=?5F      $??304,211,0,0q?5G      $	??Top=?5H      $??80??5I      5J      ?? 5M   
   -   5         ??Name$ passwordCheckBox??5M      $??1??5N      $??show password
??5O      $
??Left=?5P      $??289,240,0,0q?5Q      $	??Top=?5R      	 d? 	IsChecked$
	 TrueY?5S      5U      ?? 5X   
   -   5        
 ??Name$
 passwordBoxWatermark??5X      $??1??5Y      $??Center=?5Z      $??Password??5[      $
??Left=?5\      $??304,163,0,0q?5]      $	??Top=?5^      $??62??5_      ?? 5b   
   -   5        $
 usernameWatermark??5b      $??1??5c      $??Center=?5d      $??Username??5e      $
??Left=?5f      $??304,137,0,0q?5g      $	??Top=?5h      $??62??5i      5k      5l      