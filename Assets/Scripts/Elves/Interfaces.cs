using UnityEngine;

public interface IMovementController //Отвечает за физическое перемещение персонажа или объекта
{
    void MoveTo(Vector3 position); //Движение к указанной точке
    bool IsMoving { get; } //Проверка идет ли персонаж
    Vector3 CurrentPosition { get; } //Возвращает текущие координаты объекта
}

public interface IAnimationController //Управление анимациями (визуально)
{
    void SetWalking(bool isWalking);
    void SetSpeed(float speed);
}

public interface IInputController //Отвечает за обработку действий игрока
{
    event System.Action<Vector3> OnMoveRequested; //Событие, которое вызывается, когда игрок указывает точку для движения.
    void Update();  //Проверяем ввод
}