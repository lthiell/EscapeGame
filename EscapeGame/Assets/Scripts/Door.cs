using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animator animator;
    private ObjectHider objectHider = ObjectHider.GetSingleton();
    public List<GameObject> container = new List<GameObject>();
     
    void Start()
    {
        animator = GetComponent<Animator>();
        foreach (GameObject go in container)
        {
            objectHider.HideGameObject(go);
        }
    }

    public void OpenDoor()
    {
        animator.SetTrigger("OpenDoor");
        print("openDoor");
        foreach (GameObject go in container)
        {
            print("showGameObject: " + go.name);
            objectHider.ShowGameObject(go);
        }
    }
}
