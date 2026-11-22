using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;
    private Animator animator;
    private Vector3 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // evita que se voltee
        // buscar el animator del personaje
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // leer el movimiento del teclado
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        movimiento = new Vector3(x, 0f, z).normalized;
        
        // cambiar la animacion segun el movimiento
        if (animator != null)
            animator.SetFloat("velocidad", movimiento.magnitude);
        
        // girar hacia donde camina el personaje
        if (movimiento.sqrMagnitude > 0.01f)
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(movimiento),
                12f * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // mover al jugador usando fisicas
        rb.MovePosition(rb.position + movimiento * velocidad * Time.fixedDeltaTime);
    }
}
