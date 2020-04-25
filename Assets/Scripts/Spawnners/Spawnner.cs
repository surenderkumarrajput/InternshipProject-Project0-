using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawnner : MonoBehaviour
{
    GameObject Object_Spawn;

    public Transform Object_Spawn_Holder;

    public static List<Object_Ref.Object_Info> Go_Pos = new List<Object_Ref.Object_Info>();

    private void Start()
    {
        Object_Spawn = null;
        Go_Pos.Clear();
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
            //Instantiating Objects.
            if (Input.GetMouseButtonDown(0))
            {
                var Inputpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(Inputpos, Camera.main.transform.forward);
                if (hit.collider.gameObject.CompareTag("Grid"))
                {
                    var go = Instantiate(Object_Spawn, hit.collider.GetComponent<Transform>().position, Quaternion.identity);
                    go.transform.SetParent(Object_Spawn_Holder);
                    //Taking References
                    var Obj=  go.GetComponent<Object_Ref>().Object_Info_Struct;
                    //Position Reference..
                    float X = go.transform.position.x;
                    float Y = go.transform.position.y;
                    Vector2 Obj_Pos = new Vector2(X, Y);
                    //Object Type Reference
                    Object_Type objtype = Obj.Obj_Type;
                    //Creating new Object
                    Object_Ref.Object_Info Obj_Info = new Object_Ref.Object_Info();
                    //Setting Values
                    Obj_Info.Obj_Type = objtype;
                    Obj_Info.Object_Position = Obj_Pos;
                    Go_Pos.Add(Obj_Info);
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
