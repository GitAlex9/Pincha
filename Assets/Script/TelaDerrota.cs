using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;

public class TelaDerrota : MonoBehaviour
{

public GameObject telaDerrota;

void Start()

{

if (telaDerrota != null)

{

telaDerrota.SetActive(true); // Certifique-se de que o Canvas de tela de vitória está desativado no início
Time.timeScale = 0;

}
}


void Update()

{

}

public void GoToMenu()

{

Time.timeScale = 1; // Retorna o tempo de jogo ao normal

// Carrega a cena do Menu
Debug.Log("Você voltou para o Menu");
/*
CARREGA O MENU
SceneManager.LoadScene("Menu");
*/

}

public void RetryLevel()

{
Debug.Log("Você reiniciou a fase!");
Time.timeScale = 1; // Retorna o tempo de jogo ao normal

SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}

}

