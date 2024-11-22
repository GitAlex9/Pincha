using UnityEngine;
using UnityEngine.UI;

public class VibrarComSlider : MonoBehaviour
{
    public Slider slider;  // Referência ao Slider
    public Image buttonImage;  // Referência à imagem do botão
    private bool isVibrating = false;  // Flag para controlar se a vibração está ativa
    private float tempoDeVibracao = 0f;  // Tempo de vibração em milissegundos

    void Start()
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(AlterarVibracao);
        }
    }

    // Método chamado sempre que o valor do Slider muda
    void AlterarVibracao(float valor)
    {
        // Animar o botão de acordo com o valor do Slider
        AnimarBotao(valor);

        // A magnitude da vibração é proporcional ao valor do slider (0 a 1)
        tempoDeVibracao = valor * 1000f; // Multiplicando por 1000 para ajustar a duração em milissegundos

        // Se o jogador ainda estiver pressionando o Slider, continua a vibrar
        if (isVibrating && tempoDeVibracao > 0)
        {
            VibrarCelular(tempoDeVibracao);
        }

        // Alterar a cor do botão com base no valor do Slider
        AlterarCorBotao(valor);
    }

    // Animar o botão (por exemplo, modificando a escala)
    void AnimarBotao(float valor)
    {
        // A escala vai de 1 a 1.2, por exemplo, conforme o valor do Slider aumenta
        float scale = 1f + (valor * 0.2f); // A escala vai de 1 a 1.2 dependendo do valor do Slider
        LeanTween.scale(buttonImage.gameObject, new Vector3(scale, scale, 1f), 0.1f).setEase(LeanTweenType.easeOutQuad);
    }

    // Alterar a cor do botão com base no valor do Slider
    void AlterarCorBotao(float valor)
    {
        Color cor = Color.green; // Cor padrão

        if (valor > 0.5f)
        {
            // Se o valor for maior que 0.5, gradualmente fica mais vermelho
            cor = Color.Lerp(Color.green, Color.red, (valor - 0.5f) * 2f);  // Faz a transição de verde/azul para vermelho
        }

        buttonImage.color = cor;
    }

    // Método para começar a vibrar quando o botão do Slider for pressionado
    public void OnPointerDown()
    {
        isVibrating = true;  // Inicia a vibração
        AlterarVibracao(slider.value);  // Começa a vibração com o valor atual do Slider
    }

    // Método para parar a vibração quando o botão do Slider for solto
    public void OnPointerUp()
    {
        isVibrating = false;  // Para a vibração
        StopVibration();  // Parar a vibração no dispositivo
    }

    // Método para fazer o celular vibrar
    void VibrarCelular(float duracao)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // A vibração só ocorre se o valor for maior que 0
            if (duracao > 0)
            {
                AndroidJavaObject vibrator = new AndroidJavaObject("android.os.Vibrator");

                if (vibrator != null)
                {
                    vibrator.Call("vibrate", (long)duracao);  // Vibra pelo tempo calculado
                }
            }
        }
    }

    // Método para parar a vibração no Android
    void StopVibration()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaObject vibrator = new AndroidJavaObject("android.os.Vibrator");

            if (vibrator != null)
            {
                vibrator.Call("cancel");  // Cancela a vibração no Android
            }
        }
    }
}
