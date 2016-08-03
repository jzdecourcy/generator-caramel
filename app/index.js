'use strict';
var yeoman = require('yeoman-generator');
var yosay = require('yosay');
var chalk = require('chalk');
var path = require('path');
var guid = require('uuid');
var projectName = require('vs_projectname');

var CaramelGenerator = yeoman.generators.Base.extend({

	constructor: function() {
		yeoman.generators.Base.apply(this, arguments);
		// only implemented for web template
		//this.option('grunt', {
		//  type: Boolean,
		//  defaults: false,
		//  desc: 'Use the Grunt JavaScript task runner instead of Gulp in web projects.'
		//});
	},


	init: function() {
		this.log(yosay('Welcome to the Caramel generator!'));
		this.templatedata = {};
		this.config.save();
	},

	askFor: function() {
		var done = this.async();

		var prompts = [{
			type: 'list',
			name: 'type',
			message: 'What?',
			choices: [{
				name: 'Caramel Solution',
				value: 'empty'
			}]
		}];

		this.prompt(prompts, function(props) {
			this.type = props.type;

			done();
		}.bind(this));
	},

	askForName: function() {
		var done = this.async();
		var app = '';
		var prompts = [
			{
				name: 'companyName',
				message: 'What\'s the name of your application\'s company?',
				default: app
			},			
			{
				name: 'applicationName',
				message: 'What\'s the name of your application?',
				default: app
			},
			{
				name: 'basenamespace',
				message: 'What\'s the base namespace of your application?',
				default: app
			},
			{
				name: 'webprojectNames',
				message: 'What web projects should be created?',
				default: ""
			}
		];
		this.prompt(prompts, function(props) {
			this.applicationName = props.applicationName;
			this.templatedata.companyName = props.companyName;
			this.templatedata.applicationName = props.applicationName;
			this.templatedata.basenamespace = props.basenamespace;
			this.templatedata.webprojectNames = props.webprojectNames.split(",");
			this.templatedata.guid = guid.v4();
			this.templatedata.year = new Date().getFullYear();
			done();
		}.bind(this));
	},

	writing: function() { 
		this.sourceRoot(path.join(__dirname, './templates/Solution'));
		this.log(this.templatedata.basenamespace);
		this.templatedata.solutionguid = guid.v4();
		
		// Library projects
		this.templatedata.projects = {};
		this.templatedata.projectNames = [ "Migrations", "Entities", "Commands", "Events", "CommandHandlers", "EventHandlers", "Services", "Services.Contracts" ];
		
		for (var i = 0; i < this.templatedata.projectNames.length; i++) {
			this.templatedata.projects[this.templatedata.projectNames[i]] = {
				name: this.templatedata.projectNames[i],
				guid: guid.v4()
			};
		}
		
		for (var i = 0; i < this.templatedata.projectNames.length; i++) {
			var project = this.templatedata.projects[this.templatedata.projectNames[i]];
			var templateName = "ApplicationName." + project.name;
			var projectFullName = this.templatedata.basenamespace + "." + project.name;
		
			this.templatedata.guid = project.guid;
			this.template(this.templatePath(templateName + "/" + templateName + ".csproj"), projectFullName + "/" + projectFullName + ".csproj", this.templatedata);
			this.copy(this.templatePath(templateName + "/packages.config"), projectFullName + "/packages.config");
			
			this.fs.copyTpl(
				this.templatePath(this.templatePath(templateName) + "/**/*.cs"),
				projectFullName,
				this.templatedata
			);
		}
		
		// Web projects
		this.templatedata.webprojects = {};
		//this.templatedata.webprojectNames = [ "Public" ]; //, "Admin" ];
		
		for (var i = 0; i < this.templatedata.webprojectNames.length; i++) {
			this.templatedata.webprojects[this.templatedata.webprojectNames[i]] = {
				name: this.templatedata.webprojectNames[i],
				guid: guid.v4()
			};
		}		
		
		for (var i = 0; i < this.templatedata.webprojectNames.length; i++) {
			var webproject = this.templatedata.webprojects[this.templatedata.webprojectNames[i]];
			
			this.templatedata.guid = webproject.guid;
			this.templatedata.basewebnamespace = this.templatedata.basenamespace + ".Web.Mvc." + webproject.name;
			//this.template(this.templatePath("Web/" + webproject.name + "/" + webproject.name + ".csproj"), "Web/" + webproject.name + "/" + webproject.name + ".csproj", this.templatedata);
			//this.copy(this.templatePath("Web/" + webproject.name + "/packages.config"), "Web/" + webproject.name + "/packages.config");
			
			this.fs.copyTpl(
				[ this.templatePath("Web/Public/**/*.*"), "!" + this.templatePath("Web/Public/**/*.csproj") ],
				"Web/" + webproject.name,
				this.templatedata
			);
			
			this.fs.copyTpl(
				this.templatePath("Web/Public/Public.csproj"),
				"Web/" + webproject.name + "/" + webproject.name + ".csproj", 
				this.templatedata
			);					
		}
		
		// Root files
		this.template(this.templatePath("CreateDatabase.sql"), "CreateDatabase.sql", this.templatedata);
		this.template(this.templatePath("Build.bat"), "Build.bat", this.templatedata);
		this.template(this.templatePath("GlobalAssemblyInfo.cs"), "GlobalAssemblyInfo.cs", this.templatedata);
		this.template(this.templatePath("Migrate.bat"), "Migrate.bat", this.templatedata);
		this.template(this.templatePath("RebuildDatabase.bat"), "RebuildDatabase.bat", this.templatedata);
		this.copy(this.templatePath("Restore.bat"), "Restore.bat");
		
		this.log(this.templatePath() + "/.nuget/*.*");
		this.log(this.destinationRoot());
		
		// .nuget
		this.copy(this.templatePath(".nuget/nuget.exe"), ".nuget/nuget.exe");
		this.copy(this.templatePath(".nuget/nuget.Config"), ".nuget/nuget.Config");
		this.copy(this.templatePath(".nuget/nuget.targets"), ".nuget/nuget.targets");
		
		// Solution
		var solutionGuid = guid.v4();
		this.templatedata.guid = guid.v4();
		this.templatedata.webguid = guid.v4();
		this.templatedata.testsguid = guid.v4();
		
		this.template(this.templatePath("ApplicationName.sln"), this.applicationName + '.sln', this.templatedata);
	},

	end: function() {
		this.config.set("basenamespace", this.templatedata.basenamespace);
		this.config.save();
		
		this.log('\r\n');
		this.log('Your solution is now created, you can use the following commands to get going');
		//this.log(chalk.green('    cd "' + this.applicationName + '"'));
		this.log(chalk.green('    Restore.bat'));
		this.log(chalk.green('    Build.bat Debug'));
		this.log(chalk.green('    RebuilDatabase.bat'));
		this.log('\r\n');
}
});

module.exports = CaramelGenerator;
