using System.Collections.Generic;
using UnityEngine;

public class LockedMovable : MagicMovable
{

    public bool locked;
    public GameObject key;
    public List<GameObject> container = new List<GameObject>();
    public List<Hint> associatedHints = new List<Hint>();

    private AudioSource audioSource;

    private ObjectHider objectHider = ObjectHider.GetSingleton();


    public override void StartSpecific()
    {
        base.StartSpecific();
        foreach (GameObject go in container)
        {
            objectHider.HideGameObject(go);
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
            if (audioSource)
            {
                audioSource.Play();
            }
            foreach (GameObject go in container)
            {
                objectHider.ShowGameObject(go);
            }
            foreach (Hint hint in associatedHints)
            {
                hint.Disable();
            }
        }
    }
}
