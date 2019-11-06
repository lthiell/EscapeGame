using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Dient dazu, Objekte temporär aus- und wieder einzublenden. Dazu wird der Scale des Objekts auf null gesetzt. Um es später wieder 
 * einblenden zu können, wird der ursprüngliche Scale gespeichert.
 * 
 * Zudem wird die Gravity ausgeblendeter Objekte deaktiviert.
 */
public class ObjectHider
{
    private Dictionary<int, Vector3> initialScales = new Dictionary<int, Vector3>();
    private static ObjectHider objectHider = new ObjectHider();

    public static ObjectHider GetSingleton()
    {
        return objectHider;
    }
    
    public void HideGameObject(GameObject go)
    {
        initialScales.Add(go.GetInstanceID(), go.transform.localScale);
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
        initialScales.TryGetValue(go.GetInstanceID(), out value);
        go.transform.localScale = value;
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
        }
    }
}
