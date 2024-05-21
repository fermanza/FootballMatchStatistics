# Football Match Statistics Analyzer

This C# console application parses a text file containing football match data and calculates statistics for each team, including total points scored. It's designed to provide insights into team performance based on match results.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Contributing](#contributing)
- [License](#license)

## Installation

1. Clone the repository to your local machine:

2. Open the project in your preferred C# IDE (such as Visual Studio or JetBrains Rider).
```
dotnet build
```
## Usage

1. Ensure that your football match data is stored in a text file with each line representing a match in the format: `Team1 Goals1, Team2 Goals2`.
   
2. Update the `filePath` variable in the `Main` method of `FileNameReader.cs` with the path to your data file.

3. Run the application.
```
dotnet run
```
4. View the output in the console, which will display the statistics for each team, including total points scored.

## Features

- Parses football match data from a text file.
- Calculates statistics for each team, including total points scored.
- Supports flexible input formats for match data.
- Simple and intuitive command-line interface.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
