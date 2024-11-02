using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("VOCE PERDEU, TU É RUIM DE MAIS HEIN!! HAHAHA");
        }
    }
}
