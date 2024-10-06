using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundFoo : MonoBehaviour
{
    int speed = 36;

    Vector3 e = Vector3.up;

    Vector3 pivot_point;

    // Start is called before the first frame update
    void Start()
    {
        GameObject point = GameObject.Find("Point");
        if (point != null)
        {
            pivot_point = point.transform.position;
            Debug.Log($"pivot_point={pivot_point}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pivot_point != Vector3.zero)
        {
            Quaternion rot = Quaternion.AngleAxis(speed * Time.deltaTime, e);
            transform.position = rot * (transform.position - pivot_point) + pivot_point;
            transform.rotation = rot * transform.rotation;
        }
    }
}
