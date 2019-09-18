﻿using UnityEngine;
using UnityEngine.Events;

public class TextValidator : MonoBehaviour
{
    public string password;
    

    public UnityEvent handleValidPassword;

    public void Validate(string password)
    {
        if(this.password.Equals(password))
        {
            handleValidPassword.Invoke();
        }
    }
}
