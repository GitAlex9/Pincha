using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject[] tampinhas; // Array com as tampinhas
    public Cinemachine.CinemachineVirtualCamera[] cameras; // Câmeras Cinemachine correspondentes
    public Cinemachine.CinemachineVirtualCamera navigationCamera; // Referência à câmera de navegação
    public static GameObject tampinhaSelecionada; // Armazena a tampinha selecionada globalmente
    public Rigidbody rb;

    // private ObjectLineSelector objectLineSelector;

    // void Start()
    // {
    //    // objectLineSelector = GetComponent<ObjectLineSelector>();
    // }

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

    // void Update()
    // {
    //     if (tampinhaSelecionada != null)
    //     {
    //         MakeCameraLookAtMiddleOfOtherObjects(tampinhaSelecionada);
    //     }
    // }

    // private void MakeCameraLookAtMiddleOfOtherObjects(GameObject selectedTampinha)
    // {
    //     GameObject[] otherObjects = objectLineSelector.GetOtherObjects(selectedTampinha);

    //     // Calcula o ponto médio entre as outras duas tampinhas
    //     if (otherObjects.Length == 2)
    //     {
    //         Vector3 pontoMedio = (otherObjects[0].transform.position + otherObjects[1].transform.position) / 2;

    //         // Encontra a câmera da tampinha selecionada
    //         int index = System.Array.IndexOf(tampinhas, selectedTampinha);
    //         if (index >= 0 && index < cameras.Length)
    //         {
    //             // Faz a câmera olhar para o ponto médio
    //             cameras[index].transform.LookAt(pontoMedio);
    //         }
    //     }
    // }

    public void SwitchToNavigationCamera()
    {
        // Desativa todas as câmeras das tampinhas
        foreach (var cam in cameras)
        {
            cam.gameObject.SetActive(false);
            tampinhaSelecionada = null;
        }

        // Ativa a câmera de navegação
        navigationCamera.gameObject.SetActive(true);
    }
}
