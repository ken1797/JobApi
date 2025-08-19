# Teknorix Jobs API

## How to Run

1. Ensure SQL Server is running locally.
2. Update `appsettings.json` with your SQL Server connection string.
3. Run EF migrations:
   ```bash
   dotnet ef database update
   ```
4. Run the API:
   ```bash
   dotnet run
   ```
5. Open Swagger at:
   ```
   https://localhost:5001/swagger
   ```

## Endpoints

- `POST /api/v1/jobs`
- `PUT /api/v1/jobs/{id}`
- `GET /api/v1/jobs/{id}`
- `POST /api/jobs/list` (to be implemented)
- Department + Location CRUD APIs included similarly.