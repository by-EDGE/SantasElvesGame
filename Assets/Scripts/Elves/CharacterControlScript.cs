using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using System.Threading;

public class CharacterControlScript : MonoBehaviour
{
    private IMovementController _movementController;
    private IAnimationController _animationController;
    private IInputController _inputController;

    private Vector3 _prevPosition;

    [Inject]
    public void Construct(
        IMovementController movementController,
        IAnimationController animationController,
        IInputController inputController)
    {
        _movementController = movementController;
        _animationController = animationController;
        _inputController = inputController;

        // подписываемся на событие движения из InputController
        _inputController.OnMoveRequested += OnMoveRequested;
    }

    private void Start()
    {
        // сохраняем стартовую позицию для расчёта скорости
        _prevPosition = transform.position;
    }

    private void Update()
    {
        // обновляем контроллер ввода (например, клик мышкой)
        _inputController.Update();

        // переключение анимации ходьбы
        if (!_movementController.IsMoving)
            _animationController.SetWalking(false);
        else
            _animationController.SetWalking(true);

        // расчёт скорости для blend tree анимаций
        Vector3 curMove = _movementController.CurrentPosition - _prevPosition;
        float curSpeed = curMove.magnitude / Time.deltaTime;
        _prevPosition = _movementController.CurrentPosition;

        _animationController.SetSpeed(curSpeed);
    }

    private void OnMoveRequested(Vector3 targetPosition)
    {
        _movementController.MoveTo(targetPosition);
    }

    private void OnDestroy()
    {
        if (_inputController != null)
            _inputController.OnMoveRequested -= OnMoveRequested;
    }

    // 🔹 Вызов из менеджера задач – эльф двигается к подарку
    public void MoveToGift(GameObject gift)
    {
        if (gift != null)
            _movementController.MoveTo(gift.transform.position);
    }

    // 🔹 Универсальный метод для любых точек
    public void MoveTo(Vector3 target)
    {
        _movementController.MoveTo(target);
    }
}
