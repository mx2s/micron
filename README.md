# framework-base

<a href="https://travis-ci.org/mxss/framework-base"><img src="https://travis-ci.org/mxss/framework-base.svg?branch=master" alt="TravisCI"></a>

## Description
Minimal .net core framework based on three tier architecture, can be used as template for building API's

### Tech summary:
**Supported databases:** PostgreSQL

***

### System requirements:
- .net core > 2.2
- database (PostgreSql only)
- PHP > 7.0 (for migrations)

***

### Used tools:
**Database:**
- Auth: [JWT(jwt-dotnet)](https://github.com/jwt-dotnet/jwt)
- WebServer: [Nancy](https://github.com/NancyFx/Nancy)
- ORM: [Dapper(StackExchange)](https://github.com/StackExchange/Dapper)
- Migrations: [Phinx(CakePHP)](https://github.com/cakephp/phinx)

***

### Set up:
1. build project
2. copy config.example.json into: 
- **For main app**
- App/bin/%BUILD_TYPE%/netcoreapp2.2/config/config.json
- **For unit tests**
- Tests/bin/%BUILD_TYPE%/netcoreapp2.2/config/config.json
