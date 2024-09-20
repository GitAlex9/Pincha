using UnityEngine;

public class ObjectLineSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] pinchas;
    private Camera cam;
    private LineRenderer lineRenderer;
    private Vector3 lineStart;
    private Vector3 lineEnd;
    private GameObject selectedPincha;
    private Vector3 prevPosition;
    public int movementCount = 0;

    void Start()
    {
        cam = Camera.main;
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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = cam.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit) && TrySelectPincha(hit.transform.gameObject))
                {
                    Debug.Log("teste");
                }
            }
        }
    }

    private bool TrySelectPincha(GameObject hitObject)
    {
        for (int i = 0; i < pinchas.Length; i++)
        {
            if (hitObject == pinchas[i])
            {
                selectedPincha = hitObject;
                prevPosition = selectedPincha.transform.position;
                return true;
            }
        }
        return false;
    }

    private GameObject[] GetOtherObjects(GameObject selectedPincha)
    {
        GameObject[] otherObjects = new GameObject[2];
        int index = 0;

        foreach (var pincha in pinchas)
        {
            if (pincha != selectedPincha && index < 2)
            {
                otherObjects[index++] = pincha;
            }
        }

        return otherObjects;
    }

    private void DrawLineBetweenObjects(GameObject[] otherObjects)
    {
        if (lineRenderer != null)
        {
            Destroy(lineRenderer.gameObject);
        }

        if (otherObjects.Length < 2) return;

        GameObject lineObject = new GameObject("Line");
        lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(new Vector3[] { otherObjects[0].transform.position, otherObjects[1].transform.position });

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.blue;

        lineStart = otherObjects[0].transform.position;
        lineEnd = otherObjects[1].transform.position;
    }

    private void CheckObjectCrossing()
    {
        // Obtenha os outros objetos
        GameObject[] otherObjects = GetOtherObjects(selectedPincha);

        // Verifique se há colisão entre os outros objetos
        if (otherObjects.Length < 2) return;

        Vector3 start = otherObjects[0].transform.position;
        Vector3 end = otherObjects[1].transform.position;
        Vector3 direction = (end - start).normalized; // Direção do raio

        float offset = 0.5f;

        Vector3 offsetStart = start + direction * offset;
        Vector3 offsetEnd = end - direction * offset;


        // Desenha a linha no Editor para visualização
        Debug.DrawLine(offsetStart, offsetEnd, Color.green);
        // Verifica se há colisão ao longo do raio
        RaycastHit hit;
        if (Physics.Raycast(offsetStart, direction, out hit, Vector3.Distance(offsetStart, offsetEnd)))
        {
            Debug.Log("Colidiu com: " + hit.collider.name);  

            if (hit.transform.gameObject == selectedPincha)
            {
                Debug.Log("colidiu");
            }          
        }
        else
        {
            Debug.Log("Nenhuma colisão detectada.");
        }
    }
}
