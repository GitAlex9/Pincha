using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public Image starCrown;

    private void Awake()
    {
        starCrown = GetComponent<Image>();
        starCrown.transform.localScale = Vector3.zero;
    }
}
