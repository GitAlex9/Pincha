using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    private Material originalMaterial;
    private bool isSelected = false;
    public GameObject tampinhaSelecionada;
    private TouchCameraController touchCameraController;
    private Outline outline;

    void Start()
    {
        touchCameraController = GetComponent<TouchCameraController>();
        if (tampinhaSelecionada != null)
        {
            originalMaterial = tampinhaSelecionada.GetComponent<MeshRenderer>().material;
            outline = tampinhaSelecionada.GetComponent<Outline>();
            outline.enabled = false;
        }
    }

    void Update()
    {
        if (!isSelected && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == tampinhaSelecionada.transform)
                {
                    ToggleSelection();
                }
            }
        }
    }

    private void ToggleSelection()
    {
        if (isSelected)
            Deselect();
        else
            Select();
    }

    private void Select()
    {
        if (tampinhaSelecionada != null)
        {
            outline.enabled = true;
            touchCameraController.MoveCameraOff();
            isSelected = true;
        }
    }

    private void Deselect()
    {
        if (tampinhaSelecionada != null)
        {
            outline.enabled = false;
            touchCameraController.MoveCameraOn();
            isSelected = false;
        }
    }
}
