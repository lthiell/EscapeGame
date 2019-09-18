using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CodeValidator : MonoBehaviour
{
    public int[] code = new int[4];
    public UnityEvent handleValidCode;

    private Queue<int> queue = new Queue<int>();

    public void EnterNumber(int number)
    {
        queue.Enqueue(number);
        if (queue.Count > 4)
        {
            queue.Dequeue();
        }
        if (IsValid())
        {
            handleValidCode.Invoke();
        }
    }

    private bool IsValid()
    {
        return Enumerable.SequenceEqual(queue.ToArray(), code);
    }
}
