# Stunt Car Stadium - Imported Unity Project

## Project Structure

The Unity project has been successfully imported with:
- Scene files located in `Assets/!scenes/` and `Assets/Scenes/` directories
- Original extracted asset files are preserved in the `original_extracted_assets/` directory
- Build settings have been configured with the available scenes

## Available Scenes

- `Assets/!scenes/!1.unity` - Main menu scene
- `Assets/!scenes/!2carselect.unity` - Car selection scene
- `Assets/!scenes/!2game.unity` - Game scene
- `Assets/!scenes/level.unity` - Level scene
- `Assets/!scenes/levelloader.unity` - Level loader scene
- `Assets/Scenes/level4.unity` - Level 4 scene

## Building the Project

To build the project, you need Unity 6000.2.8f1 (the version used in the original project).

### Option 1: Using Unity Editor
1. Open Unity Hub
2. Click "Add" and navigate to this project directory
3. Open the project with Unity 6000.2.8f1
4. In the Unity Editor, go to File -> Build Settings
5. Select your target platform (Windows, Linux, or macOS)
6. Click "Build" and choose an output directory

### Option 2: Using Unity Command Line
If Unity is installed, you can build from command line:

```bash
# For Linux standalone build
/path/to/Unity -batchmode -projectPath "/common/active/sblo/Dev/StuntCarStadium" -buildTarget StandaloneLinux64 -executeMethod BuildScript.PerformBuild -quit

# For Windows standalone build  
/path/to/Unity -batchmode -projectPath "/common/active/sblo/Dev/StuntCarStadium" -buildTarget StandaloneWindows64 -executeMethod BuildScript.PerformBuild -quit

# For macOS standalone build
/path/to/Unity -batchmode -projectPath "/common/active/sblo/Dev/StuntCarStadium" -buildTarget StandaloneOSX -executeMethod BuildScript.PerformBuild -quit
```

### Option 3: Using the Build Script
A BuildScript.cs is available in `Assets/Editor/` which can be accessed in the Unity Editor under the "Build" menu.

