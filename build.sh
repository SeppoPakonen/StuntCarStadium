#!/bin/bash
# build.sh - Build script for Stunt Car Stadium

echo "Stunt Car Stadium Build Script"
echo "=============================="

echo "Project Info:"
echo "- Unity Version: 6000.2.8f1"
echo "- Available Scenes: 6 scene files found"
echo "  - Assets/!scenes/!1.unity"
echo "  - Assets/!scenes/!2carselect.unity"  
echo "  - Assets/!scenes/!2game.unity"
echo "  - Assets/!scenes/level.unity"
echo "  - Assets/!scenes/levelloader.unity"
echo "  - Assets/Scenes/level4.unity"
echo ""

echo "Attempting to build the project using Unity located at ~/Unity/6000.2.8f1/Editor/Unity..."
echo ""

UNITY_PATH="$HOME/Unity/6000.2.8f1/Editor/Unity"

if [ ! -f "$UNITY_PATH" ]; then
    echo "Error: Unity executable not found at $UNITY_PATH"
    echo "Please verify Unity 6000.2.8f1 is installed in ~/Unity/"
    exit 1
fi

PROJECT_PATH="/common/active/sblo/Dev/StuntCarStadium"
BUILD_PATH="$PROJECT_PATH/Builds/LinuxStandalone"

echo "Creating build directory if it doesn't exist..."
mkdir -p "$BUILD_PATH"

echo "Starting Unity build process..."
echo "Unity executable: $UNITY_PATH"
echo "Project path: $PROJECT_PATH"
echo "Build target: StandaloneLinux64"
echo ""

# Run Unity in batchmode to build the project
"$UNITY_PATH" \
  -batchmode \
  -nographics \
  -silent-crashes \
  -projectPath "$PROJECT_PATH" \
  -buildTarget StandaloneLinux64 \
  -executeMethod BuildScript.PerformBuild \
  -quit

BUILD_RESULT=$?

if [ $BUILD_RESULT -eq 0 ]; then
    echo ""
    echo "Build process completed successfully!"
    echo "Check the Builds/LinuxStandalone directory for the built executable."
    if [ -d "$BUILD_PATH" ] && [ "$(ls -A $BUILD_PATH)" ]; then
        echo "Build output files:"
        ls -la "$BUILD_PATH"
    fi
else
    echo ""
    echo "Build process failed with exit code: $BUILD_RESULT"
    echo "Check Unity logs for more information."
fi

echo ""
echo "For alternative build options:"
echo "1. For Windows build:"
echo "   \"$UNITY_PATH\" -batchmode -projectPath \"$PROJECT_PATH\" -buildTarget StandaloneWindows64 -executeMethod BuildScript.PerformBuild -quit"
echo ""
echo "2. For macOS build:"
echo "   \"$UNITY_PATH\" -batchmode -projectPath \"$PROJECT_PATH\" -buildTarget StandaloneOSX -executeMethod BuildScript.PerformBuild -quit"
echo ""
echo "3. If using .NET CLI (experimental, will likely fail without Unity references):"
echo "   dotnet build"
echo ""
echo "For best results, use Unity Editor 6000.2.8f1 for development and building."
