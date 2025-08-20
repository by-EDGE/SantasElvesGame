using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputController : IInputController
{
    // Камера, через которую будем пускать луч
    private Camera _camera;

    // Событие: вызывается, когда игрок кликает мышью и выбирает точку
    public event System.Action<Vector3> OnMoveRequested;

    // Конструктор: сюда передаём камеру при создании
    public MouseInputController(Camera camera)
    {
        _camera = camera;
    }

    // Проверка ввода мыши каждый кадр
    public void Update()
    {
        // Если нажата правая кнопка мыши
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            // Берём позицию курсора на экране
            var screenPosition = Mouse.current.position.ReadValue();

            // Строим луч от камеры через курсор
            Ray ray = _camera.ScreenPointToRay(screenPosition);

            // Проверяем, попал ли луч во что-то
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Если попали, сообщаем всем: двигаться в точку попадания
                OnMoveRequested?.Invoke(hit.point);
            }
        }
    }
}