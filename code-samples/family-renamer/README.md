# Family Renamer — Representative Code Sample

This folder contains a small, review-oriented extract from **Family Renamer V02**.

It demonstrates:

- a Revit `IExternalCommand` entry point;
- separation between the data model, validation, and Revit transaction logic;
- MVVM-compatible change notification;
- validation for empty, unchanged, invalid, existing, and duplicated names;
- controlled batch renaming inside a Revit transaction.

## Included files

| File | Purpose |
|---|---|
| [Main.cs](Main.cs) | Revit external-command entry point and view initialisation |
| [FamilyRenameRow.cs](Models/FamilyRenameRow.cs) | UI-facing data model with property-change notification |
| [FamilyRenameValidationService.cs](Services/FamilyRenameValidationService.cs) | Pre-flight validation of proposed family names |
| [FamilyRenameService.cs](Services/FamilyRenameService.cs) | Controlled rename operation within a Revit transaction |

## Scope

This is a representative architectural sample, not a complete or runnable distribution. The full application also includes WPF views, a larger ViewModel, filtering, CSV/XLSX workflows, mapping tools, undo operations, and additional services.

The complete source remains private while the project is being refined.
