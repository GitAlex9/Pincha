using UnityEngine;

public class WellDoneScreenManager : MonoBehaviour
{
    [SerializeField] Star[] Stars;

    [SerializeField] float EnlargeScale = 1.5f;
    [SerializeField] float ShrinkScale = 1f;
    [SerializeField] float EnlargeDuration = 0.25f;
    [SerializeField] float ShrinkDuration = 0.25f;

    private void Start() {
        ShowStars(3);
    }
    
    public void ShowStars(int numberOfStars)
    {
        foreach (Star star in Stars)
        {
            RectTransform rectTransform = star.starCrown.GetComponent<RectTransform>();
            rectTransform.localScale = Vector3.zero; // Inicializa a escala como zero.
        }

        for (int i = 0; i < numberOfStars; i++)
        {
            AnimateStar(Stars[i], i);
        }
    }

    private void AnimateStar(Star star, int delayIndex)
    {
        RectTransform rectTransform = star.starCrown.GetComponent<RectTransform>();
        float delay = delayIndex * (EnlargeDuration + ShrinkDuration);

        // Animação de "Enlarge" e depois "Shrink" usando LeanTween.
        LeanTween.scale(rectTransform, Vector3.one * EnlargeScale, EnlargeDuration)
            .setDelay(delay)
            .setEase(LeanTweenType.easeOutBounce)
            .setOnComplete(() =>
            {
                LeanTween.scale(rectTransform, Vector3.one * ShrinkScale, ShrinkDuration)
                    .setEase(LeanTweenType.easeInOutQuad);
            });
    }
}
