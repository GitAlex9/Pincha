using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaVitoria : MonoBehaviour
{
    public GameObject faseCompleta;

    private void Start()
    {
        faseCompleta.SetActive(false);
    }

    public void VerificarResultado(bool venceu)
    {
        if (venceu)
        {
            Debug.Log("Você venceu a fase!");
            faseCompleta.SetActive (true);
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("Você perdeu!");
        }


    }

    public void Continuar()
    {
        Debug.Log("Continuar para a próxima fase...");
        faseCompleta.SetActive(false);
        Time.timeScale = 1;
        // Aqui você pode adicionar lógica para carregar a próxima cena
    }

    public void Reiniciar()
    {
        Debug.Log("Reiniciando a fase...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        Debug.Log("Voltando para o Menu...");
        // Aqui você pode implementar o retorno ao menu principal
    }
}
