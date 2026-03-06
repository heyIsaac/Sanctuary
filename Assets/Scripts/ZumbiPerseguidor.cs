using UnityEngine;
using UnityEngine.AI; // Obriga a Unity a ler os códigos de Inteligência Artificial

public class ZumbiPerseguidor : MonoBehaviour
{
    public Transform jogador; // O alvo que o zumbi vai seguir
    private NavMeshAgent agente;

    void Start()
    {
        // Pega o componente NavMeshAgent que adicionamos na cápsula
        agente = GetComponent<NavMeshAgent>();

        if (jogador == null)
        {
            Debug.LogWarning("Você esqueceu de colocar o Jogador no script do Zumbi!");
        }
    }

    void Update()
    {
        // Se o jogador existir, manda o zumbi ir até a posição dele o tempo todo
        if (jogador != null)
        {
            agente.SetDestination(jogador.position);
        }
    }
}
