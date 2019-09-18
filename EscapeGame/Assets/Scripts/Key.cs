using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public enum KeyType {normal, submit, show, delete};

    public KeyType keyType;

    private Text text;


    public void Awake()
    {
        InitText();
    }

    private void InitText()
    {
        if (text == null)
        {
            text = this.GetComponentInChildren<Text>();
        }
    }


    public string GetText()
    {
        InitText();
        return text.text;
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
