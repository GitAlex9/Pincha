using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject victoryUI;
    public GameObject defeteadUI;
    public TesteCollider testeCollider;
    public WellDoneScreenManager wellDoneScreenManager;
    [SerializeField] private int winMovement = 7;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            victoryUI.SetActive(true);
            if (testeCollider.moveCount <= winMovement)
            {
                Debug.Log("GANHOU 3 ESTRELAS");
                wellDoneScreenManager.ShowStars(3);

            }
        }
    }
}
