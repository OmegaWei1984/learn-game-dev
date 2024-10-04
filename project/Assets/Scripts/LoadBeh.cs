using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBeh : MonoBehaviour
{
    public Transform res;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        GameObject game_object = 
            Instantiate<Transform>(res, this.transform).gameObject;
        game_object.transform.position = 
            new Vector3(0, Random.Range(-5, 3), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
