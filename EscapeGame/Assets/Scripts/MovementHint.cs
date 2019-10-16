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
        ADJUSTED_SPEED = speed * INTERVAL;
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


    void FixedUpdate()
    {
        if(started && duration > 0.0f)
        {
            transform.position += ADJUSTED_SPEED;
            duration -= INTERVAL;
        }
    }
}
