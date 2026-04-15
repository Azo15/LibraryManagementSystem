# 📚 EduLibrary: Kütüphane Yönetim Sistemi (KYS)

![EduLibrary Dashboard](https://via.placeholder.com/1000x500.png?text=EduLibrary+K%C3%BCt%C3%BCphane+Y%C3%B6netim+Sistemi+%E2%80%A2+C%23+WinForms)

EduLibrary, modern **Single Page Application (SPA)** mantığıyla C# WinForms üzerinde sıfırdan geliştirilmiş, son derece şık, profesyonel ve yenilikçi bir **Kütüphane Yönetim Sistemidir.** 

Geleneksel ve karmaşık masaüstü yazılımlarının aksine, EduLibrary "Web-Tasarım" trendlerinden esinlenerek (Top-Nav mimarisi, canlı grafikler, degrade afişler) kullanıcı deneyimini en üst seviyeye çıkartır.

---

## 🌟 Öne Çıkan Özellikler

* **🚀 Yeni Nesil Web-Benzeri Arayüz:** Eski nesil sol menüler (sidebar) yerine **Top-Navbar** (Üst Gezinme Çubuğu) ile daha geniş bir çalışma alanı.
* **📊 Etkileşimli İstatistik ve Grafikler:** Ana sayfada dinamik istatistik kartları ve C# `DataVisualization.Charting` kütüphanesiyle hazırlanan **Kitap Tür Dağılımı (Pasta Grafiği)** ve **Ödünç Alma Trendi (Çizgi Grafiği)**.
* **⚡ Single Page Application (SPA) Deneyimi:** Pencerelerin üst üste açılması sorununu tarihe gömdük. Bütün işlemler tek bir ana pencere (`panelContent`) içerisinde dinamik alt formlarla yüklenerek hafıza (RAM) dostu muazzam bir akıcılık sağlar.
* **📱 Dinamik Bildirim Akışı:** Sağ tarafta konumlandırılmış **"Son İşlemler & Bildirimler"** (Side Feed) paneli ile kütüphanedeki en güncel aktiviteleri (ödünç alma, teslim vb.) Twitter/Facebook akışı gibi anlık takip etme fırsatı.
* **👮 Çoklu Rol Sistemi:**
  * **Yönetici (Admin):** Tüm sisteme tam erişim, kullanıcı atamaları ve detaylı analizler.
  * **Personel (Staff):** Okuyucu işlemleri, ödünç/iade onayı ve stok takibi.
  * **Öğrenci (Student):** Kişisel kitap araştırmaları, geçmiş ödünçleri inceleme ve profil kolaylığı.
* **🔐 Güvenli Kimlik Doğrulama:** Split-screen (Bölünmüş ekran) yeni nesil çok şık giriş ekranları (Login).

---

## 🛠️ Kullanılan Teknolojiler

* **Yazılım Dili:** C# (.NET Framework)
* **Arayüz (UI/UX):** Gelişmiş WinForms Tasarım Teknikleri (Yuvarlatılmış paneller, LinearGradient fırçaları, Anti-alias metin ve çizim yetenekleri)
* **Veri Görselleştirme:** `System.Windows.Forms.DataVisualization.Charting`
* **Veritabanı:** *(Projenizin veritabanı yapısına göre: SQLite / LocalDB / SQL Server vb.)*

---

## 📸 Ekran Görüntüleri

| Hoşgeldin & Analiz Ekranı (Dashboard) | Kullanıcı Girişi (Login) |
| :---: | :---: |
| ![Dashboard]<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/9d9f2f2a-22dd-463e-a79c-0f12eb4717a2" />
 | ![Login](https://via.placeholder.com/500x300.png?text=Split-Screen+Giris+Ekrani) |

> *(Not: Github'a pushlarken `https://via.placeholder.com/...` linklerini `/Screenshots/dashboard.png` gibi gerçek klasör yollarınızla güncelleyebilirsiniz.)*

---

## 🚀 Kurulum ve Çalıştırma

1. Projeyi bilgisayarınıza klonlayın:
   ```bash
   git clone https://github.com/KULLANICI_ADINIZ/Gorsel-Programlama-KYS-Projesi.git
   ```
2. **Visual Studio (2019 veya üzeri)** aracılığı ile `.sln` uzantılı solution dosyasını açın.
3. Proje açılırken `.Designer.cs` form açık sekmelerini (varsa) 'X' ile kapatın.
4. Üst Menü'den **Build > Rebuild Solution** (Çözümü Yeniden Derle) seçeneğine tıklayın.
5. Yeşil **Start (Başlat)** tuşuna basarak sistemin tadını çıkarın!

---

## 💡 Geliştirici Notu

Bu proje, masaüstü uygulamalarının sadece basit gri pencerelerden ibaret olmak zorunda olmadığını; klasik C# WinForms araçları kullanılarak bile bir web sitesi veya modern SPA uygulaması kalitesinde tasarımlar üretilebileceğini göstermek amacıyla modernize edilmiştir.
