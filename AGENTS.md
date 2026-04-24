# AGENTS.md

Инструкции для AI-агентов при работе с этим репозиторием.

Тестовые проекты и линтеры не настроены.

## Архитектура

**MCP-сервер (Model Context Protocol)** для управления сущностями и полями IdeaPlatform. Данные хранятся в PostgreSQL.

**Решение (IPmcp.sln) — три проекта:**

- **IPmcp.Tools** — точка входа. Запускает MCP-сервер через stdio. Содержит 10 классов инструментов (CRUD для сущностей и полей), регистрируемых через `WithToolsFromAssembly()`. Каждый инструмент — статический класс с атрибутом `[McpServerToolType]` и единственным методом `Execute`, помеченным `[McpServerTool]`.
- **IPmcp.App** — слой сервисов. Содержит `IEntityService`/`EntityService` и `IFieldService`/`FieldService`. Сервисы и фильтры внедряются в инструменты через параметры метода `Execute`.
- **IPmcp.Database** — слой доступа к данным. `AppDataConnection` (наследник `DataConnection` из linq2db) предоставляет `ITable<Entity>` и `ITable<Field>`, сопоставленные с таблицами `system.ipentitytype` и `system.ipentityfield`.

**Стек:** .NET 10.0, ModelContextProtocol 1.2.0, linq2db 5.4.1.9, PostgreSQL, Microsoft.Extensions.Hosting.

## Обработка исключений

**`IPmcp.App.Exceptions.DatabaseException`** — бизнес-исключение при сбое соединения с БД.
- Создаётся в сервисах при перехвате `LinqToDB.LinqToDBException`.
- В инструментах перехватывается и оборачивается в `McpException`.

## Зависимости

| Пакет | Версия | Проект |
|-------|--------|--------|
| `ModelContextProtocol` | 1.2.0 | IPmcp.Tools |
| `Microsoft.Extensions.Hosting` | 10.0.7 | IPmcp.Tools |
| `linq2db.AspNet` | 5.4.1.9 | IPmcp.Tools |
| `linq2db` | 5.4.1.9 | IPmcp.Database |

Все проекты: `net10.0`, `ImplicitUsings: enable`, `Nullable: enable`.

## Code Style

**Именование:**
- Классы / интерфейсы — `PascalCase`, интерфейсы с префиксом `I`
- Методы / параметры / локальные переменные — `camelCase`
- Названия инструментов MCP — `snake_case` (`create_entity`, `read_field`)
- Пространства имён — `IPmcp.{Project}.{Layer}.{Category}`

**Организация файлов:**
- Один тип на файл
- Интерфейс и реализация в отдельных файлах
- Инструменты: `Tools/Entity/` и `Tools/Field/`
- Сервисы: `Services/Entities/` и `Services/Fields/`
- Модели и фильтры каждой группы: `Services/{Group}/Models/`

**Типы моделей:**
- DTO-модели (например, `EntityModel`) — `class` с `required` свойствами и `init`-сеттерами
- Фильтры (например, `ListEntityFilter`) — `record` тип с инициализацией параметров в аргументах конструктора

**Внедрение зависимостей:**
- Инструменты получают сервис и фильтр как параметры метода `Execute` — MCP-фреймворк разрешает их автоматически
- Сервисы используют C# 12 primary constructors: `public class EntityService(AppDataConnection db)`
- Регистрация в DI — `AddScoped`

**Языковые возможности:** C# 12 primary constructors, expression-bodied members, implicit usings, nullable reference types, top-level statements.

## Инструменты

Инструменты разделены на две группы: **Entity** (сущности/таблицы) и **Field** (поля/столбцы).

> **Статус реализации:** реализован только `list_entity`. Остальные 9 инструментов являются заглушками и бросают `NotImplementedException`.

### Entity — управление сущностями

Таблица БД: `system.ipentitytype`. Сервис: `IEntityService`.

| Инструмент | Описание | Статус |
|-----------|----------|--------|
| `list_entity` | Список всех сущностей | Реализован |
| `read_entity` | Прочитать сущность по ID | Заглушка |
| `create_entity` | Создать новую сущность | Заглушка |
| `update_entity` | Обновить существующую сущность | Заглушка |
| `delete_entity` | Удалить сущность по ID | Заглушка |

`IEntityService` содержит: `ListEntities(ListEntityFilter filter)`.

`EntityModel` содержит поля: `EntityTypeId`, `ShortName`, `TableName`, `DisplayName`, `IsActive`, `IsAbstract`, `BaseEntityTypeId`, `WorkspaceId`.

### Field — управление полями

Таблица БД: `system.ipentityfield`. Сервис: `IFieldService`.

| Инструмент | Описание | Статус |
|-----------|----------|--------|
| `list_field` | Список всех полей | Заглушка |
| `read_field` | Прочитать поле по ID | Заглушка |
| `create_field` | Создать новое поле | Заглушка |
| `update_field` | Обновить существующее поле | Заглушка |
| `delete_field` | Удалить поле по ID | Заглушка |

`IFieldService` пока не содержит методов — интерфейс нужно расширять по мере реализации.

## Сборка и запуск

```bash
# Сборка
dotnet build

# Запуск (требуется строка подключения к PostgreSQL)
dotnet run --project IPmcp.Tools -- -database "<строка_подключения>"
```
