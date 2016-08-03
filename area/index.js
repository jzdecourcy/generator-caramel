'use strict';
var util = require('util');
var pluralize = require('pluralize')
var ScriptBase = require('../script-base.js');

var NamedGenerator = module.exports = function NamedGenerator() {
  ScriptBase.apply(this, arguments);
};

util.inherits(NamedGenerator, ScriptBase);

// Commands
// Events
// Command Handlers
// Area

NamedGenerator.prototype.createNamedItem = function() {
	var pluralname = pluralize(this.name);
    
	var templateData = {
		namespace: this.namespace(),
		classname: this.name,
		basenamespace: this.basenamespace,
		basewebnamespace: this.basenamespace = this.config.get("basewebnamespace"),
		pluralname: pluralname
	};
	
	// We get a name - let's create:
	// 1: AreaRegistration
    this.fs.copyTpl(this.templatePath("Area/AreaRegistration.cs"), "Areas/" + pluralname + "/" + this.name + "AreaRegistration.cs", templateData);
	
    // 2: Controller
    this.fs.copyTpl(this.templatePath("Area/Controllers/Controller.cs"), "Areas/" + pluralname + "/Controllers/" + this.name + "Controller.cs", templateData);
	
    // 3: Profile
    this.fs.copyTpl(this.templatePath("Area/AutoMapper/Profile.cs"), "Areas/" + pluralname + "/AutoMapper/" + this.name + "Profile.cs", templateData);
	
	// 4: View Models
	this.fs.copyTpl(this.templatePath("Area/Models/CreateViewModel.cs"), "Areas/" + pluralname + "/Models/Create" + this.name + "ViewModel.cs", templateData);
	this.fs.copyTpl(this.templatePath("Area/Models/EditViewModel.cs"), "Areas/" + pluralname + "/Models/Edit" + this.name + "ViewModel.cs", templateData);
	this.fs.copyTpl(this.templatePath("Area/Models/DetailsViewModel.cs"), "Areas/" + pluralname + "/Models/" + this.name + "DetailsViewModel.cs", templateData);
	this.fs.copyTpl(this.templatePath("Area/Models/ViewModel.cs"), "Areas/" + pluralname + "/Models/" + this.name + "ViewModel.cs", templateData);
	this.fs.copyTpl(this.templatePath("Area/Models/SearchCriteriaViewModel.cs"), "Areas/" + pluralname + "/Models/" + this.name + "SearchCriteriaViewModel.cs", templateData);

	// 5: Metadata
	this.fs.copyTpl(this.templatePath("Area/Metadata/CreateViewModelMetadata.cs"), "Areas/" + pluralname + "/Metadata/Create" + this.name + "ViewModelMetadata.cs", templateData);
	this.fs.copyTpl(this.templatePath("Area/Metadata/EditViewModelMetadata.cs"), "Areas/" + pluralname + "/Metadata/Edit" + this.name + "ViewModelMetadata.cs", templateData);
	this.fs.copyTpl(this.templatePath("Area/Metadata/DetailsViewModelMetadata.cs"), "Areas/" + pluralname + "/Metadata/" + this.name + "DetailsViewModelMetadata.cs", templateData);
	this.fs.copyTpl(this.templatePath("Area/Metadata/ViewModelMetadata.cs"), "Areas/" + pluralname + "/Metadata/" + this.name + "ViewModelMetadata.cs", templateData);
	   
	// 6: Validators
	this.fs.copyTpl(this.templatePath("Area/Validation/CreateViewModelValidator.cs"), "Areas/" + pluralname + "/Validation/Create" + this.name + "ViewModelValidator.cs", templateData);
	this.fs.copyTpl(this.templatePath("Area/Validation/EditViewModelValidator.cs"), "Areas/" + pluralname + "/Validation/Edit" + this.name + "ViewModelValidator.cs", templateData);

	// 7: Routes
	this.fs.copyTpl(this.templatePath("Area/Route.cs"), "Routing/" + "Routes." + this.name + ".cs", templateData);
   
	// 8: Views
	this.fs.copyTpl(this.templatePath("Area/Views/_CreateActions.cshtml"), "Views/" + this.name + "/_CreateActions.cshtml", templateData);
	this.fs.copyTpl(this.templatePath("Area/Views/_EditActions.cshtml"), "Views/" + this.name + "/_EditActions.cshtml", templateData);
	
	this.fs.copyTpl(this.templatePath("Area/Views/DisplayTemplates/Table.Row.Cell.Name.cshtml"), "Views/" + this.name + "/DisplayTemplates/Table.Row.Cell.Name.cshtml", templateData);
	this.fs.copyTpl(this.templatePath("Area/Views/EditorTemplates/SearchCriteriaViewModel.cshtml"), "Views/" + this.name + "/EditorTemplates/" + this.name + "SearchCriteriaViewModel.cshtml", templateData);
};