using UnityEngine;

public class Salida : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // comprobar que sea el jugador
        if (!other.CompareTag("Player")) return;

        // buscar el gestor de la partida
        GestorPartida gestor = Object.FindFirstObjectByType<GestorPartida>();
        if (gestor == null) return;

        // comprobar si ya encontro todas las mascotas
        if (gestor.MisionCumplida)
            gestor.Ganar();
        else
            Debug.Log("Todavía faltan mascotas por encontrar.");
    }
}
