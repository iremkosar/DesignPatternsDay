OrganikMarket — ASP.NET Core MVC E-Ticaret Projesi

OrganikMarket, ASP.NET Core MVC ve Entity Framework Core kullanılarak geliştirilmiş, 6 farklı tasarım deseninin (design pattern) uçtan uca uygulandığı bir organik gıda e-ticaret platformudur. Proje; ürün yönetimi, sepet, karşılaştırma, ödeme ve sipariş süreçlerinin yanı sıra içerik yönetimi yapılabilen kapsamlı bir admin paneli içerir.

Özellikler


Dinamik ana sayfa (banner, servisler, trend ürünler, blog, müşteri yorumları)
Kategoriye göre ürün filtreleme ve listeleme (Shop)
Session tabanlı sepet sistemi (miktar artırma/azaltma, indirim seçimi, KDV hesaplama)
Ürün karşılaştırma (en fazla 4 ürün, yan yana kıyaslama)
Ürün detay sayfası
Sipariş oluşturma (Checkout) ve sipariş takibi
Kapsamlı admin paneli:

Ürün, banner, servis, trend, blog, müşteri yorumu CRUD işlemleri
Sipariş listesi, detayı ve durum güncelleme
Stok durumuna göre otomatik bildirim (Observer Pattern)


Kullanılan Teknolojiler

ASP.NET Core MVC (.NET 8)
Entity Framework Core
Microsoft SQL Server
Razor Views (Partial View mimarisi)
Bootstrap 5


Mimari ve Design Pattern Kullanımı

Proje, klasik CRUD operasyonlarının ötesinde gerçek dünya senaryolarında 6 design pattern'i bir arada kullanır:

PatternKullanım AlanıRepository PatternTüm veritabanı erişimlerinde (IGenericRepository) generic veri erişim katmanıUnit of WorkAdmin panelindeki tüm ekleme/güncelleme/silme işlemlerinde tutarlı commit yönetimiObserver PatternÜrün eklenince/güncellenince stok seviyesine göre otomatik düşük stok / tükendi bildirimiChain of ResponsibilityÜrün ekleme/düzenleme formunda sıralı validasyon zinciri (isim → fiyat → stok)Strategy PatternSepette ve admin panelinde seçilebilir indirim stratejileri (standart, toplu, sezonluk)Decorator PatternÜrün ve sepet fiyatlarına KDV ekleme, orijinal fiyatı bozmadan sarmalama

![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/1.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/2.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/3.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/4.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/5.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/6.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/7.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/8.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/9.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/10.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/11.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/12.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/13.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/14.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/15.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/16.png)
![Resim Açıklaması](https://github.com/iremkosar/DesignPatternsDay/blob/eb8eda49833b848410721da0c66b75197ea37b2f/DesignPatternsDay/wwwroot/17.png)
