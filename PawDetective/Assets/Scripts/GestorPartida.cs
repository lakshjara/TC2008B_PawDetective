using UnityEngine;

public class GestorPartida : MonoBehaviour
{
    public int meta = 3;

    private int rescatadas = 0;
    private bool terminada = false;

    public bool MisionCumplida
    {
        get { return rescatadas >= meta; }
    }

    public void Rescatar()
    {
        if (terminada) return;

        rescatadas++;

        Debug.Log("Mascotas encontradas: " + rescatadas + " de " + meta);

        if (MisionCumplida)
        {
            Debug.Log("¡Encontraste todas las mascotas!");
        }
    }

    public void Ganar()
    {
        // evitar que la partida termine dos veces
        if (terminada) return;

        terminada = true;
        Debug.Log("¡Ganaste!");
    }
}
