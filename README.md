# generator-caramel

Yeoman generator for Caramel based projects

## Usage

* `yo caramel` shows a wizard for generating a new Caramel app

* `yo caramel --help` shows flags and other configurable options

## Template projects

Full, template based projects available in generator:

- Caramel Soultion (with or without web projects)

The Caramel Soultion includes entities, commands, command handlers, events, event handlers, and services with the option to add web projects.


## Command line automation

The project type, comapany name, application name, base namespace, and web projects can be specified as optional command line arguments:

    yo caramel [solution [comapanyname] [applicationname] [basenamespace] [webprojects]]

The valid project types are:

- `solution` for Empty Web Application

> Example: `yo caramel solution "Acme Inc." TheGadget  Acme.TheGadget Public,Admin` will create a "Caramel Solution" "TheGadget" with a base namespace "Acme.TheGadget" and web projects "Public" and "Admin".

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