#!/bin/bash

# Navigate to the Builds directory
cd Builds

# Set environment variables for debugging
export UNITY_LOG_LEVEL=debug
export DEBUG=1

# Print diagnostic information
echo "=== Diagnostic Information ==="
echo "Current directory: $(pwd)"
echo "LinuxPlayer exists: $(if [ -f LinuxPlayer ]; then echo "Yes"; else echo "No"; fi)"
echo "LinuxStandalone_Data exists: $(if [ -d LinuxStandalone_Data ]; then echo "Yes"; else echo "No"; fi)"
echo "Managed directory exists: $(if [ -d LinuxStandalone_Data/Managed ]; then echo "Yes ($(ls -la LinuxStandalone_Data/Managed/ | wc -l) files)"; else echo "No"; fi)"
echo "MonoBleedingEdge directory exists: $(if [ -d LinuxStandalone_Data/MonoBleedingEdge ]; then echo "Yes"; else echo "No"; fi)"
echo ""
echo "=== Running Game ==="

# Run the game
./LinuxPlayer