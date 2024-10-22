using System.Collections.Generic;
using UnityEngine;

public class TesteCollider : MonoBehaviour
{
    public Transform[] pos;
    private Transform pincha;
    public float offset = 0;
    private Rigidbody rb;
    private bool isMoving = false;
    private bool moveOk = false;
    public GameObject victoryUI;
    public GameObject defeatUI; 


    void OnEnable()
    {
        PinchaForceReceiver.OnPinchaMovement += OnMoveOk;
    }

    void OnDisable()
    {
        PinchaForceReceiver.OnPinchaMovement -= OnMoveOk;
    }

    public void SelectTransform(int index )
    {
        if (index >= 0 && index < pos.Length)
        {
            pincha = pos[index];
            rb = pos[index].GetComponent<Rigidbody>();
        }
    }
 
    // Update is called once per frame
    void Update()
    {        
        if (pincha != null)
        {
            BoxResize(GetTransforms(pincha));
        } 

        if (isMoving)
        {
            CheckCondiction();

            if (rb.velocity.magnitude <= 0.01 && moveOk == false)
            {
                Debug.Log("você perdeu");
                isMoving = false;

                    if (defeatUI != null)
                    {
                        defeatUI.SetActive(true);
                    }
            }
        }

    }

    public Transform[] GetTransforms(Transform pincha)
    {
        List<Transform> transforms = new List<Transform>();

        foreach (var position in pos)
        {
            if (position != pincha)
            {
                transforms.Add(position);
            }
            if (transforms.Count > 2)
            {
                break;
            }
        }
        return transforms.ToArray();
    }
    void BoxResize(Transform[] pos)
    {
        //Determina a posição do GameObject e para qual objeto ele olha
        Vector3 position = (pos[0].position + pos[1].position)/2.0f;
        transform.position = position;
        transform.LookAt(pos[0].position); 

        //Redimenciona o GameObject com o collider atual.
        Vector3 dif = pos[0].position - pos[1].position;
        float size = dif.magnitude;
        transform.localScale = Vector3.forward * (size - offset) + new Vector3(1, 1, 0);
    }

        private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Você realizou um movimento perfeito");
            moveOk = true;
            
        }
    }

    void CheckCondiction()
    {
        if (moveOk)
        {
            Debug.Log("Chama contador de movimento.");
            moveOk = !moveOk;
            isMoving = false;  

            if (victoryUI != null)
            {
                victoryUI.SetActive(true);
            }                     
        }
    }

    void OnMoveOk(bool value)
    {
        isMoving = value;
    }
}