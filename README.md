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
Example: App/bin/Debug/netcoreapp2.2/config/config.json
3. edit config files - fill db name / user / etc.

**Migrating**
1. copy migrations/phinx.example.yml to migrations/phinx.yml
2. edit phinx.yml - fill database user / password etc.
3. install php & composer dependencies from migrations/composer.json
4. run migrations (in migrations folder):

`php vendor/bin/phinx migrate` - to migrate with default database (development)

`php vendor/bin/phinx migrate -e testing` - to migrate with test database
