## Metrics

[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=leafar396_ZbwCarRentApi&metric=ncloc)](https://sonarcloud.io/dashboard?id=leafar396_ZbwCarRentApi)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=leafar396_ZbwCarRentApi&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=leafar396_ZbwCarRentApi)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=leafar396_ZbwCarRentApi&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=leafar396_ZbwCarRentApi)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=leafar396_ZbwCarRentApi&metric=security_rating)](https://sonarcloud.io/dashboard?id=leafar396_ZbwCarRentApi)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=leafar396_ZbwCarRentApi&metric=bugs)](https://sonarcloud.io/dashboard?id=leafar396_ZbwCarRentApi)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=leafar396_ZbwCarRentApi&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=leafar396_ZbwCarRentApi)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=leafar396_ZbwCarRentApi&metric=coverage)](https://sonarcloud.io/dashboard?id=leafar396_ZbwCarRentApi)

[Link to Sonar](https://sonarcloud.io/dashboard?id=leafar396_ZbwCarRentApi)

## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

* MS Visual Studio
* MSSQL-Datenbank
    * Your Windows User must be allowed to use the DB --> (trusted connection=true)

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/leafar396/ZbwCarRentApi.git
   ```
   
2. Open with MS Visual Studio
   
3. Open the Package Manager Console

   ```sh
   update-database
   ```
4. Start with IIS Express


## Documentation

<a href="https://leafar396.github.io/ZbwCarRentApi/index.html"><strong>Link to published Documentation</strong></a>

_[Documentation in Source Code](docs/index.md)_

install mkdocs
```sh
pip install mkdocs
```
install mkdocs material template
```sh
pip install mkdocs-material
```
serve locally
```sh
mkdocs serve
```
Publishing to github
```sh
mkdocs gh-deploy --force
```