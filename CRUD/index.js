'use strict';
var util = require('util');
var camelcase = require('camelcase');
var ScriptBase = require('../script-base.js');

var NamedGenerator = module.exports = function NamedGenerator() {
  ScriptBase.apply(this, arguments);
};

util.inherits(NamedGenerator, ScriptBase);

//his.log("Hellllllloooo!");

// Entity
//t//his.generateTemplateFile("mutableentity.cs", this.name + ".cs", 

// Commands
// Events
// Command Handlers
// Area

NamedGenerator.prototype.createNamedItem = function() {
	var templateData = {
		namespace: this.namespace(),
		classname: this.name,
		basenamespace: this.basenamespace,
		camelcaseclassname: camelcase(this.name)
	};


	// We get a name - let's create:
	// 1: Entity
	this.fs.copyTpl(this.templatePath("mutableentity.cs"), this.basenamespace + ".Entities/" + this.name + ".cs", templateData);
	// 2: Commands
	this.fs.copyTpl(this.templatePath("crudcommands.cs"), this.basenamespace + ".Commands/" + this.name + "Command.cs", templateData);
	// 3: Events
	this.fs.copyTpl(this.templatePath("crudevents.cs"), this.basenamespace + ".Events/" + this.name + "Event.cs", templateData);
	// 4: Command Handlers
	this.fs.copyTpl(this.templatePath("createcommandhandler.cs"), this.basenamespace + ".CommandHandlers/Create" + this.name + "CommandHandler.cs", templateData)
	this.fs.copyTpl(this.templatePath("updatecommandhandler.cs"), this.basenamespace + ".CommandHandlers/Update" + this.name + "CommandHandler.cs", templateData)
	this.fs.copyTpl(this.templatePath("deletecommandhandler.cs"), this.basenamespace + ".CommandHandlers/Delete" + this.name + "CommandHandler.cs", templateData)
};