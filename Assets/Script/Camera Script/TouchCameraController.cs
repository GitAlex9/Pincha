using UnityEngine;

public class TouchCameraController : MonoBehaviour
{
    public GameObject selectedTampinha;
    public Transform cameraTransform;

    [Header("Camera Settings")]
    public float rotationSpeed = 1f;
    public float cameraDistance = 2f;
    public float cameraHeight = 1f;
    public float cameraAngle = 15f;

    private Vector3 offset;
    private bool isActive = true;

    void Start()
    {
        offset = new Vector3(0, cameraHeight, -cameraDistance);
    }

    void Update()
    {
        if (selectedTampinha != null)
        {
            UpdateCameraPosition();
            if (isActive)
                TouchMoveCamera();
        }
    }

    private void UpdateCameraPosition()
    {
        Vector3 tampinhaPosition = selectedTampinha.transform.position;
        cameraTransform.position = tampinhaPosition + offset;
        Vector3 lookTarget = tampinhaPosition + Vector3.up * Mathf.Tan(cameraAngle * Mathf.Deg2Rad) * cameraDistance;
        cameraTransform.LookAt(lookTarget);
    }

    public void TouchMoveCamera()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotationX = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                offset = Quaternion.Euler(0, rotationX, 0) * offset;
            }
        }
    }

    public void MoveCameraOn() => isActive = true;
    public void MoveCameraOff() => isActive = false;
}
