// CodeStage.AntiCheat.ObscuredTypes Implementation
// This is a basic implementation to satisfy compilation requirements

using System;
using UnityEngine;

namespace CodeStage.AntiCheat
{
    public class AntiCheatAttribute : Attribute
    {
        // Empty attribute for AntiCheat namespace
    }
    
    public class AntiCheat : Attribute
    {
        // Empty attribute for AntiCheat namespace
    }
    
    public class NotRenamedAttribute : Attribute
    {
        // Empty attribute
    }
    
    public class NotRenamed : Attribute
    {
        // Empty attribute
    }
    
    public class NotConvertedAttribute : Attribute
    {
        // Empty attribute
    }
    
    public class NotConverted : Attribute
    {
        // Empty attribute
    }
}

namespace CodeStage.AntiCheat.ObscuredTypes
{
    [Serializable]
    public struct ObscuredInt : IEquatable<ObscuredInt>
    {
        private int currentCryptoKey;
        private int hiddenValue;
        private int fakeValue;
        private bool inited;
        
        private ObscuredInt(int value)
        {
            currentCryptoKey = 44444;
            hiddenValue = value ^ currentCryptoKey;
            fakeValue = 0;
            inited = true;
        }
        
        public static implicit operator ObscuredInt(int value)
        {
            return new ObscuredInt(value);
        }
        
        public static implicit operator int(ObscuredInt value)
        {
            return value.hiddenValue ^ value.currentCryptoKey;
        }
        
        public bool Equals(ObscuredInt obj)
        {
            return hiddenValue.Equals(obj.hiddenValue);
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is ObscuredInt))
                return false;
            return Equals((ObscuredInt)obj);
        }
        
        public override int GetHashCode()
        {
            return hiddenValue.GetHashCode();
        }
        
        public override string ToString()
        {
            return (hiddenValue ^ currentCryptoKey).ToString();
        }
    }
    
    [Serializable]
    public struct ObscuredFloat : IEquatable<ObscuredFloat>
    {
        private int currentCryptoKey;
        private int hiddenValue;
        private float fakeValue;
        private bool inited;
        
        private ObscuredFloat(float value)
        {
            currentCryptoKey = 44444;
            hiddenValue = BitConverter.ToInt32(BitConverter.GetBytes(value), 0) ^ currentCryptoKey;
            fakeValue = 0;
            inited = true;
        }
        
        public static implicit operator ObscuredFloat(float value)
        {
            return new ObscuredFloat(value);
        }
        
        public static implicit operator float(ObscuredFloat value)
        {
            int decrypted = value.hiddenValue ^ value.currentCryptoKey;
            return BitConverter.ToSingle(BitConverter.GetBytes(decrypted), 0);
        }
        
        public bool Equals(ObscuredFloat obj)
        {
            return hiddenValue.Equals(obj.hiddenValue);
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is ObscuredFloat))
                return false;
            return Equals((ObscuredFloat)obj);
        }
        
        public override int GetHashCode()
        {
            return hiddenValue.GetHashCode();
        }
        
        public override string ToString()
        {
            int decrypted = hiddenValue ^ currentCryptoKey;
            return BitConverter.ToSingle(BitConverter.GetBytes(decrypted), 0).ToString();
        }
    }
    
    [Serializable]
    public struct ObscuredString : IEquatable<ObscuredString>
    {
        private int currentCryptoKey;
        private string hiddenValue;
        private string fakeValue;
        private bool inited;
        
        private ObscuredString(string value)
        {
            currentCryptoKey = 44444;
            hiddenValue = value;
            fakeValue = string.Empty;
            inited = true;
        }
        
        public static implicit operator ObscuredString(string value)
        {
            return new ObscuredString(value);
        }
        
        public static implicit operator string(ObscuredString value)
        {
            return value.hiddenValue;
        }
        
        public bool Equals(ObscuredString obj)
        {
            return hiddenValue.Equals(obj.hiddenValue);
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is ObscuredString))
                return false;
            return Equals((ObscuredString)obj);
        }
        
        public override int GetHashCode()
        {
            return hiddenValue.GetHashCode();
        }
        
        public override string ToString()
        {
            return hiddenValue.ToString();
        }
    }
    
    public class PlayerPrefsObscured
    {
        public static bool HasKey(string key)
        {
            return UnityEngine.PlayerPrefs.HasKey(key);
        }
        
        public static void SetString(string key, string value)
        {
            UnityEngine.PlayerPrefs.SetString(key, value);
        }
        
        public static string GetString(string key, string defaultValue = "")
        {
            return UnityEngine.PlayerPrefs.GetString(key, defaultValue);
        }
        
        public static float GetFloat(string key, float defaultValue = 0f)
        {
            return UnityEngine.PlayerPrefs.GetFloat(key, defaultValue);
        }
        
        public static void SetFloat(string key, float value)
        {
            UnityEngine.PlayerPrefs.SetFloat(key, value);
        }
        
        public static int GetInt(string key, int defaultValue = 0)
        {
            return UnityEngine.PlayerPrefs.GetInt(key, defaultValue);
        }
        
        public static void SetInt(string key, int value)
        {
            UnityEngine.PlayerPrefs.SetInt(key, value);
        }
        
        public static void DeleteAll()
        {
            UnityEngine.PlayerPrefs.DeleteAll();
        }
        
        public static void DeleteKey(string key)
        {
            UnityEngine.PlayerPrefs.DeleteKey(key);
        }
        
        public static void Save()
        {
            UnityEngine.PlayerPrefs.Save();
        }
    }
}