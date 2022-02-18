

# Add migration

```posh
dotnet ef migrations add [MIGRATION_NAME] --project ./Pets.Platform.Permissions.Migrations/Pets.Platform.Permissions.Migrations.csproj --startup-project ./Pets.Platform.Permissions.SampleClient/Pets.Platform.Permissions.SampleClient.csproj -o Migrations --context PermissionsDbContext
```