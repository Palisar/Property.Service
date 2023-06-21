# MyHome.Property.Service

## Project Setup

To run this project, follow these steps:

1. Open the **Common** class library.
2. Navigate to the **docker** folder.
3. Open a terminal in this directory.

Run the following command to start the project using Docker:

```bash
docker-compose up -d
```

Note: Docker must be installed on your system for this command to work. If you don't have Docker installed, you can use an alternative database setup.
Alternative Database Setup

1. Open the Program.cs file.
2. Locate the section related to the database setup.
3. Comment out the AddMongo part.
4. Uncomment the InMemoryDatabase section.

By performing the above steps, the project will use an in-memory database instead of MongoDB.
