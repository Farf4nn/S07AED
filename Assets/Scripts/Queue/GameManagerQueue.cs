using Sirenix.OdinInspector;
using UnityEngine;

public class GameManagerQueue : MonoBehaviour
{
    public MyQueue<string> BankQueue = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    [Button]
    public void EnQueue(string name)
    {
        BankQueue.Enqueue(name);
    }
    [Button]
    public void Dequeue()
    {
        Debug.Log("Pase a ser atendido : " + BankQueue.Dequeue());
    }
    [Button]
    public void Peek()
    {
        Debug.Log("El siguiente en ser atendido sera .. " + BankQueue.Peek());
    }
    [Button]
    public void Clear()
    {
        BankQueue.Clear();
    }
    [Button]
    public void Count()
    {
        Debug.Log(BankQueue.Count);
    }
}
