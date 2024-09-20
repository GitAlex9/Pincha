using UnityEngine;
using System.Collections.Generic;

public class ObjectLineSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] pinchas;
    private Camera cam;
    private LineRenderer lineRenderer;
    private GameObject selectedPincha;
    private TelaVitoria telaVitoria; // Para chamar a UI de Vitoria

    void Start()
    {
        cam = Camera.main;
        telaVitoria = FindAnyObjectByType<TelaVitoria>();
    }

    void Update()
    {
        HandleTouchInput();

        if (selectedPincha != null)
        {
            CheckObjectCrossing();
            DrawLineBetweenObjects(GetOtherObjects(selectedPincha));
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out RaycastHit hit) && TrySelectPincha(hit.transform.gameObject))
            {
                Debug.Log("Pincha selecionado.");
            }
        }
    }

    private bool TrySelectPincha(GameObject hitObject)
    {
        foreach (var pincha in pinchas)
        {
            if (hitObject == pincha)
            {
                selectedPincha = hitObject;
                return true;
            }
        }
        return false;
    }

    private GameObject[] GetOtherObjects(GameObject selectedPincha)
    {
        List<GameObject> otherObjects = new List<GameObject>();

        foreach (var pincha in pinchas)
        {
            if (pincha != selectedPincha)
                otherObjects.Add(pincha);

            if (otherObjects.Count >= 2)
                break;
        }

        return otherObjects.ToArray();
    }

    private void DrawLineBetweenObjects(GameObject[] otherObjects)
    {
        if (otherObjects.Length < 2) return;

        if (lineRenderer != null)
        {
            Destroy(lineRenderer.gameObject);
        }

        GameObject lineObject = new GameObject("Line");
        lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(new Vector3[] { otherObjects[0].transform.position, otherObjects[1].transform.position });

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.blue;
    }

    private void CheckObjectCrossing()
    {
        GameObject[] otherObjects = GetOtherObjects(selectedPincha);

        // Verifique se a seleção e os outros objetos estão corretos
        if (otherObjects == null || otherObjects.Length < 2 || selectedPincha == null)
        {
            Debug.LogWarning("Objetos insuficientes ou seleção inválida.");
            return;
        }

        Vector3 start = otherObjects[0].transform.position;
        Vector3 end = otherObjects[1].transform.position;
        Vector3 direction = (end - start).normalized;
        float distance = Vector3.Distance(start, end);
        Vector3 offsetStart = start + direction * 0.5f;
        Vector3 offsetEnd = end - direction * 0.5f;

        Debug.DrawLine(offsetStart, offsetEnd, Color.green);

        if (Physics.Raycast(offsetStart, direction, out RaycastHit hit, distance))
        {
            if (hit.transform.gameObject == selectedPincha)
            {
                Debug.Log("Colidiu com: " + hit.collider.name);
                telaVitoria.VerificarResultado(true); // Chamada da funcao da UI Vitoria
            }
        }
        else
        {
            Debug.Log("Nenhuma colisão detectada.");
        }
    }

}
