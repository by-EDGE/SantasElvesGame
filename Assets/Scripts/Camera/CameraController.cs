using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _cameraEdgeThreshold = 20f;
    [SerializeField] private float _cameraSpeed = 10f;
    [SerializeField] private Transform mapPlane; // ← сюда перетаскиваешь Plane

    private float minX, maxX, minZ, maxZ;

    private void Start()
    {
        SetBoundsFromPlane();
    }

    private void Update()
    {
        UpdateCamera();
    }

    private void SetBoundsFromPlane()
    {
        Vector3 center = mapPlane.position;
        Vector3 scale = mapPlane.localScale;

        float width = scale.x * 10f; // стандартная ширина Plane = 10
        float depth = scale.z * 10f;

        minX = center.x - width / 2f;
        maxX = center.x + width / 2f;
        minZ = center.z - depth / 2f;
        maxZ = center.z + depth / 2f;
    }

    private void UpdateCamera()
    {
        Vector3 direction = Vector3.zero;

        // X – влево/вправо
        if (Input.mousePosition.x < _cameraEdgeThreshold && _mainCamera.transform.position.x > minX)
        {
            direction += Vector3.left;
        }
        else if (Input.mousePosition.x > Screen.width - _cameraEdgeThreshold && _mainCamera.transform.position.x < maxX)
        {
            direction += Vector3.right;
        }

        // Z – вперёд/назад
        if (Input.mousePosition.y < _cameraEdgeThreshold && _mainCamera.transform.position.z > minZ)
        {
            direction += Vector3.back;
        }
        else if (Input.mousePosition.y > Screen.height - _cameraEdgeThreshold && _mainCamera.transform.position.z < maxZ)
        {
            direction += Vector3.forward;
        }

        if (direction != Vector3.zero)
        {
            _mainCamera.transform.Translate(direction.normalized * _cameraSpeed * Time.deltaTime, Space.World);
        }
    }
}