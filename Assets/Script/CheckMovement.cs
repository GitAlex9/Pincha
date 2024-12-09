using System;
using UnityEngine;

public class CheckMovement : MonoBehaviour
{
    private bool isMoving;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LineProjection lineProjection; // Referência à classe LineProjection
    [SerializeField] private GameObject forceSliderController;
    [SerializeField] private GameObject buttonMenu;
 
    public AudioClip soundClip; 
    public AudioSource audioSource; 

    void Start()
    {
        isMoving = false;    

        audioSource = GetComponent<AudioSource>();    
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
            audioSource.PlayOneShot(soundClip);
            if (lineProjection != null)
            {
                lineProjection.activeLineRenderer = false; // Ativa a classe LineProjection
                forceSliderController.SetActive(false);
                buttonMenu.SetActive(false);
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
                    lineProjection.activeLineRenderer = true; // Desativa a classe LineProjection
                    forceSliderController.SetActive(true);
                    buttonMenu.SetActive(true);
                }
                isMoving = false;  
                audioSource.Stop();              
               
            }
        }

    }

    public static implicit operator Rigidbody(CheckMovement v)
    {
        throw new NotImplementedException();
    }
}