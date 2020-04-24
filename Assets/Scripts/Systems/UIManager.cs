using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject Editor_Window;

    void Update()
    {
        //Editor Window Active and !Active
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            bool isActive = Editor_Window.activeSelf;
            Editor_Window.SetActive(!isActive);
        }
    }
    //Scene Changing Function
    public void SceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
