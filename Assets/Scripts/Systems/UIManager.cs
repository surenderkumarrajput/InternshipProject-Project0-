using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject Editor_Window;

    void Update()
    {
        if(Editor_Window!=null)
        {
            //Editor Window Active and !Active
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                bool isActive = Editor_Window.activeSelf;
                Editor_Window.SetActive(!isActive);
            }
        }
        else
        {
            return;
        }
    }
    //Scene Changing Function
    public void SceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
  
}
