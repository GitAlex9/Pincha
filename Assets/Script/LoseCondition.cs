using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    public GameObject derrota;
    
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player")
        {
            derrota.SetActive(true);
        }
    }
}
