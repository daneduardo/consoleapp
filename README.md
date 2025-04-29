# Pokédex App (.NET Core MVC)
This is a simple Pokédex app built with ASP.NET Core MVC that allows users to search for a Pokémon by name and view its strengths and weaknesses based on type relationships from the [PokéAPI](https://pokeapi.co/).

---

## Features

- Search by Pokémon name
- View Pokémon types
- View which types the Pokémon is strong or weak against
- Error handling for invalid or unknown Pokémon names
- MVC architecture using dependency injection and async services

---

## Getting Started

### Prerequisites

- [.NET 7 or .NET 8 SDK](https://dotnet.microsoft.com/download)

### Running the App

```bash
git clone https://github.com/yourusername/ConsoleApp.git
cd ConsoleApp
dotnet restore
dotnet run

Then open your browser and go to:
https://localhost:5001 or http://localhost:5000

Example
Try searching for:

pikachu

bulbasaur

charizard

You'll get their types, and a list of what they are strong/weak against.