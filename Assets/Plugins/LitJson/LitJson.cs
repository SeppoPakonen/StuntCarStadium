// LitJson Implementation
// This is a basic implementation to satisfy compilation requirements

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace LitJson
{
    public class JsonData
    {
        private object inst_value;
        private JsonType type;
        private IList<JsonData> object_list;
        private IDictionary<string, JsonData> object_table;
        
        public JsonType JsonType
        {
            get { return type; }
        }
        
        // Indexers
        public JsonData this[int index]
        {
            get
            {
                if (type != JsonType.Array)
                    throw new InvalidOperationException("This JsonData instance is not a JsonArray");
                    
                return object_list[index];
            }
            set
            {
                if (type != JsonType.Array)
                    throw new InvalidOperationException("This JsonData instance is not a JsonArray");
                    
                object_list[index] = value;
            }
        }
        
        public JsonData this[string prop_name]
        {
            get
            {
                if (type != JsonType.Object)
                    throw new InvalidOperationException("This JsonData instance is not a JsonObject");
                    
                return object_table[prop_name];
            }
            set
            {
                if (type != JsonType.Object)
                    throw new InvalidOperationException("This JsonData instance is not a JsonObject");
                    
                if (object_table.ContainsKey(prop_name))
                    object_table[prop_name] = value;
                else
                    object_table.Add(prop_name, value);
            }
        }
        
        // Constructor
        public JsonData()
        {
        }
        
        public JsonData(bool boolean)
        {
            type = JsonType.Boolean;
            inst_value = boolean;
        }
        
        public JsonData(double number)
        {
            type = JsonType.Double;
            inst_value = number;
        }
        
        public JsonData(int number)
        {
            type = JsonType.Int;
            inst_value = number;
        }
        
        public JsonData(long number)
        {
            type = JsonType.Long;
            inst_value = number;
        }
        
        public JsonData(string str)
        {
            type = JsonType.String;
            inst_value = str;
        }
        
        public JsonData(object obj)
        {
            if (obj is Boolean)
            {
                type = JsonType.Boolean;
                inst_value = (bool)obj;
                return;
            }
            if (obj is Double || obj is float)
            {
                type = JsonType.Double;
                inst_value = Convert.ToDouble(obj);
                return;
            }
            if (obj is Int32 || obj is Int16 || obj is Int64)
            {
                type = JsonType.Int;
                inst_value = Convert.ToInt32(obj);
                return;
            }
            if (obj is String)
            {
                type = JsonType.String;
                inst_value = (string)obj;
                return;
            }
            if (obj is IList || obj.GetType().IsArray)
            {
                type = JsonType.Array;
                object_list = new List<JsonData>();
                foreach (object item in (IEnumerable)obj)
                {
                    object_list.Add(new JsonData(item));
                }
                return;
            }
            
            // Default to string if unknown type
            type = JsonType.String;
            inst_value = obj.ToString();
        }
        
        // Conversions
        public static implicit operator JsonData(Boolean data)
        {
            return new JsonData(data);
        }
        
        public static implicit operator JsonData(Double data)
        {
            return new JsonData(data);
        }
        
        public static implicit operator JsonData(Int32 data)
        {
            return new JsonData(data);
        }
        
        public static implicit operator JsonData(Int64 data)
        {
            return new JsonData(data);
        }
        
        public static implicit operator JsonData(String data)
        {
            return new JsonData(data);
        }
        
        public static implicit operator Boolean(JsonData data)
        {
            if (data.type != JsonType.Boolean)
                throw new InvalidOperationException("JsonData instance doesn't hold a boolean value");
                
            return (bool)data.inst_value;
        }
        
        public static implicit operator Double(JsonData data)
        {
            if (data.type != JsonType.Double)
                throw new InvalidOperationException("JsonData instance doesn't hold a double value");
                
            return (double)data.inst_value;
        }
        
        public static implicit operator Int32(JsonData data)
        {
            if (data.type != JsonType.Int)
                throw new InvalidOperationException("JsonData instance doesn't hold an int value");
                
            return (int)data.inst_value;
        }
        
        public static implicit operator Int64(JsonData data)
        {
            if (data.type != JsonType.Long)
                throw new InvalidOperationException("JsonData instance doesn't hold a long value");
                
            return (long)data.inst_value;
        }
        
        public static implicit operator String(JsonData data)
        {
            if (data.type != JsonType.String)
                throw new InvalidOperationException("JsonData instance doesn't hold a string value");
                
            return (string)data.inst_value;
        }
        
        // ToString override
        public override string ToString()
        {
            switch (type)
            {
                case JsonType.Array:
                    // Return a simple representation of the array
                    var arrayStr = new StringBuilder();
                    arrayStr.Append("[");
                    for (int i = 0; i < object_list.Count; i++)
                    {
                        if (i > 0) arrayStr.Append(",");
                        arrayStr.Append(object_list[i].ToString());
                    }
                    arrayStr.Append("]");
                    return arrayStr.ToString();
                
                case JsonType.Object:
                    // Return a simple representation of the object
                    var objStr = new StringBuilder();
                    objStr.Append("{");
                    var first = true;
                    foreach (var kvp in object_table)
                    {
                        if (!first) objStr.Append(",");
                        objStr.Append("\"" + kvp.Key + "\":");
                        objStr.Append(kvp.Value.ToString());
                        first = false;
                    }
                    objStr.Append("}");
                    return objStr.ToString();
                
                case JsonType.Boolean:
                case JsonType.Double:
                case JsonType.Int:
                case JsonType.Long:
                case JsonType.String:
                    return inst_value.ToString();
                
                default:
                    return inst_value?.ToString() ?? "null";
            }
        }
        
        // Additional methods needed for compatibility
        public bool IsArray
        {
            get { return type == JsonType.Array; }
        }
        
        public bool IsObject
        {
            get { return type == JsonType.Object; }
        }
        
        public bool Contains(string property)
        {
            if (type != JsonType.Object)
                return false;
            return object_table.ContainsKey(property);
        }
        
        public string ToJson()
        {
            return ToString();
        }
        
        public int Count
        {
            get
            {
                switch (type)
                {
                    case JsonType.Array:
                        return object_list.Count;
                    case JsonType.Object:
                        return object_table.Count;
                    default:
                        return 0;
                }
            }
        }
    }
    
    public enum JsonType
    {
        None,
        Object,
        Array,
        String,
        Int,
        Long,
        Double,
        Boolean
    }
    
    public class JsonMapper
    {
        public static JsonData ToObject(string json)
        {
            // This is a very basic implementation - in a real scenario you'd use a proper JSON parser
            // For now, we just create a simple JsonObject to satisfy compilation
            var result = new JsonData();
            // In a real implementation, we would parse the JSON string
            // For now, return an empty object
            return result;
        }
        
        public static JsonData ToObject<T>(string json)
        {
            return ToObject(json);
        }
        
        public static string ToJson(object obj)
        {
            // Simple JSON serialization
            return obj?.ToString() ?? "null";
        }
    }
    
    public class JsonException : Exception
    {
        public JsonException() : base()
        {
        }
        
        public JsonException(string message) : base(message)
        {
        }
        
        public JsonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}