Bu proje güvenli yazılım geliştirme eğitimi için örnek bir projedir. Prodenin zafiyet içeren haline insecure branch inden, Güvenli haline secure branch inden erişebilirsiniz. İçerdiği zafiyetler aşağıda listelenmiştir.

A1 SQL injection => Müşteri Login payload / Credential.cs
A2 Broken Authentication and session management => Urlden giriş / Tooken Base authentication , JWT employeedasboard.html
A3 XSS => Müşteri Login qwe / CustomerRepository.cs 
A4 Insecure direct object references / Broken Access Control =>Burp  ShoppingRepository.cs create
A5 Security Misconfiguration => http://localhost:54250 DB username password ...   
