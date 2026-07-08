# MVC Exercises — Hard Level (លំហាត់ 5.5 & 5.6)

An ASP.NET Core MVC (.NET 8) project containing two exercises.

## Exercises

- **5.5 DepartmentStaff** — A `Department` object (Id, Name, StaffMembers) built in the
  action and passed to a strongly-typed View that renders the staff list in a Razor table.
- **5.6 DoctorSchedule** — A `List<Doctor>` (Id, Name, Specialty, AvailableDays) of 2 doctors
  rendered in an HTML table styled with Bootstrap badges.

## How to run

### Option A — Visual Studio 2022
1. Open `MvcExercises.csproj` (or double-click it).
2. Wait for NuGet to restore.
3. Press **F5** (or the green ▶ button).

### Option B — Terminal (.NET CLI)
```bash
cd MvcExercises
dotnet run
```
Then open the URL shown in the terminal (e.g. `http://localhost:5175`).

## Routes

| Page                | URL                                  |
|---------------------|--------------------------------------|
| Home (links to both)| `/`                                  |
| Exercise 5.5        | `/Department`  or `/Department/Index` |
| Exercise 5.6        | `/Doctor`      or `/Doctor/Index`     |

## Project structure
```
MvcExercises/
├── Controllers/
│   ├── HomeController.cs
│   ├── DepartmentController.cs   (5.5)
│   └── DoctorController.cs       (5.6)
├── Models/
│   ├── Department.cs             (5.5)
│   └── Doctor.cs                 (5.6)
├── Views/
│   ├── Home/Index.cshtml
│   ├── Department/Index.cshtml   (5.5 — strongly-typed)
│   ├── Doctor/Index.cshtml       (5.6 — Bootstrap badges)
│   └── Shared/_Layout.cshtml
├── wwwroot/  (Bootstrap 5.3 + jQuery)
├── Program.cs
└── MvcExercises.csproj
```

## Requirements
- .NET 8 SDK (https://dotnet.microsoft.com/download)
