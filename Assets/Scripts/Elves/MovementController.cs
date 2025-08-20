using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovementController : IMovementController
{
    private NavMeshAgent _agent;

    public NavMeshMovementController(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public void MoveTo(Vector3 position) //Публичный метод: «иди в указанную точку»
    {
        if (Vector3.Distance(_agent.destination, position) > 0.1f)
        {
            _agent.SetDestination(position);
            _agent.isStopped = false;
        }
    }

    public bool IsMoving => !_agent.pathPending && _agent.remainingDistance > _agent.stoppingDistance;

    public Vector3 CurrentPosition => _agent.transform.position;
}