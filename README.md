# CalendarPetProject

**CalendarPetProject** is a modern, extensible, and user-friendly web-based calendar application built with ASP.NET Core (C#), Entity Framework Core, and a responsive HTML5/CSS3/JavaScript front-end. Designed for both individual and team productivity, this project aims to provide a robust platform for scheduling, event management, and daily planning.

---

## ✨ Key Features

- **Intuitive Calendar Interface:**  
  Interactive monthly, weekly, and daily views make it easy to browse, add, and manage events.

- **Event & Task Management:**  
  Quickly create, edit, and delete events with titles and descriptions. Organize your days with task containers for each date.

- **User Authentication & Identity:**  
  Secure login and registration using ASP.NET Core Identity. User data and events are protected.

- **Responsive UI:**  
  Clean, mobile-first design using Bootstrap and custom CSS. Enjoy a consistent experience on desktops, tablets, and phones.

- **Modular Architecture:**  
  Clear separation of business logic, data models, and presentation (Razor Views). Easy to extend or customize.

- **Accessibility:**  
  Semantic HTML, ARIA roles, and keyboard navigation for inclusive access.

- **Extensible Data Layer:**  
  Powered by Entity Framework Core, ready for SQL Server or in-memory testing.

- **Customizable Theming:**  
  Easily adjust CSS or extend with your own themes.

- **Privacy & Contact Pages:**  
  Built-in privacy policy and support contact info.

---

## 🚀 Quick Start

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- (Optional) SQL Server for production database

### Installation

1. **Clone the repository**
    ```bash
    git clone https://github.com/vampire7432804732985734985743948/CalendarPetProject.git
    cd CalendarPetProject
    ```

2. **Restore dependencies**
    ```bash
    dotnet restore
    ```

3. **Configure the database**
    - Edit `appsettings.json` if you want to change the connection string.
    - By default, uses SQL Server via Entity Framework Core.

4. **Apply migrations**
    ```bash
    dotnet ef database update
    ```

5. **Run the application**
    ```bash
    dotnet run
    ```

6. **Open in your browser**
    - By default: http://localhost:5000

---

## 🗂️ Project Structure

```
CalendarPetProject/
├── BusinessLogic/Calendar/   # Core scheduling/event logic
├── Views/                    # Razor views (UI pages)
├── wwwroot/                  # Static assets (CSS, JS, images)
├── CalendarPetProject.csproj # Project file
└── ...
```

- **BusinessLogic/Calendar:**  
  - `EventContainer.cs`: Handles event/task titles and descriptions.
  - `DayCantainer.cs`, `DaysInMonth.cs`: Encapsulate daily/monthly structures.

- **Views:**  
  - Shared layouts and partials for consistent navigation and page structure.
  - Home, Privacy, and contact support views.

- **wwwroot:**  
  - Bootstrap, custom CSS (`site.css`), images, and JavaScript.

---

## 👥 Contributing

Contributions are welcome!  
If you have ideas for new features, improvements, or bugfixes:

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/my-new-feature`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature/my-new-feature`)
5. Open a Pull Request

Please review our [LICENSE](./LICENSE) before contributing.

---

## 📄 License

This project is licensed under the [Creative Commons Attribution-NonCommercial 4.0 International License (CC BY-NC 4.0)](https://creativecommons.org/licenses/by-nc/4.0/).  
**Commercial use is strictly prohibited.**

See the [LICENSE](./LICENSE) file for details.

---
![image alt](https://github.com/vampire7432804732985734985743948/CalendarPetProject/blob/master/CalendarPetProject/wwwroot/Resources/Images/ApplicationScreenshotsReadMe/Screenshot%20(1958).png)
![image alt](https://github.com/vampire7432804732985734985743948/CalendarPetProject/blob/master/CalendarPetProject/wwwroot/Resources/Images/ApplicationScreenshotsReadMe/Screenshot%20(1959).png)
![image alt](https://github.com/vampire7432804732985734985743948/CalendarPetProject/blob/master/CalendarPetProject/wwwroot/Resources/Images/ApplicationScreenshotsReadMe/Screenshot%20(1960).png)
![image alt](https://github.com/vampire7432804732985734985743948/CalendarPetProject/blob/master/CalendarPetProject/wwwroot/Resources/Images/ApplicationScreenshotsReadMe/Screenshot%20(1961).png)
![image alt](https://github.com/vampire7432804732985734985743948/CalendarPetProject/blob/master/CalendarPetProject/wwwroot/Resources/Images/ApplicationScreenshotsReadMe/Screenshot%20(1962).png)
![image alt](https://github.com/vampire7432804732985734985743948/CalendarPetProject/blob/master/CalendarPetProject/wwwroot/Resources/Images/ApplicationScreenshotsReadMe/Screenshot%20(1963).png)
![image alt](https://github.com/vampire7432804732985734985743948/CalendarPetProject/blob/master/CalendarPetProject/wwwroot/Resources/Images/ApplicationScreenshotsReadMe/Screenshot%20(1964).png)
## 💬 Contact & Support

- Privacy Policy: see the Privacy page in the app
![image alt](https://github.com/vampire7432804732985734985743948/CalendarPetProject/blob/master/CalendarPetProject/wwwroot/Resources/Images/ApplicationScreenshotsReadMe/Screenshot%20(1965).png)
- Contact Support: use the "Contact Support" link in the footer
![image alt](https://github.com/vampire7432804732985734985743948/CalendarPetProject/blob/master/CalendarPetProject/wwwroot/Resources/Images/ApplicationScreenshotsReadMe/Screenshot%20(1966).png)
![image alt](https://github.com/vampire7432804732985734985743948/CalendarPetProject/blob/master/CalendarPetProject/wwwroot/Resources/Images/ApplicationScreenshotsReadMe/Screenshot%20(1967).png)
- Email: MiraiDays@gmail.com

---

## 🏗️ Roadmap / Future Ideas

- Calendar sharing & team collaboration
- Event reminders & notifications
- Recurring events
- iCal export/import
- Color-coded categories
- REST API for integrations

---

## 🙏 Acknowledgements

- [Bootstrap](https://getbootstrap.com/)
- [jQuery Validation (MIT License)](https://github.com/jquery-validation/jquery-validation)
- [Google Fonts - Dancing Script](https://fonts.google.com/specimen/Dancing+Script)
- [ASP.NET Core Team](https://github.com/dotnet/aspnetcore)

---

> _Built with passion for productivity and learning. Open source, non-commercial use only._
