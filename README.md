# Stunt Car Stadium - Unity Project

This is a Unity-based project for the Stunt Car Stadium game, reconstructed from AssetRipper extraction of the original game files.

## Project Status
Assets and scenes have been successfully imported from the AssetRipper TRO2 export directory. The Unity project structure has been restored with scene files and build settings configured.

## Setup Instructions

### Prerequisites
- Unity Engine 6000.2.8f1 (the version used in the original project) - recommended for best compatibility
- .NET SDK 9.0 or later

### Building the Project

#### Option 1: Using Unity Editor (Recommended)
1. Open Unity Hub
2. Click "Add" and navigate to this project directory
3. Open the project with Unity 6000.2.8f1
4. In the Unity Editor, go to File -> Build Settings
5. Review that scenes in `Assets/!scenes/` and `Assets/Scenes/` are included in the build
6. Select your target platform (Windows, Linux, or macOS)
7. Click "Build" and choose an output directory

#### Option 2: Using Unity Command Line
If Unity is installed, you can build from command line:

```bash
# For Linux standalone build
/path/to/Unity -batchmode -projectPath "/common/active/sblo/Dev/StuntCarStadium" -buildTarget StandaloneLinux64 -executeMethod BuildScript.PerformBuild -quit

# For Windows standalone build  
/path/to/Unity -batchmode -projectPath "/common/active/sblo/Dev/StuntCarStadium" -buildTarget StandaloneWindows64 -executeMethod BuildScript.PerformBuild -quit

# For macOS standalone build
/path/to/Unity -batchmode -projectPath "/common/active/sblo/Dev/StuntCarStadium" -buildTarget StandaloneOSX -executeMethod BuildScript.PerformBuild -quit
```

#### Option 3: Using the Build Script
A BuildScript.cs is available in `Assets/Editor/` which can be accessed in the Unity Editor under the "Build" menu or via command-line execution.

### Available Scenes
- `Assets/!scenes/!1.unity` - Main menu scene
- `Assets/!scenes/!2carselect.unity` - Car selection scene
- `Assets/!scenes/!2game.unity` - Game scene
- `Assets/!scenes/level.unity` - Level scene
- `Assets/!scenes/levelloader.unity` - Level loader scene
- `Assets/Scenes/level4.unity` - Level 4 scene

### Project Structure
- `Assembly-CSharp.csproj` - Main C# project file
- `mania.sln` - Solution file
- `Assets/` - All game assets including scenes, textures, materials, etc. (proper Unity Assets folder)
- `ProjectSettings/` - Unity project configuration
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

### Notes
- The project was reconstructed using AssetRipper from the TRO2 directory
- Some assets or code may have been slightly modified during the extraction process
- The build process requires Unity installation and may not work with just .NET CLI alone
