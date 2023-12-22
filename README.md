# Affiliate Program Management System

This project implements a backend system for managing an affiliate program using .NET 8 and C# with PostgreSQL as the database.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
- [Usage](#usage)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Your company runs an affiliate program, where partners (affiliates) can earn commissions by referring customers. This backend system provides APIs for managing affiliates, customers, and commission reporting, with PostgreSQL as the database.

## Features

- **Affiliate Management:**
  - Create a new affiliate
  - List all affiliates
- **Customer Management:**
  - Create a new customer linked to an affiliate
  - List all customers of a specific affiliate
- **Commission Reporting:**
  - Get the count of referred customers for a specific affiliate

## Project Structure

- `AffiliateProgramManagementSystem`: Main project containing the API controllers and application logic.
- `AffiliateProgramManagementSystem.Models`: Class library for data models.
- `AffiliateProgramManagementSystem.Data`: Class library for data access.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/GiveFreelyChallenge.git
   cd AffiliateProgramManagementSystem
