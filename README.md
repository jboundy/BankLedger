## Justin Boundy Bank Ledger Challenge ##

This Readme contains some information about the project and instructions on setup.

### Technologies ###
- The project is built on dotnet core 2.1. 
- The project is a 3 layer architecture pattern, a data access layer (which is just a runtime static class), a business logic layer to validate, and front ends (command line console, web project).
- The only package that was installed was on the web project using Bower for Bootstrap (the one for nuget was deprecated).

### Instructions ###
- To run the console application you will need to open the command line, find the dll file in the bin directory, and use the command "dotnet pathtodllfile."
- To run the web application you will need to open the command line, find the csproj file, and use the command "dotnet run --project pathtocsprojfile."

### Improvements ###
- A TDD style could have been used to add more confidence in code.
- More validations and UI changes would make a better user experience.
- The console app could be seperated for better readability.
- A DI Container for the console application would be ideal.
