/// <binding AfterBuild='default' Clean='clean' />

var gulp = require("gulp");
var mainBowerFiles = require("main-bower-files");
var rimraf = require("rimraf");
var concat = require("gulp-concat");
var cssmin = require("gulp-cssmin");
var uglify = require("gulp-uglify");
var util = require("gulp-util");
var less = require("gulp-less");
var flatten = require("gulp-flatten");
var runSequence = require("run-sequence");

gulp.task("default", function () {
	runSequence(
		["clean"], 
		["prepare"], 
		["build"], 
		["copy"]
	);
});

gulp.task("clean", ["clean:temp", "clean:content"], function () {
});

gulp.task("clean:temp", function (cb) {
	rimraf("./wwwroot/temp", cb);
});

gulp.task("clean:content", function (cb) {
	rimraf("./content", cb);
});

gulp.task("prepare", ["prepare:bower", "prepare:bootstrapLess", "prepare:js"], function () {
});

// Move the bower files to our working directory
gulp.task("prepare:bower", function () {
	return gulp.
		src(mainBowerFiles(), { base: "bower_components" }).
		pipe(gulp.dest("./wwwroot/temp/"));
});

// Move our custom files to our working directory
gulp.task("prepare:bootstrapLess", function () {
	return gulp.
		src(["./wwwroot/bootstrap/less/*.less"], { base: "./wwwroot/bootstrap/less/" }).
		pipe(gulp.dest("./wwwroot/temp/bootstrap/less/"));
});

gulp.task("prepare:js", function () {
	return gulp.
		src(["./wwwroot/js/**/*.js"], { base: "./wwwroot/js" }).
		pipe(gulp.dest("./wwwroot/temp/js"));
});

gulp.task("build", ["build:css", "build:js"], function () {
});

// Build less
gulp.task("build:css", function () {
	return gulp.src("./wwwroot/temp/bootstrap/less/site.less").
		pipe(less()).
		on('error', function (err) {
			util.log(err);
			this.emit('end');
		}).
		//pipe(cssmin()).
		pipe(gulp.dest("./content/css/")).
		on("error", util.log);
});

// Build js
gulp.task("build:js", function () {
	gulp.
		src(
			[
				"./wwwroot/temp/jquery/**/*.js",
				"./wwwroot/temp/bootstrap/**/*.js",
				"./wwwroot/temp/bootbox.js/**/*.js",
				"./wwwroot/temp/bootstrap-datepicker/**/*.js",
				"./wwwroot/temp/jquery.maskedinput/**/*.js",
				"./wwwroot/temp/jquery-validation/**/*.js",
				"./wwwroot/temp/jquery-validation-unobtrusive/**/*.js",
				"./wwwroot/temp/typeahead.js/**/*.js",
				"./wwwroot/temp/js/**/*.js",
				"!./wwwroot/temp/**/npm.js",
				"!./wwwroot/temp/**/*.min.js",
				"!./wwwroot/temp/ckeditor/**/*.*",
			]
		).
		pipe(concat("app.js")).
		pipe(uglify()).
		pipe(gulp.dest("./content/js/"));

	gulp.
		src(
			[
				"./wwwroot/temp/ckeditor/**/*.*"
			]
		).
		pipe(gulp.dest("./content/js/ckeditor/"));
});


gulp.task("copy", ["copy:fonts", "copy:images", "copy:favicon", "copy:login"], function () {
});

// Copy fonts
gulp.task("copy:fonts", function () {
	gulp.
		src(
			[
				"./wwwroot/temp/bootstrap/dist/fonts/*.*"
			]
		).
		pipe(gulp.dest("./content/fonts"));
});

// Copy fonts
gulp.task("copy:images", function () {
	gulp.
		src(
			[
				"./wwwroot/images/*.*"
			]
		).
		pipe(gulp.dest("./content/images"));
});


// Copy favicon
gulp.task("copy:favicon", function () {
	gulp.
		src(
			[
				"./wwwroot/favicon.ico"
			]
		).
		pipe(gulp.dest("./content"));
});

// Copy favicon
gulp.task("copy:login", function () {
	gulp.
		src(
			[
				"./wwwroot/login.htm"
			]
		).
		pipe(gulp.dest("./content"));
});

gulp.task("watch", function () {
	gulp.
		watch(
			"./wwwroot/**/*.*",
			["default"]
		);
});