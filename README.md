# Calculator 
A step by step calculator that calculates the given operation step by step. It can do complex operation than just addition and subtraction.
also it can make the given operation graph and convert temperature different scales.
<p align="center">
    <img src=".\screenshot\2 file.png" width="250" higth="400" >
    <img src=".\screenshot\6 temperature.PNG" width="300" higth="400" >
</p>

## Simple mode
when you start the application this mode is selected by default. it can calculate operations like:
* multiplication
* division
* addition
* subtraction

<p align="center">
    <img src=".\screenshot\1 main form.PNG" width="450" higth="300" >
</p>

## Scientific mode
when you click on the scientific mode button it will show the scientific mode. it can calculate operations that include:
* Square root
* PI
* Percentage
* Sinus
* Cosinus
* Tangent
* Logarithm
* power
* parentheses

<p align="center">
    <img src=".\screenshot\3 enter the operation.PNG" width="600" higth="500" >
</p>
<p align="center">
    <img src=".\screenshot\4 step by step solution.PNG" width="600" higth="500" >
</p>

## Graph mode
After you calculate the operation by choosing the graph mode it will show the graph of the operation like this:

<p align="center">
    <img src=".\screenshot\5 graph.PNG" width="300" higth="400" >
</p>
<div dir='rtl' align="justify">

## Requirements
* Visual studio
 
# توضیحات این فاز
 
در این پروژه قرار است عملکرد یک ماشین حساب را شبیه سازی کنیم. عملیات جمع (+)، تفریق (-)، ضرب (*)، تقسیم (/)، توان (^) ، را باید پیاده سازی کنید. 
دقت داشته باشید که اعداد ورودی میتوانند از نوع اعشاری نیز باشد و برنامه شما باید "." (ممیز) را پشتیبانی کند.
با توجه به اینکه ماشین حساب باید پرانتز گداری عبارات را نیز پشتیبانی کند با کمک ساختمان داده استک،  پرانتز گذاری و اولویت عبارات را محاسبه نمایید. 
 (کلاس ساختمان داده استک را باید خودتان پیاده سازی کنید و استفاده از کلاس های آماده برای آن مجاز نیست!)

راهنمایی:
یکی از روش ها برای محاسبه عبارات تبدیل آن ها به فرم postfix است .

### مدیریت خطا
 اگر عبارت داده شده فرمت صحیح واستانداردی نداشته باشد مثلا پرانتز گذاری اشتباه باشد و یا عملگر ها درست استفاده نشده باشند باید ارور چاپ کرده و سپس آن را مدیریت نمایید.
 .مثال هایی از ورودی های نادرست که باید ارور چاپ کند:
 
 <div dir='ltr' align="justify">


 ```

 )(1+3)*2<br>
 (((2+5)^2)+4<br>
 3+5^<br>
 +5^<br>
 5/0<br>

 ```


 <div>

### ورودی:
یک عبارت ریاضی شامل اعداد گویا و پرانتز "()" و عملگر های مورد نظر است که  به صورت یک رشته داده می شود . <br>
### خروجی:
یک عدد که حاصل عبارت ریاضی داده شده است ویا پیغام ارور در صورت وجود خطا.
 
  <div dir='ltr' align="justify">


   ورودی1:

 ```
  (1+3) * 2^2
```

 عبارت خروجی 1:

```
  16
```

  ورودی2:

```
  -(-(2^3))/4+1 
```

  عبارت خروجی 2:

```
  3
```

  ورودی3:

``` 
  -(((1+2)*(-3))^(1+1)) 
```

  عبارت خروجی 3:

```
  -81
```

  ورودی4:

```
  )(2+3) 
```

  عبارت خروجی 4:

```
  error
```

  ورودی5:

```
  3+4^
```

  عبارت خروجی 5:

```
  error
```

  ورودی6:

```
  ((1.4+1.6)*10)/100 
``` 
   
  عبارت خروجی 6:

```
  0.3
```
  
  <div>

## تاریخچه
 ماشین حساب شما باید در هر مرحله از محاسبه وضعیت عبارت را چاپ کند  .

چاپ مراحل محاسبه:
 
 مرحله 1:

4*(2^3)<br>


 مرحله2:
 
 4*8<br>


 مرحله3:
 
 32<br>


 جواب نهایی:<br>


 32<br>
 <br>


## درخت عبارت
 علاوه بر موارد گفته شده شما باید عبارت ریاضی داده شده در ابتدا  را به فرم درخت تبدیل کرده و چاپ کنید.<br>


  مثال :
 ورودی:

 <div dir='ltr' align="justify">

```
 (1+3)*(2^3)
```
 
 <div>

 خروجی درخت:
 
 tree:

 ![tree](https://user-images.githubusercontent.com/70153144/142826292-37bd0066-1964-454f-a66b-fc8a03124bc3.png)

- دقت کنید نیازی به نمایش گرافیکی درخت عبارت نیست و تصویر بالا برای درک بهتر درخت نمایش داده شده است.
شما بصورت چاپی از ریشه درخت شروع کرده و به سلیقه خودتان درخت را نمایش دهید. ( اما به عنوان بخش اضافه میتوانید با کتابخانه های گرافیکی آن را نمایش دهید.) 
- همانند استک، ساختمان داده درخت را نیز خودتان باید پیاده سازی کنید و استفاده از ساختمان داده های آماده مجاز نیست!




## بخش امتیازی:
برای پیاده سازی این بخش شما باید  در منوی برنامه خود گزینه ای به نام "add new operator "داشته باشید تا با استفاده از ان بتوان عمگلر های دلخواه تعریف کرد و به ماشین حساب اضافه کرد و در محاسبات از انها استفاده کرد.
 نحوه تعریف اپراتور جدید به صورت زیر خواهد بود:


 add new operator <br>
a Comp b = 2*a+b<br>
 


 add new operator<br>
a trick b = a^b/b<br>


 
add new operator<br>
a square b = a^2+b^2<br>
 
 ### سایر موارد اضافه  :
+ گرافیک زیبا برای خود ماشین حساب
+ افزدون عملگرهای ماشین حساب علمی 
+ وارد کردن توابع ریاضی
+ رسم نمودار توابع
+ محاسبه مشتق ،و ازین دست توابع
+  هرگونه خلاقیت و نکته اضافی که به فکرتان رسید (دستتون بازه :) )

<hr>

  ### نکته :  همانند مینی پروژه های قبلی تمیزی کد و بخش بندی کردن کامیت های پروژه جزو نمره دهی اصلی خواهد بود، همچنین قسمت محاسبه عبارت را نیز تحلیل زمانی کرده و تحلیل آن را در یک برنچ جداگانه نسبت به برنچ project کامیت و پوش نمایید. 
 <div>


