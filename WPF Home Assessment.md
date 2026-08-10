# WPF Home Assessment

## Overview

This project is a **WPF Home Assessment** for evaluating a developer's practical skills in C#, WPF, MVVM, data binding, command handling, and UI development.

The repository contains a partially implemented **Customer Management application**.

The provided project is a **Starter Project**. Candidates are expected to review the existing implementation and complete the remaining requirements.

---

## Technology Stack

- C#
- .NET 8
- WPF
- MVVM
- XAML
- Visual Studio 2022

The application is intended to run on:

- Windows 10
- Windows 11

---

## Project Structure

```text
WpfHomeAssessment
│
├── Commands
│   └── RelayCommand.cs
│
├── Models
│   └── Customer.cs
│
├── ViewModels
│   ├── MainViewModel.cs
│   └── CustomerFormViewModel.cs
│
├── Views
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   ├── CustomerWindow.xaml
│   └── CustomerWindow.xaml.cs
│
├── Services
│
├── Resources
│
├── App.xaml
├── App.xaml.cs
└── WpfHomeAssessment.csproj
```

---

# Current Implementation

The Starter Project already provides the following functionality.

### Customer Model

The `Customer` model contains:

- Id
- First Name
- Last Name
- Email
- Phone
- Status

### Customer List

The main window displays customers using a WPF `DataGrid`.

The initial sample data contains several customers.

### MVVM

The project uses a basic MVVM structure:

```text
View
  ↓
ViewModel
  ↓
Model
```

`MainViewModel` manages the customer collection and commands.

### Data Binding

The project uses WPF data binding between the View and ViewModel.

Example:

```xml
ItemsSource="{Binding Customers}"
```

### ICommand

The project includes a simple `RelayCommand` implementation.

The existing commands include:

- Add Customer
- Delete Customer

### Add Customer

The Starter Project provides a Customer input window.

The user can enter:

- First Name
- Last Name
- Email
- Phone
- Status

and save or cancel the operation.

### Delete Customer

A selected customer can currently be removed from the DataGrid.

---

# CustomButton Requirement

This project uses a custom WPF control called:

```text
CustomButton
```

The `CustomButton` is provided separately as part of the company's custom controls library.

Candidates should use the provided `CustomButton` for application action buttons.

For example:

```xml
<custom:CustomButton
    Text="Save"
    Width="90"
    Height="32" />
```

Do **not** replace the provided CustomButton with a standard WPF `Button` for the application's primary action buttons.

Standard WPF controls such as the following may continue to be used:

- TextBox
- ComboBox
- DataGrid
- TextBlock
- Grid
- StackPanel
- etc.

The purpose is to evaluate whether the candidate can correctly consume and integrate a custom WPF control while maintaining a clean application architecture.

---

# Assessment Requirements

The following functionality is intentionally **not fully implemented** in the Starter Project.

The candidate is expected to complete these requirements.

## 1. Customer Validation

Implement appropriate validation for the Customer form.

At minimum, validate:

- First Name
- Last Name
- Email
- Phone
- Status

Examples of expected behavior:

- Required fields should not accept empty values.
- Email should have a valid format.
- Invalid input should provide useful feedback to the user.
- The user should not be able to save invalid customer data.

The implementation approach is up to the candidate.

---

# 2. Edit Customer

Add the ability to edit an existing customer.

Expected workflow:

```text
Select Customer
      ↓
Edit Customer
      ↓
Customer Form
      ↓
Modify Information
      ↓
Save
      ↓
Update DataGrid
```

The existing Customer data should be loaded into the edit form.

---

# 3. Delete Confirmation

Improve the existing Delete functionality.

Before deleting a customer, the application should ask the user for confirmation.

Expected behavior:

```text
Select Customer
      ↓
Delete
      ↓
Confirmation
      ↓
Yes / No
      ↓
Delete if confirmed
```

The application should not delete a customer accidentally.

---

# 4. Customer Search

Add customer search functionality.

The user should be able to search the customer list.

At minimum, search should support:

- First Name
- Last Name
- Email

Example:

```text
Search: john
```

should display customers matching the search criteria.

The implementation approach is up to the candidate.

---

# 5. Status Filter

Add a customer status filter.

At minimum, support:

```text
All
Active
Inactive
```

Example:

```text
Status: Active
```

should display only active customers.

The search and status filter should work together.

---

# 6. UI / UX Improvements

Improve the existing UI where appropriate.

Candidates may improve:

- Layout
- Spacing
- Typography
- Form organization
- Button placement
- Visual hierarchy
- Empty states
- Error messages
- User feedback

