using UnityEngine;

public class Pet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // buscar el gestor de la partida
            GestorPartida gestor = Object.FindFirstObjectByType<GestorPartida>();

            // aumentar el contador de mascotas
            if (gestor != null) gestor.Rescatar();

            // ocultar la mascota encontrada
            gameObject.SetActive(false);
        }
    }
}
