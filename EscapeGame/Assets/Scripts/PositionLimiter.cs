using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLimiter : MonoBehaviour
{
    public Vector3 min;
    public Vector3 max;
    public bool[] lockAxisAtInitial = new bool[3];
    

    // Start is called before the first frame update
   void Start()
    {
        print(transform.position);
        for (int i = 0; i < lockAxisAtInitial.Length; i++)
        {
            if (lockAxisAtInitial[i]) {
                max[i] = transform.position[i] +0.00f;
                min[i] = max[i] - 0.00f;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        applyLimits();
    }


    public void applyLimits()
    {
        //print(transform.localPosition);
        //print(transform.localPosition.x);
        Vector3 localPos = new Vector3(Mathf.Max(Mathf.Min(transform.position.x, max.x), min.x)
            , Mathf.Max(Mathf.Min(transform.position.y, max.y), min.y)
            , Mathf.Max(Mathf.Min(transform.position.z, max.z), min.z));

        transform.position = localPos;
        //print("Angepasst zu: " + transform.localPosition);
    }
}
