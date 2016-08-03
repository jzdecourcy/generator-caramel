var findup = require('findup-sync');
var path = require('path');
var abstractionsStr = '.Abstractions';

function getBaseNamespace(fs) {
  'use strict';

  var projectSolutionPath = module.exports.getProjectSolutionPath();

  if (!projectSolutionPath) {
    return 'MyNamespace';
  }

  var solutionPath = path.resolve(path.dirname(projectSolutionPath));
  var namespace = path.basename(solutionPath);

  return namespace;
}

module.exports = {
  // Get the namespace relative to the cwd
  getNamespace: function(fs) {
    'use strict';

    var baseNamespace = getBaseNamespace(fs);
    var cwd = process.cwd();
    var baseDirectory = path.resolve(path.dirname(this.getProjectSolutionPath()));
    var relativePath = path.relative(baseDirectory, cwd);
    if (relativePath) {
      return relativePath.split(path.sep).join('.');
    }

    return baseNamespace;
  },
  getProjectSolutionPath: function() {
    'use strict';

    return findup('*.sln');
  },  
  getProjectJsonPath: function() {
    'use strict';

    return findup('project.json');
  },
  getProjectJson: function(fs) {
    'use strict';

    var path = module.exports.getProjectJsonPath();
    if (!path) {
      return {};
    }

    return fs.readJSON(path, {});
  },
  getGlobalJsonPath: function() {
    'use strict';

    return findup('global.json');
  },
  getGlobalJson: function(fs) {
    'use strict';

    var path = module.exports.getGlobalJsonPath(path);
    if (!path) {
      return {};
    }

    return fs.readJSON(path, {});
  },
};
