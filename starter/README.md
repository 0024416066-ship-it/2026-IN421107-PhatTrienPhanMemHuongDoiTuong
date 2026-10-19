# EduHub Ch02 — Refactoring với SOLID và Design Patterns

Dự án minh họa cách tách `ClubManager` thành domain, services, repositories và các abstraction nhỏ. Bản phân tích các vi phạm SOLID ban đầu nằm tại [`docs/solid-analysis.md`](docs/solid-analysis.md).

## Cấu trúc

- `Ch02.Refactor/Domain`: quy tắc nghiệp vụ của `Club`, `Member`, `Event`.
- `Ch02.Refactor/Services`: `ClubService`, `EventService`, `ReportService` và interface.
- `Ch02.Refactor/Repositories`: repository interface, bộ nhớ trong và `LoggingClubRepository` decorator.
- `Ch02.Refactor/Notifications`: notification services và factory theo `NotificationChannel`.
- `Ch02.Refactor/Patterns`: observer cho sự kiện và strategy cho báo cáo Console/CSV.
- `Ch02.Refactor.Tests`: kiểm thử AAA cho domain và design patterns.

## Chạy

```bash
dotnet build Ch02.Refactor.sln
dotnet test Ch02.Refactor.sln
dotnet run --project Ch02.Refactor
```

`Program.cs` là composition root, nơi các implementation cụ thể được tạo và truyền vào services qua constructor.
