using System;
using UnityEngine;

public class CheckMovement : MonoBehaviour
{
    private bool isMoving;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LineProjection lineProjection; // Referência à classe LineProjection

    void Start()
    {
        isMoving = false;        
    }

    void OnEnable()
    {
        ForceSliderController.ForceReleased += StartMovement;  // Inscreve no evento de controle de força
    }

    void OnDisable()
    {
        ForceSliderController.ForceReleased -= StartMovement;  // Remove inscrição no evento
    }

    void StartMovement(float value)
    {
        if (value > 0 && rb.velocity.magnitude > 0f)
        {
            isMoving = true;
            if (lineProjection != null)
            {
                lineProjection.gameObject.SetActive(false); // Ativa a classe LineProjection
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (rb.velocity.magnitude == 0)
            {
                if (lineProjection != null)
                {
                    lineProjection.gameObject.SetActive(true); // Desativa a classe LineProjection
                }
                isMoving = false;                
            }
        }
    }

    public static implicit operator Rigidbody(CheckMovement v)
    {
        throw new NotImplementedException();
    }
}
