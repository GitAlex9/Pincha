using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DragAndShoot : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform referencePoint;
    [SerializeField] private TouchCameraController touchCameraController;
    private static bool isDragging = false; // Tornar essa variável estática
    private Vector3 startDrag;
    private Vector3 endDrag;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer não está atribuído ao GameObject");
        }
        else
        {
            lineRenderer.positionCount = 2;            
        }

        if (referencePoint == null)
        {
            referencePoint = transform;
        }
    }

    void Update()
    {
        OnTouch();

        if (isDragging)
        {
            DrawDirectionLine();
        }
        else
        {
            ClearDirectionLine();
        }
    }

    private void OnTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                    if (touch.phase == TouchPhase.Began)
                    {
                        isDragging = true;
                        startDrag = touch.position;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        endDrag = touch.position;
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        isDragging = false;
                        ApplyForce();
                    }
            }
        }
    }

    private void ApplyForce()
    {
        Vector3 dragVector = endDrag - startDrag;
        Vector3 force = new Vector3(-dragVector.x, 0f, -dragVector.y) * power;
        rb.AddForce(force, ForceMode.Impulse);
        this.enabled = false;
        touchCameraController.MoveCameraOn();
    }

    private void DrawDirectionLine()
    {
        Vector3 start = referencePoint.position;
        Vector3 directionVector = endDrag - startDrag;
        Vector3 line = new Vector3(-directionVector.x, 0f, -directionVector.y) * power;
        Vector3 end = start + line;

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }

    private void ClearDirectionLine()
    {
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}
