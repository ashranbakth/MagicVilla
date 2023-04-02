# Database migration command (PostgreSQL) for MAC

Summary: These are the essentials for connecting your Web API service to the Database using Entity Framework Core for MAC. You have to use the dotnet CLI to initialize the migration instance and update the database because the nugget package manager console does not exist on MAC. For this document, this is specifically for PostgreSQL data migration.

Create the migration instance:
```
Format: dotnet ef migrations add {NAME} --project {PATH TO THE .csproj}
example:
dotnet ef migrations add AddVillaTable --project /Users/ashranbakth/Projects/MagicVilla/MagicVilla_VillaAPI/MagicVilla_VillaAPI.csproj
```

Update the database:
```
Format: dotnet ef database update {NAME} --project {PATH TO THE .csproj}
example:
dotnet ef database update AddVillaTable --project  /Users/ashranbakth/Projects/MagicVilla/MagicVilla_VillaAPI/MagicVilla_VillaAPI.csproj
```

Add this in the app settings.json:
```
"ConnectionStrings": {
    "DefaultSQLConnection": "Server=localhost;Database=MagicVilla;Port=5432;Username=postgres; Password=password"
  }
```

Add this in the Program.cs where you add services to the container (this one is for postgresql):
```
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
```
