using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ForceSliderController : MonoBehaviour, IPointerUpHandler
{
    public Slider forceSlider;   // Referência ao slider de força
    private float currentForce;  // Força atual do slider

    public delegate void OnForceReleased(float force);
    public static event OnForceReleased ForceReleased;

    void Update()
    {
        // Atualiza o valor atual da força com base no slider
        currentForce = forceSlider.value;
    }

    // Detecta quando o jogador solta o slider
    public void OnPointerUp(PointerEventData eventData)
    {
        // Dispara o evento quando o toque no slider termina, enviando a força
        ForceReleased?.Invoke(currentForce);
        
        // Opcional: reseta o valor do slider após soltar
        forceSlider.value = 0;
    }
}
