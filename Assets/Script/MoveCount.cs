using UnityEngine;
using TMPro;

public class MoveCount : MonoBehaviour
{
    public TextMeshProUGUI MoveCounter;  // Reference to the TextMeshPro UI element
    public TesteCollider moveChecker;    // Reference to the TesteCollider script

    void Start()
    {
        UpdateTextUI();  // Initialize the UI text at the start
    }

    void UpdateTextUI()
    {
        MoveCounter.text = "" + moveChecker.moveCount.ToString();
    }

    public void UpdateCountText()
    {
        UpdateTextUI();  // This will be called by TesteCollider when the move count changes
    }
}