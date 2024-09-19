using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public Material selectedMaterial; // Material para o efeito de stroke
    private Material originalMaterial; // Material original do GameObject
    private bool isSelected = false;

    void Start()
    {
        // Armazena o material original
        if (GetComponent<MeshRenderer>() != null)
        {
            originalMaterial = GetComponent<MeshRenderer>().material;
        }
    }

    void Update()
    {
        // Verifica se há toque na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform == transform)
                    {
                        ToggleSelection();
                    }
                }
            }
        }
    }

    private void ToggleSelection()
    {
        if (isSelected)
        {
            Deselect();
        }
        else
        {
            Select();
        }
    }

    private void Select()
    {
        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().material = selectedMaterial;
        }
        isSelected = true;
    }

    private void Deselect()
    {
        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().material = originalMaterial;
        }
        isSelected = false;
    }
}
