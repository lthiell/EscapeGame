using UnityEngine;

public class MovementHint : Hint
{

    public Vector3 speed;

    public float duration;
    public AudioSource sound;

    private Vector3 ADJUSTED_SPEED;
    private bool started = false;
    private bool soundStopped = false;
   

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
            if (sound != null)
            {
                sound.Play();
            }
            return true;
        }
        return false;
    }


    void FixedUpdate()
    {
        if (started && duration > 0.0f)
        {
            transform.position += ADJUSTED_SPEED;
            duration -= INTERVAL;
        } else if(!soundStopped && sound != null && started)
        {
            soundStopped = true;
            sound.Pause();
        }
    }

    public override void Disable()
    {
        base.Disable();
        print("Ausgemacht!");
    }
}
