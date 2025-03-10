TEST

Run the following commands to test the project:

docker compose up -d

dotnet restore

dotnet test


DEV

Duplicate .env.local and rename to .env

Run the following commands to start the project:

docker compose up -d

dotnet restore

Run migrations:
dotnet ef database update

dotnet run

The API is running at http://localhost:5279/

The swagger documentation is available at http://localhost:5279/swagger/index.html