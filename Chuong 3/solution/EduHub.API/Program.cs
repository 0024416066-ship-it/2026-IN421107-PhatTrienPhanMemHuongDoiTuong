using EduHub.Application.Clubs;
using EduHub.Domain.Interfaces;
using EduHub.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ── Đăng ký services (Dependency Injection) ──────────────────────────────
// Scoped = mỗi request một instance. Kho in-memory dùng danh sách static nên dữ liệu vẫn giữ giữa các request.
builder.Services.AddScoped<IClubRepository, InMemoryClubRepository>();
builder.Services.AddScoped<IMemberRepository, InMemoryMemberRepository>();

builder.Services.AddScoped<GetClubsQueryHandler>();
builder.Services.AddScoped<GetClubByIdQueryHandler>();
builder.Services.AddScoped<CreateClubCommandHandler>();
builder.Services.AddScoped<DeleteClubCommandHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "EduHub API", Version = "v1" });
});

var app = builder.Build();

// ── Middleware pipeline ───────────────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Mở trang tài liệu API khi truy cập địa chỉ gốc hoặc /index.html.
    app.MapGet("/", () => Results.Redirect("/swagger"));
    app.MapGet("/index.html", () => Results.Redirect("/swagger"));
}

app.MapControllers();

app.Run();
