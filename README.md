# Bankacılık Kredi Sistemi

.NET Core 9 ile Clean Architecture ve CQRS pattern kullanılarak geliştirilmiş bir bankacılık kredi sistemi.

## Proje Yapısı

- **BankingCreditSystem.Core**: 
  - Core katmanı, tüm projenin temel yapı taşlarını içerir
  - Generic Repository Pattern implementasyonu
  - Paging yapısı
  - Entity base sınıfları
  - Dinamik query yapısı

- **BankingCreditSystem.Domain**: 
  - Domain nesneleri (Customer, IndividualCustomer, CorporateCustomer)
  - Domain için özel exception'lar
  - Enum'lar ve sabitler

- **BankingCreditSystem.Application**: 
  - CQRS (Command Query Responsibility Segregation) implementasyonu
  - MediatR kullanılarak command/query handler'lar
  - AutoMapper ile DTO dönüşümleri
  - Validation kuralları (FluentValidation)
  - Business Rules

- **BankingCreditSystem.Persistence**: 
  - Entity Framework Core implementasyonu
  - Repository implementasyonları
  - DbContext ve konfigürasyonlar
  - Migration'lar

- **BankingCreditSystem.WebAPI**: 
  - REST API endpoints
  - Swagger/OpenAPI dokümantasyonu
  - JWT Authentication
  - API versiyonlama

## Kullanılan Teknolojiler

- .NET Core 9
- Entity Framework Core 9
- MediatR (CQRS implementasyonu için)
- AutoMapper (DTO dönüşümleri için)
- FluentValidation (Validasyon kuralları için)
- Swagger/OpenAPI (API dokümantasyonu)
- SQL Server (Veritabanı)

## Mimari Özellikler

- Clean Architecture
  - Bağımlılıklar içten dışa doğru
  - Katmanlar arası sıkı bağımlılık kontrolü
  - Domain-Driven Design prensipleri

- CQRS Pattern
  - Command ve Query sorumluluklarının ayrılması
  - Her işlem için özel DTO'lar
  - MediatR ile handler implementasyonu

- Repository Pattern
  - Generic async repository
  - Specification pattern desteği
  - Include mekanizması
  - Soft delete implementasyonu

- Cross-Cutting Concerns
  - Global exception handling
  - Loglama
  - Caching
  - Transaction yönetimi

## Temel Özellikler

- Bireysel ve Kurumsal Müşteri Yönetimi
- Kredi Skoru Hesaplama
- Soft Delete İmplementasyonu
- Sayfalama Desteği
- CRUD Operasyonları
- Validation ve Business Rules
- Exception Handling

## Kurulum

1. Projeyi klonlayın
2. .NET Core 9 SDK'yı yükleyin
3. SQL Server bağlantı ayarlarını yapılandırın
4. Migration'ları çalıştırın: `dotnet ef database update`
5. WebAPI projesini çalıştırın: `dotnet run`

## Geliştirme Ortamı

- Visual Studio 2022
- SQL Server Management Studio
- Postman (API testleri için)

