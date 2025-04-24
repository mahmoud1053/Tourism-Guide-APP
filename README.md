# 🧭 Tourism Guide App

This is a full-stack Tourism Guide application built with **ASP.NET Core** for the backend and **HTML, CSS, JavaScript, Bootstrap** for the frontend. The app allows users to register, browse tourism programs, and view details about program places.

## 🛠 Technologies Used

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

### Frontend
- HTML5 / CSS3
- Bootstrap 5
- Vanilla JavaScript

## 📦 Features

- User registration and management
- Program listing with details
- View places in each tourism program
- RESTful API (CRUD) for Users, Programs, and Program Places
- CORS enabled for frontend integration

## 📦 Project Structure
```
TourismGuideApp/
├── Backend/            <-- your .NET project here
│   ├── WebApplication2/
│   └── WebApplication2.sln
├── Frontend/           <-- your HTML, CSS, JS, Bootstrap here
│   ├── index.html
│   ├── register.html
│   ├── programs.html
│   └── css/, js/ etc.
└── README.md     
```
---
## 🚀 Getting Started

🧩 Backend (ASP.NET Core)

### Clone the repo and navigate to the backend folder:
```
 cd WebApplication2
```
### Add your connection string Update appsettings.json under:
```
"ConnectionStrings": {
  "DefaultConnections": "your-sql-connection-string"
}
```
### Apply database migrations:

```
dotnet ef database update
```

### Run the backend server:
```
dotnet run
```

### Your backend will be live at:
```
👉 http://localhost:5031
```
---
🌐 Frontend

Open the Frontend folder.

Launch index.html or any page using a local server like Live Server or:
```
npm install -g http-server
http-server .
```
---
## Ensure the backend is running at http://localhost:5031 for the frontend to fetch data properly.
---
## 📃 License
📌 This project is open-source and free to use for learning and development.

---

## 🧑‍💻 Developer

**Mahmoud Ahmed Alam Eldin**  

📎 LinkedIn: [Mahmoud Ahmed Alam](www.linkedin.com/in/mahmoud-ahmed-alam-8346a6233)
