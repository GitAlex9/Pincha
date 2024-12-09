using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class Credits : MonoBehaviour
{
    public float scrollSpeed = 200f;
    public float endPosition = 2000f;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

        // Verifica se a posição final foi alcançada
        if (rectTransform.anchoredPosition.y >= endPosition)
        {
            // Chama a próxima cena
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
