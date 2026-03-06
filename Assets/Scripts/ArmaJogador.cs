using UnityEngine;
using UnityEngine.InputSystem; // Sistema novo de botões do Unity

public class ArmaJogador : MonoBehaviour
{
    public float distanciaTiro = 50f; // Alcance do tiro
    private Camera cam;

    void Start()
    {
        cam = Camera.main; // Pega a câmera principal dos olhos do jogador
    }

    void Update()
    {
        // Verifica se o botão ESQUERDO do mouse foi clicado neste frame
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Atirar();
        }
    }

    void Atirar()
    {
        if (cam == null) return;

        // Cria o raio saindo do centro da tela para frente
        Ray raio = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit colisao;

        // Toca um som de tiro aqui no futuro, se quiser!
        Debug.Log("POW! Tiro disparado.");

        // Se o tiro acertar alguma coisa...
        if (Physics.Raycast(raio, out colisao, distanciaTiro))
        {
            // Tenta pegar o script de vida no objeto que o tiro acertou
            ZumbiVida zumbiAtingido = colisao.collider.GetComponent<ZumbiVida>();

            // Se o objeto realmente for um zumbi (tiver o script)...
            if (zumbiAtingido != null)
            {
                zumbiAtingido.ReceberDano(); // Aplica o dano!
            }
        }
    }
}
