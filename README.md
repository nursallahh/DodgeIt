<div align="center">

# DodgeIT

### Engelleri oku. Zamanlamanı seç. Parkuru geç.

**3D Parkur · Tek Oyunculu · Unity & C#**

Hareketli engeller, lav alanları ve beklenmedik tuzaklarla dolu bir parkur oyunu.

[Oyun Hakkında](#oyun-hakkında) · [Kontroller](#kontroller) · [Çalıştırma](#çalıştırma) · [Teknolojiler](#teknolojiler)

</div>

---

## Oyun hakkında

**DodgeIT**, oyuncunun engeller arasından ilerleyerek parkuru aşmaya çalıştığı, zamanlama ve dikkat odaklı bir 3D oyundur. Dönen bariyerlerin ritmini takip et, tuzaklara karşı hazırlıklı ol ve lavların üzerindeki platformlarda adımlarını dikkatli seç.

Unity ile oyun geliştirmeyi öğrenme sürecinde hazırlanmış, tamamlanmış bir kişisel projedir.

## Parkurda seni neler bekliyor?

| Engel / Sistem | Oynanış |
| --- | --- |
| Dönen bariyerler | Geçiş için doğru anı bekle. |
| İleri–geri hareket eden engeller | Hareket düzenini takip ederek aradan geç. |
| Lav alanları ve platformlar | Güvenli yüzeylerde kal ve zıplamalarını ayarla. |
| Yaklaşınca düşen engeller | Yol üzerindeki sürpriz tuzaklara dikkat et. |
| Tetiklenen mermiler | Tehlikeli bölgelere girerken gelen saldırılardan kaçın. |
| Yeniden doğma bölgeleri | Ölüm alanına temas ettiğinde belirlenen noktadan devam et. |

## Kontroller

| Tuş | İşlev |
| --- | --- |
| **W / A / S / D** | Hareket |
| **Space** | Zıplama |

## Çalıştırma

Bu depo Unity proje dosyalarını içerir. Oynamak için projeyi Unity Editor içinde açabilirsin; kaynak kodu indirmek tek başına tarayıcıda oynanabilir bir sürüm oluşturmaz.

1. Depoyu klonla veya **Code → Download ZIP** ile indirip arşivi çıkar.
2. **Unity Hub** üzerinden **Unity 6000.6.3f1** sürümünü kur.
3. Unity Hub'da **Add / Add project from disk** ile `Assets`, `Packages` ve `ProjectSettings` klasörlerini içeren proje klasörünü seç.
4. Projeyi aç ve paketlerin yüklenmesini bekle.
5. Project panelinden **`Assets/Scenes/Recovered_20261029_1355.unity`** sahnesini aç. Tam parkurun bulunduğu sahne budur.
6. **Play** düğmesine bas.

> İlk açılışta Unity, `Library` gibi yerel önbellek klasörlerini yeniden oluşturur. Bu nedenle ilk yükleme daha uzun sürebilir.

## Teknolojiler

| Bileşen | Kullanım |
| --- | --- |
| **Unity 6000.6.3f1** | Oyun motoru |
| **C#** | Oyuncu hareketi, tuzaklar ve oyun davranışları |
| **Universal Render Pipeline (URP)** | Görüntüleme |
| **Cinemachine** | Kamera sistemi |
| **Rigidbody & Collider** | Fizik, çarpışmalar ve tetikleme alanları |

## Proje yapısı

```text
Assets/
├── Animations/       # Animasyon dosyaları
├── Materials/        # Materyaller ve dokular
├── Prefabs/          # Yeniden kullanılabilir oyun nesneleri
├── Scenes/           # Oyun sahneleri
└── Scripts/          # C# oyun kodları
Packages/             # Paket bağımlılıkları
ProjectSettings/      # Unity proje ayarları
```

## Bağımsız oyun çıktısı

Unity kurulmadan çalıştırılabilen bir sürüm hazırlamak için **File → Build Profiles** üzerinden hedef platformu seç ve tam parkur sahnesini sahne listesine ekle. Build almadan önce etkin sahne listesinin `Recovered_20261029_1355` sahnesini içerdiğini kontrol et; depodaki mevcut build ayarı `SampleScene` sahnesine işaret eder.

## Geliştirici

**Nursallah**

Unity ile hareket, fizik, kamera ve engel sistemlerini bir araya getiren bir parkur projesi.

---

Üçüncü taraf görsel varlıkların kullanım koşulları ilgili hak sahiplerine aittir. Bu depoda bulunmaları, ayrı bir yeniden dağıtım lisansı verildiği anlamına gelmez.
