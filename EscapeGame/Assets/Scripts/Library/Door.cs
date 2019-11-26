using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animator animator;
    private ObjectHider objectHider = ObjectHider.GetSingleton();
    // Objekte, die ausgeblendet sein müssen, wenn die Tür geschlossen ist (--> der Flur)
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
        foreach (GameObject go in container)
        {
            objectHider.ShowGameObject(go);
        }
    }

}
