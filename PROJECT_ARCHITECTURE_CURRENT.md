# PortfolioPlatform — Current Architecture

## Project Goal

PortfolioPlatform is a multi-service backend platform designed for:

- CV management
- Portfolio/project management
- Blog/content management
- File management
- Identity/authentication

The system is intended to evolve into a production-grade enterprise-level backend platform.

---

# Architecture Style

The project uses:

- Microservice Architecture
- DDD (Domain Driven Design)
- Clean Architecture

---

# Layer Structure

Each service follows this structure:

API
Application
Domain
Infrastructure
Contracts

---

# Layer Responsibilities

## API
- Controllers
- HTTP handling
- Swagger
- DI registrations

## Application
- Business logic
- Service orchestration
- Interfaces/abstractions

## Domain
- Entities
- Core business models

## Infrastructure
- EF Core
- Persistence
- External integrations
- Storage implementations

## Contracts
- DTOs
- Request/Response models

---

# Current Services

## Identity Service
Responsibilities:
- Login
- JWT generation
- Authorization

Status:
- Implemented

---

## CV Service
Modules:
- PersonalInfo
- Experience
- Education
- Skill
- SocialLink
- Language
- Certificate
- Hobby

Status:
- Full CRUD completed

Notes:
- PersonalInfo contains ProfileImageId
- File binary is NOT stored here

---

## Portfolio Service
Modules:
- Project
- Category
- Technology
- Architecture
- Image

Status:
- Full CRUD completed

Important:
- Project uses many-to-many relationships with:
  - Categories
  - Technologies
  - Architectures

- Image is modeled as a child entity:
  - Project -> Images (one-to-many)

- File storage is NOT handled here
- Image entity references File Service via FileId

---

## Blog Service
Modules:
- Post
- Category
- Tag
- Image

Status:
- Implemented

Notes:
- Similar architecture to Portfolio Service
- Images reference File Service

---

## File Service
Responsibilities:
- File upload
- File metadata storage
- Physical storage

Current Storage Strategy:
- Physical files stored on disk
- Metadata stored in PostgreSQL

Important:
- Services only store FileId references
- File Service owns actual files

---

# Database Strategy

- Separate database per service
- EF Core + PostgreSQL
- UTC DateTime usage

---

# Architectural Rules

## General
- Controllers remain thin
- Business logic belongs to Application layer
- Infrastructure handles persistence/integrations
- Contracts used for external DTOs

---

## File Ownership Rule
Other services NEVER store physical files.

Only:
- FileId
- metadata references

---

## Service Communication
Direct DB access between services is forbidden.

Communication must happen through:
- HTTP APIs
- later possibly messaging

---

## Relationship Modeling
- Many-to-many used for Project relations
- Explicit join entities intentionally avoided currently

---

# Current Technical State

The system currently contains:
- Multiple independent services
- Swagger support
- EF Core persistence
- Modular architecture
- Refactored service structure

The next phase is:
- service-to-service communication
- infrastructure hardening
- operational maturity