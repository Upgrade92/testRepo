   M S B A M L   `   `   `  ????N  JWpfApplication_Zach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfApplication_ZachWpfApplication_Zach  5   	   !    WpfApplication_Zach.NewUser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfApplication_Zach     5   	     ? Title$  NewUser??5   	   $	??390??6   $	??624??6&   ??5	      ?? 5
   
    ?? ImageSource$ 	/user.jpg??6   .??5      ? .+?5   
   ?? -   5         ??Name$ comboBoxTitle??5      $
??Left=?5      $??	50,36,0,0q?5      $	??Top=?5      $	??120??5      {?.  .@?5      ?? -   5         ??Name$ comboBoxItem1??5      $??Anrede??62    ?? 
IsSelected . 6C   ?? 5      -   5        $ comboBoxItem2??5      $
??Herr??62   ?? 5      -   5        $ comboBoxItem3??5      $
??Frau??62   5      ?? 5   
   -   5         ??Name$ textBoxFirstname??5      $
??Left=?5      $??	50,70,0,0q?5       ?? TextWrapping$
 Wrap=?5      $?? ??5      $	??Top=?5       $	??120??5!       J? RenderTransformOrigin$ 0.527,-0.572&?5"       ? ToolTip$ Enter first name??5#      ?? 5&   
   -   5        $ textBoxLastname??5&      $
??Left=?5'      $??
50,100,0,0q?5(      $
 Wrap=?5)      $?? ??5*      $	??Top=?5+      $	??120??5,      $ Enter last name??5-      ?? 5/   
   -   5        $ textBoxEmail??5/      $
??Left=?50      $??
50,130,0,0q?51      $
 Wrap=?52      $?? ??53      $	??Top=?54      $	??120??55      $ Enter your mail address??56      	? 58   
   -   5        	 	?Name$	 radioButtonMale??59      
 	? 	GroupName$
 radioButtonGender??58      $??M??5:      $
??Left=?5;      $??
70,160,0,0q?61   $	??Top=?5<      6/   	? 5>   
   -	   5        $	 radioButtonFemale??5?      $
 radioButtonGender??5>      $??W??5@      $
??Left=?5A      $??125,160,0,0q?61   $	??Top=?5B      $ 1.611,0.716&?5C      6:   (  "System.Windows.Controls.DatePicker  5E   
   -
   5          Name$ birthdatePicker??5E      $
??Left=?5F      $??
50,187,0,0q?5G      $	??Top=?5H         Text$  ??5I      ?? 5K   
   -   5         ??Name$ 
saveButton??5K      $
??Save??5L      $
??Left=?5M      $??
50,259,0,0q?5N      $	??Top=?5O      $ 1.001,0.737&?5P      $??60??5Q      6   ?? 5S   
   -   5        $ cancelButton??5S      $??Cancel??5T      $
??Left=?5U      $??110,259,0,0q?5V      $	??Top=?5W      $??60??5X      6   ?? 5Z   
   -   5         ??Name$ 
labelError??5Z      $??ERROR!??5[      
???  ??$??Center=?5]      $??Center=?5^      $??0,29,0,0q?5_      $	??Top=?5`      $??79??5a      $??14(?5b      $y?Visible=?6   5d      5e      