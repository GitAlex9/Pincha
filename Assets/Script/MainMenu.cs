using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string NameGameLevel;
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelOpcoes;
    
    public void Jogar(){
        SceneManager.LoadScene(NameGameLevel);
    }

    public void AbrirOpcoes(){
        painelMenu.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes(){
        painelMenu.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void Creditos(){
        SceneManager.LoadScene("Credits");
    }

}
