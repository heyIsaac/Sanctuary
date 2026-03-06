using UnityEngine;

public class ZumbiVida : MonoBehaviour
{
    public int vidas = 3; // Quantidade de tiros para ser eliminado

    public void ReceberDano()
    {
        vidas--; // Tira 1 de vida
        Debug.Log("Zumbi tomou um tiro! Vidas restantes: " + vidas);

        if (vidas <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Zumbi eliminado!");
        // Destrói o objeto do zumbi da cena
        Destroy(gameObject);
    }
}
