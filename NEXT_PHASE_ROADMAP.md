# PortfolioPlatform — Final Roadmap

# Ordered Roadmap

1. Service-to-service communication
2. API Gateway
3. Central configuration / secrets
4. Docker / Docker Compose
5. Logging
6. Health checks
7. Monitoring / tracing
8. OpenTelemetry + Collector
9. Resilience
10. RabbitMQ / async messaging
11. Background workers / scheduled jobs
12. Caching
13. Distributed cache
14. Output caching strategy
15. Search
16. Audit trail / activity history
17. Error contract standardization across all services and gateway
18. OpenAPI contract governance + client generation
19. API versioning
20. Rate limiting
21. Feature flags
22. Environment strategy
23. Database backup / migration strategy standardization
24. Documentation
25. CI/CD pipeline hardening
26. Security scanning / dependency scanning
27. Performance baseline / bottleneck review
28. Idempotency / safe retry strategy
29. Centralized auth flow
30. Identity integration
31. Refresh token / token lifecycle management
32. Security hardening
33. Kubernetes
34. Infrastructure as Code
35. .NET Aspire
36. Tests

---

# Important Development Strategy

## Identity integration intentionally postponed
Reason:
Authentication everywhere would slow down architecture iteration.

---

# Current Next Step

The immediate next phase is:

# Service-to-service communication

Initial target:
- Portfolio Service -> File Service validation
- CV Service -> File Service validation
- Blog Service -> File Service validation

Planned implementation style:
- HttpClient abstraction
- typed clients
- enterprise-style service integration

---

# Important Rules

## Do NOT redesign architecture
Current architecture decisions are intentional.

## Keep services independent
No direct database sharing between services.

## Keep controllers thin
Business logic belongs to Application layer.

## Preserve Clean Architecture boundaries
Avoid leaking Infrastructure concerns into Application or Domain.

## Prefer incremental enterprise evolution
Do not introduce premature complexity unless required by the roadmap phase.