# PortfolioPlatform — Current Project Status

# Completed Services

## Identity Service
Completed:
- Login
- JWT generation
- Authorization basics

---

## CV Service
Completed:
- PersonalInfo CRUD
- Experience CRUD
- Education CRUD
- Skill CRUD
- SocialLink CRUD
- Language CRUD
- Certificate CRUD
- Hobby CRUD

Important:
- PersonalInfo contains ProfileImageId
- File validation between services not implemented yet

---

## Portfolio Service
Completed:
- Project CRUD
- Category CRUD
- Technology CRUD
- Architecture CRUD
- Image CRUD

Relationships:
- Project <-> Category (many-to-many)
- Project <-> Technology (many-to-many)
- Project <-> Architecture (many-to-many)
- Project -> Images (one-to-many)

Implemented:
- Include-based eager loading
- Relationship mapping in responses
- Request models support relation ids

Important:
- Images are added AFTER project creation
- Image entity references File Service through FileId

---

## Blog Service
Completed:
- Blog CRUD structure
- Categories
- Tags
- Images

---

## File Service
Completed:
- Upload
- GetAll
- GetById
- Delete

Implemented:
- Disk storage
- Metadata persistence
- Uploads folder strategy
- File metadata entity

Important:
- Upload folder ignored via .gitignore

---

# Important Decisions

## Authentication
Not yet integrated across all services intentionally.

Reason:
Development speed optimization.

Planned later:
- centralized auth validation
- token lifecycle management
- refresh tokens

---

## Tests
Testing intentionally postponed.

Reason:
Fast architecture iteration first.

---

## Current Focus
The project is transitioning from:
- CRUD architecture phase
to:
- distributed systems phase