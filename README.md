<h1 align="center">
Blood Bank Management</h1>
<p align="center">
  <a href="https://github.com/MarcusCFarias/BloodBankManagement/issues"><img alt="number of issues for the repository" src="https://img.shields.io/github/issues/marcuscfarias/BloodBankManagement?color=red&label=Issues&style=for-the-badge" target="_blank" /></a>
  <a href="https://github.com/MarcusCFarias/BloodBankManagement"><img alt="the size of the repo in kb" src="https://img.shields.io/github/repo-size/marcuscfarias/BloodBankManagement?color=orange&label=Repo-Size&style=for-the-badge" target="_blank" /></a>
  <a href="https://opensource.org/licenses/MIT"><img alt="licence the repo is published under" src="https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge" target="_blank" /></a>
 <a href="https://github.com/MarcusCFarias/BloodBankManagement/graphs/contributors"><img alt="the number of contributers on the repo" src="https://img.shields.io/github/contributors/marcuscfarias/BloodBankManagement?color=brightgreen&label=Contributors&style=for-the-badge" target="_blank" /></a>
  <a href="https://github.com/MarcusCFarias/BloodBankManagement/network/members"><img alt="total number of times the repo has been forked" src="https://img.shields.io/github/forks/marcuscfarias/BloodBankManagement?color=blue&label=Forks&style=for-the-badge" target="_blank" /></a>
  <a href="https://github.com/MarcusCFarias/BloodBankManagement/stargazers"><img alt="total number of times the repo has been starred" src="https://img.shields.io/github/stars/marcuscfarias/BloodBankManagement?color=blueviolet&label=Stars&style=for-the-badge" target="_blank" /></a>
</p>

## 1. Screenshots or Demo
![ApiEndpoints](https://github.com/MarcusCFarias/BloodBankManagement/assets/77988058/9e3d01aa-e242-43b7-938c-0ffccc13fd84)
![AppOnDocker](https://github.com/MarcusCFarias/BloodBankManagement/assets/77988058/0c82e2fe-8779-42dd-9746-32f50c32f51b)
![UnitTestsReport](https://github.com/MarcusCFarias/BloodBankManagement/assets/77988058/c1f96d4b-e2f5-420e-bf49-38d56620bd2f)
![Demo](https://github.com/MarcusCFarias/BloodBankManagement/assets/77988058/ff870d9b-ca20-48af-ae2c-37fc1a1d8fc7)

## 2. About this project
#### 2.1 Description

#### 2.2 Why?
BloodBankManagement is a project designed in ASP.NET Core to practice new trends and technologies in software development. It offers hands-on experience with modern tools and methodologies, promoting growth and adaptability. Additionally, the project enables the exploration of efficient coding practices and project management skills, enhancing my ability to deliver high-quality software solutions.

## 3. Functionalities
- Create and get Donor
- Validate CEP with external API
- CSV report with donor's activity
- Create donation
- CSV report from the last 30 days of donation
- Update storage
- CSV report from the actual state of storage
- Global Error handling with middleware
- Send email when the storage is above minimum
- Some business rules on domain

## 4. Technologies Used, Frameworks, Patterns and Architecture
- ASP .NET 8
- Entity Framework Core
- SQL Server
- Docker Container
- Repository Pattern
- Result Pattern
- Domain Event Pattern
- Migrations
- Fluent Validation
- CQRS using MediatR
- Clean Architecture
- Send emails with MailKit
- Unit Tests using xUnit, Bogus, FluentAssertions, Coverlet and Moq

## 5. Running on your machine
- .NET SDK (version 8.0)
- Docker Desktop

## 6. Getting started
#### 6.1 Clone the repository
```
git clone https://github.com/MarcusCFarias/BloodBankManagement.git
```
#### 6.2 Navigate to the project directory
```
cd BloodBankManagement
```

#### 6.3 Run docker compose file
```
docker compose up --build -d
```

## 7. Contribuiting
You can send how many PR's do you want, I'll be glad to analyse and accept them! And if you have any question about the project just ask...

## 8. License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/MarcusCFarias/BloodBankManagement/blob/main/LICENSE) file for details
