using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hint: MonoBehaviour
{
    protected bool used = false;
    public abstract bool Give();

    public virtual void Disable() {
        used = true;
        HintController hintController = GameObject.Find("GameLogic").GetComponent<HintController>();
        hintController.RestartTimer();
    }
}
