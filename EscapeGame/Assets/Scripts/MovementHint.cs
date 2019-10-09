using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHint : Hint
{

    public Vector3 speed;
    private Vector3 ADJUSTED_SPEED;
    public float duration;
    private bool started = false;

    private static float INTERVAL;

    private void Start()
    {
        INTERVAL = Time.fixedDeltaTime;
        ADJUSTED_SPEED = new Vector3(speed.x * INTERVAL, speed.y * INTERVAL, speed.z * INTERVAL);
    }

    public override bool Give()
    {
        if (!used)
        {
            started = true;
            used = true;
            return true;
        }
        return false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(started && duration > 0.0f)
        {
            print(ADJUSTED_SPEED);
            print(INTERVAL);
            transform.position += ADJUSTED_SPEED;
            duration -= INTERVAL;
        }
    }
}
