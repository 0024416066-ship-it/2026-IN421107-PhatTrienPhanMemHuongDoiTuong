# SOLID analysis of the original `ClubManager`

The original implementation was the starter version of `ClubManager`, before it was split into the services and interfaces described below.

| Location | Principle | Violation and consequence |
|---|---|---|
| `CreateClub` | SRP | It validates input, constructs and stores a club, writes a file, and sends a notification. Changes to persistence, validation, logging, or notifications all affect the same method and make it harder to test. |
| `AddMemberToClub` | SRP | It looks up the club, enforces capacity, creates and stores a member, writes a log, and sends two notifications. Business rules and infrastructure effects are coupled. |
| `CreateEvent` | SRP | It creates an event, logs it, finds every member, and sends email output. Event creation cannot be reused without also triggering notification behavior. |
| `CreateClub`, `AddMemberToClub` | OCP | Channel-specific conditionals and hard-coded welcome/Slack output must be edited whenever a notification channel or behavior is added. |
| `CreateClub`, `AddMemberToClub`, `CreateEvent`, `PrintClubReport` | DIP | High-level workflows call `File.AppendAllText` and `Console.WriteLine` directly. They cannot substitute logging or notification implementations for tests or other environments. |
| `ClubManager` fields and `GetAllClubs` | ISP | The class owns club and member collections and exposes a concrete mutable `List<Club>`. Consumers become coupled to its storage representation and receive unrelated responsibilities through one broad class. |
| `PrintClubReport` | OCP / SRP | Report data collection, formatting, console output, and file logging live together. Adding CSV or another output format requires modifying the manager. |
| `CreateEvent` notification loop | OCP / DIP | The workflow knows which members receive emails and how output is performed. New listeners require changes to event creation rather than subscription through an observer interface. |

The refactor moves domain rules to `Club` and `Event`, splits workflows into services, injects small repository/logger/notification interfaces, and uses Factory, Decorator, Strategy, and Observer implementations under `Ch02.Refactor`.
