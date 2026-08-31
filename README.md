# Customer Management

A WPF (.NET 8, MVVM) customer management app.

## Running the application

Requirements: Windows 10/11, .NET 8 SDK, Visual Studio 2022 (or the `dotnet` CLI).

**Visual Studio:** open `CustomerManagement.slnx`, set `CustomerManagement` as the startup project, and press F5.

**CLI:**

```bash
dotnet run --project CustomerManagement/CustomerManagement.csproj
```

The `StyledComponent` NuGet package (providing the `StyledAppButton` custom control used for all primary action buttons) restores automatically on build.

## What was implemented

Starting from the provided starter project (customer list, Add/Delete, basic MVVM), the following assessment requirements were completed:

- **Validation** — First name, last name, email (format-checked), phone (format-checked) and status are all required. Errors show inline under each field, and Save is disabled until the form is valid (`CustomerFormViewModel`).
- **Edit customer** — New "Edit Customer" button/command loads the selected customer into the same form used for Add, and saves changes back into the grid.
- **Delete confirmation** — Deleting now prompts a Yes/No confirmation dialog naming the customer before removing it.
- **Search** — Filters the grid by first name, last name, or email as you type.
- **Status filter** — All / Active / Inactive dropdown, combined with search (both apply together via a single `ICollectionView` filter).
- **UI/UX** — Search/filter toolbar, wider action buttons, alternating row colors, an empty-state message when no rows match, and a friendlier Add/Edit form layout with inline validation messages.
- **Error handling** — A top-level `DispatcherUnhandledException` handler shows a message box instead of crashing the app on an unexpected error.

The existing MVVM structure was preserved: view logic stays in the views, form/list state and business logic live in `CustomerFormViewModel` and `MainViewModel`, and the provided `StyledAppButton` control is used for every primary action button (Add, Edit, Delete, Save, Cancel).

`Customer` was updated to raise `PropertyChanged` so that editing a customer updates the grid live without manually refreshing bound collections.
