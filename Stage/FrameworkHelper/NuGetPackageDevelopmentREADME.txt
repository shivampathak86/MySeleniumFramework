Follow the steps at this link to create a NuGet Package:

https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package

Specifically:

***NOTE - Make sure that your project has been built so the latest changes are included in the NuGet package when it is created

1. Compile your project in the way you desire it to be setup (i.e. my project includes all of our reporting and logging classes)
2. Open a command prompt from the directory that includes the .csproj file for your project
--- Make sure that you check out .nuspec file in the solution so that we can modify it.
3. Run the command ".\NuGet.exe spec -force". This will create a .nuspec file where you can enter information about the NuGet package
(this information is displayed in the NuGet package manager, and helps when searching for it)
--- Update all of the metadata in the .nuspec XML file, authors and description is required
4. Once the .nuspec file has information entered into it, run the command .\NuGet.exe pack from the command prompt
5. The command in step 4 will create .nupkg file, which represents the package that can be published to NuGet (or used locally)

To use the NuGet package locally without publishing it to NuGet:

1. In Visual Studio, open Package Manager Settings under Tools -> NuGet Package Manager
2. Click Package Sources
3. Click the plus button to add a new Package Source
4. Give the Package Source a Name
5. Specify the Source by clicking the ... (elipses) button, and specify the folder where your .nupkg file is located
6. Click Ok and close the Package Manager Settings window
7. Now to add the local NuGet package to a project you want to use it, manage the package settings for your project
8. Under the Browse section, select the Package Source name you defined in step 4 from the Package source dropdown
9. The local NuGet package should be available for installation into your project (installs following the normal
NuGet installation process)

To get NuGet package file from Source Control:

1. Get latest version of AutomationLogging
2. Use the AutomationTestReporterAndLoggerForNunit.<Version Number> with the "Use NuGet package locally" steps above

Publishing - Read Me Steps in Progress