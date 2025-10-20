# Stunt Car Stadium - Unity Project

This is a Unity-based project for the Stunt Car Stadium game.

## Setup Instructions

### Prerequisites
- Unity Engine (version compatible with the project)
- .NET SDK 9.0 or later

### Building the Project

#### Option 1: Using Unity Editor (Recommended)
1. Open the project folder in Unity Hub
2. Select the project to open it in Unity Editor
3. Use Unity's build system to compile and run the project

#### Option 2: Using .NET CLI (Experimental)
The project has been partially configured to work with .NET CLI, but requires Unity engine assemblies to be referenced.

To compile with .NET CLI:
```bash
dotnet build
```

Note: This will likely fail due to missing Unity engine references unless Unity is properly installed and the assemblies are referenced.

### Project Structure
- `Assembly-CSharp.csproj` - Main C# project file
- `mania.sln` - Solution file
- Various `.cs` files containing game logic

### Common Issues
- Missing UnityEngine references: The project depends on Unity engine assemblies which must be available
- Unity-specific attributes and types: Many scripts use Unity-specific functionality that may not compile outside of Unity

### Development Workflow
For best results, develop using Unity Editor which provides:
- Proper IntelliSense for Unity APIs
- Integrated debugging
- Asset management
- Scene editing
- Correct compilation with Unity engine references