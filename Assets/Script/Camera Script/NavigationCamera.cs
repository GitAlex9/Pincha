using UnityEngine;
using Cinemachine;

public class NavigationCamera : MonoBehaviour
{
#if UNITY_ANDROID
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private float scrollSpeed = 5f; // Velocidade de movimentação
    //[SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float minX, maxX, minZ, maxZ, minY, maxY;

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
            /*else if (Input.touchCount == 3)
            {
                HandleRotation(Input.GetTouch(0), Input.GetTouch(1), Input.GetTouch(2));
            }*/
        }
    }

    private void HandleScroll(Touch touch)
    {
        Vector3 delta = CalculatePlanePositionDelta(touch) * scrollSpeed; // Aplica a velocidade de scroll
        if (touch.phase == TouchPhase.Moved)
        {
            Vector3 newPosition = cam.transform.position - delta;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
            
            cam.transform.position = newPosition;
            //cam.transform.Translate(-delta, Space.World);
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
            //cam.m_Lens.FieldOfView /= zoomFactor;
            Vector3 currentPos = cam.transform.position;
            currentPos.y = Mathf.Clamp(currentPos.y * zoomFactor, minY, maxY);
            cam.transform.position = currentPos;

        }
    }

    /*private void HandleRotation(Touch touch1, Touch touch2, Touch touch3)
    {
        
        Vector3 position1 = CalculatePlanePosition(touch1.position);
        Vector3 position2 = CalculatePlanePosition(touch2.position);
        Vector3 position3 = CalculatePlanePosition(touch3.position);

        Vector3 centerPosition = (position1 + position2 + position3) / 3;

        Vector3 delta1 = CalculatePlanePositionDelta(touch1);
        Vector3 delta2 = CalculatePlanePositionDelta(touch2);
        Vector3 delta3 = CalculatePlanePositionDelta(touch3);

        float deltaY = (delta1.y + delta2.y + delta3.y) / 3;

        float rotationAmount = deltaY * rotationSpeed * Time.deltaTime;

        cam.transform.Rotate(rotationAmount, 0f, 0f);
    }*/

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
