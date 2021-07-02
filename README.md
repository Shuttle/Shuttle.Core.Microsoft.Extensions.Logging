# Shuttle.Core.Microsoft.Extensions.Logging

```
PM> Install-Package Shuttle.Core.Microsoft.Extensions.Logging
```

Shuttle logging implementation for Microsoft's extension logging adapter

## Usage

``` c#
 Log.Assign(new Logger(loggerFactory.CreateLogger<Program>()));
````

