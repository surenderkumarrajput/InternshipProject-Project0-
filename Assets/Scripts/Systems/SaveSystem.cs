using UnityEngine;
using System.Collections;
using System.IO;
public static class SaveSystem 
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    //Check if Directory Exists or not.
    public static void Inint()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }
    //Writes Data to File
    public static void save(string Savestring,string FileName)
    {
        File.WriteAllText(SAVE_FOLDER + FileName , Savestring);
    }
    //Reads Data from File
    public static string Load(string FileName)
    {
        if (File.Exists(SAVE_FOLDER + FileName))
        {
            string LoadString = File.ReadAllText(SAVE_FOLDER + FileName);
            return LoadString;
        }
        else
        {
            return null;
        }
    }
}