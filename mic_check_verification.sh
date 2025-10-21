#!/bin/bash
# mic_check_verification.sh - Script to verify stdout logging works

echo "Mic Check Verification"
echo "====================="

# Run the built executable and capture output
OUTPUT=$(timeout 10s ./LinuxStandalone -batchmode -nographics 2>&1)

# Check if we can find the mic check messages
if echo "$OUTPUT" | grep -q "mic check 1 2 1 2"; then
    echo "SUCCESS: Found 'mic check 1 2 1 2' in output!"
    echo "Output contains:"
    echo "$OUTPUT" | grep -i "mic check"
    exit 0
else
    echo "FAILURE: Did not find 'mic check 1 2 1 2' in output"
    echo "Full output:"
    echo "$OUTPUT"
    exit 1
fi