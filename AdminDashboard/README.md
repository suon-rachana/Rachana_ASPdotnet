# Admin Dashboard — Shared Layout, @RenderBody, @RenderSection

An ASP.NET Core MVC (.NET 8) admin dashboard built to demonstrate how the
**Shared folder**, **@RenderBody()**, and **@RenderSection()** fit together.

## Run it

```bash
cd AdminDashboard
dotnet run
```
Open the URL printed in the terminal (e.g. `http://localhost:5180`).
Or open `AdminDashboard.csproj` in Visual Studio 2022 and press **F5**.

## Routes

| Page      | URL              |
|-----------|------------------|
| Dashboard | `/Admin`         |
| Users     | `/Admin/Users`   |
| Reports   | `/Admin/Reports` |

`/` redirects to `/Admin`.

---

## The three concepts

### 1. The Shared folder

`Views/Shared/` holds views that **any controller** can use. When Razor looks for
a view or partial, it searches:

1. `Views/{Controller}/` — e.g. `Views/Admin/`
2. `Views/Shared/`  ← fallback

That's why `_AdminLayout`, `_Sidebar`, and `_TopBar` live there — every page uses them.

```
Views/
├── _ViewStart.cshtml       <- sets Layout = "_AdminLayout" for all views
├── _ViewImports.cshtml     <- @using + tag helpers for all views
├── Shared/
│   ├── _AdminLayout.cshtml <- THE LAYOUT (RenderBody + RenderSection)
│   ├── _Sidebar.cshtml     <- partial view
│   └── _TopBar.cshtml      <- partial view
└── Admin/
    ├── Index.cshtml        <- Dashboard
    ├── Users.cshtml
    └── Reports.cshtml
```

### 2. @RenderBody()

The layout is the page frame. `@RenderBody()` is the hole where the child view's
main content is dropped in.

- **Exactly one** per layout.
- Everything in a view that is **not** inside a `@section` block goes here.

```cshtml
<main class="page-body">
    @RenderBody()
</main>
```

### 3. @RenderSection()

A **named** hole. The layout declares it, the view fills it. Use it when content
needs to land somewhere other than the main body — the `<head>`, the header bar,
the bottom of `<body>`.

**In the layout:**
```cshtml
@await RenderSectionAsync("Scripts", required: false)
```

**In the view:**
```cshtml
@section Scripts {
    <script>console.log('only on this page');</script>
}
```

| `required:` | If the view omits the section |
|-------------|-------------------------------|
| `true`      | Runtime error — the page won't load |
| `false`     | Renders nothing, no error |

This project declares four sections in `_AdminLayout.cshtml`:

| Section       | Where it lands | Required? |
|---------------|----------------|-----------|
| `Styles`      | end of `<head>` | no  |
| `Breadcrumb`  | page header     | **yes** |
| `PageActions` | header, right   | no  |
| `Scripts`     | end of `<body>` | no  |

### Why sections instead of just putting it in the body?

Order matters. Scripts must load **after** jQuery and Bootstrap; CSS must load
**inside** `<head>`. A `@section` lets a view inject content at the right point in
the document instead of wherever `@RenderBody()` happens to be.

Notice the Dashboard loads Chart.js in its `Scripts` section — the Users page never
downloads it, because it doesn't need it.

---

## Try this to see it work

1. **Delete the `@section Breadcrumb` block from `Views/Admin/Reports.cshtml`.**
   Reload `/Admin/Reports` → you get:
   `InvalidOperationException: ... cannot find section 'Breadcrumb'`
   That's `required: true` doing its job. Put it back.

2. **Compare `Index.cshtml` and `Users.cshtml`** — same layout, completely different
   `Scripts` sections.

3. **Look at `Reports.cshtml`** — it defines `Styles` but no `Scripts` and no
   `PageActions`. Optional sections can simply be left out.

## Requirements
- .NET 8 SDK
