// VoiceChat Utils Implementation
// This is a basic implementation to satisfy compilation requirements

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoiceChat
{
    public class BitStream
    {
        private List<byte> data = new List<byte>();
        private int position = 0;
        
        public void Serialize(ref int value)
        {
            // Serialize integer
        }
        
        public void Serialize(ref float value)
        {
            // Serialize float
        }
        
        public void Serialize(ref bool value)
        {
            // Serialize boolean
        }
        
        public void Serialize(ref string value)
        {
            // Serialize string
        }
        
        public void Serialize(ref Vector3 value)
        {
            // Serialize vector3
        }
        
        public void Serialize(ref Quaternion value)
        {
            // Serialize quaternion
        }
    }
}