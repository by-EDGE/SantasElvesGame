using UnityEngine;

public enum TaskType
{
    MoveTo,
    PickItem
}

public class UnitTask
{
    public TaskType Type;
    public Vector3 TargetPosition;
    public GameObject TargetObject;

    public UnitTask(TaskType type, Vector3 pos, GameObject obj = null)
    {
        Type = type;
        TargetPosition = pos;
        TargetObject = obj;
    }
}