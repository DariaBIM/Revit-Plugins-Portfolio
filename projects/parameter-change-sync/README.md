# Parameter Change Sync

A controlled tool for transferring and synchronizing parameter values in Revit models.

## Problem

BIM data often needs to be copied between parameters, related elements, or nested families. Manual transfer is time-consuming and can leave the model with missing or inconsistent information.

## Solution

Parameter Change Sync applies configurable source-to-target rules to a selected scope. It validates the operation and provides a report so that changes can be reviewed.

## Key capabilities

- configurable source and target parameters;
- controlled selection and processing scope;
- host and nested-family workflows;
- validation before synchronization;
- reporting of processed elements and results;
- safeguards against unintended operations.

## Business value

- reduces manual data entry;
- improves model-information consistency;
- lowers the risk of transfer errors;
- makes synchronization results traceable.

## Technology

Revit API · C# · .NET · WPF · MVVM

## Status

**In development.** The primary synchronization workflow is implemented and requires final runtime verification.

## Media placeholders

> **Add media here before sharing the final portfolio**

- [ ] **Main screenshot:** synchronization-rule setup
- [ ] **Workflow screenshot:** source, target, and processing scope
- [ ] **Result screenshot:** synchronization report
- [ ] **Demo video/GIF:** parameter-transfer workflow
