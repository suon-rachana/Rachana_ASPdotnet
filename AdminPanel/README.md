# AdminPanel — Default ASP.NET Core MVC template + @RenderBody / @RenderSection

An admin panel built on the **stock ASP.NET Core MVC template** (the layout
Visual Studio generates with a new MVC project), extended to demonstrate the
Shared folder, `@RenderBody()`, and `@RenderSection()`.

## Run it

```bash
cd AdminPanel
dotnet run
```
Or open `AdminPanel.csproj` in Visual Studio 2022 and press **F5**.

## Routes

| Page      | URL              |
|-----------|------------------|
| Home      | `/`              |
| Dashboard | `/Admin`         |
| Users     | `/Admin/Users`   |
| Reports   | `/Admin/Reports` |
| Privacy   | `/Home/Privacy`  |

---

## What is "the default template"?

These files are the originals from `dotnet new mvc`, unchanged:

| File | Notes |
|------|-------|
| `Views/Shared/_Layout.cshtml` | white navbar, `.container`, footer |
| `Views/Shared/_Layout.cshtml.css` | CSS isolation — the default blue `#1b6ec2` |
| `Views/Shared/_ValidationScriptsPartial.cshtml` | jQuery validation |
| `Views/Shared/Error.cshtml` | default error page |
| `Models/ErrorViewModel.cs` | |
| `Controllers/HomeController.cs` | Index / Privacy / Error |
| `wwwroot/css/site.css` | the template's own CSS |
| `Program.cs`, `appsettings.json` | |

The only edits to `_Layout.cshtml`: nav links for Dashboard/Users/Reports, and
three extra `@RenderSection` holes.

## The Shared folder

`Views/Shared/` holds views any controller can use. Razor searches:

1. `Views/{Controller}/`  — e.g. `Views/Admin/`
2. `Views/Shared/`        — fallback

```
Views/
├── _ViewStart.cshtml         <- Layout = "_Layout"
├── _ViewImports.cshtml       <- @using + tag helpers
├── Shared/
│   ├── _Layout.cshtml        <- RenderBody + 4 RenderSections
│   ├── _Layout.cshtml.css
│   ├── _ValidationScriptsPartial.cshtml
│   └── Error.cshtml
├── Home/    Index · Privacy
└── Admin/   Index · Users · Reports
```

## @RenderBody()

One per layout. Everything in a view **not** inside a `@section` lands here.

```cshtml
<main role="main" class="pb-3">
    @RenderBody()
</main>
```

## @RenderSection()

A **named** hole. The layout declares it, the view fills it.

**Layout:**
```cshtml
@await RenderSectionAsync("Scripts", required: false)
```
**View:**
```cshtml
@section Scripts {
    <script>console.log('only on this page');</script>
}
```

| `required:` | If the view omits it |
|-------------|----------------------|
| `true`      | Runtime error — page won't load |
| `false`     | Renders nothing, no error |

Declared in `_Layout.cshtml`:

| Section       | Lands in        | Required |
|---------------|-----------------|----------|
| `Styles`      | end of `<head>` | no       |
| `Breadcrumb`  | above the title | **yes**  |
| `PageActions` | right of title  | no       |
| `Scripts`     | end of `<body>` | no       |

**Why sections and not just the body?** Order matters. Scripts must load *after*
jQuery/Bootstrap; CSS must sit *inside* `<head>`. `@RenderBody()` can't reach
either spot — a section can.

## Try this

1. Delete `@section Breadcrumb` from `Views/Admin/Reports.cshtml`, reload
   `/Admin/Reports` → `InvalidOperationException: ... cannot find the section
   'Breadcrumb'`. That's `required: true`. Put it back.
2. Compare the `Scripts` section in `Admin/Index.cshtml` (loads Chart.js) with
   `Admin/Users.cshtml` (a filter script). Same layout, different injected JS.
3. `Admin/Reports.cshtml` defines `Styles` but skips `Scripts` and `PageActions` —
   optional sections can be left out entirely.

## Requirements
- .NET 8 SDK
