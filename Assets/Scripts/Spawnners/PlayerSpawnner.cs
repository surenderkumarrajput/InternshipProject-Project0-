using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnner : MonoBehaviour
{
    public GameObject Object_Player;

    public Transform Player_SpawnPoint;
    private void Awake()
    {
        //Instantiating Player
        Instantiate(Object_Player, Player_SpawnPoint);
    }
}
