using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public Transform tile1, tile2;
    public float speed;

    private void FixedUpdate()
    {
        tile1.position -= new Vector3(speed, 0, 0);
        tile2.position -= new Vector3(speed, 0, 0);

        if(tile2.position.x <= 0)
        {
            tile1.position = tile2.position + new Vector3(25, 0, 0);

            var tmp = tile1;
            tile1 = tile2;
            tile2 = tmp;
        }
    }
}
