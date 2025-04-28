using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace authguard;

public class json_wrapper
{
    private DataContractJsonSerializer serializer;

    private object current_object;

    public static bool is_serializable(Type to_check)
    {
        return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), inherit: true);
    }

    public json_wrapper(object obj_to_work_with)
    {
        current_object = obj_to_work_with;
        Type type = current_object.GetType();
        serializer = new DataContractJsonSerializer(type);
        if (!is_serializable(type))
        {
            throw new Exception($"the object {current_object} isn't a serializable");
        }
    }

    public string to_json_string()
    {
        using MemoryStream memoryStream = new MemoryStream();
        serializer.WriteObject(memoryStream, current_object);
        memoryStream.Position = 0L;
        using StreamReader streamReader = new StreamReader(memoryStream);
        return streamReader.ReadToEnd();
    }

    public object string_to_object(string json)
    {
        byte[] bytes = Encoding.Default.GetBytes(json);
        using MemoryStream stream = new MemoryStream(bytes);
        return serializer.ReadObject(stream);
    }

    public dynamic string_to_dynamic(string json)
    {
        return string_to_object(json);
    }

    public T string_to_generic<T>(string json)
    {
        return (T)string_to_object(json);
    }

    public dynamic to_json_dynamic()
    {
        return string_to_object(to_json_string());
    }
}
