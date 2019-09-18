using UnityEngine;

public class RespawnOutOfBounds : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (OutOfBounds())
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
            Movable mov = GetComponent<Movable>();
            if (mov != null && mov.m_ActiveHand != null)
            {
                mov.m_ActiveHand.Drop();
            }
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = new Vector3(0, 0, 0);
                rb.angularVelocity = new Vector3(0, 0, 0);
            }
        }
    }

    private bool OutOfBounds()
    {
        // TODO: Konstanten irgendwo hin!
        return transform.position.y < -1 || transform.position.y > 11 || transform.position.x > 6 || transform.position.x < -6 || transform.position.z > 6 || transform.position.z < -6;
    }
}
