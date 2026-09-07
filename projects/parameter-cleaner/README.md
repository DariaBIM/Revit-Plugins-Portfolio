# Parameter Cleaner

A parameter-analysis and controlled-cleanup tool designed to support safer Revit model maintenance.

## Problem

Models and families can accumulate obsolete, empty, duplicated, or unused parameters. Incorrect deletion may affect data, schedules, formulas, or dependent workflows.

## Solution

Parameter Cleaner scans parameter usage, presents findings for review, and applies safety checks before selected parameters can be removed.

## Key capabilities

- parameter inventory and usage analysis;
- shared-parameter review;
- parameter comparison matrix;
- preview before deletion;
- editable-document checks;
- safeguards against empty or unintended selections.

## Business value

- improves model-data clarity and quality;
- reduces the risk of accidental deletion;
- supports safer model maintenance;
- makes cleanup decisions easier to review.

## Technology

Revit API · C# · .NET · WPF · MVVM

## Status

**Testing.** The core analysis interface and safety logic are implemented; final runtime checks are still required.

## Demonstration

Screenshots and a short workflow video will be added soon.
