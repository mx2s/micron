# Micron

<a href="https://travis-ci.org/mxss/micron"><img src="https://travis-ci.org/mxss/micron.svg?branch=master" alt="TravisCI"></a>
<a href="https://www.nuget.org/packages/MicronCore">NuGet Package (framework core)</a>

## Description
Minimal .net core framework based on three tier architecture, can be used as template for building API's

I've built this framework mostly for myself with all needed features out of the box, but this foundation can be more modular to have more potential use cases.


## Features
Example route with validation
```csharp
Get("/api/v1/item/get", _ => {
    var errors = ValidationProcessor.Process(Request, new IValidatorRule[] {
        new ExistsInTable("item_guid", "items", "guid"),
    });
    if (errors.Count > 0) {
        return HttpResponse.Errors(errors);
    }

    return HttpResponse.Item("item", new ItemTransformer().Transform(
        ItemRepository.FindByGuid(Request.Query["item_guid"])
    ));
});
```
Example controller with middleware (check JWT token)
```csharp
public class ItemCrudController : BaseController {
    protected override IMiddleware[] Middleware() => new IMiddleware[] {
        new JwtMiddleware()
    };
    
    public ItemCrudController() {
        Post("/api/v1/item/create", _ => {
            var errors = ValidationProcessor.Process(Request, new IValidatorRule[] { });
            if (errors.Count > 0) {
                return HttpResponse.Errors(errors);
            }

            var item = ItemRepository.CreateAndGet((string) Request.Query["title"], (float) Request.Query["price"]);

            return HttpResponse.Item("item", new ItemTransformer().Transform(item));
        });
    }
}
```
Example transformer
```csharp
public class ItemTransformer : BaseTransformer {
    public override JObject Transform(object obj) {
        var item = (ItemModel) obj;
        return new JObject {
            ["guid"] = item.guid,
            ["title"] = item.title,
            ["price"] = item.price,
        };
    }
}
```

### Set up:
1. restore nuget packages / load 'Base' git submodule
2. build project
3. copy config.example.json into: 
- **For main app**
- App/bin/%BUILD_TYPE%/netcoreapp2.2/config/config.json
- **For unit tests**
- Tests/bin/%BUILD_TYPE%/netcoreapp2.2/config/config.json

**Example:** App/bin/Debug/netcoreapp2.2/config/config.json

4. edit config files - fill database name / user / etc.


**Migrating**
1. copy migrations/phinx.example.yml to migrations/phinx.yml
2. edit phinx.yml - fill database user / password etc.
3. install php & composer dependencies from migrations/composer.json
4. run migrations (in migrations folder):

`php vendor/bin/phinx migrate` - to migrate with default database (development)

`php vendor/bin/phinx migrate -e testing` - to migrate with test database

***

5. Run it! via dotnet `dotnet App/bin/Debug/netcoreapp2.2/App.dll`

### Tech summary:
**Supported databases:** PostgreSQL

***

### System requirements:
- .net core > 2.2
- database (PostgreSql only)
- PHP > 7.0 (for migrations)

***

### Project structure:
Foundation of the framework is located in [framework-base-core](https://github.com/mxss/framework-base-core) and loaded as submodule into Base project

***

### Used tools:
**Database:**
- Auth: [JWT(jwt-dotnet)](https://github.com/jwt-dotnet/jwt)
- WebServer: [Nancy](https://github.com/NancyFx/Nancy)
- ORM: [Dapper(StackExchange)](https://github.com/StackExchange/Dapper)
- Migrations: [Phinx(CakePHP)](https://github.com/cakephp/phinx)

**Building & running project**

You should be able to build with `dotnet build` and run app via for example: `dotnet App/bin/Debug/netcoreapp2.2/App.dll`

# Contribution:
Thank you for considering contributing to this repo. Feel free to submit any improvements / issues / refactoring / documentation etc. 
