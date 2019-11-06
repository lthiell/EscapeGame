using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerUI : MonoBehaviour
{

    public List<GameObject> pointerObjects;

    public void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Hand"))
            return;
        foreach (GameObject obj in pointerObjects)
        {
            obj.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Hand"))
            return;

        foreach (GameObject obj in pointerObjects)
        {
            obj.SetActive(false);
        }
    }
}
