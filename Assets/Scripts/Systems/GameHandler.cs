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

    public TMP_InputField Input;

    void Start()
    {
        SaveSystem.Inint();
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
        if (Input.text == "")
        {
            Debug.Log("No Name Given");
            return;
        }
        else
        {
            SaveSystem.Save(JsonString, Input.text);
        }
    }

    //Load Function
    public void Load(GameObject LoadButton)
    {
            if (Input.text == "")
            {
                Debug.Log("No Name Given");
                return;
            }
            else
            {
                string LoadString = SaveSystem.Load(Input.text);
                if (LoadString != null)
                {
                    SaveObject Save_Object = JsonUtility.FromJson<SaveObject>(LoadString);
                    foreach (var item in Save_Object.Save_Pos)
                    {
                        for (int i = 0; i < Object_ToSpawn.Length; i++)
                        {
                            if (Object_ToSpawn[i].GetComponent<Object_Ref>().Object_Info_Struct.Obj_Type == item.Obj_Type)
                            {
                                Instantiate(Object_ToSpawn[i], new Vector2(item.Object_Position.x, item.Object_Position.y), Quaternion.identity);
                            }
                        }
                    }
                    LoadButton.SetActive(false);
                }
          
                else
                {
                    Debug.Log("No directory Found");
                }
            }
       
    }

    //Function that Show Saves
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
             FileName.text += FileNames[i]+"\n" ;
        }
    }
}

//Save Object or properties Class..
public class SaveObject
{
    public List<Object_Ref.Object_Info> Save_Pos;
}
