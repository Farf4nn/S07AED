using TMPro;
using UnityEngine;

public class GameManagerTurn : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI orderText;

    [Header("Priority")]
    [SerializeField] private PriorityType currentPriority;

    private PriorityQueue<Entity> combatQueue;

    private Entity[] entities;

    private void Start()
    {
        entities = FindObjectsByType<Entity>(FindObjectsSortMode.None);

        BuildQueue();
    }

    private void BuildQueue()
    {
        combatQueue = new PriorityQueue<Entity>(HasHigherPriority);

        foreach (Entity entity in entities)
        {
            combatQueue.Enqueue(entity);
        }

        ShowOrder();
    }

    private bool HasHigherPriority(Entity a, Entity b)
    {
        if (currentPriority == PriorityType.HigherSpeed)
        {
            return a.currentSpeed > b.currentSpeed;
        }
        else
        {
            return a.entityID < b.entityID;
        }
    }

    public void ChangePriority()
    {
        if (currentPriority == PriorityType.HigherSpeed)
        {
            currentPriority = PriorityType.LowerID;
        }
        else
        {
            currentPriority = PriorityType.HigherSpeed;
        }

        BuildQueue();
    }

    public void NextTurn()
    {
        if (combatQueue.Count == 0)
        {
            Debug.Log("No quedan entidades");
            return;
        }

        Entity current = combatQueue.Dequeue();

        Debug.Log(current.entityName + " realizó su turno");

        ShowOrder();
    }

    private void ShowOrder()
    {
        orderText.text = "";

        PriorityQueue<Entity> tempQueue =
            new PriorityQueue<Entity>(HasHigherPriority);

        int position = 1;

        while (combatQueue.Count > 0)
        {
            Entity entity = combatQueue.Dequeue();

            orderText.text += position + ". " + entity.entityName + " | Speed: " + entity.currentSpeed + " | ID: " + entity.entityID + "\n";

            tempQueue.Enqueue(entity);

            position++;
        }

        while (tempQueue.Count > 0)
        {
            combatQueue.Enqueue(tempQueue.Dequeue());
        }
    }
}