# Beauty-tochka
REST API для управления бизнес-процессами салона красоты на .NET Core с реализацией паттернов Repository и Unit of Work.

# Beauty&Tochka — Салон красоты премиум-класса

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white" alt=".NET 9.0">
  <img src="https://img.shields.io/badge/ASP.NET_Core-Web_API-512BD4?logo=dotnet&logoColor=white" alt="ASP.NET Core">
  <img src="https://img.shields.io/badge/PostgreSQL-16-4169E1?logo=postgresql&logoColor=white" alt="PostgreSQL 16">
  <img src="https://img.shields.io/badge/JWT-Auth-000000?logo=jsonwebtokens&logoColor=white" alt="JWT Auth">
  <img src="https://img.shields.io/badge/Docker-Compose-2496ED?logo=docker&logoColor=white" alt="Docker">
  <img src="https://img.shields.io/badge/Bootstrap-5.3-7952B3?logo=bootstrap&logoColor=white" alt="Bootstrap 5">
  <img src="https://img.shields.io/badge/xUnit-Tests-6A5ACD?logo=xunit&logoColor=white" alt="xUnit Tests">
</p>

<p align="center">
  <b>Полнофункциональное веб-приложение для управления салоном красоты</b><br>
  Каталог услуг, онлайн-запись, профили мастеров, отзывы клиентов и админ-панель
</p>

---

## 📋 Содержание

