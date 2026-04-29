using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Scriptable Objects/EntityStats")]
public class EntityStats : ScriptableObject
{
    public string entityName;//-> nombre de la entidad ps
    public float speed;//->mayor velocidad
    public float id;//->menor id
}