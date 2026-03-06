using UnityEngine;

public class Porta : MonoBehaviour
{
    private Animator animator;
    private bool estadoAberta = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("ERRO: O script Porta não encontrou o componente Animator na Porta_Automatica!");
        }
    }

    public void AlternarPorta()
    {
        estadoAberta = !estadoAberta;
        Debug.Log("4. A porta agora deve estar: " + (estadoAberta ? "ABERTA" : "FECHADA"));

        if (animator != null)
        {
            animator.SetBool("isAberta", estadoAberta);
        }
    }
}
