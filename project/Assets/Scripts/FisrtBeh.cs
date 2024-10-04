using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistBuh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "a cube";
        cube.transform.position = new Vector3(0, Random.Range(0, 5), 0);
        cube.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
    }
    void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    void Awake()
    {
        Debug.Log("Awake");
    }

    void OnGUI()
    {
        //Debug.Log("OnGUI");
    }
}
