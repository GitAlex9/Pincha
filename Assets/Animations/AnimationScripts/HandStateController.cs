using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandStateController : MonoBehaviour
{
    private Animator animator;
    int isAttackingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttacking = animator.GetBool(isAttackingHash);
        bool forwardPressed = Input.GetKey(KeyCode.W);

        if (!isAttacking && forwardPressed)
        {
            animator.SetBool("isAttacking", true);
            Debug.Log("a");

        }
        if (isAttacking && !forwardPressed)
        {
            animator.SetBool("isAttacking", false);
            Debug.Log("b");
        }
    }
}
