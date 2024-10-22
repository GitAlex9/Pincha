
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject uiButtons;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>(); 
    }

    public void Pause()
    {
        Debug.Log("Pausando o jogo...");
        pauseMenu.SetActive(true);
        uiButtons.SetActive(false);
        Time.timeScale = 0;

        if (audioManager != null)
        {
            audioManager.PauseBackgroundMusic();
        }
    }

    public void Retomar()
    {
        Debug.Log("Retomando à fase...");
        pauseMenu.SetActive(false);
        uiButtons.SetActive(true);
        Time.timeScale = 1;

        if (audioManager != null) 
        {
            audioManager.ResumeBackgroundMusic();
        }
    }

    public void Reiniciar()
    {
        Debug.Log("Reiniciando a fase...");
        //Linha 27 d� o comando de reiniciar a fase
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

        if (audioManager != null) 
        {
            audioManager.ResumeBackgroundMusic(); 
        }
    }

    public void Menu()
    {
        Debug.Log("Voltando para o Menu...");
        //Gui e Alex, desconsiderem esta fun��o, pois n�o teremos o Menu montado para a primeira entrega
        //SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}
