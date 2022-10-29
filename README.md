# VitalityExercise
SpecFlow .net Framework for Temperatures compare execise + JSON describe yourself exercise

#About Solution
```
-This is a SpecFlow .net Playwright Framework.
This Solution uses a SpecFlow BDD feature file to compare Bournemouth's high temperature against low temperature on the official BBC Weather's website.  
A corresponding step defination file is liked to the above file to run the test.
```
Required dependencies
```
-Microsoft Playwright (https://playwright.dev/dotnet/)

-.net 6.0

-SpecFlow
```
First Time / After Each Playwright Upgrade

When you run this project for the first time (or when you've upgraded Playwright) you'll have to install the browsers that Playwright uses to render everything. To do this, build the project, then run:
```
Install required browsers - replace netX with actual output folder name, f.ex. net6.0. e.g. pwsh .\bin\Debug\net5.0\playwright.ps1 install
pwsh bin\Debug\netX\playwright.ps1 install
```

Before running the above command make sure you have powershell version 7 or above installed in your machine.
In the powershell terminal change directory to the project/solution folder e.g. cd "C:\Users\mbcha\Projects\PlaywrightTests"  (Ensure the path is between double quotes)
Run the above command.

If that doesn't work, (specifically with a type error) make sure you're using an up to date version of Powershell. Powershell 7.2.2 has been known to work, at least as of 29/10/2022
If this doesn't seem to do anything, and you're sure you've changed Playwright, try forcing a rebuild of the project and then try again.

