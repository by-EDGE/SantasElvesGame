using UnityEngine;

public class ElfManager : MonoBehaviour
{
    [SerializeField] private ElfUnit[] elves;

    private void Start()
    {
        // Каждому эльфу выдаём случайную задачу "идти в точку"
        foreach (var elf in elves)
        {
            Vector3 randomPos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
            elf.AddTask(new UnitTask(TaskType.MoveTo, randomPos));
        }
    }
}