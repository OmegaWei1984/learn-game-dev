using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public int speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > -5)
            this.transform.position += speed * Vector3.left * Time.deltaTime;
    }
}
