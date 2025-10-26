# OnionArcServer

**OnionArcServer**, Clean Architecture ve Onion Architecture prensiplerini temel alan güçlü bir .NET sunucu uygulama çatısıdır. Amaç, kodun sürdürülebilirliğini, test edilebilirliğini ve genişletilebilirliğini artırmaktır.

## Neden OnionArcServer?

Modern backend geliştirmede okunabilirlik, test edilebilirlik ve esneklik çok önemlidir. **OnionArcServer**, bu ihtiyaçları karşılamak için tasarlanmıştır:

- **Domain**, **Application**, **Infrastructure**, **Persistence** ve **API** katmanlarını net bir şekilde ayırır.  
- Yeni özellikler eklemeyi veya altyapı katmanlarını değiştirmeyi kolaylaştırır.  
- **DDD (Domain-Driven Design)** yaklaşımını ve **Clean Architecture** prensiplerini uygular.  
- Kurumsal projeler için güçlü bir başlangıç noktası sağlar.

---

## Mimari Genel Bakış

Proje **Onion Architecture** yaklaşımına göre katmanlı olarak yapılandırılmıştır:

- `OnionArc.Domain`: Temel domain modelleri, arayüzler ve iş kuralları.  
- `OnionArc.Application`: Use Case’ler, CQRS komut/sorgular, DTO’lar.  
- `OnionArc.Infrastructure`: Servis implementasyonları, dış sistem bağlantıları.  
- `OnionArc.Persistence`: Veritabanı erişimi, repository yapıları, migration işlemleri.  
- `OnionArc.API`: Web API uç noktaları ve uygulama giriş noktası.

Bu yapı, **bağımlılık tersine çevirmeyi** (Dependency Inversion) destekleyerek domain katmanının dış etkenlerden bağımsız olmasını sağlar.

---

## Başlarken

### Gereksinimler
- [.NET 6+ SDK](https://dotnet.microsoft.com)  
- Entity Framework Core (veya belirtilen ORM)  
- Visual Studio, VS Code veya JetBrains Rider

---

## Kullanım
- Yeni domain varlıklarını Domain katmanında tanımla.
- Use Case’leri Application katmanında uygula.
- Servisleri veya dış sistem bağlantılarını Infrastructure katmanına ekle.
- Repository veya veritabanı işlemlerini Persistence katmanında yönet.
- API uç noktalarını API katmanında tanımla.
- Her katman bağımsız olarak test edilebilir şekilde tasarlanmıştır.
