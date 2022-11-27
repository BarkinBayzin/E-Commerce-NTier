# NTierProje
-- Core --

Referanslar = Entity Framework (NuGet)
1)NTier.Core isimli bir C# Library açıyoruz.
1.1)Bu kütüphane içerisinde Entity, Map ve Service klasörlerini yerleştiriyoruz.
1.2.1)Entity içerisine Enum klasörü açıyoruz, Statüleri enum olarak yerleştiriyoruz.
1.2.2)IEntity interface oluşturuyoruz. ID tanımlaması yapıyoruz.
1.2.3)CoreEntity classı oluşturuyoruz. Ortak tüm propları yazıp ctor içerisinde ön tanımlama yapıyoruz.
1.3)Map Sınını yazıyoruz ve CoreEntity içerisinde var olan tüm propların mapleme işlemini "Fluent Api" kullanarak gerçekleştiriyoruz.
1.4)Service içerisine veritabanı üzerinde gerçekleştirilecek olan işlemlerimizi içeren metotları ekliyoruz.

-- Model --

Referanlar = NTier.Core, EntityFramework(NuGet)
1)NTier.Model isimli bir C# Library açıyoruz.
1.1)Kütüphane içerisine Context, Entities, Map klasörleri açıyoruz.
1.2)Entities klasöründe AppUser,Category,OrderDetails,Orders,SubCategory sınıflarını açıyoruz.
1.3)Maps klasöründe tüm entitylerin mapleme işlemlerini gerçekleştiriyoruz. CoreMap sınıfından miras olarak ortak propertler ekleniyor.
1.4)Context klasörü içerisinde ProjectContext sınıfını açıyorz.
1.4.1)Sınıf içerisinde onModelCreating methodunu override ediyoruz ve yazmış olduğumuz map sınıfılarının konfigürasyonlara ekliyoruz.
1.4.2)DbSetleri tanımlıyoruz.
1.4.3)SaveChanges methodunu override ediyoruz. Bu sayede güncellenen ve yenmi eklenen tüm entity'ler otomatik olarak bazı sütunlarına değerleri alıyor.(CreatedMachineName veya ModifiedDate gibi..)
1.5)enable-migrations -enableAutomaticMigrations ile console üzerinden migrate ediyoruz. Update-database yapıyoruz.

-- Service --

Referanslar = NTier.Core, NTier.Model, EntityFrameWork(NuGet)
1)NTier.Service isimli bir C# Library açıyoruz.
1.1)Kütüphane içerisine Base ve Option isimli iki klasör oluşturuyoruz.
1.2)Base içerisine BaseService sınfını açıyoruz. Bu sınıf içerisine ICoreService üzerinde tanımlanmış olan tüm methodların gövdelerini ekliyoruz.
1.3)Option klasörü içerisine tüm entityleri service olarak açıyoruz. Entity'e özel metotları varsa eğer ekliyoruz.

-- UI --

Referanslar = NTier.Core, NTier.Model, NTier.Service, EntityFramework(NuGet)
1)Proje içerisine layout oluşturuyoruz.
2)Partial View oluşturarak Kategori menüsünü layout içerisine ekliyoruz.
(HomeController içerisindeki [ChildActionOnly] bu attribute partialView için _CategoryLis menüyü içermektedir.)
3)ProductController ile Ürün listeleme metotlarımızı oluşturyoruz.
4)Sepete ekleme işlemleri için Cart sınıfını Models altına ekliyoruz.(Session örneğindeki sepet işlemlerinin aynısını ekliyoruz.)
-Bazı sayfalarda "Regex'ler" anlatım için eklenmiştir. Kaynakları internetten bulunabilir.

-- UI/Admin(AREA)

1)Proje içerisine Admin Area ekliyoruz. Route.Config içerisine area kodunu ekliyoruz.
1.1)Admin Area için Layout oluşturuyoruz.
1.2)CRUD işlemleri tüm entityler için controller'lar içerisine ekleniyor.
2)Helpers kalsöründeki ImageUploader sınıfını oluştuyoruz(Bu sınıf ile ürün ve product image ekleme işlemlerimiz için path oluşturuyoruz)

-- UI/Member(AREA)

1)Member alanında Sepet(Cart), Checkout(sipariş tamamlama), Register(Yeni üye kaydı) işlemlerimiz için controller'lar oluşturuyoruz.
Sepet için ProductCart sınıfını models içerisine eklemeyi unutmayınız.

--API/NTier.AuthService

Referanslar = NTier.Core, NTier.Model, NTier.Service
1)Solution içerisine API projesini ekliyoruz.
2)Login.cshtml içerisine ekledğimiz ajax kodu ile kullanıcı bilgilerini API'ye gönderiyoruz.
3)API içerisindeki controller ile gelen verilere göre yönlendirme gerçekleştiriyoruz.(ID bu aşamada url üzerinden iletilecektir ve UI-HomeController içeriisnde FormsAuthentiacion eklenecektir. Web.Config içerisine authentication için gerekli bölümü eklemeyi unutmayın)
4)Logout için _Layout içerisine link ekliyoruz ve API içerisindeki controller'a yönlendirme yapıyoruz.
