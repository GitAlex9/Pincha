
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;

    public void Pause()
    {
        Debug.Log("Pausando o jogo...");
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Retomar()
    {
        Debug.Log("Retomando à fase...");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Reiniciar()
    {
        Debug.Log("Reiniciando a fase...");
        //Linha 27 dá o comando de reiniciar a fase
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        Debug.Log("Voltando para o Menu...");
        //Gui e Alex, desconsiderem esta função, pois não teremos o Menu montado para a primeira entrega
        //SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}
