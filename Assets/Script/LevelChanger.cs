using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelChanger : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup; // Canvas Group do FadeImage
    public float fadeDuration = 1f;    // Duração do fade-in e fade-out
    public float displayTime = 1f;     // Tempo para exibir a cena inicial antes de trocar

    private void Start()
    {
        // Garante que a tela começa preta
        fadeCanvasGroup.alpha = 1;

        // Inicia a sequência de fade-in, exibição e fade-out
        StartCoroutine(PlayIntroSequence());
    }

    private IEnumerator PlayIntroSequence()
    {
        // Fade-in (clarear a tela)
        yield return StartCoroutine(Fade(1, 0));

        // Espera o tempo de exibição da tela inicial
        yield return new WaitForSeconds(displayTime);

        // Fade-out (escurecer a tela)
        yield return StartCoroutine(Fade(0, 1));

        // Carrega a Cena do Menu
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, timer / fadeDuration);
            yield return null;
        }

        // Garante que a opacidade final está correta
        fadeCanvasGroup.alpha = endAlpha;
    }
}
