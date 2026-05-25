# 🏦 Bank System — Learning C#

Et simpelt konsolbaseret banksystem bygget i C# som en læringsopgave.
Projektet demonstrerer grundlæggende OOP principper, encapsulation og layered architecture.

---

## Hvad programmet kan
- Indsætte penge (Deposit)
- Hæve penge (Withdraw)
- Tjekke saldo (Check Balance)

## Teknologier
- C# / .NET
- Konsol applikation

---

## Principper

### Encapsulation
`balance` er `private` i `BankAccount` — ingen udefra kan ændre den direkte, kun via `Deposit()` og `Withdraw()`.

### Single Responsibility Principle (SRP)
Hver klasse har ét ansvarsområde:
- `BankAccount` — banklogik og validering
- `BankMenu` — UI og brugerinput
- `Program` — starter applikationen

### Separation of Concerns
Logik, UI og opstart er adskilt i hver sin klasse og blander sig ikke i hinandens arbejde.

### Object Oriented Programming (OOP)
Bruger klasser og objekter i stedet for at have alt i én lang `Main` metode.

### Defensive Programming
`decimal.TryParse` og `try/catch` sikrer at programmet ikke crasher ved ugyldigt input.

---

## Arkitektur

Koden følger en simpel **Layered Architecture** med 3 lag:

```mermaid
graph TD
    A["Program.cs — Entry point / opstartslag"]
    B["BankMenu.cs — UI lag (hvad brugeren ser)"]
    C["BankAccount.cs — Business logic lag (regler og data)"]
    A --> B --> C
```

Hvert lag må kun tale med laget under sig:
- `Program` taler med `BankMenu`
- `BankMenu` taler med `BankAccount`
- `BankAccount` taler ikke med nogen — den passer sig selv

---

## Diagrammer

### Domæne Model
```mermaid
classDiagram
    class BankAccount {
        -balance: decimal
    }
    class Transaction {
        +amount: decimal
        +type: string
    }
    BankAccount "1" --> "*" Transaction
```

### Klasse Diagram
```mermaid
classDiagram
    class Program {
        +Main(args: string)
    }
    class BankMenu {
        -bankAccount: BankAccount
        +Start()
        -ShowMenu()
        -Deposit()
        -Withdraw()
    }
    class BankAccount {
        -balance: decimal
        +Deposit(amount: decimal)
        +Withdraw(amount: decimal)
        +GetBalance() decimal
    }
    Program --> BankMenu : creates
    BankMenu --> BankAccount : uses
```

### Use Case Diagram
```mermaid
graph TD
    Bruger((Bruger))
    Bruger --> UC1[Deposit money]
    Bruger --> UC2[Withdraw money]
    Bruger --> UC3[Check Balance]
```

### Sekvens Diagram — Withdraw success
```mermaid
sequenceDiagram
    actor Bruger
    participant BankMenu
    participant BankAccount
    Bruger->>BankMenu: Vælger "2" Withdraw
    BankMenu->>BankAccount: Withdraw(amount)
    BankAccount->>BankAccount: Tjek amount > 0
    BankAccount->>BankAccount: Tjek balance >= amount
    BankAccount->>BankAccount: balance -= amount
    BankAccount-->>BankMenu: OK
    BankMenu-->>Bruger: ✓ Withdrawal completed
```

### Sekvens Diagram — Withdraw fejl
```mermaid
sequenceDiagram
    actor Bruger
    participant BankMenu
    participant BankAccount
    Bruger->>BankMenu: Vælger "2" Withdraw
    BankMenu->>BankAccount: Withdraw(amount)
    BankAccount->>BankAccount: amount > balance
    BankAccount-->>BankMenu: throws InvalidOperationException
    BankMenu-->>Bruger: Fejl: Insufficient funds
```

## Demo
https://github.com/user-attachments/assets/6b9b4574-a4c4-43e7-a56c-e6a83c9fc750

