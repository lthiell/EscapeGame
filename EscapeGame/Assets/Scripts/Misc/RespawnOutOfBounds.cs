using UnityEngine;

public class RespawnOutOfBounds : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public static float lowerX = -6, lowerY = -1, lowerZ = -6;
    public static float upperX = 6, upperY = 11, upperZ = 6;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (OutOfBounds())
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
            Movable mov = GetComponent<Movable>();
            if (mov != null && mov.activeHand != null)
            {
                mov.activeHand.Drop();
            }
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    private bool OutOfBounds()
    {
        return transform.position.y < lowerY || transform.position.y > upperY || transform.position.x > upperX 
            || transform.position.x < lowerX || transform.position.z > upperZ || transform.position.z < lowerZ;
    }
}
