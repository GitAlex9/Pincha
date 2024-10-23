using UnityEngine;

using UnityEngine.SceneManagement;

public class TelaVitoriaFinal : MonoBehaviour

{

public GameObject telaVitoria; // Referência ao Canvas de tela de vitória

void Start()

{

if (telaVitoria != null)

{

telaVitoria.SetActive(true); // Certifique-se de que o Canvas de tela de vitória está desativado no início
Time.timeScale = 0;

}

else

{

Debug.LogWarning("telaVitoria não está no Inspector");

}

}

/*public void ShowVictoryScreen()

{

if (telaVitoria != null)

{

telaVitoria.SetActive(true); // Ativa o Canvas de tela de vitória

Time.timeScale = 0; // Pausa o jogo

}

}

*/

// Função chamada pelo botão "Próxima Fase"

public void LoadNextLevel()

{

Time.timeScale = 1; // Retorna o tempo de jogo ao normal

Debug.Log("Próxima fase...");
// Carrega a próxima cena (supondo que as cenas estão em ordem no Build Settings)
/*
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
*/

}

// Função chamada pelo botão "Menu"

public void GoToMenu()

{
// ESTE É CÓDIGO CORRETO! ESTE É CÓDIGO CORRETO!
/*
Time.timeScale = 1; // Retorna o tempo de jogo ao normal

// Carrega a cena do Menu
Debug.Log("Você voltou para o Menu");
/*
CARREGA O MENU
SceneManager.LoadScene("Menu");
*/

//VOU ADICIONAR UM RETRY APENAS PARA A NOSSA ENTREGA
Debug.Log("Você foi para o Menu, mas sabemos que deu Retry!");
Time.timeScale = 1; // Retorna o tempo de jogo ao normal

SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}

}
