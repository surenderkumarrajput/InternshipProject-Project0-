using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnner : MonoBehaviour
{
    public GameObject Object_Player;
    Transform Start_Position;

    //Spawns Player
    public void Player_Spawnner()
    {
        if(GameObject.FindGameObjectWithTag("Start")==null)
        {
            return;
        }
        else
        {
            Start_Position = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();
        }
        //Instantiating Player
        Instantiate(Object_Player, Start_Position.position, Quaternion.identity);
    }
}
