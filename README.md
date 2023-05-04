# Configuration Ec2 Metadata
[![Actions Status](https://github.com/ZenExtensions/configuration-ec2-metadata/workflows/.NET%20Core%20Publish/badge.svg)](https://github.com/ZenExtensions/configuration-ec2-metadata/actions) [![Current Version](https://img.shields.io/badge/Version-1.1.2-brightgreen?logo=nuget&labelColor=30363D)](./CHANGELOG.md#100---2023-05-05)

# Overview
Load Ec2 Instance tags as configuration in your .Net Application

## Installing
You can add the package to your project using dotnet core CLI
```bash
dotnet add package ZenExtensions.Configuration.Ec2Metadata
```
or by package manager console in Visual Studio
```bash
Install-Package ZenExtensions.Configuration.Ec2Metadata
```
Please refer to [Changelog](./CHANGELOG.md) for changes between versions.

## Usage
Add ec2 metadata configuration source

```csharp
using ZenExtensions.Configuration.Ec2Metadata;
configurationBuilder.AddEc2Metadata();
```

Now you can get tag values using 
```csharp
var instanceName = configuration.GetValue<string>("Tags:Name");
```