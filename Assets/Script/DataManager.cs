using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonFx.Json;
public class DataManager {
    /// <summary>
    /// 保存一个对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="data"></param>
   public static void SaveData<T>(string key,T data)
   {
        string json = JsonWriter.Serialize(data);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
   }
  
    /// <summary>
    /// 从本地存储获取一个对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
   public static T LoadData<T>(string key)
   {
        string json = PlayerPrefs.GetString(key);
        return JsonReader.Deserialize<T>(json);
    }
}
