# 📚 Library Borrowing System

## 📌 Overview

The Library Borrowing System is a simple console-based application that tracks
books, members, and borrowing history.  
Its primary focus is **decision-making across collections** using C# collections
and LINQ, while enforcing clear business rules.

---

## 🎯 Project Goals

The system demonstrates:

- Intentional use of `List<T>` and `Dictionary<TKey, TValue>`
- LINQ for filtering collections and asking business questions
- Business rules that prevent invalid borrowing actions
- Runtime decisions made across multiple collections
- Clear separation between orchestration, business logic, and domain models

---

## ⚙️ What the System Does

Users can:

- Borrow a book
- View a member’s borrowing history

The system ensures that:

- A book cannot be borrowed if it is already borrowed
- A member cannot exceed the maximum allowed number of borrowed books
- Borrow requests must reference existing books and members
- Invalid borrow attempts are rejected early (fail-fast)

---

## 🧠 Architecture Overview

The project is structured into three clear layers:

### 🟦 Domain Models
Represent core concepts without business logic across collections.

- `Book`
- `Member`
- `BorrowRecord`

### 🟨 Business Logic
Encapsulates rules and decision-making across collections.

- `BorrowingService`
  - Uses `List<T>` and `Dictionary<TKey, TValue>`
  - Uses LINQ (`Any`, `Where`, `Count`)
  - Enforces borrowing rules
  - Tracks active borrows and history

### 🟩 Application Orchestration
Handles user interaction only.

- `Program.cs`
  - Displays menus
  - Captures user input
  - Delegates decisions to `BorrowingService`

**Program.cs acts as a thin application orchestration layer.**

---
```
## 🗂 Project Structure

LibraryBorrowingSystem/
│
├── Program.cs
│
├── Domain/
│ ├── Book.cs
│ ├── Member.cs
│ └── BorrowRecord.cs
│
├── Services/
│ └── BorrowingService.cs
│
└── README.md
```

---

## 🔍 Use of Collections & LINQ

- `List<Book>` – stores available books
- `List<Member>` – stores registered members
- `List<BorrowRecord>` – stores borrowing history
- `Dictionary<int, BorrowRecord>` – tracks currently borrowed books for fast lookup

LINQ is used to:
- Filter borrowing history
- Check availability (`Any`)
- Enforce borrowing limits (`Count`)
- Query member-specific data (`Where`)

---

## 🚀 Running the Project

### Prerequisites
- .NET SDK
- Any C# compatible IDE or editor

### Steps
1. Open the project
2. Build the solution
3. Run the application
4. Interact with the console menu

---

## 📚 Scope & Limitations

### In Scope
- Console-based interaction
- In-memory collections
- Business rule enforcement
- LINQ-based decision-making

### Out of Scope
- Persistent storage (databases)
- User authentication
- Book returns
- Graphical user interfaces

---

## ✍️ Author

TJ Gaba