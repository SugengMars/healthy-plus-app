   M S B A M L   `   `   `  ????J  FHPlus_App.Win10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HPlus_App.Win10.View.BiasaHPlus_App.Win10.View.Biasa  5   	   ,    &HPlus_App.Win10.View.Biasa.LambungForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:HPlus_App.Win10.View.Biasa     5   	   $
??8600??5      $	??400??6(     ? 
ResizeMode$  NoResize=?5   	    ? SizeToContent$ WidthAndHeight=?5	   	    ? WindowStartupLocation$ CenterScreen=?5
   	    ? WindowStyle$ SingleBorderWindow=?5   	    ? Title$ Form Lambung??5   	   ??5      ?? 5   
    ?? ImageSource$+ %pack://application:,,/Assets/form.png??6   .??5      ? $
??8600??6   $	??400??6    ? RowDefinitions 5   
   ?? 5      $	??20* ?6   ?? 5      $	??62* ?6   ?? 5      $	??18* ?6   .+?5   
   ??  ?? Orientation$ Vertical=?6   $??1??6,   .+?5      ?? $ 
Horizontal=?6   .+?5      ?? $	??Uid??6   $??10,0,0,0q?6&      	Atb_Label#??[  68   ?? 5      $??60??6K   $??10,0,0,0q?6V     	Text_View#??[ 6h   ??6   ?? *ModelLambung.Uid_l+ ?? Mode$ TwoWay=?6h   5      ?? 5      $??PENYAKIT LAMBUNG ??6   $??	35,0,35,0q?60   #??[  6C   ?? 5      $??	35,0,35,0q?6F   #??[ 6Y   ??6   ?? *ModelLambung.Name+$ TwoWay=?6Y   ?? 5      $??Description??6   $??	35,0,35,0q?6*   #??[  6=   ?? 5      $??	35,0,35,0q?6M     	Text_Area#??[ 6`   ??6   ?? *ModelLambung.Description+$ TwoWay=?6`   ?? 5      $
??OBAT??6   $??	35,0,35,0q?6#   #??[  66   ?? 5       $??	35,0,35,0q?6F   #??[ 6Y   ??6   ?? *ModelLambung.Obat+$ TwoWay=?6Y   5!      ? 5"   
   $??2??6   	 ? ColumnDefinitions	 5#      ?? 5$      $??* ?6#   ?? 5%      $??* ?6#   ?? 5&      $??* ?6#   .+?5(      ?? -   5        
 ??Name$
 	BtnDelete??5(   &   $??DELETE??6   $??0??6[   $??
30,10,0,35q?6k     Button_Form#??[ 6   ??69   ?? *DeleteCommand+6   ?? 5)      -   5        $
 BtnSave??5)   $   $
??SAVE??6   $??1??6U   $??10,10,10,35q?6e   #??[ 6z   ??65   ?? *SaveCommand+6z   ?? 5*      -   5        $
 	BtnUpdate??5*   &   $??UPDATE??6   $??1??6\   $y?Hidden=?6l   $??10,10,10,35q?6?   #??[ 6?   ??6:   ?? *UpdateCommand+6?   ?? 5+      -   5        $
 BtnClose??5+      $??Close??6'   $??2??6N   $??
0,10,30,35q?6^   #??[ 6r   5,      5-      5.      