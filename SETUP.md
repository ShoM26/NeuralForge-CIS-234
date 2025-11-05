# 🧠 Neural Forge — Development Environment Setup Guide

Welcome to the **Neural Forge** project!  
This document walks you through setting up the local development environment to run the C# backend, MySQL databases, and Python mock data generator.
---
## 🧰 Prerequisites
Before you begin, ensure the following tools are installed on your system:

| Tool | Version | Purpose | Install Link |
|------|----------|----------|---------------|
| **Git** | Latest | Clone the repository | [https://git-scm.com/downloads](https://git-scm.com/downloads) |
| **.NET SDK** | 9.0+ | Run the backend | [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download) |
| **MySQL Server** | 8.0+ | Host the databases | [https://dev.mysql.com/downloads/](https://dev.mysql.com/downloads/) |
| **Python** | 3.10+ | Generate mock data | [https://www.python.org/downloads/](https://www.python.org/downloads/) |
| *(Optional)* **PowerBI** | — | Data visualization | [[https://www.tableau.com/trial](https://app.powerbi.com/home?experience=power-bi)] |
---
## 🚀 1. Clone the Repository
```bash
git clone https://github.com/<your-org-or-username>/neural-forge.git
cd neural-forge
```
⚙️ 2. Configure Environment Variables

You’ll need to connect to the correct database environments.

Copy the example appsettings file create a new appsettings.Development.json and paste what you copied:

Then open appsettings.Development.json and update the values for your test database:

Server=localhost
Port=3306
Database=neural_forge_test
User=root
DB_PASS=yourpassword

⚠️ Never commit appsettings.Development files or production credentials to GitHub!

🧩 3. Restore and Build the C# Backend

Restore dependencies and build the backend using .NET:

dotnet ef --version  Should return correctly
dotnet tool install --global dotnet-ef
dotnet restore
dotnet build --configuration Release

🗄️ 4. Create & Update the Test Database

Ensure MySQL is running locally, then run EF Core migrations:

dotnet ef database update

✅ This creates or updates your test database schema automatically.
The production database should not be modified directly during development.

🧠 5. Run the Backend

Start the C# backend (hosted locally):

dotnet run

✅ 6. Common Developer Tasks
Task	Command
Apply migrations	dotnet ef database update
Add a new migration	dotnet ef migrations add <name>
Run backend	dotnet run
Run mock data script	python generate_mock_data.py
View running API	http://localhost:5000/swagger
🧱 7. Project Rules & Standards
These rules keep our workflow clean and professional:

Feature Branches: Every change must be made on a feature branch.

Pull Requests: Required before merging into main.

Code Reviews: At least one team member must review a PR before merge.

Commit Messages:
Format → <type>(<branch name>): <description>
Example → feat(api-endpoints): added POST route for chip data

Database Policy:
All testing happens on the test database.
Only the team lead can modify the production database.

Naming Conventions:
Database fields should use snake_case.
