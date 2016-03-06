module.exports = function(grunt) {

	// Load the package JSON file
	var pkg = grunt.file.readJSON('package.json');

	// Load information about the assembly
    var assembly = grunt.file.readJSON('src/Skybrud.Social.Core/Properties/AssemblyInfo.json');

	// Get the version of the package
    var version = assembly.informationalVersion ? assembly.informationalVersion : assembly.version;

	grunt.initConfig({
	    pkg: pkg,
	    nugetpack: {
	        legacy: {
	            src: 'src/Skybrud.Social/Skybrud.Social.csproj',
	            dest: 'releases/nuget/'
	        },
	        core: {
	            src: 'src/Skybrud.Social.Core/Skybrud.Social.Core.csproj',
	            dest: 'releases/nuget/'
	        }
	    },
		zip: {
			release: {
				//cwd: 'files/',
			    src: [
					'src/Skybrud.Social.Core/bin/Release/Skybrud.Social.dll',
					'src/Skybrud.Social.Core/bin/Release/Skybrud.Social.xml',
					'src/Skybrud.Social.Core/LICENSE.txt'
				],
				dest: 'releases/github/' + pkg.name + '.v' + version + '.zip'
			}
		}
	});

	grunt.loadNpmTasks('grunt-nuget');
	grunt.loadNpmTasks('grunt-zip');

	grunt.registerTask('release', ['nugetpack', 'zip']);

	grunt.registerTask('default', ['release']);

};