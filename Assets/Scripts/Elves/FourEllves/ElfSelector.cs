using UnityEngine;

public class ElfSelector : MonoBehaviour
{
    private Camera _camera;
    private CharacterControlScript _selectedElf;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ЛКМ - выбрать эльфа
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var elf = hit.collider.GetComponent<CharacterControlScript>();
                if (elf != null)
                {
                    _selectedElf = elf;
                    Debug.Log($"Выбран эльф: {_selectedElf.name}");
                }
            }
        }
    }

    public CharacterControlScript GetSelectedElf()
    {
        return _selectedElf;
    }
}