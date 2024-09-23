using UnityEngine;

public class TouchCameraController : MonoBehaviour
{
    public GameObject selectedTampinha;  // A tampinha que está sendo seguida
    public Transform cameraTransform;    // A câmera que será rotacionada

    [Header("Camera Settings")]
    public float rotationSpeed = 1f;     // A velocidade da rotação
    public float cameraDistance = 2f;    // Distância da câmera em relação à tampinha
    public float cameraHeight = 1f;      // Altura da câmera em relação à tampinha
    public float cameraAngle = 15f;      // Ângulo da câmera (em graus) ajustável no Inspector

    private Vector3 offset;

    void Start()
    {
        // Define o offset inicial da câmera com base na distância e altura ajustáveis
        offset = new Vector3(0, cameraHeight, -cameraDistance);
    }

    void Update()
    {
        // Rotaciona a câmera com base no toque
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                // Calcula a rotação com base na movimentação do toque
                    float rotationX = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;

                // Aplica a rotação horizontal ao offset
                    offset = Quaternion.Euler(0, rotationX, 0) * offset;
                }
        }

        // Atualiza a posição da câmera com base no offset e ângulo da câmera
        if (selectedTampinha != null)
        {
            Vector3 tampinhaPosition = selectedTampinha.transform.position;

            // Aplica o offset em relação à tampinha
            cameraTransform.position = tampinhaPosition + offset;

            // Define o ponto que a câmera irá olhar com base no ângulo ajustado
            Vector3 lookTarget = tampinhaPosition + Vector3.up * Mathf.Tan(cameraAngle * Mathf.Deg2Rad) * cameraDistance;

            // Faz a câmera olhar para o ponto com base no ângulo
            cameraTransform.LookAt(lookTarget);
        }
    }
}
