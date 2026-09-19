# Task List API — CSE5032, Модуль 02

REST API для управления списком задач на ASP.NET Core (без базы данных, хранение — в оперативной памяти).

## Запуск

```bash
cd TaskListApi
dotnet restore
dotnet run
```

После запуска откройте в браузере:

```
http://localhost:5000/swagger
```

## Структура проекта

```
TaskListApi/
├── Controllers/
│   └── TasksController.cs   # CRUD-методы для /api/tasks
├── Models/
│   └── TaskItem.cs          # Модель задачи (Id, Title, Description, IsCompleted)
├── Program.cs                # Точка входа, настройка Swagger
├── appsettings.json
└── TaskListApi.csproj
```

## Методы API

| HTTP   | Маршрут           | Назначение                     | Код при успехе | Код при ошибке |
|--------|-------------------|---------------------------------|-----------------|-----------------|
| GET    | /api/tasks        | Получить все задачи             | 200 OK          | —               |
| GET    | /api/tasks/{id}   | Получить задачу по ID           | 200 OK          | 404 Not Found   |
| POST   | /api/tasks        | Добавить новую задачу           | 201 Created     | 400 Bad Request |
| PUT    | /api/tasks/{id}   | Изменить существующую задачу    | 200 OK          | 400 / 404       |
| DELETE | /api/tasks/{id}   | Удалить задачу                  | 200 OK          | 404 Not Found   |

## Порядок тестирования через Swagger (по заданию лабораторной)

1. POST — создайте минимум 3 задачи (Title обязателен).
2. GET /api/tasks — получите список всех задач.
3. GET /api/tasks/{id} — получите одну задачу по ID.
4. PUT /api/tasks/{id} — измените название или статус (IsCompleted) задачи.
5. DELETE /api/tasks/{id} — удалите одну задачу.
6. Повторите GET /api/tasks и убедитесь, что изменения применились.

Скриншоты каждого шага нужно сделать самостоятельно из Swagger UI при запуске проекта — это подтверждает, что API работает на вашей машине.
