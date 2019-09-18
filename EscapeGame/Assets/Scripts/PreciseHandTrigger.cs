using UnityEngine;

public class PreciseHandTrigger : MonoBehaviour
{
    public float preciseRadius;

    private float originalRadius;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            SphereCollider handCollider = other.gameObject.GetComponent<SphereCollider>();
            originalRadius = handCollider.radius;
            handCollider.radius = preciseRadius;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            SphereCollider handCollider = other.gameObject.GetComponent<SphereCollider>();
            handCollider.radius = originalRadius;
        }
    }
}
