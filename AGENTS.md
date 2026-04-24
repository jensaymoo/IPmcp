# AGENTS.md

Instructions for AI agents working with this repository.

> **Note:** Test projects and linters are not configured.

## Table of Contents

1. [Overview](#overview)
2. [Architecture](#architecture)
3. [Dependencies](#dependencies)
4. [Code Style](#code-style)
5. [Key Design Principles](#key-design-principles)
6. [Exception Handling](#exception-handling)
7. [Tools](#tools)
8. [Build and Run](#build-and-run)

## Overview

**IPmcp** is an MCP server (Model Context Protocol) for managing IdeaPlatform entities and fields. Data is stored in PostgreSQL.

**Stack:** .NET 10.0, ModelContextProtocol 1.2.0, linq2db 5.4.1.9, PostgreSQL, Microsoft.Extensions.Hosting.

## Architecture

The solution (`IPmcp.sln`) contains three projects organized in a layered architecture:

| Project | Layer | Responsibility | Contents |
|---------|-------|----------------|----------|
| **IPmcp.Tools** | Presentation | Application entry point and MCP tool definitions. | Tool classes grouped under `Tools/{Group}/`. |
| **IPmcp.App** | Service | Business logic and domain contracts. | Services, models, and filters grouped under `Services/{Group}/`. |
| **IPmcp.Database** | Data access | Database connection and table mappings. | `AppDataConnection` and entity mapping types. |

## Dependencies

### Packages

| Package | Version | Project |
|---------|---------|---------|
| `ModelContextProtocol` | 1.2.0 | IPmcp.Tools |
| `Microsoft.Extensions.Hosting` | 10.0.7 | IPmcp.Tools |
| `linq2db.AspNet` | 5.4.1.9 | IPmcp.Tools |
| `linq2db` | 5.4.1.9 | IPmcp.Database |

### Common Project Settings

All projects target `net10.0` with `ImplicitUsings: enable` and `Nullable: enable`.

## Code Style

### Naming

- Classes, interfaces, and methods — `PascalCase`; interfaces are prefixed with `I`.
- Parameters and local variables — `camelCase`.
- MCP tool names — `snake_case` (e.g., `create_entity`, `read_field`).
- Namespaces — `IPmcp.{Project}.{Layer}.{Category}`.

### File Organization

- One type per file.
- Interface and implementation live in separate files.
- Tools: `Tools/Entity/` and `Tools/Field/`.
- Services: `Services/Entities/` and `Services/Fields/`.
- Models and filters for each group: `Services/{Group}/Models/`.

### Model Types

- **DTO models** (e.g., `EntityModel`) — `class` with `required` properties and `init` setters.
- **Filters** (e.g., `ListEntityFilter`) — `record` type with parameters initialized via constructor arguments.

### Dependency Injection

- Tools receive the service and filter as parameters of the `Execute` method — the MCP framework resolves them automatically.
- Services use C# 12 primary constructors: `public class EntityService(AppDataConnection db)`.
- DI registration uses `AddScoped`.

### C# Language Features

Primary constructors (C# 12), expression-bodied members, implicit usings, nullable reference types, top-level statements.

### Message Language

All informational and system messages (exception texts, logs, error messages) are written in **English**.

## Key Design Principles

When developing or reviewing code, verify adherence to these key design principles:

- **DRY** — Avoid code duplication by moving common logic into helper methods or helper classes.
- **Single Responsibility** — Each class should have one clear responsibility.
- **Encapsulation** — Keep implementation details private and expose only necessary public APIs.
- **Strong Typing** — Use strong typing to ensure that code is self-documenting and to catch errors at compile time.

## Exception Handling

`IPmcp.App.Exceptions.DatabaseException` is a business exception raised on a database connection failure.

- **Thrown in services** when `LinqToDB.LinqToDBException` or `System.Data.Common.DbException` is caught.
- **Caught in tools** and wrapped in `McpException` before being surfaced to the MCP client.

## Tools

Tools are split into two groups: **Entity** (entities/tables) and **Field** (fields/columns).

> **Implementation status:** only `list_entity` is implemented. The remaining 9 tools are stubs and throw `NotImplementedException`.

### Entity — Entity Management

- **Database table:** `system.ipentitytype`
- **Service:** `IEntityService`
- **Implemented methods:** `ListEntities(ListEntityFilter filter)`
- **`EntityModel` fields:** `EntityTypeId`, `ShortName`, `TableName`, `DisplayName`, `IsActive`, `IsAbstract`, `BaseEntityTypeId`, `WorkspaceId`.

| Tool | Description | Status |
|------|-------------|--------|
| `list_entity` | List all entities | Implemented |
| `read_entity` | Read an entity by ID | Stub |
| `create_entity` | Create a new entity | Stub |
| `update_entity` | Update an existing entity | Stub |
| `delete_entity` | Delete an entity by ID | Stub |

### Field — Field Management

- **Database table:** `system.ipentityfield`
- **Service:** `IFieldService`
- **Implemented methods:** none — the interface should be extended as implementation progresses.

| Tool | Description | Status |
|------|-------------|--------|
| `list_field` | List all fields | Stub |
| `read_field` | Read a field by ID | Stub |
| `create_field` | Create a new field | Stub |
| `update_field` | Update an existing field | Stub |
| `delete_field` | Delete a field by ID | Stub |

## Build and Run

A PostgreSQL connection string is required to run the server.

```bash
# Build
dotnet build

# Run
dotnet run --project IPmcp.Tools -- -database "<connection_string>"
```
