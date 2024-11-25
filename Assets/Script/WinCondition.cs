using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject victoryUI;
    public GameObject defeteadUI;
    public TesteCollider testeCollider;
    public StarCrownManager starCrownManager;
    [SerializeField] private int threeStar;
    [SerializeField] private int twoStar;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            victoryUI.SetActive(true);
            if (testeCollider.moveCount <= threeStar)
            {
                Debug.Log("GANHOU 3 ESTRELAS");
                starCrownManager.ShowStars(3);
            }
            else if (testeCollider.moveCount <= twoStar)
            {
                starCrownManager.ShowStars(2);
            }
            else
            {
                starCrownManager.ShowStars(1);
            }
        }
    }
}
