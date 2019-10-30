using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hint: MonoBehaviour
{
    protected bool used = false;

    private HintController controller;
    public abstract bool Give();

    public virtual void Disable() {
        if(!used)
        {
            used = true;
            HintController hintController = GameObject.Find("GameLogic").GetComponent<HintController>();
            hintController.RestartTimer();
        }
    }
}
