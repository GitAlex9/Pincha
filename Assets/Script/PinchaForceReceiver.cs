using UnityEngine;

public class PinchaForceReceiver : MonoBehaviour
{
    public Rigidbody tampinhaRb;  // Referência ao Rigidbody da tampinha
    public float maxForce = 1000f;  // Força máxima aplicável
    bool isMoving;
    public delegate void OnPinchaStopped(bool move);
    public static event OnPinchaStopped pinchaStopped;

    private void Start()
    {
        isMoving = false;
    }
    void OnEnable()
    {
        ForceSliderController.ForceReleased += ApplyForce;  // Se inscreve no evento
    }

    void OnDisable()
    {
        ForceSliderController.ForceReleased -= ApplyForce;  // Remove inscrição no evento
    }

    void ApplyForce(float sliderValue)
    {
        // Calcula a força com base no valor recebido do slider
        float forceAmount = sliderValue * maxForce;

        // Aplica a força na direção forward da tampinha
        tampinhaRb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
        pinchaStopped?.Invoke(isMoving = true);
    }

    void CheckMovement()
    {
        if (tampinhaRb.velocity.magnitude < 0.1f)
        {
            Debug.Log("A tampinha parou de se mover");
            pinchaStopped?.Invoke(false);
        }
    }

    private void Update()
    {
        if (isMoving == true)
        {
            CheckMovement();
        }
    }
}
