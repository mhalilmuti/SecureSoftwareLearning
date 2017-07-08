Bu proje güvenli yazılım geliştirme eğitimi için örnek bir projedir. Prodenin zafiyet içeren haline insecure branch inden, Güvenli haline secure branch inden erişebilirsiniz. İçerdiği zafiyetler aşağıda listelenmiştir.

**A1 SQL injection** => Müşteri Login kısmında payload=" **a' OR '1' ='1**  " / Credential.cs kısmında parametre kullanımı   
**A2 Broken Authentication and session management** => Urlden giriş yapıldığında sayfa açılıyor  / Tooken Base authentication employeedasboard.html    
**A3 XSS** => Müşteri Login kulllanıcıa adı:qwe parola:123 / CustomerRepository.cs  (stored XSS kullanıcı adı payload)  
**A4 Insecure direct object references - Broken Access Control** =>Burp vb. proxy araçları ile araya girip alışveriş yapıldığı anda istediğimiz fiyatı girebiliyoruz  ShoppingRepository.cs create fiyatbilgisini FE den alma    
**A5 Security Misconfiguration** => http://localhost:54250 DB username password ...   

Uygulama DB olarak My sql kullanmaktadır. My sql veritabanınıza DbScript.sql dosyası ile DB yi kopyalayabilirsiniz. (DB kullanıcı adı:root , parola: admin DB ismi: companydb)     
Uygulama BE olarak .Net kullanmaktaır. solution u visual studio ile ayağa kaldırabilirsiniz.
Uygulama FE html,css ve js den oluşmaktadır. FrondEnd dosyası içindeki index.html dosyasını browserda çalıştırarak kullanabilirsiniz.
zafiyetler için kullanabileceğiniz payloadlar Zafiyetleri kullanma.md dosyasında bulunmaktadır. İyi eğlenceler ...
