using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineProjection : MonoBehaviour
{
    public LineRenderer lineRenderer;  // Referência ao Line Renderer
    public float lineLength = 5f;      // Comprimento da linha
    public Transform pinchaTransform;  // Referência à tampinha (GameObject)
    public bool activeLineRenderer {get; set;}

    void Start()
    {
        activeLineRenderer = true;
    }

    void FixedUpdate()
    {
        if (activeLineRenderer)
        {
        lineRenderer.SetPosition(0, pinchaTransform.position);
        // Define o ponto final da linha (projetado à frente da câmera)
        Vector3 endPoint = pinchaTransform.position + pinchaTransform.forward * lineLength;
        lineRenderer.SetPosition(1, endPoint);
        // Rotaciona a tampinha para seguir a direção da câmera
        pinchaTransform.rotation = Quaternion.LookRotation(pinchaTransform.forward);
        }
        else if (!activeLineRenderer)
        {
            lineRenderer.SetPosition(0, pinchaTransform.position);
            lineRenderer.SetPosition(1, pinchaTransform.position);
        }        
    }
}
