using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private EntityStats baseStats;

    public string entityName;
    public float entityID;
    public float currentSpeed;

    private void Awake()
    {
        if (baseStats != null)
        {
            InitializeEntity();
        }
        else
        {
            Debug.LogError("Falta el ScriptableObject de estadísticas en " + gameObject.name);
        }
    }

    private void InitializeEntity()
    {
        entityName = baseStats.entityName;
        entityID = baseStats.id;
        currentSpeed = baseStats.speed;

        Debug.Log("Entidad Inicializada: " + entityName + " ID: " + entityID + " con velocidad " + currentSpeed);
    }
}