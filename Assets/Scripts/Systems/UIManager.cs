using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject Editor_Window;

    public TextMeshProUGUI Coin_Count_Text;

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
       
        //Checking if player is not null Display Score.
        if (GameObject.FindGameObjectWithTag("Player")!=null)
        {
            //Making Text equals to Player Coin Count.
            Coin_Count_Text.text = "x"+GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Coin_Count.ToString();
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
    //Quits Application.
    public void Quit()
    {
        Application.Quit();
    }

}
