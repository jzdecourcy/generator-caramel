# generator-caramel

Yeoman generator for Caramel based projects

## Usage

* `yo caramel` shows a wizard for generating a new Caramel app

* `yo caramel --help` shows flags and other configurable options


## Sub Generators

The alphabetic list of available sub generators (_to create files after the project has been created_):

* [caramel:crud](#crud)
* [caramel:area](#area)

### crud

Creates types to facilitate CRUD operations invluding entities, commands, events, and command handlers.

Example:
```
yo caramel:crud Employee
```

### area

Creates MVC Area with basic CRUD operations with models, validators, metadata, mappings, and views.

Example:
```
yo caramel:area Employee
```

[Return to top](#top)