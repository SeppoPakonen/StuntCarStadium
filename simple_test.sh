#!/bin/bash

echo "Simple Unity Build and Run Script"
echo "================================="

# Set up paths
PROJECT_PATH="/common/active/sblo/Dev/StuntCarStadium"
BUILD_OUTPUT="$PROJECT_PATH/Builds/SimpleTest"
LOG_FILE="$PROJECT_PATH/simple_build.log"

echo "Project path: $PROJECT_PATH"
echo "Build output: $BUILD_OUTPUT"
echo "Log file: $LOG_FILE"

# Create build output directory
mkdir -p "$BUILD_OUTPUT"

# Try to build using existing build method
echo "Attempting to build project..."
cd "$PROJECT_PATH"

# Check if there's a working build script
if [ -f "./build.sh" ]; then
    echo "Found build.sh, attempting to use it..."
    ./build.sh 2>&1 | tee "$LOG_FILE"
else
    echo "No build.sh found, trying direct Unity build..."
    
    # Try to build with Unity directly
    UNITY_PATH="/home/sblo/Unity/6000.2.8f1/Editor/Unity"
    
    if [ -f "$UNITY_PATH" ]; then
        echo "Unity found at $UNITY_PATH"
        "$UNITY_PATH" \
            -batchmode \
            -nographics \
            -silent-crashes \
            -projectPath "$PROJECT_PATH" \
            -buildTarget StandaloneLinux64 \
            -quit \
            -logFile "$LOG_FILE"
    else
        echo "Unity not found at expected location"
        exit 1
    fi
fi

echo "Build attempt completed. Checking results..."

# Check if build was successful
if [ -f "$BUILD_OUTPUT/SimpleTest" ] || [ -f "$PROJECT_PATH/Builds/LinuxStandalone" ]; then
    echo "Build appears successful"
    
    # Try to run the executable and capture output
    EXECUTABLE=""
    if [ -f "$BUILD_OUTPUT/SimpleTest" ]; then
        EXECUTABLE="$BUILD_OUTPUT/SimpleTest"
    elif [ -f "$PROJECT_PATH/Builds/LinuxStandalone" ]; then
        EXECUTABLE="$PROJECT_PATH/Builds/LinuxStandalone"
    fi
    
    if [ -n "$EXECUTABLE" ]; then
        echo "Running executable: $EXECUTABLE"
        timeout 15s "$EXECUTABLE" -batchmode -nographics 2>&1 | tee run_output.log
        echo "Checking for mic check in output..."
        if grep -i "mic check" run_output.log; then
            echo "SUCCESS: Found 'mic check' in output!"
        else
            echo "NOT FOUND: 'mic check' not found in output"
            cat run_output.log
        fi
    else
        echo "Could not find executable to run"
    fi
else
    echo "Build failed. Check $LOG_FILE for details"
    if [ -f "$LOG_FILE" ]; then
        tail -50 "$LOG_FILE"
    fi
fi