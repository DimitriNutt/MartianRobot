# Martian Robot

A web-based simulation for controlling robots on Mars. Input commands to navigate robots on a grid while avoiding danger zones marked by previous "lost" robots.

## Features

- Web interface for robot command input
- Robot navigation with L (left), R (right), F (forward) commands
- Scent system - robots avoid positions where others were lost
- Real-time position tracking and results

## Quick Start

**Prerequisites:** [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

- The solution can be opened in and run from Visual Studio 2022 or from the CLI

```bash
git clone [repository-url]
cd MartianRobot
dotnet run --project MartianRobot
```

Navigate to `http://localhost:5053`

## Usage

### Input Format
```
5 3          # Grid size (X Y)
1 1 E        # Robot position (X Y Orientation)
RFRFRFRF     # Commands
3 2 N        # Next robot...
FRRFLLFFRRFLL
```

### Commands
- **L**: Turn left
- **R**: Turn right  
- **F**: Move forward

### Orientations
- **N**: North, **E**: East, **S**: South, **W**: West

### Example
**Input:**
```
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL
```

**Output:**
```
1 1 E
3 3 N LOST
2 3 S
```

## How It Works

- Robots navigate on a rectangular grid (max 50x50)
- When a robot falls off the grid, it's marked "LOST" and leaves a scent
- Future robots ignore forward commands that would lead to scented positions
- Grid coordinates start at (0,0) in the bottom-left corner

## Technology

- ASP.NET Core 8.0
- C# with Razor Pages
- Bootstrap CSS
