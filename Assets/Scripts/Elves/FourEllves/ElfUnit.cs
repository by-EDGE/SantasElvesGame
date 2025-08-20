using System.Collections.Generic;
using UnityEngine;

public class ElfUnit : MonoBehaviour
{
    [SerializeField] private int maxTasks = 3;   // Лимит задач
    private Queue<UnitTask> taskQueue = new Queue<UnitTask>();
    private Vector3 target;

    public bool HasFreeTaskSlot => taskQueue.Count < maxTasks;

    public void Start()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (taskQueue.Count > 0)
        {
            ExecuteTask(taskQueue.Peek());
        }
    }

    public void AddTask(UnitTask task)
    {
        if (HasFreeTaskSlot)
            taskQueue.Enqueue(task);
    }

    private void ExecuteTask(UnitTask task)
    {
        switch (task.Type)
        {
            case TaskType.MoveTo:
                transform.position = Vector3.MoveTowards(transform.position, task.TargetPosition, 2f * Time.deltaTime);
                if (Vector3.Distance(transform.position, task.TargetPosition) < 0.1f)
                    taskQueue.Dequeue();
                break;

            case TaskType.PickItem:
                if (task.TargetObject != null)
                {
                    transform.position = Vector3.MoveTowards(transform.position, task.TargetObject.transform.position, 2f * Time.deltaTime);
                    if (Vector3.Distance(transform.position, task.TargetObject.transform.position) < 0.1f)
                    {
                        Destroy(task.TargetObject); // подобрали
                        taskQueue.Dequeue();
                    }
                }
                else
                {
                    taskQueue.Dequeue(); // предмет исчез
                }
                break;
        }
    }
}