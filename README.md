# DI2-P2-P3
- Un script pour créer une base de données.
## Backend
- La solution du backend se trouve dans le dossier ws > API.
  - Pour se connecter à la base de données choisie, voici l'étape:
    - Aller dans API > appsettings.json et configurer:
        "SqlConnectionString": "Server=Host,port;Database=database_name;User ID=user;Password=password_user;TrustServerCertificate=True;"
- Lancer 'dotnet run' pour run le webservice.

## Frontend
- La solution du frontend se trouve dans le dossier ui.
  - Pour l'installation des dépendences, lancer un 'npm i'
  - Pour la configuration, référencer l'url de l'api dans le fichier environment.ts
- Lancer un 'ng serve' pour run l'application.
