using UnityEngine;

// Um script simples que destrói o aviso após alguns segundos, criando um efeito de "Toast"
public class AvisoInicial : MonoBehaviour
{
    // Tempo que a mensagem vai ficar na tela antes de sumir
    public float tempoVisivel = 5f;

    void Start()
    {
        // O comando Destroy pode destruir um objeto instantaneamente ou após um tempo.
        // Aqui, dizemos: "Destrua ESTE objeto (o texto) depois de X segundos".
        Destroy(gameObject, tempoVisivel);
    }
}
