# Collection.API
An API for handling CRUD requests to a NoSQL database, built for managing a collection.

## Overview
This is an API that is meant to sit between a front end and NoSQL DB (in my case an Azure DocumentDB with the MongoDB protocol).
Its intention is to allow for the management of a collection of Movies/Games/Books, etc.

### Routing
| HTTPCommand | Route | Description | Returns |
| --- | --- | --- | --- |
| **GET** | /api/v1/[*controller*]/ | Gets all from specified collection | [*controller*]ViewModel |
| **GET** | /api/v1/[*controller*]/{*id*} | Gets specific item from collection | [*controller*]DetailViewModel |
| **POST** | /api/v1/[*controller*]/ | Posts new item to collection | HttpActionResult |
| **PATCH** | /api/v1/[*controller*]/{*id*} | Patches specified item from collection, accepts new item in JSON body | HttpActionResult |
| **DELETE** | /api/v1/[*controller*]/{*id*} | Deletes specified item from collection | HttpActionResult |

### To-Do
- [x] Movies route
- [ ] Video Games route
- [ ] Books route
- [ ] Music route
- [ ] README.md
