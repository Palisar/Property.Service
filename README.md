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

    Open the Program.cs file.
    Locate the section related to the database setup.
    Comment out the AddMongo part.
    Uncomment the InMemoryDatabase section.

By performing the above steps, the project will use an in-memory database instead of MongoDB.
