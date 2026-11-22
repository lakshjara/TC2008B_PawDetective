using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;

    void Start()
    {
        // guardar la distancia inicial entre la camara y el jugador
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // seguir al jugador manteniendo la misma distancia
        transform.position = player.position + offset;
    }
}