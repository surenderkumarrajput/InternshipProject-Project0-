using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class GridSpawnner : MonoBehaviour
{
    public GameObject Grid;

    public Transform Grid_Holder;

    public int GridCount_X;
    public int GridCount_Y;

    void Start()
    {
        //Calaculating Width and height of a sprite
        #region Calculation(Sprite (Width && Height))
        var Pixelperunit = Grid.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        float Width = Grid.GetComponent<SpriteRenderer>().sprite.rect.width/Pixelperunit;
        float Height = Grid.GetComponent<SpriteRenderer>().sprite.rect.height/Pixelperunit;
        #endregion

        //Spawning Grids
        #region GridSpawn
        for (int i = 0; i < GridCount_X; i++)
        {
            for (int j = 0; j < GridCount_Y; j++)
            {
                GameObject go=Instantiate(Grid, new Vector2((i*Width)-(GridCount_X/2) + Width/2, ((j*Height)-(GridCount_Y / 2))+Height/2), Quaternion.identity);
                go.transform.SetParent(Grid_Holder);
            }
        }
        #endregion
    }
  
}
