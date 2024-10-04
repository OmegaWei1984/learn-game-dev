using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWall : MonoBehaviour
{
    public GameObject brick;

    public const int hight = 5;

    public const int width = 3;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 size = brick.GetComponent<Renderer>().bounds.size;
        for (var i = 0; i < hight; i++)
        {
            for (var j = 0; j < width; j++)
            {
                Instantiate(
                    brick,
                    new Vector3(size.x * i, size.y * j, 0),
                    Quaternion.identity
                 );
                //Debug.Log($"x={size.x * i}, y={size.y * j}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
