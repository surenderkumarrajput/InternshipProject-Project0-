using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawnner : MonoBehaviour
{
    GameObject Object_Spawn;
    GameObject Object_Spawn_Ref;

    public Transform Object_Spawn_Holder;

    public static List<Object_Ref.Object_Info> Go_Pos = new List<Object_Ref.Object_Info>();

    public bool EndPoint_Spawnned = false;
    public bool StartPoint_Spawnned = false;


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

        //Spawnning and Destroying Selected Object in the Scene..
        #region  Objects
        if (Object_Spawn == null)
        {
            return;
        }
        else
        {
            //Instantiating Objects.
            #region Instantiating Objects
            if (Input.GetMouseButtonDown(0))
            {
                var Inputpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D Hit = Physics2D.Raycast(Inputpos, Camera.main.transform.forward);
                if (Hit.collider.gameObject.CompareTag("Grid"))
                {
                    //Spawnning Start Position if it is not Spawnned.
                    if(Object_Spawn.name=="StartPosition" && !StartPoint_Spawnned&& Object_Spawn!=null)
                    {
                        Object_Spawn_Ref = Instantiate(Object_Spawn, Hit.collider.GetComponent<Transform>().position, Quaternion.identity);
                        StartPoint_Spawnned = true;
                    }
                    //Spawnning End Position if it is not Spawnned.
                    else if (Object_Spawn.name=="EndPosition" && !EndPoint_Spawnned&&Object_Spawn != null)
                    {
                        Object_Spawn_Ref = Instantiate(Object_Spawn, Hit.collider.GetComponent<Transform>().position, Quaternion.identity);
                        EndPoint_Spawnned = true;
                    }
                    //Spawnning Other Objects
                    else if(Object_Spawn.name == "Coins"|| Object_Spawn.name == "Platform"&& Object_Spawn != null)
                    {
                        Object_Spawn_Ref = Instantiate(Object_Spawn, Hit.collider.GetComponent<Transform>().position, Quaternion.identity);
                    }
                    else
                    {
                        return;
                    }
                    Object_Spawn_Ref.transform.SetParent(Object_Spawn_Holder);
                    //Add Data to List When Object get Instantiated.
                    #region Data Manipulation
                    //Taking References
                    var Obj = Object_Spawn_Ref.GetComponent<Object_Ref>().Object_Info_Struct;
                    //Position Reference..
                    float X = Object_Spawn_Ref.transform.position.x;
                    float Y = Object_Spawn_Ref.transform.position.y;
                    Vector2 Obj_Pos = new Vector2(X, Y);
                    //Object Type Reference
                    Object_Type Obj_Type_Ref = Obj.Obj_Type;
                    //Creating new Object
                    Object_Ref.Object_Info Obj_Info = new Object_Ref.Object_Info();
                    //Setting Values
                    Obj_Info.Obj_Type = Obj_Type_Ref;
                    Obj_Info.Object_Position = Obj_Pos;
                    //Adding the Object Data to the List
                    Go_Pos.Add(Obj_Info);
                    #endregion
                }
                else
                {
                    return;
                }
            }
            #endregion

            //Destroying Objects
            #region Destroying Objects
            if (Input.GetMouseButtonDown(1))
            {
                var Inputpos_Destroy = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D Hit_Destroy = Physics2D.Raycast(Inputpos_Destroy, Camera.main.transform.forward);
                if (Hit_Destroy.collider.gameObject.CompareTag("Grid"))
                {
                    return;
                }
                else if(Hit_Destroy.collider.gameObject.CompareTag("Start"))
                {
                    Destroy(Hit_Destroy.collider.gameObject);
                    StartPoint_Spawnned = false;
                }
                else if (Hit_Destroy.collider.gameObject.CompareTag("End"))
                {
                    Destroy(Hit_Destroy.collider.gameObject);
                    EndPoint_Spawnned = false;
                }
                else
                {
                    Destroy(Hit_Destroy.collider.gameObject);
                }
                //Removes Data from List When Object gets Deleted.
                #region Data Manipulation
                //Taking References
                var Obj = Hit_Destroy.collider.GetComponent<Object_Ref>().Object_Info_Struct;
                //Position Reference..
                float X = Hit_Destroy.collider.transform.position.x;
                float Y = Hit_Destroy.collider.transform.position.y;
                Vector2 Obj_Pos = new Vector2(X, Y);
                //Object Type Reference
                Object_Type Obj_Type_Ref = Obj.Obj_Type;
                //Creating new Object
                Object_Ref.Object_Info Obj_Info = new Object_Ref.Object_Info();
                //Setting Values
                Obj_Info.Obj_Type = Obj_Type_Ref;
                Obj_Info.Object_Position = Obj_Pos;
                //Removing From the deleted Object Data from the List 
                Go_Pos.Remove(Obj_Info);
                #endregion
            }
            #endregion
        }

        #endregion
    }
   

    //Function which makes player to selects a particular Object from Editor Window
    public void SelectionFunction(GameObject Go)
    {
        Object_Spawn = Go;
    }
}
