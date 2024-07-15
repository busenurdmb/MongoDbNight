#  MongoDB ve Google Cloud Entegrasyonu ile Admin Paneli
M&Y Yazılım Eğitim Akademi Danışmanlık bünyesinde MongoDB   öğrenmek için yapılan 8. Projedir.

#  MongoDB -Google Cloud Nedir?
- 🗃️ MongoDB:
MongoDB, belge tabanlı bir NoSQL veritabanı yönetim sistemidir. İlişkisel olmayan (non-relational) bir veritabanı olarak, JSON benzeri belge formatında veri depolar 
ve bu belgeleri koleksiyonlar içinde düzenler. MongoDB'nin esnek şema yapısı, dinamik sorgulama yetenekleri ve yüksek ölçeklenebilirlik özellikleri bulunur.
Genellikle büyük veri ve hızlı geliştirme gerektiren uygulamalarda tercih edilir.

- 🌍 Google Cloud:
Google Cloud, Google'ın sunucu barındırma, hesaplama, depolama ve uygulama hizmetleri gibi çeşitli bulut bilişim hizmetlerini sağladığı platformdur.
Bu platform, IaaS (Altyapı olarak hizmet), PaaS (Platform olarak hizmet) ve SaaS (Yazılım olarak hizmet) gibi hizmet modelleri sunar. 
Google Cloud, küresel olarak dağıtılmış bir altyapıya sahip olup, geliştiricilere ve işletmelere ölçeklenebilir ve güvenli bulut çözümleri sunar.

# Temel Prensipler ve Avantajlar
➡️Belge Tabanlı Depolama: Veriler JSON benzeri belgeler halinde depolanır, esnek veri modellemesi sağlar.

➡️Esnek Şema Tasarımı: İlişkisel veritabanlarına göre daha esnek bir yapı sunar, uygulama gereksinimlerinde kolay değişiklik yapılabilir.

➡️Yüksek Performans ve Ölçeklenebilirlik: Paralel sorgulama ve dağıtılmış veritabanı mimarisi ile büyük veri hacimleri üzerinde etkili çalışma sağlar.

➡️Dinamik Sorgulama Dili: Zengin bir sorgu diline sahiptir, karmaşık sorguları destekler.

➡️Yüksek Kullanılabilirlik ve Dayanıklılık: Otomatik failover ve veri kopyalama gibi özelliklerle kesintisiz hizmet ve veri koruması sağlar.

➡️Açık Kaynak ve Topluluk Desteği: Açık kaynaklıdır ve geniş bir kullanıcı topluluğu vardır, yaygın destek ve hızlı geliştirme imkanı sunar.

➡️Bulut Entegrasyonu: Bulut hizmet sağlayıcılarıyla entegre çalışabilir, özellikle Google Cloud gibi platformlarda kolay entegrasyon sağlar.

# 🛞 Proje Örneği: Admin Paneli Ürün Ekleme

MongoDB ve Google Cloud üzerinde odaklanarak ürün, kategori, müşteri ve sipariş verilerini yönetmeyi amaçlamaktadır.
Bu projede, fotoğraf depolama, PDF ve Excel işlemleri gibi özellikler de entegre edilmiştir.

İşte sürecin adımları:
⌨️Kullanıcı Girişi: Yönetici veya kullanıcı, ürün bilgilerini (adı, açıklaması, fiyatı vb.) girer ve ürün resmini yükler.

🧑‍💻Veri Ekleme İşlemi Başlatma: Kullanıcı girişi alındıktan sonra, ürün bilgileri MongoDB'ye kaydedilir. Bu işlem için bir servis sınıfı kullanılır ve
ilgili MongoDB işlemleri (örneğin, ekleme işlemi) bu servis üzerinden gerçekleştirilir.

❓Resmin Google Cloud Storage'a Yüklenmesi: Ürün resmi, ürün bilgileri MongoDB'ye başarıyla kaydedildikten 
sonra Google Cloud Storage'a güvenli bir şekilde yüklenir. Bu işlem için ayrı bir servis veya modül kullanılabilir.

📜Sonuçların Gösterimi: Ürün başarıyla MongoDB'ye kaydedildikten ve resim Google Cloud Storage'a yüklendikten sonra listeleme
işlemi gerçekleşir site üzerinde yeni eklenen ürünü görüntüleyebilirler.



♟️ Özellikler
Fotoğraf Depolama: Ürünler için görsellerin Google Cloud üzerinde güvenli bir şekilde depolanması.
PDF ve Excel İşlemleri: Müşteri bilgilerini PDF olarak indirme ve sipariş listesini Excel formatında alma özelliği.

🌍Sonuç
 MongoDB'nin esnek veri depolama yeteneklerinden ve Google Cloud Storage'ın güvenilir depolama hizmetlerinden yararlanarak, modern ve güvenilir bir yapıda ürün yönetimi sağlanabilir.

💻 Kullanılan Teknolojiler ve Yapılar:
- 🎆.NET Core 6.0: Web uygulamasının temel çerçevesi olarak kullanıldı.
- 🎐 Entity Framework (ORM) 6.0: Veritabanı etkileşimi ve ORM için kullanıldı.
- ☁️ Google Cloud: Fotoğraf depolama için bulut hizmeti olarak kullanıldı.
- 📄 EPPlus: Excel dosyaları oluşturmak için kullanıldı.
- 🖋️ iTextSharp: PDF dosyaları oluşturmak için kullanıldı.
- Ⓜ️ AutoMapper: Nesne eşlemesi işlemlerini kolaylaştırmak için kullanılan bir kütüphane.
- 🎡 Code First: Veritabanı şemasının uygulama tarafında kodlanıp veritabanına aktarıldığı yaklaşım.
- 🗃️ MongoDB: NoSQL veritabanı yönetimi ve depolama için tercih edildi.
- 🎨 HTML/CSS/Bootstrap: Arayüz tasarımı için kullanıldı.
- ⌨️ LINQ: Veri sorgulama ve düzenleme için kullanılan bir dil


   ![d](https://github.com/busenurdmb/MongoDbNight/blob/master/MongoDbNight/wwwroot/mongo.gif)
   ![d](https://github.com/busenurdmb/MongoDbNight/blob/master/MongoDbNight/wwwroot/googlecloud.jpeg)
   ![d](https://github.com/busenurdmb/MongoDbNight/blob/master/MongoDbNight/wwwroot/pdf.png)
   ![d](https://github.com/busenurdmb/MongoDbNight/blob/master/MongoDbNight/wwwroot/excel.png)
