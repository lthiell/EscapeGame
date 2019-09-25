using System.Collections.Generic;
using UnityEngine;

public class LockedMovable : MagicMovable
{

    public bool locked;
    public GameObject key;
    public List<GameObject> container = new List<GameObject>();

    private AudioSource audioSource;

    private Dictionary<int, Vector3> containerInitialLocalScales = new Dictionary<int, Vector3>();


    public override void StartSpecific()
    {
        base.StartSpecific();
        foreach (GameObject go in container)
        {
            HideGameObject(go);
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (!locked)
        {
            base.Update();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(key))
        {
            Unlock();
        }

    }

    private void Unlock()
    {
        if (locked)
        {
            locked = false;
            print("Offen auf Umwegen (:");
            if (audioSource)
            {
                audioSource.Play();
            }

            foreach (GameObject go in container)
            {
                ShowGameObject(go);
            }
        }
    }

    private void HideGameObject(GameObject go)
    {
        containerInitialLocalScales.Add(go.GetInstanceID(), go.transform.localScale);
        go.transform.localScale = new Vector3(0, 0, 0);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
        }
    }

    private void ShowGameObject(GameObject go)
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
