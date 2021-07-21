using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using static System.IO.Path;
using System.Data.SqlTypes;

public static class SaveSystem
{
    private static void Save<T>(string path, T data)
    {
        FileStream filestream;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        try
        {
            filestream = new FileStream(path, FileMode.Create);
            binaryFormatter.Serialize(filestream, data);
            filestream.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }
    private static T Load<T>(string path)
    {
        //Debug.Log(path);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream filestream = new FileStream(path, FileMode.Open);
        T data = (T)binaryFormatter.Deserialize(filestream);
        filestream.Close();
        return data;
    }
    public static void SaveSoundIsEnabled(bool SoundIsEnabled)
    {
        string path = Application.persistentDataPath + "/Sound.inj";
        Save(path, SoundIsEnabled);
    }
    public static bool LoadSoundIsEnabled()
    {
        string path = Application.persistentDataPath + "/Sound.inj";
        try
        {
            if (File.Exists(path))
            {
                bool SoundIsEnabled = Load<bool>(path);
                return SoundIsEnabled;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return false;
        }
    }
    public static void SaveBestScore(string score)
    {
        string path = Application.persistentDataPath + "/BestScore.inj";
        Save(path, score);
    }
    public static string LoadBestScore()
    {
        string path = Application.persistentDataPath + "/BestScore.inj";
        try
        {
            if (File.Exists(path))
            {
                string BestScore = Load<string>(path);
                return BestScore;
            }
            else
            {
                return "0";
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return "0";
        }
    }
    public static void SaveNames(string[] names)
    {
        string path = Application.persistentDataPath + "/names.inj";
        Save(path, names);
    }
    public static string[] LoadNames()
    {
        string path = Application.persistentDataPath + "/names.inj";
        try
        {
            if (File.Exists(path))
            {
                string[] names = Load<string[]>(path);
                return names;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return null;
        }
    }
    public static void SaveScores(string[] scores)
    {
        string path = Application.persistentDataPath + "/scores.inj";
        Save(path, scores);
    }
    public static string[] LoadScores()
    {
        string path = Application.persistentDataPath + "/scores.inj";
       // Debug.Log(path);
        try
        {
            if (File.Exists(path))
            {
                string[] names = Load<string[]>(path);
                return names;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return null;
        }
    }
    public static void SaveTime(DateTime time)
    {
        string path = Application.persistentDataPath + "/Time.inj";
        List<int> list = new List<int>
        {
            time.Year,
            time.Month,
            time.Day,
            time.Hour,
            time.Minute,
            time.Second
        };
        Save(path, list);
    }
    public static DateTime LoadTime()
    {
        string path = Application.persistentDataPath + "/Time.inj";
        try
        {
            List<int> list = Load<List<int>>(path);
            DateTime dateTime = new DateTime(list[0], list[1], list[2], list[3], list[4], list[5]);
            return dateTime;

        }
        catch
        {
            return default;
        }
    }
}
