# Preparation

1. install VSCode
1. add extension "C#"
1. add extension "C# Dev Kit"
1. add extension ".NET Install Tool"
1. add extension "IntelliCode for C# Dev Kit" (optional)
1. add extension "NuGet Gallery"

# Project creation

1. dotnet new sln -o SBRunScr
1. cd SBRunScr
1. dotnet new winforms -o src -n SBRunScr
1. dotnet sln add src
1. dotnet new xunit -o test -n SBRunScr.Test
1. dotnet sln add test
1. change file test/SBRunScr.Test.csproj: TargetFramework=net9.0-windows
1. dotnet add test reference src
1. add NuGet 'Sqlite'
   1. \>Nuget: Focus on NuGet View
   1. find and add 'Microsoft.Data.Sqlite'

# Description

This is tool for changing wallpapers in Windows
