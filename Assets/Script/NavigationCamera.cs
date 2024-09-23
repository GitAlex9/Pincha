using UnityEngine;
using Cinemachine;

public class NavigationCamera : MonoBehaviour
{
#if UNITY_ANDROID
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private bool rotate;
    [SerializeField] private float scrollSpeed = 10f; // Velocidade de movimentação
    [SerializeField] private float zoomSpeed = 1f; // Velocidade de zoom

    private Plane interactionPlane;

    private void Awake()
    {
        if (cam == null)
        {
            cam = FindObjectOfType<CinemachineVirtualCamera>();
        }
        
        // Initialize the plane with default values
        interactionPlane = new Plane(transform.up, transform.position);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            // Update Plane position
            interactionPlane.SetNormalAndPosition(transform.up, transform.position);

            if (Input.touchCount == 1)
            {
                HandleScroll(Input.GetTouch(0));
            }
            else if (Input.touchCount == 2)
            {
                HandlePinch(Input.GetTouch(0), Input.GetTouch(1));
            }
        }
    }

    private void HandleScroll(Touch touch)
    {
        Vector3 delta = CalculatePlanePositionDelta(touch) * scrollSpeed; // Aplica a velocidade de scroll
        if (touch.phase == TouchPhase.Moved)
        {
            cam.transform.Translate(-delta, Space.World);
        }
    }

    private void HandlePinch(Touch touch1, Touch touch2)
    {
        Vector3 position1 = CalculatePlanePosition(touch1.position);
        Vector3 position2 = CalculatePlanePosition(touch2.position);
        Vector3 position1Before = CalculatePlanePosition(touch1.position - touch1.deltaPosition);
        Vector3 position2Before = CalculatePlanePosition(touch2.position - touch2.deltaPosition);

        float zoomFactor = Vector3.Distance(position1, position2) / Vector3.Distance(position1Before, position2Before);

        if (zoomFactor != 1)
        {
            cam.m_Lens.FieldOfView /= zoomFactor;
        }
    }

    private Vector3 CalculatePlanePosition(Vector2 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        interactionPlane.Raycast(ray, out float enter);
        return ray.GetPoint(enter);
    }

    private Vector3 CalculatePlanePositionDelta(Touch touch)
    {
        Vector3 currentPos = CalculatePlanePosition(touch.position);
        Vector3 lastPos = CalculatePlanePosition(touch.position - touch.deltaPosition);
        return currentPos - lastPos;
    }
#endif
}
