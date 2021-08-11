# Fifth Edition's support for .NET 6
Microsoft will release previews of .NET 6 regularly until the final version on Tuesday 9 November 2021.

- [Download .NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- November 9, 2021: Announcing .NET 6.0
- October, 2021: Announcing .NET 6 RC 2
- September, 2021: Announcing .NET 6 RC 1
- August 10, 2021: [Announcing .NET 6 Preview 7](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-7/)
- July 14, 2021: [Announcing .NET 6 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-6/)
- June 17, 2021: [Announcing .NET 6 Preview 5](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-5/)
- May 25, 2021: [Announcing .NET 6 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-4/)
- April 8, 2021: [Announcing .NET 6 Preview 3](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-3/)
- March 11, 2021: [Announcing .NET 6 Preview 2](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-2/)
- February 17, 2021: [Announcing .NET 6 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-1/)

## Chapters 1 to 19
After [downloading](https://dotnet.microsoft.com/download/dotnet/6.0) and installing .NET 6.0 SDK, follow the step-by-step instructions in the book and they should work as expected since the project file will automatically reference .NET 6.0 as the target framework. 

However, with .NET 6 Preview 7 and later, the default project template for console apps has changed. To retain the existing behaviour, when creating a console app, use the following command that tells the SDK to use the .NET 5.0 template:
```
dotnet new console -f net5.0
```
Then manually change the target framework from 5 to 6. You do this in the same way as you upgrade a project from the GitHub repo.

To upgrade a project in the GitHub repository from .NET 5.0 to .NET 6.0 just requires a target framework change in your project file.

Change this:
```
<TargetFramework>net5.0</TargetFramework>
```
To this:
```
<TargetFramework>net6.0</TargetFramework>
```
For projects that reference additional NuGet packages, use the latest NuGet package version, as shown in the rest of this page, instead of the version given in the book. You can search for the correct NuGet package version numbers yourself at the following link: https://www.nuget.org

## Chapter 4 - Writing, Debugging, and Testing Functions
For the `Instrumenting` project, the additional referenced NuGet packages should use the .NET 6.0 preview versions, as shown in the following markup: 
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="6.0.0-preview.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Binder" Version="6.0.0-preview.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="6.0.0-preview.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="6.0.0-preview.*" />
  </ItemGroup>

</Project>
```
For the `CalculatorLibUnitTests` project, the additional referenced NuGet packages for unit testing can use the latest versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.10.0" />
    <PackageReference Include="xunit" Version="2.4.1" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.3" />
    <PackageReference Include="coverlet.collector" Version="3.0.2" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference 
      Include="..\CalculatorLib\CalculatorLib.csproj" />
  </ItemGroup>

</Project>
```
## Chapter 11 - Working with Databases Using Entity Framework Core
For the `WorkingWithEFCore` project, the additional referenced NuGet packages should use the .NET 6.0 preview versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.0-preview.*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="6.0.0-preview.*" />
  </ItemGroup>

</Project>
```
## Chapter 12 - Querying and Manipulating Data Using LINQ
For the `LinqWithEFCore` and `Exercise02` projects, the additional referenced NuGet package should use the .NET 6.0 preview version, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.0-preview.*" />
  </ItemGroup>

</Project>
```
## Chapter 14 - Practical Applications of C# and .NET
For the `NorthwindContextLib` project, the referenced NuGet package for SQLite should use the .NET 6.0 preview version, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindEntitiesLib\NorthwindEntitiesLib.csproj" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SQLite" Version="6.0.0-preview.*" />
  </ItemGroup>

</Project>
```
## Chapter 16 - Building Websites Using the Model-View-Controller Pattern
For the `NorthwindMvc` project, the referenced NuGet packages should use the .NET 6.0 versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <UserSecretsId>aspnet-NorthwindMvc-72F8E5E5-AF15-4520-91A9-EF8090AF2961</UserSecretsId>
  </PropertyGroup>

  <ItemGroup>
    <None Update="app.db" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="6.0.0-preview.*" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.0-preview.*" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="6.0.0-preview.*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.0-preview.*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="6.0.0-preview.*" />
    
    <!-- added in Chapter 18 to call a web service -->
    <PackageReference Include="Newtonsoft.Json" Version="13.0.1" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindContextLib\NorthwindContextLib.csproj" />
  </ItemGroup>

</Project>
```
## Chapter 17 - Building Websites Using a Content Management System
Also read [Upgrading to Piranha CMS 8.1 or later](piranha-cms.md)

For the `NorthwindCms` project, the referenced NuGet packages should use the latest versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <Folder Include="wwwroot\" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.0-preview.*" />
    <PackageReference Include="Piranha" Version="9.1.1" />
    <PackageReference Include="Piranha.AspNetCore" Version="9.1.0" />
    <PackageReference Include="Piranha.AspNetCore.Identity.SQLite" Version="9.1.0" />
    <PackageReference Include="Piranha.AttributeBuilder" Version="9.1.0" />
    <PackageReference Include="Piranha.Data.EF.SQLite" Version="9.1.0" />
    <PackageReference Include="Piranha.ImageSharp" Version="9.1.0" />
    <PackageReference Include="Piranha.Local.FileStorage" Version="9.1.0" />
    <PackageReference Include="Piranha.Manager" Version="9.1.1" />
    <PackageReference Include="Piranha.Manager.TinyMCE" Version="9.1.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindEntitiesLib\NorthwindEntitiesLib.csproj" />
    <ProjectReference Include="..\NorthwindContextLib\NorthwindContextLib.csproj" />
  </ItemGroup>

</Project>
```
## Chapter 18 - Building and Consuming Web Services
For the `NorthwindService` project, the referenced NuGet packages should use the latest versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindContextLib\NorthwindContextLib.csproj" />

    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.1.4" />
    <PackageReference Include="Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore" 
                      Version="6.0.0-preview.*" />
  </ItemGroup>

</Project>
```
## Chapter 19 - Building Intelligent Apps Using Machine Learning
For the `NorthwindML` project, the referenced NuGet packages should use the latest versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="6.0.0-preview.*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.0-preview.*" />
    <PackageReference Include="Microsoft.ML" Version="1.5.4" />
    <PackageReference Include="Microsoft.ML.Recommender" Version="0.17.4" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindContextLib\NorthwindContextLib.csproj" />
    <ProjectReference Include="..\NorthwindEmployees\NorthwindEmployees.csproj" />
  </ItemGroup>

</Project>
```
