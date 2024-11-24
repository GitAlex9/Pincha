using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public Image starCrown;

    private RectTransform rectTransform;

    private void Awake()
    {
        starCrown = GetComponent<Image>();
        rectTransform = starCrown.GetComponent<RectTransform>();
        
        // Inicializa a escala como zero.
        rectTransform.localScale = Vector3.zero;
    }
}
