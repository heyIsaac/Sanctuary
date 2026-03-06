using UnityEngine;
using UnityEngine.InputSystem;

public class InteracaoJogador : MonoBehaviour
{
    public float distanciaInteracao = 5f; // Aumentei um pouco a distância por segurança
    public LayerMask layerPorta;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("ERRO: Câmera não encontrada! A câmera do jogador precisa ter a tag 'MainCamera'.");
        }
    }

    void Update()
    {
        // Verifica se apertou E
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("1. Tecla E pressionada!");
            TentarInteragir();
        }
    }

    void TentarInteragir()
    {
        if (cam == null) return;

        Ray raio = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit colisao;

        // Desenha um laser vermelho na aba SCENE para você ver para onde está olhando
        Debug.DrawRay(raio.origin, raio.direction * distanciaInteracao, Color.red, 2f);

        if (Physics.Raycast(raio, out colisao, distanciaInteracao, layerPorta))
        {
            Debug.Log("2. O raio BATEU EM: " + colisao.collider.gameObject.name);

            Porta portaEncontrada = colisao.collider.GetComponentInParent<Porta>();

            if (portaEncontrada != null)
            {
                Debug.Log("3. Script da Porta ENCONTRADO! Acionando...");
                portaEncontrada.AlternarPorta();
            }
            else
            {
                Debug.LogWarning("O raio bateu na porta, mas não achou o script 'Porta.cs' no objeto pai.");
            }
        }
        else
        {
            Debug.Log("O raio foi disparado, mas não acertou nada que tenha a Layer 'Interagivel'.");
        }
    }
}