The UI should remain clean, professional, and easy to understand.

---

# Technical Expectations

## MVVM

Maintain the existing MVVM architecture.

Avoid placing business logic directly inside code-behind when it can reasonably be handled by the ViewModel.

For example, prefer:

```text
View
  ↓
Command
  ↓
ViewModel
```

over placing application logic directly inside button click handlers.

---

## Data Binding

Use WPF data binding appropriately.

Avoid unnecessary manual UI updates when binding can be used.

---

## Code Quality

We expect:

- Clean and readable code
- Meaningful naming
- Appropriate separation of responsibilities
- Reasonable class sizes
- Minimal duplication
- Proper use of C# features
- Maintainable architecture

---

## Error Handling

The application should handle invalid user input and unexpected situations gracefully.

Avoid allowing unhandled exceptions to terminate the application during normal user interaction.

---

# What We Are Evaluating

The primary purpose of this assessment is not simply to see whether all requested features can be implemented.

We are also evaluating how you approach the problem.

Key areas include:

| Area | Evaluation |
|---|---|
| C# | Code quality and language fundamentals |
| WPF | Understanding of WPF controls and application structure |
| MVVM | Separation of View, ViewModel, and Model |
| Data Binding | Appropriate use of WPF binding |
| ICommand | Command-based interaction |
| Validation | Handling invalid user input |
| UI/UX | Usability and visual organization |
| Architecture | Maintainability and separation of concerns |
| Custom Controls | Correct use of `CustomButton` |
| Problem Solving | Ability to make reasonable technical decisions |
| Code Quality | Readability, simplicity, and maintainability |

---

# Implementation Freedom

You are free to decide how to implement the missing functionality.

For example, we are **not requiring a specific validation framework, filtering implementation, or architectural pattern beyond the existing MVVM approach**.

You may choose the approach you consider most appropriate.

We are interested in seeing your technical judgment and reasoning.

---

# Restrictions

Please do not:

- Replace the application with another UI framework.
- Convert the project to WinForms.
- Convert the project to WinUI 3.
- Remove the existing MVVM structure.
- Replace `CustomButton` with standard `Button` controls for primary application actions.
- Introduce unnecessary third-party dependencies.
- Rewrite the entire project without a clear reason.

Keep the existing project structure unless there is a reasonable technical reason to improve it.

---

# Deliverables

Please submit the completed project including:

```text
Source Code
README.md
Project Files
```

The project should:

1. Build successfully.
2. Run successfully on Windows.
3. Implement all required assessment functionality.
4. Maintain a clean MVVM structure.
5. Use the provided `CustomButton`.
6. Include any necessary instructions for running the application.

---

# Completion Criteria

The assessment is considered complete when:

- The project builds without errors.
- The application launches successfully.
- Customer data can be displayed.
- Customers can be added.
- Customers can be edited.
- Customers can be deleted with confirmation.
- Customer validation works correctly.
- Customer search works.
- Status filtering works.
- Search and filtering work together.
- The provided `CustomButton` is used appropriately.
- The code remains maintainable and consistent with the existing architecture.

---

# Expected Result

The final application should provide a simple but professional Customer Management experience.

Conceptually:

```text
┌─────────────────────────────────────────────────────────────┐
│ Customer Management                                         │
│                                                             │
│ Search: [____________________]  Status: [All ▼]             │
│                                                             │
│ [ Add Customer ] [ Edit ] [ Delete ]                        │
│                                                             │
│ ┌────┬──────────┬──────────┬─────────────────┬────────────┐ │
│ │ ID │ First    │ Last     │ Email           │ Status     │ │
│ ├────┼──────────┼──────────┼─────────────────┼────────────┤ │
│ │ 1  │ John     │ Smith    │ john@...        │ Active     │ │
│ │ 2  │ Sarah    │ Johnson  │ sarah@...       │ Active     │ │
│ │ 3  │ Michael  │ Brown    │ michael@...     │ Inactive   │ │
│ └────┴──────────┴──────────┴─────────────────┴────────────┘ │
└─────────────────────────────────────────────────────────────┘
```

The exact visual design is left to the candidate.

---

# Final Note

This assessment is intended to be a practical evaluation of your ability to work with an existing WPF codebase.

Please do not focus only on completing the requested features.

We are also interested in:

- How you structure your code
- How you approach MVVM
- How you handle validation
- How you design the user experience
- How you make technical decisions
- How maintainable your implementation is

**Keep the solution simple, clean, and production-oriented.**