using UnityEngine;

public class MovementChecker : MonoBehaviour
{
    private GameObject[] pinchas;
    private ObjectLineSelector objectLineSelector;
    private bool hasCrossedLine = false;
    private int moveCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        pinchas = GetComponent<CameraSwitcher>().tampinhas;
        objectLineSelector = GetComponent<ObjectLineSelector>();
    }


    // Update is called once per frame
    void Update()
    {
        GameObject selectedPincha = CameraSwitcher.tampinhaSelecionada;

        /*while (selectedPincha != null && isMoving)
        {
            CheckObjectCrossing(selectedPincha);
        }
        EndMovement();*/
    }

    private void CheckObjectCrossing(GameObject tampinha)
    {
        GameObject[] otherObjects = objectLineSelector.GetOtherObjects(tampinha);

        if (otherObjects == null || otherObjects.Length < 2 || tampinha == null)
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
            if (hit.transform.gameObject == tampinha)
            {
                Debug.Log("Colidiu com: " + hit.collider.name);
                hasCrossedLine = true;  // Marca que a linha foi cruzada
            }
        }
    }

    private void EndMovement()
    {
        if (hasCrossedLine)
        {
            moveCount++;
            Debug.Log("Você fez " + moveCount + " movimento válido.");
            hasCrossedLine = false;
        }
        else
        {
            Debug.Log("Derrota! A tampinha não cruzou a linha.");
        }
    }
}
