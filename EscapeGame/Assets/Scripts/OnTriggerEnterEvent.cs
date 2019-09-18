using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{
    public UnityEvent unityEvent;
    public List<Collider> triggerColliders = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if(triggerColliders.Contains(other) || triggerColliders.Count == 0) {
            unityEvent.Invoke();
        }
    }
}
