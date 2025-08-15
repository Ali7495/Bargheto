## 🚀 How to Run the Project

### 1️⃣ Clone the repository
### 2️⃣ The Database is SQLite and there is no need for any specific configuration
### 3️⃣ Just apply the migration ( first use command 'Add-Migration' on the terminal for the layer Infrastructure then execute the command 'Update-Database' . it will automatically create the database and tables with the initiall data on the DbContext of the project )
### 4️⃣ Run the project on Visual Studio then on the Swagger first Register users ( Admin and Employee ) then you will be able to use other services by login as any role you want.

## 💡 Assumptions & Decisions Made

### 1️⃣ Clean Architecture, DDD, Repository Pattern, Unit Of Work Pattern ( layers are : Domain, Application, Infrastructure, IoC, Presentation )
### 2️⃣ My Specials: ValueObjects, Extentions, AutoMapper, FluentValidation, Middlewares ( for centrelizing the exception handling ), DependencyInjection
### 3️⃣ Concerns: SOLID, Clean Code, ...
