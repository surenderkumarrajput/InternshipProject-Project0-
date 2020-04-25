using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Object_Type
{
    Coin,Platform,Start_Position,End_Position
}
public class Object_Ref : MonoBehaviour
{
    [Serializable]
    public struct Object_Info
    {
        public Object_Type Obj_Type;
        public Vector2 Object_Position;
    }
    public Object_Info Object_Info_Struct;
}
