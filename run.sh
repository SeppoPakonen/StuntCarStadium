#!/bin/bash

# Navigate to the Builds directory
cd Builds

# Run the game with maximum verbose logging
export UNITY_LOG_LEVEL=debug
export MONO_LOG_LEVEL=debug
./LinuxStandalone -logFile - -verbose -force-opengl -force-glcore -force-single-instance