using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;
    private Vector3 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // evita que se voltee
    }

    void Update()
    {
        // leer el movimiento del teclado
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        movimiento = new Vector3(x, 0f, z).normalized;
    }

    void FixedUpdate()
    {
        // mover al jugador usando fisicas
        rb.MovePosition(rb.position + movimiento * velocidad * Time.fixedDeltaTime);
    }
}
