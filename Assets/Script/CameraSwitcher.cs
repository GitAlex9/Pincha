using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject[] tampinhas; // Array com as tampinhas
    public Cinemachine.CinemachineVirtualCamera[] cameras; // Câmeras Cinemachine correspondentes
    public GameObject[] touchSelection;
    public Cinemachine.CinemachineVirtualCamera navigationCamera; // Referência à câmera de navegação
    public static GameObject tampinhaSelecionada; // Armazena a tampinha selecionada globalmente
    public Rigidbody rb;

    public void SelectTampinha(int index)
    {
        // Desativa todas as câmeras
        foreach (var cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        // Ativa a câmera correspondente à tampinha selecionada
        if (index >= 0 && index < cameras.Length)
        {
            cameras[index].gameObject.SetActive(true);
            tampinhaSelecionada = tampinhas[index]; // Define a tampinha ativa
            rb = tampinhas[index].GetComponent<Rigidbody>();
        }
    }

    public void CheckTouchOnPincha(int index)
    {
        foreach (var obj in touchSelection)
        {
            obj.SetActive(false);
        }

        if (index >=0 && index < touchSelection.Length)
        {
            touchSelection[index].SetActive(true);
        }
    }
    public void SwitchToNavigationCamera()
    {
        // Desativa todas as câmeras das tampinhas
        foreach (var cam in cameras)
        {
            cam.gameObject.SetActive(false);
            tampinhaSelecionada = null;
        }

        foreach (var obj in touchSelection)
        {
            obj.SetActive(false);
        }

        // Ativa a câmera de navegação
        navigationCamera.gameObject.SetActive(true);
    }
}
