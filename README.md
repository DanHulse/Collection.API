# Collection.API
An API for handling CRUD requests to a NoSQL database, built for managing a collection.

## Overview
This is an API that is meant to sit between a front end and NoSQL DB (in my case an Azure DocumentDB with the MongoDB protocol).
Its intention is to allow for the management of a collection of Movies/Games/Books, etc.

## Setup
This API requires a NoSQL database backing it in order to function. I used an Azure DocumentDB, picking the MongoDB API option during the setup process, after the DB has been provisioned, you will need the connection string from the Properties pane in Azure.

Go to the root folder of the Repo and create a file called "AppSettingsSecrets.config" and in here you should put the following configuration:
```xml
<appSettings>
  <add key="MongoDbCollection" value="{Name of collection}"/>
  <add key="MongoDbConnection" value="{Connection string}"/>
</appSettings>
```
This will ensure that the API will connect to your Azure DB without storing the connection details in the Web.config file.

When publishing this API to Azure, you can then add these AppSettings into the live app by following this: [AppSettings and Connection Strings in Azure] (https://azure.microsoft.com/en-gb/blog/windows-azure-web-sites-how-application-strings-and-connection-strings-work/)

### Routing
| HTTPCommand | Route | Description | Returns |
| --- | --- | --- | --- |
| **GET** | /api/v1/[*controller*]/ | Gets all from specified collection | [*controller*]ViewModel |
| **GET** | /api/v1/[*controller*]/{*id*} | Gets specific item from collection | [*controller*]DetailViewModel |
| **POST** | /api/v1/[*controller*]/ | Posts new item(s) to collection, accepts array of [*controller*]Model to insert | HttpActionResult |
| **PATCH** | /api/v1/[*controller*]/{*id*} | Patches specified item from collection, accepts new item in JSON body | HttpActionResult |
| **DELETE** | /api/v1/[*controller*]/ | Deletes specified item(s) from collection, accepts array of Ids to delete | HttpActionResult |

### To-Do
- [x] Movies route
- [ ] Video Games route
- [ ] Books route
- [ ] Music route
- [x] README.md
