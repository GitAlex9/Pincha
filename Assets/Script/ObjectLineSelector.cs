using UnityEngine;
using System.Collections.Generic;

public class ObjectLineSelector : MonoBehaviour
{
    private GameObject[] pinchas;
    private LineRenderer lineRenderer;    

    void Start()
    {
        pinchas = GetComponent<CameraSwitcher>().tampinhas;
    }

    void Update()
    {
        GameObject selectedPincha = CameraSwitcher.tampinhaSelecionada; // Obtém a tampinha selecionada do CameraSwitcher

        if (selectedPincha != null)
        {
            DrawLineBetweenObjects(GetOtherObjects(selectedPincha)); // Desenha a linha entre as tampinhas restantes
        }
    }

    public GameObject[] GetOtherObjects(GameObject selectedPincha)
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
}
