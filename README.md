# Neural Forge Project Summary

## Project Overview
Neural Forge is a **simulated GPU manufacturing company** created by a team of 4 CS students to demonstrate a complete data pipeline and business intelligence workflow. It's **not a real manufacturer** - all production data is simulated.

---

## Project Goals
Design and implement a **local, end-to-end data pipeline** that:
- Tracks production data from **12 simulated manufacturing sites**
- Records chip production counts and assembly line outages over time
- Stores data in a **relational MySQL database**
- Provides **analytical insights and visualizations** using PowerBI

---

## Tech Stack

| Component | Technology |
|-----------|-----------|
| **Backend** | C# (.NET 8) with Entity Framework Core |
| **IDE** | JetBrains Rider |
| **Database** | MySQL (two instances: `test` and `production`) |
| **Mock Data** | Python script (sends POST requests to API) |
| **Visualization** | PowerBI |

---

## Database Schema (5 Entities)

### 1. Sites (`sites`)
- Manufacturing facilities (12 total across the nation)
- Fields: `site_id`, `location`, `number_of_lines`, `amount_of_chips_per_hour`

### 2. Assembly Lines (`assembly_lines`)
- Production lines within each site
- Fields: `assembly_line_id`, `site_id` (FK), `chip_id` (FK), `number_of_machines`, `quota`

### 3. Chips (`chips`)
- GPU models being produced
- Fields: `chip_id`, `chip_name`, `number_of_cores`, `production_time`, `market_price`

### 4. Downtime Events (`downtime_events`)
- Records of production outages
- Fields: `downtime_event_id`, `assembly_line_id` (FK), `start_time`, `end_time`

### 5. Production Records (`production_records`)
- Time-series production data
- Fields: `production_record_id`, `site_id` (FK), `amount_of_chips_per_hour`, `timestamp`

---

## Entity Relationships
```
Site (1) ──→ (M) AssemblyLine
Chip (1) ──→ (M) AssemblyLine
AssemblyLine (1) ──→ (M) DowntimeEvent
Site (1) ──→ (M) ProductionRecord
```

**Cascade Delete Strategy:**
- Site → AssemblyLine: **Cascade**
- All others: **Restrict** (prevents dependency loops)

---

## Data Flow Pipeline
```
Python Mock Data Script
    ↓ (POST JSON)
C# Web API (EF Core)
    ↓
MySQL Test/Production Database
    ↓ (after validation)
Tableau Visualization
```

---

## Project Structure
```
NeuralForge/
├── NeuralForge.Api/              # C# Web API project
│   ├── Controllers/              # API endpoints
│   ├── Models/                   # Entity classes
│   │   ├── Site.cs
│   │   ├── AssemblyLine.cs
│   │   ├── Chip.cs
│   │   ├── DowntimeEvent.cs
│   │   └── ProductionRecord.cs
│   ├── Data/
│   │   └── NeuralForgeContext.cs # DbContext
│   ├── Migrations/               # EF Core migrations
│   ├── appsettings.Example.json  # Template (COMMITTED)
│   ├── appsettings.Development.json # Real credentials (NOT COMMITTED)
│   └── Program.cs
├── scripts/
│   └── generate_mock_data.py     # Python data generator
├── docs/                          # Documentation
├── .gitignore
└── README.md
```

---

## GitHub Workflow & Standards

### Repository Rules
1. **Single repo** for entire project
2. **All changes go to `test` database first**
3. **Only verified changes go to `production` database**
4. **Feature branch workflow** - no direct commits to `main`

### Branch Naming
```
feature/<short-description>
```

### Commit Message Format
```
<type>(<branch name>): <message>

Examples:
feat(feature/mock-data): added POST endpoint for chip data
fix(feature/backend-api): corrected EF entity mapping
nit(feature/docs): updated README
```

### Pull Request Rules
- Required for all merges to `main`
- At least **1 other team member** must review
- Must pass simple build test

---

## Naming Conventions

| Context | Convention | Example |
|---------|-----------|---------|
| **Database** | `snake_case` | `site_id`, `assembly_lines` |
| **C# Properties** | `PascalCase` | `SiteId`, `AssemblyLines` |
| **C# Methods** | `PascalCase` | `GetAllSites()` |
| **Git Branches** | `feature/kebab-case` | `feature/add-chip-status` |

---

## Getting Started for New Team Members

### See Docs

---

### When Pulling New Changes

Always update your database after pulling:
```bash
git pull origin main
dotnet ef database update
```

---

## Current Project Status

### Completed
- NuGet packages installed:
  - `Pomelo.EntityFrameworkCore.MySql`
  - `Microsoft.EntityFrameworkCore.Design`
  - `Microsoft.EntityFrameworkCore.Tools`
- 5 Entity models created with `[Table]` and `[Column]` attributes
- `NeuralForgeContext` DbContext configured
- Test and Production database created using EF Core
- API controllers created and functional
- Python mock data generator functional
- Production database seeded via mock data generator
- PowerBI pages made and connected via database so data automatically updates
- Recorded implementation of the script and seeding the production database [here](https://youtu.be/STsO2FZXGwQ)
---

## Learning Objectives
This project demonstrates:
- Full-stack data pipeline design
- Relational database modeling
- RESTful API development
- ORM usage (Entity Framework Core)
- Git version control best practices
- Environment separation (test vs production)
- Business intelligence visualization
- Team collaboration workflows

---

## Key Design Decisions

1. **Code-First Approach**: Entity models → Migrations → Database schema
2. **Snake_case in DB, PascalCase in C#**: Using EF Core attributes to map
3. **Restrict over Cascade**: Safer deletion, avoids dependency loops
4. **Enums stored as strings**: Readable in database/Tableau
5. **Auto-migration on startup**: Convenient for development
6. **Each team member has own local test DB**: Safe parallel development

---

## Contact & Support
For questions or issues, contact the team lead or submit an issue in the GitHub repository.
