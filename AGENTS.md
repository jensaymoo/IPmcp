# AGENTS.md

Этот файл содержит инструкции для AI агентов при работе с кодом в этом репозитории.

Тестовые проекты и линтеры не настроены.

## Архитектура

Это **MCP-сервер (Model Context Protocol)** для управления **IdeaPlatform** сущностями и их полями, с хранением данных в PostgreSQL.

**Решение из трёх проектов (IPmcp.sln):**

- **IPmcp.Tools** — Точка входа. Запускает MCP-сервер через stdio. Содержит 10 классов инструментов (CRUD для сущностей и полей), обнаруживаемых через `WithToolsFromAssembly()`. Каждый инструмент — статический класс с единственным методом `Execute`, помеченным атрибутом `[McpServerTool]`.
- **IPmcp.App** — Слой сервисов. `IEntityService`/`EntityService` и `IFieldService`/`FieldService` внедряются в инструменты через DI.
- **IPmcp.Database** — Слой доступа к данным. `AppDataConnection` (наследник `DataConnection` из PostgreSQL клиента) предоставляет `ITable<Entity>` и `ITable<Field>`, сопоставленные с таблицами PostgreSQL `system.ipentitytype` и `system.ipentityfield`.

**Стек:** .NET 10.0, ModelContextProtocol v1.2.0, PostgreSQL, Microsoft.Extensions.Hosting для DI.

## Зависимости

| Пакет | Версия | Где используется |
|-------|--------|-----------------|
| `ModelContextProtocol` | 1.2.0 | IPmcp.Tools |
| `Microsoft.Extensions.Hosting` | 10.0.7 | IPmcp.Tools |
| `linq2db` | 5.4.1.9 | IPmcp.Database, IPmcp.Tools (транзитивно) |
| `linq2db.AspNet` | 5.4.1.9 | IPmcp.Tools |

Свойства проектов: `net10.0`, `ImplicitUsings: enable`, `Nullable: enable`.

## Code Style

**Именование:**
- Классы / интерфейсы — `PascalCase`, интерфейсы с префиксом `I`
- Методы / параметры / локальные переменные — `camelCase`
- Названия инструментов — `snake_case` (`create_entity`, `read_field`)
- Пространства имён — `IPmcp.{ProjectName}.{Layer}.{Category}`

**Организация файлов:**
- Один класс на файл
- Интерфейс и реализация в отдельных файлах
- Инструменты сгруппированы: `Tools/Entity/` и `Tools/Field/`
- Сервисы сгруппированы: `Services/Entities/` и `Services/Fields/`
- Модели в `Models/`

**Внедрение зависимостей:**
- Инструменты — параметр метода `Execute` (интерфейс)
- Сервисы — C# 12 primary constructor: `public class EntityService(AppDataConnection db)`
- Регистрация в DI — `AddScoped`

**Языковые фичи:** C# 12 primary constructors, expression-bodied members, implicit usings, nullable reference types, top-level statements.

## Инструменты

Инструменты разделены на две группы: **Entity** (управление сущностями/таблицами) и **Field** (управление полями/столбцами).

### Entity — управление сущностями (таблицами)

Работают с таблицей `system.ipentitytype`. Внедряемый сервис: `IEntityService`.

| Инструмент | Описание |
|-----------|----------|
| `create_entity` | Создать новую IdeaPlatform сущность (таблицу) |
| `read_entity` | Прочитать одну сущность по ID |
| `update_entity` | Обновить существующую сущность |
| `delete_entity` | Удалить сущность по ID |
| `list_entity` | Список всех сущностей |

### Field — управление полями (столбцами)

Работают с таблицей `system.ipentityfield`. Внедряемый сервис: `IFieldService`.

| Инструмент | Описание |
|-----------|----------|
| `create_field` | Создать новое поле (столбец) для сущности |
| `read_field` | Прочитать одно поле по ID |
| `update_field` | Обновить существующее поле |
| `delete_field` | Удалить поле по ID |
| `list_field` | Список всех полей |

## Сборка и запуск

```bash
# Сборка
dotnet build

# Запуск (требуется строка подключения к PostgreSQL)
dotnet run --project IPmcp.Tools -- -database "<строка_подключения>"
```