- [О проекте](#о-проекте)
- [Архитектура](#архитектура)
- [Технологии](#технологии)
- [Функционал](#функционал)
- [Быстрый старт](#быстрый-старт)
- [API Endpoints](#api-endpoints)
- [База данных](#база-данных)
- [Тестирование](#тестирование)
- [Скриншоты](#скриншоты)
- [Структура проекта](#структура-проекта)

---

## 🌸 О проекте

**Beauty&Tochka** — это полнофункциональное веб-приложение для салона красоты премиум-класса, расположенного в Казани. Проект состоит из трёх частей:

| Компонент | Назначение |
|-----------|-----------|
| **BeautyTochka.API** | REST API на ASP.NET Core — бизнес-логика, база данных, аутентификация |
| **Beauty_tochka** | MVC Frontend на ASP.NET Core — пользовательский интерфейс с Razor-страницами |
| **BeautyTochka.Tests** | Модульные тесты на xUnit с использованием Moq |

Приложение демонстрирует современные паттерны разработки: **Repository + Unit of Work**, **JWT-аутентификацию**, **Code-First миграции** и **Docker-контейнеризацию**.

---

## 🏗 Архитектура

```
┌─────────────────────────────────────────────────────────────┐
│                      Клиент (Браузер)                        │
└──────────────────────┬──────────────────────────────────────┘
                       │ HTTP
                       ▼
┌─────────────────────────────────────────────────────────────┐
│  Beauty_tochka (MVC Frontend)                               │
│  • Razor Views + Bootstrap 5                                │
│  • Client-side JS (fetch API)                               │
│  • Session + localStorage для JWT                           │
│  Порт: http://localhost:5133                                │
└──────────────────────┬──────────────────────────────────────┘
                       │ HTTP
                       ▼
┌─────────────────────────────────────────────────────────────┐
│  BeautyTochka.API (REST API)                                │
│  • Controllers + DTOs                                       │
│  • Repository + Unit of Work                                │
│  • JWT Authentication                                       │
│  • Swagger UI                                               │
│  Порт: http://localhost:5003                                │
└──────────────────────┬──────────────────────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────────────────────┐
│  PostgreSQL 16                                              │
│  • EF Core Code-First                                       │
│  • Auto-seed данных при старте                              │
│  Порт: localhost:5432                                       │
└─────────────────────────────────────────────────────────────┘
```

---

## 🛠 Технологии

### Backend (API)
| Технология | Версия | Назначение |
|------------|--------|------------|
| .NET | 9.0 | Runtime и фреймворк |
| ASP.NET Core Web API | 9.0 | REST API |
| Entity Framework Core | 9.0.0 | ORM для работы с БД |
| Npgsql.EFCore.PostgreSQL | 9.0.0 | Провайдер PostgreSQL |
| JWT Bearer | 9.0.0 | Аутентификация по токенам |
| Swashbuckle (Swagger) | 7.0.0 | Документация API |

### Frontend (MVC)
| Технология | Версия | Назначение |
|------------|--------|------------|
| ASP.NET Core MVC | 9.0 | Серверный рендеринг |
| Razor Pages | 9.0 | Шаблонизация |
| Bootstrap | 5.3 | Адаптивная вёрстка |
| jQuery | 3.7 | DOM-манипуляции |

### Инфраструктура
| Технология | Назначение |
|------------|------------|
| Docker + Docker Compose | Контейнеризация |
| PostgreSQL 16 | Реляционная БД |
| Cloudflare Tunnel | Публичный доступ к локальному API |

### Тестирование
| Технология | Версия | Назначение |
|------------|--------|------------|
| xUnit | 2.9.2 | Фреймворк тестирования |
| Moq | 4.20.72 | Мокирование зависимостей |
| Coverlet | 6.0.2 | Покрытие кода |

---

## ✨ Функционал

### 👤 Для клиентов (публичный доступ)
- 🏠 **Главная страница** — баннер, преимущества, карусель мастеров, отзывы, форма записи
- 💅 **Каталог услуг** — 7 категорий: Маникюр, Педикюр, Стрижки, Окрашивание, Ресницы, Брови, Депиляция
- 👩 **Профили мастеров** — фото, специализация, портфолио работ
- ⭐ **Отзывы** — просмотр и добавление отзывов с рейтингом
- 📅 **Онлайн-запись** — без регистрации, по имени и телефону
- 🔍 **Поиск записей** — по номеру телефона
- 📍 **Контакты** — адрес, часы работы, соцсети, Яндекс.Карта

### 🔐 Для пользователей
- Регистрация и вход по email/пароль
- JWT-токен сохраняется в localStorage
- Просмотр профиля (`GET /api/auth/me`)

### 🛡️ Для администраторов
- **CRUD услуг** — создание, редактирование, удаление
- **CRUD мастеров** — управление профилями
- **Управление записями** — просмотр всех, изменение статуса (Новая → Подтверждена/Отклонена)
- **Управление отзывами** — модерация

### 🎨 Дизайн
- Премиальная цветовая палитра: `#2F1C1B` (тёмно-коричневый), `#54140A` (бордовый), `#F8F5F0` (кремовый)
- Адаптивная вёрстка на Bootstrap 5
- Hover-эффекты на карточках
- Карусели Bootstrap для мастеров и отзывов

---

## 🚀 Быстрый старт

### Предварительные требования
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker](https://docs.docker.com/get-docker/) + Docker Compose
- [PostgreSQL](https://www.postgresql.org/download/) (опционально, для локального запуска без Docker)

### Вариант 1: Запуск через Docker Compose (рекомендуется)

```bash
# Клонировать репозиторий
git clone <repository-url>
cd Beauty_tochka

# Запустить PostgreSQL + API
docker-compose up --build

# API будет доступен на http://localhost:5003
# Swagger UI: http://localhost:5003/swagger
```

### Вариант 2: Локальный запуск

**Шаг 1: Запустить PostgreSQL**
```bash
# Через Docker
docker run -d \
  --name beauty-postgres \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=postgres \
  -e POSTGRES_DB=beautytochka \
  -p 5432:5432 \
  postgres:16
```

**Шаг 2: Запустить API**
```bash
cd BeautyTochka.API
dotnet run
# API: http://localhost:5003
# Swagger: http://localhost:5003/swagger
```

**Шаг 3: Запустить Frontend**
```bash
# В новом терминале
cd Beautytochka
dotnet run
# Frontend: http://localhost:5133
```

### 🔑 Демо-данные

При первом запуске база данных автоматически создаётся и заполняется:

| Сущность | Количество |
|----------|-----------|
| Услуги | 35 шт. (7 категорий) |
| Мастера | 6 шт. с фото и портфолио |
| Отзывы | 5 шт. |

**Администратор:**
```
Email: admin@beautytochka.ru
Пароль: Admin123!
```

> Создать админа вручную: `POST /api/auth/seed-admin`

---

## 📡 API Endpoints

Базовый URL: `http://localhost:5003/api`

### Аутентификация
| Метод | Endpoint | Доступ | Описание |
|-------|----------|--------|----------|
| POST | `/auth/register` | Публичный | Регистрация нового пользователя |
| POST | `/auth/login` | Публичный | Вход, возвращает JWT-токен |
| GET | `/auth/me` | Авторизованный | Профиль текущего пользователя |
| POST | `/auth/seed-admin` | Публичный | Создание демо-администратора |

### Услуги
| Метод | Endpoint | Доступ | Описание |
|-------|----------|--------|----------|
| GET | `/services` | Публичный | Список всех услуг |
| GET | `/services/{id}` | Публичный | Услуга по ID |
| GET | `/services/categories/{category}` | Публичный | Услуги по категории |
| POST | `/services` | Admin | Создать услугу |
| PUT | `/services/{id}` | Admin | Обновить услугу |
| DELETE | `/services/{id}` | Admin | Удалить услугу |

### Мастера
| Метод | Endpoint | Доступ | Описание |
|-------|----------|--------|----------|
| GET | `/masters` | Публичный | Список мастеров |
| GET | `/masters/{id}` | Публичный | Мастер по ID |
| POST | `/masters` | Admin | Добавить мастера |
| PUT | `/masters/{id}` | Admin | Обновить мастера |
| DELETE | `/masters/{id}` | Admin | Удалить мастера |

### Записи
| Метод | Endpoint | Доступ | Описание |
|-------|----------|--------|----------|
| GET | `/appointments` | Admin | Все записи |
| GET | `/appointments/search?phone=` | Публичный | Поиск по телефону |
| GET | `/appointments/{id}` | Авторизованный | Запись по ID |
| POST | `/appointments` | Публичный | Создать запись |
| PUT | `/appointments/{id}` | Admin | Обновить запись |
| PATCH | `/appointments/{id}/status` | Admin | Изменить статус |
| DELETE | `/appointments/{id}` | Admin | Удалить запись |

### Отзывы
| Метод | Endpoint | Доступ | Описание |
|-------|----------|--------|----------|
| GET | `/reviews` | Публичный | Все отзывы |
| GET | `/reviews/{id}` | Публичный | Отзыв по ID |
| POST | `/reviews` | Публичный | Добавить отзыв |
| PUT | `/reviews/{id}` | Публичный | Обновить отзыв |
| DELETE | `/reviews/{id}` | Публичный | Удалить отзыв |

### Swagger UI
```
http://localhost:5003/swagger
```

---

## 🗄 База данных

### Схема

```
┌─────────────┐     ┌─────────────┐     ┌─────────────┐
│   Users     │     │  Services   │     │   Masters   │
├─────────────┤     ├─────────────┤     ├─────────────┤
│ Id (PK)     │     │ Id (PK)     │     │ Id (PK)     │
│ FullName    │     │ Name        │     │ FullName    │
│ Email       │     │ Description │     │ Position    │
│ PasswordHash│     │ Category    │     │ Description │
│ Role        │     │ Duration    │     │ Email       │
└─────────────┘     │ Price       │     │ PhoneNumber │
                    └─────────────┘     │ PhotoUrl    │
                                        │ WorkPhotos  │
                                        └─────────────┘
┌─────────────┐     ┌─────────────┐
│Appointments │     │   Reviews   │
├─────────────┤     ├─────────────┤
│ Id (PK)     │     │ Id (PK)     │
│ ClientName  │     │ AuthorName  │
│ PhoneNumber │     │ Text        │
│ ServiceName │     │ Rating      │
│ MasterName  │     │ CreatedAt   │
│ Comment     │     └─────────────┘
│ AppointmentDate     
│ Status      │     UserRole: User | Admin
└─────────────┘     AppointmentStatus: New | Confirmed | Rejected
```

### Seed-данные
База автоматически заполняется при старте через `EnsureCreated()`:
- **35 услуг** в 7 категориях
- **6 мастеров** с фотографиями и примерами работ
- **5 отзывов** с рейтингом 4-5 звёзд

---

## 🧪 Тестирование

```bash
cd BeautyTochka.Tests
dotnet test
```

### Покрытие
| Тест-класс | Тесты | Описание |
|------------|-------|----------|
| `AuthControllerTests` | 4 теста | Регистрация, вход, валидация credentials |
| `ServicesControllerTests` | 5 теста | CRUD операции с услугами |

**Всего: 9 тестов**

### Подход
- **Moq** для мокирования `IUnitOfWork` и `IRepository<T>`
- **InMemory EF Core** подключён для интеграционных тестов
- SHA256 хеширование паролей проверяется в тестах

---

## 📁 Структура проекта

```
Beauty_tochka/
├── BeautyTochka.API/                 # REST API
│   ├── Controllers/                  # API контроллеры (5 шт.)
│   │   ├── AuthController.cs
│   │   ├── ServicesController.cs
│   │   ├── MastersController.cs
│   │   ├── AppointmentsController.cs
│   │   └── ReviewsController.cs
│   ├── Models/                       # EF Core сущности
│   │   ├── User.cs
│   │   ├── Service.cs
│   │   ├── Master.cs
│   │   ├── Appointment.cs
│   │   └── Review.cs
│   ├── DTOs/                         # Data Transfer Objects
│   ├── Data/                         # DbContext + Seed
│   │   └── ApplicationDbContext.cs
│   ├── Repositories/                 # Repository + Unit of Work
│   │   ├── IRepository.cs
│   │   ├── Repository.cs
│   │   ├── IUnitOfWork.cs
│   │   └── UnitOfWork.cs
│   ├── Services/                     # JWT сервис
│   │   └── JwtService.cs
│   ├── Dockerfile                    # Мультистейдж сборка
│   ├── appsettings.json              # Конфигурация
│   └── Program.cs                    # Точка входа
│
├── Beautytochka/                     # MVC Frontend
│   ├── Controllers/
│   │   └── HomeController.cs         # 12 страниц
│   ├── Models/
│   ├── Views/
│   │   ├── Home/                     # 11 Razor-страниц
│   │   │   ├── Index.cshtml          # Главная
│   │   │   ├── Services.cshtml       # Каталог услуг
│   │   │   ├── ServiceDetails.cshtml # Детали категории
│   │   │   ├── Masters.cshtml        # Мастера
│   │   │   ├── Reviews.cshtml        # Отзывы
│   │   │   ├── Contacts.cshtml       # Контакты
│   │   │   ├── Login.cshtml          # Вход
│   │   │   ├── Register.cshtml       # Регистрация
│   │   │   ├── Cookies.cshtml        # Мои записи
│   │   │   ├── Record.cshtml         # Редирект на запись
│   │   │   └── Privacy.cshtml        # Политика
│   │   └── Shared/
│   │       ├── _Layout.cshtml        # Главный шаблон
│   │       └── Error.cshtml
│   ├── wwwroot/
│   │   ├── css/site.css              # Кастомные стили
│   │   └── lib/                      # Bootstrap, jQuery
│   ├── appsettings.json
│   └── Program.cs
│
├── BeautyTochka.Tests/               # Модульные тесты
│   ├── AuthControllerTests.cs
│   ├── ServicesControllerTests.cs
│   └── BeautyTochka.Tests.csproj
│
├── docker-compose.yml                # PostgreSQL + API
├── host-api.sh                       # Cloudflare Tunnel
├── Beautytochka.sln                  # Solution файл
└── .gitignore                        # Стандартный .NET .gitignore
```

### Статистика кода
| Компонент | Файлы | Строки |
|-----------|-------|--------|
| Backend C# | 22 | ~1,200 |
| Frontend C# | 4 | ~160 |
| Razor Views | 13 | ~1,270 |
| CSS | 2 | ~190 |
| Тесты | 2 | ~214 |
| **Итого** | **~50** | **~3,200** |

---

## 🔐 Безопасность

- **JWT Bearer** токены с HMAC-SHA256 подписью
- **SHA256** хеширование паролей
- **Role-based** авторизация (`User` / `Admin`)
- **CORS** настроен для локальной разработки
- Токен хранится в `localStorage` (для демо-целей)

### Конфигурация JWT (appsettings.json)
```json
{
  "Jwt": {
    "Secret": "YourSuperSecretKey123!@#BeautyTochka2026",
    "Issuer": "BeautyTochka",
    "Audience": "BeautyTochkaClient",
    "ExpiryMinutes": "120"
  }
}
```

---

## 🐳 Docker

### Сервисы
| Сервис | Образ | Порт | Описание |
|--------|-------|------|----------|
| `postgres` | postgres:16 | 5432 | База данных |
| `api` | Сборка из Dockerfile | 5003 → 8080 | REST API |

### Сборка и запуск
```bash
docker-compose up --build -d    # Фоновый режим
docker-compose logs -f api      # Логи API
docker-compose down             # Остановка
```

---

## 🌐 Публичный доступ

Для демонстрации API через интернет:

```bash
# Требуется установленный cloudflared
./host-api.sh
# Или с кастомным портом:
./host-api.sh 5003
```

---

## 📸 Скриншоты

> *Скриншоты будут добавлены после развёртывания*

### Страницы приложения:
1. **Главная** — баннер, преимущества, мастера, отзывы, форма записи
2. **Услуги** — сетка категорий с hover-эффектами
3. **Детали услуги** — список конкретных процедур с ценами
4. **Мастера** — карточки с фото-каруселями и портфолио
5. **Отзывы** — карточки отзывов + форма добавления
6. **Контакты** — адрес, телефон, часы, соцсети, карта
7. **Вход/Регистрация** — формы аутентификации

---

