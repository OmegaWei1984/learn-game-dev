using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoo : MonoBehaviour
{
    enum State
    {
        Translate,
        Rotate,
        RotateAround,
        LookAt,
        Max
    }

    State state;

    Vector3 translate_dir;

    GameObject target_object = null;

    const float omega = 36.0f;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Translate;
        translate_dir = Vector3.forward;
        target_object = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Translate:
                DoTranslate(); break;
            case State.Rotate:
                DoRotate(); break;
            case State.RotateAround:
                DoRotateAround(); break;
            case State.LookAt:
                DoLookAt(); break;
            default:
                DoTranslate(); break;
        }
    }

    void DoTranslate()
    {
        if (transform.position.z < -5)
        {
            translate_dir = Vector3.forward;
        }
        else if (transform.position.z > 5)
        {
            translate_dir = Vector3.back;
        }
        transform.Translate(translate_dir * Time.deltaTime);
    }

    void DoRotate()
    {
        transform.Rotate(omega * Time.deltaTime, 0.0f, 0.0f);
    }

    void DoRotateAround()
    {
        if (target_object != null)
        {
            transform.RotateAround(
                target_object.transform.position,
                Vector3.up,
                omega * Time.deltaTime
            );
        }
    }

    void DoLookAt()
    {
        transform.LookAt(new Vector3(Random.Range(0, 5), Random.Range(0, 5), 0));
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(64, 64, 64, 128), "Next"))
        {
            state = (State)(((int)state + 1) % (int)(State.Max));
        }
    }
}
