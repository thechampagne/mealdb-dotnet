# MealDB

[![](https://img.shields.io/github/v/tag/thechampagne/mealdb-dotnet?label=version)](https://github.com/thechampagne/mealdb-dotnet/releases/latest) [![](https://img.shields.io/github/license/thechampagne/mealdb-dotnet)](https://github.com/thechampagne/mealdb-dotnet/blob/main/LICENSE)

TheMealDB API client for **.NET**

### Download
[NuGet](https://www.nuget.org/packages/Meal/)

**.NET CLI**
```
dotnet add package Meal
```
**NuGet CLI**
```
nuget install Meal
```
**Package Manager**
```
Install-Package Meal
```

### Example

```csharp
static void Main(string[] args)
{
    foreach (var i in MealAPI.Search("Shawarma"))
    {
        Console.WriteLine(i.strMeal);
    }
}
```

### License

MealDB is released under the [Apache License 2.0](https://github.com/thechampagne/mealdb-dotnet/blob/main/LICENSE).

```
 Copyright 2022 XXIV

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
```