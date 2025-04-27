
# Online Exam System (Admin Panel & Exam Website)


## Overview
This project is a comprehensive online exam system built with ASP.NET Core, featuring an Admin Panel for exam management and a User Website for taking exams. The system includes secure authentication, a well-structured database, and a user-friendly interface with real-time exam evaluation.



## Table of Contents 

- [Technologies-Used](#Technologies-Used) 

- [Features](#Features) 

- [Database-Schema](#Database-Schema) 

- [Usage](#Usage)

- [Technical-Highlights](#Technical-Highlights)
  
- [Future-Enhancements](#Future-Enhancements)

- [Contact](#contact) 

## Technologies-Used 
- **Microservices**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **ASP.NET Identity**
- **Repository Pattern**
- **MS SQL Server**
- **Bootstrap 5 (Responsive UI)**
- **JavaScript/jQuery (Interactive elements)**
- **Razor Pages (Dynamic content rendering)**
## Features 

- **Admin Panel**:
- 🔐 Secure login with ASP.NET Identity

- 📝 Create, edit, and delete exams

- ❓ Manage questions (add/edit/delete) with 4 choices each

- 👥 User management (manual user addition)

  
- **User Website**:
  - 🔐 Secure login for registered users
  
  - 📚 View available exams
  
  - ✍️ Take exams with multiple-choice questions:
     - Percentage score
  
     - Correct/incorrect breakdown
  
     - Pass/Fail status (60% passing threshold)
  
  - 📊 Instant score calculation and results display
    
  - 🔐 Time-limited exams
    
  ## Database-Schema
  - The system uses a relational database with these key entities:
    Users (ASP.NET Identity)
    ├── Exams
    │   ├── Questions
    │   │   ├── Choices (4 per question)
    │   │   └── CorrectAnswer
    └── ExamResults
        ├── UserScore
        ├── Pass/Fail Status
        └── AnswerDetails
## Usage
  - **Admin Access**:
    - Navigate to /Admin
  
    - Use seeded admin credentials
  
    - Manage exams, questions, and users
  - **User Access**:
    - Register users via Admin Panel

    - Users login at /Account/Login

    - Select and complete exams
  
## Technical-Highlights
    - ✅ Clean architecture with Microservices and Repository Pattern

    - ✅ EF Core migrations for database management
    
    - ✅ AJAX
    
    - ✅ Responsive Bootstrap UI
    
    - ✅ Secure authentication with ASP.NET Identity
    
    - ✅ Comprehensive exam evaluation logic




## Future-Enhancements:
- Question randomization

- Detailed analytics dashboard

- Email notifications

- Multi-role support (Teachers/Students)


## Contact 

If you have any questions or suggestions, feel free to contact us: 

- Email: [Gmail](mailto:mahmoudeldrenyelafandy2000@gmail.com) 

Thank you for visiting 
 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 
