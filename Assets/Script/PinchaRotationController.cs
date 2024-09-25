using UnityEngine;

public class PinchaRotationController : MonoBehaviour
{
    public float rotationSpeed = 1f;  // Velocidade de rotação
    public Transform pinchaTransform;
    private Vector2 touchStartPos;
    private bool isDragging = false;


    void Update()
    {
        HandleTouchRotation();
    }

    // Função para lidar com a rotação com o toque na tela
    void HandleTouchRotation()
    {
        // Verifica se há um toque na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Armazena a posição inicial do toque
                touchStartPos = touch.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                // Calcula a diferença do toque em relação à posição inicial
                Vector2 touchDelta = touch.position - touchStartPos;

                // Converte o movimento horizontal do toque em uma rotação
                float rotationAmount = touchDelta.x * rotationSpeed * Time.deltaTime;

                // Aplica a rotação no eixo Y (rotação horizontal)
                pinchaTransform.transform.Rotate(0f, rotationAmount, 0f);

                // Atualiza a posição inicial do toque para manter a rotação contínua
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }
    }
}
