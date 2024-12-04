using UnityEngine;
using System;  // Para usar Action
using System.Collections;  // Para usar IEnumerator e Coroutine

public class PinchaForceReceiver : MonoBehaviour
{
    public Rigidbody tampinhaRb;  // Referência ao Rigidbody da tampinha
    public float maxForce = 1000f;  // Força máxima aplicável
    public float delayBeforeEvent = 0.2f;  // Tempo de espera antes de invocar o evento

    // Delegate para indicar o movimento da tampinha
    public static event Action<bool> OnPinchaMovement;

    void OnEnable()
    {
        ForceSliderController.ForceReleased += ApplyForce;  // Inscreve no evento de controle de força
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

        // Inicia a Coroutine para invocar o evento após o tempo de espera
        StartCoroutine(WaitAndInvokeMovementEvent());

    }

    // Coroutine que espera e depois invoca o evento
    IEnumerator WaitAndInvokeMovementEvent()
    {
        yield return new WaitForSeconds(delayBeforeEvent);  // Espera pelo tempo definido

        // Invoca o evento para indicar que a tampinha está em movimento
        OnPinchaMovement?.Invoke(true);
    }
}
