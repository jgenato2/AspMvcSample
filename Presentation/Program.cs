
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);



// Register EF Core DbContext
builder.Services.AddDbContext<AspMvcSample.Infrastructure.Persistence.AppDbContext>(options =>
    options.UseInMemoryDatabase("AspMvcSampleDb"));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register infrastructure and CQRS services
AspMvcSample.Infrastructure.Services.DependencyInjectionConfig.AddInfrastructureServices(builder.Services);

var app = builder.Build();

// Seed dummy data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AspMvcSample.Infrastructure.Persistence.AppDbContext>();

    // Seed Departments
    if (!db.Departments.Any())
    {
        db.Departments.AddRange(
            new AspMvcSample.Domain.Entities.Department { Id = 1, Name = "HR", CompanyId = 1 },
            new AspMvcSample.Domain.Entities.Department { Id = 2, Name = "IT", CompanyId = 1 }
        );
        db.SaveChanges();
    }

    // Seed Employees
    if (!db.Employees.Any())
    {
        db.Employees.AddRange(
            new AspMvcSample.Domain.Entities.Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", DateOfBirth = new DateTime(1990, 1, 1), DepartmentId = 1, CompanyId = 1 },
            new AspMvcSample.Domain.Entities.Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", DateOfBirth = new DateTime(1992, 2, 2), DepartmentId = 2, CompanyId = 1 }
        );
        db.SaveChanges();
    }

    // Seed Attendance
    if (!db.Attendances.Any())
    {
        db.Attendances.AddRange(
            new AspMvcSample.Domain.Entities.Attendance { Id = 1, EmployeeId = 1, Date = DateTime.Today, Present = true, Remarks = "On time" },
            new AspMvcSample.Domain.Entities.Attendance { Id = 2, EmployeeId = 2, Date = DateTime.Today, Present = false, Remarks = "Sick leave" }
        );
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
