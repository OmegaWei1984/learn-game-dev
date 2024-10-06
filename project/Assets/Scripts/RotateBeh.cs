using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class RotateBeh : MonoBehaviour
{
    int speed = 36;

    Vector3 e = Vector3.forward;

    // Start is called before the first frame update
    void Start()
    {
        float f = 2.0f;
        Vector3 e = Vector3.forward * f;
        Quaternion q = Quaternion.AngleAxis(90, e);
        Debug.Log(q);

        Vector3 p = new Vector3(1, 0, 0);
        Debug.Log(q * p);

        Quaternion q1 = Quaternion.AngleAxis(45, e);
        Debug.Log(q1 * q * p);

        Quaternion q2 = Quaternion.Inverse(q);
        Debug.Log(q2 * q);
        Debug.Log(Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q = Quaternion.AngleAxis(speed * Time.deltaTime, e);
        transform.localRotation *= q;
    }
}
