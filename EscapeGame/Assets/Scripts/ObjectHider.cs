using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHider
{
    private Dictionary<int, Vector3> containerInitialLocalScales = new Dictionary<int, Vector3>();
    
    private static ObjectHider objectHider = new ObjectHider();

    public static ObjectHider GetSingleton()
    {
        return objectHider;
    }
    
    public void HideGameObject(GameObject go)
    {
        containerInitialLocalScales.Add(go.GetInstanceID(), go.transform.localScale);
        go.transform.localScale = new Vector3(0, 0, 0);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
        }
    }

    public void ShowGameObject(GameObject go)
    {
        Vector3 value;
        containerInitialLocalScales.TryGetValue(go.GetInstanceID(), out value);
        go.transform.localScale = value;
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
        }
    }
}
