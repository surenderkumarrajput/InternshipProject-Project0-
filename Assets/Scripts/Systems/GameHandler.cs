using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public GameObject[] Object_ToSpawn;

    public TextMeshProUGUI FileName;

    //Spawnner Spawnner_Ref;

    public InputField Input;

    void Start()
    {
        SaveSystem.Inint();
       // Spawnner_Ref = GetComponent<Spawnner>();
        if (FileName != null)
        {
            ShowSaveFiles();
        }
        else
        {
            return;
        }
    }
    //Save Function
    public void Save()
    {

        SaveObject Save_Object = new SaveObject
        {
            Save_Pos = Spawnner.Go_Pos
        };

        string JsonString = JsonUtility.ToJson(Save_Object);
        SaveSystem.save(JsonString,Input.text);
    }
    //Load Function
    public void Load(GameObject LoadButton)
    {
        string LoadString = SaveSystem.Load(Input.text);
        if (LoadString != null)
        {
            SaveObject Save_Object = JsonUtility.FromJson<SaveObject>(LoadString);
            foreach (var item in Save_Object.Save_Pos)
            {
                if(Object_ToSpawn[0].GetComponent<Object_Ref>().Object_Info_Struct.Obj_Type==item.Obj_Type)
                {
                    Instantiate(Object_ToSpawn[0], new Vector2(item.Object_Position.x, item.Object_Position.y), Quaternion.identity);
                }
                else if (Object_ToSpawn[1].GetComponent<Object_Ref>().Object_Info_Struct.Obj_Type == item.Obj_Type)
                {
                    Instantiate(Object_ToSpawn[1], new Vector2(item.Object_Position.x, item.Object_Position.y), Quaternion.identity);
                }
                else if (Object_ToSpawn[2].GetComponent<Object_Ref>().Object_Info_Struct.Obj_Type == item.Obj_Type)
                {
                    Instantiate(Object_ToSpawn[2], new Vector2(item.Object_Position.x, item.Object_Position.y), Quaternion.identity);
                }
                else if (Object_ToSpawn[3].GetComponent<Object_Ref>().Object_Info_Struct.Obj_Type == item.Obj_Type)
                {
                    Instantiate(Object_ToSpawn[3], new Vector2(item.Object_Position.x, item.Object_Position.y), Quaternion.identity);
                }
            }
            LoadButton.SetActive(false);
        }
        else
        {
            Debug.Log("No directory Found");
        }
    }
    //Funvtion that Show Saves
    public void ShowSaveFiles()
    {
        string[] Files = Directory.GetFiles(SaveSystem.SAVE_FOLDER);
        List<string> FileNames = new List<string>();
        for(int i=0;i<Files.Length;i++)
        {
            FileNames.Add(Path.GetFileNameWithoutExtension(Files[i]));
        }
        for (int i = 0; i < FileNames.Count; i++)
        {
             FileName.text += "\n" + FileNames[i];
        }
    }
}
//Save Object or properties Class..
public class SaveObject
{
    public List<Object_Ref.Object_Info> Save_Pos;
}
