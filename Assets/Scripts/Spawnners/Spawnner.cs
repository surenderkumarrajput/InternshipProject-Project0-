using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawnner : MonoBehaviour
{
    GameObject Object_Spawn;

    public Transform Spawn_Point;
    public Transform Object_Spawn_Holder;

    private void Start()
    {
        Object_Spawn = null;
    }

    private void Update()
    {
        //Checking whether pointer is over UI Gameobject or not..
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //Spawnning Selected Object in the Scene..
        #region Spawning Objects
        if (Object_Spawn == null)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                var Inputpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(Inputpos, Camera.main.transform.forward);
                if (hit.collider.gameObject.CompareTag("Grid"))
                {
                    var go = Instantiate(Object_Spawn, hit.collider.GetComponent<Transform>().position, Quaternion.identity);
                    go.transform.SetParent(Object_Spawn_Holder);
                }
                else
                {
                    return;
                }
            }
        }
    
    #endregion
    }
   
    //Function which makes player to selects a particular Object from Editor Window
    public void SelectionFunction(GameObject Go)
    {
        Object_Spawn = Go;
    }
}
