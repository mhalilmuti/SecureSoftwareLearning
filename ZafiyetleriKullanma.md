A1 SQL injection	
User name kismina bu deger yazilarak giris yapilabiliyor.
 a' OR '1' ='1 

A2 Broken Authentication and session management
log out yapmadan browser kapatilirsa oturum sonlanmiyor. Bska biri gelip 
siteyi actiginda direk aciliyor. Url bilinerek sisteme grilebilir.   


A3 XSS
Name degeri zararli kod olan kullanici acildiginda script calistiriliyor
<script>alert(\":D\")\;</script>

 A4 Insecure direct object references
Alisveris yaparken burp ile araya girip urunleri farkli fiyata alabiliyoruz.


 A5 Security Misconfiguration
http://localhost:54250/ adrsinden backend bilgilerine erisilebiliyor.
Sistem veri tabanina root ile bagli veritabani sifresi tahmin edilebilir