using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GestorPartida : MonoBehaviour
{
    public int meta = 3;
    public float tiempoRestante = 90f;
    // textos que se muestran en la pantalla
    public TextMeshProUGUI petsText;
    public TextMeshProUGUI timeText;
    // mensajes de victoria y derrota
    public GameObject winText;
    public GameObject loseText;
    private bool tiempoAgotado = false;
    private int rescatadas = 0;
    private bool terminada = false;

    public bool MisionCumplida
    {
        get { return rescatadas >= meta; }
    }

    void Update()
    {
        // descontar el tiempo mientras la partida siga activa
        if (!terminada)
        {
            tiempoRestante -= Time.deltaTime;
            // mostrar los segundos que quedan
            if (timeText != null)
                timeText.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante);

            // comprobar si se termino el tiempo
            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                tiempoAgotado = true;
                Perder();
            }
        }
    }

    public void Rescatar()
    {
        if (terminada) return;

        rescatadas++;
        // actualizar las mascotas encontradas en pantalla
        if (petsText != null)
            petsText.text = "Mascotas: " + rescatadas + "/" + meta;

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

        // mostrar el mensaje de victoria
        if (winText != null)
            winText.SetActive(true);

        Debug.Log("¡Ganaste!");
        
        // reiniciar la partida despues de 3 segundos
        Invoke("Reiniciar", 3f);
    }

    public void Perder()
    {
        // evitar que la partida termine dos veces
        if (terminada) return;

        terminada = true;

        // mostrar el mensaje cuando se acaba el tiempo
        if (loseText != null)
            loseText.SetActive(true);

        Debug.Log("¡Perdiste! Se acabo el tiempo.");
        Invoke("Reiniciar", 1.5f);
    }

    void Reiniciar()
    {
        // volver a cargar el nivel desde el inicio
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
