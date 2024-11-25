using UnityEngine;
using System.Collections;

public class StarCrownManager : MonoBehaviour
{
    [SerializeField] private Star[] stars;

    [SerializeField] private float enlargeScale = 1.5f;
    [SerializeField] private float shrinkScale = 1f;
    [SerializeField] private float enlargeDuration = 0.25f;
    [SerializeField] private float shrinkDuration = 0.25f;

    public void ShowStars(int numberOfStars)
    {
        StartCoroutine(ShowStarsRoutine(numberOfStars));
    }

    private IEnumerator ShowStarsRoutine(int numberOfStars)
    {
        // Inicializa todas as estrelas com escala zero.
        foreach (var star in stars)
        {
            star.starCrown.transform.localScale = Vector3.zero;
        }

        // Mostra as estrelas até o número especificado.
        for (int i = 0; i < numberOfStars; i++)
        {
            yield return AnimateStar(stars[i]);
        }
    }

    private IEnumerator AnimateStar(Star star)
    {
        // Realiza a animação de ampliar e reduzir a estrela.
        yield return ChangeStarScale(star, enlargeScale, enlargeDuration);
        yield return ChangeStarScale(star, shrinkScale, shrinkDuration);
    }

    private IEnumerator ChangeStarScale(Star star, float targetScale, float duration)
    {
        var starTransform = star.starCrown.transform; // Evita múltiplos acessos ao transform.
        Vector3 initialScale = starTransform.localScale;
        Vector3 targetScaleVector = Vector3.one * targetScale;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            starTransform.localScale = Vector3.Lerp(initialScale, targetScaleVector, t);
            yield return null;
        }

        // Garante que a escala final seja a exata ao final da interpolação.
        starTransform.localScale = targetScaleVector;
    }
}
