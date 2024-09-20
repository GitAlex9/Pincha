using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaVitoria : MonoBehaviour
{
    [SerializeField] private GameObject faseCompleta;
    //[SerializeField] GameObject chamadaVitoria;
    //[SerializeField] GameObject chamadaDerrota;

/*
public void VerificarResultado(bool venceu)
{
    if (venceu)
    {
        Debug.Log("Voc� venceu a fase!");
        chamadaVitoria.SetActive(true);
    }
    else
    {
        Debug.Log("Voc� perdeu a fase!");
        //Futuramente, iremos implementar o GameObject que chama o painel de Derrota
        chamadaDerrota.SetActive(true);
    }

    faseCompleta.SetActive(true);
    Time.timeScale = 0;
}
*/

/*
// Exemplo de uso em outro script
public void FaseTerminada(bool venceu)
{
FaseCompleta faseCompleta = FindObjectOfType<FaseCompleta>();
if (faseCompleta != null)
{
    faseCompleta.VerificarResultado(venceu);
}
}
*/


public void Continuar()
{
    //Aqui temos que adicionar a linha que chamar� a pr�xima Cena
    Debug.Log("Continuar para a pr�xima fase...");
    faseCompleta.SetActive(false);
    Time.timeScale = 1;
}

public void Reiniciar()
{
    Debug.Log("Reiniciando a fase...");
    //Linha 26 d� o comando de reiniciar a fase
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1;
}

public void Menu()
{
    Debug.Log("Voltando para o Menu...");
    //Gui e Alex, desconsiderem esta fun��o, pois n�o teremos o Menu montado para a primeira entrega
    //SceneManager.LoadScene("Main Menu");
    Time.timeScale = 1;
}
}
