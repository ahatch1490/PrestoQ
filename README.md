# PrestoQ Parsing Exercise

Demonstration product parsing library. 

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/0db0b235c0a6437ebb74da848d725679)](https://app.codacy.com/app/ahatch1490/PrestoQ?utm_source=github.com&utm_medium=referral&utm_content=ahatch1490/PrestoQ&utm_campaign=Badge_Grade_Dashboard)     

[![Build status](https://ci.appveyor.com/api/projects/status/fldhshpqaf4gwk9s?svg=true)](https://ci.appveyor.com/project/ahatch1490/prestoq)

## Getting Started

### Prerequisites

Need to install .netcore Mac, Linux or Windows [here](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial#linuxubunt).

### Installing

Build from the solution directroy.
```
$> dotnet build
```

From PrestoQ.Cmd directory run CMD example application

```
$> dotent run ../path/to/an/example/product_file.txt
```
This should create or append a group of products into a 'product-output.json' file. This file will be located in the PrestoQ.Cmd project folder.

## Running the tests

From the PrestoQ.Parser.Test project folder 
```
$> dotent test 
```

## Built With

* [Codacy](https://www.codacy.com) Code Analytics         
* [Nuget](https://nuget.com) - Dependency Management
* [AppVoyer](https://ci.appveyor.com) - CI 

## Authors

* [Anthony Hatch](https://www.linkedin.com/in/anthony-hatch-8481b613/) - *Initial work* - 


## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

