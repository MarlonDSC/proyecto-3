using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad = 5;
    private int contador = 0;
    public TextMeshProUGUI textoContador, textoGanar;
    public GameObject background;
    // Use this for initialization
    void Start()
    {
        //Capturo esa variable al iniciar el juego
        rb = GetComponent<Rigidbody>();
        //Actualizo el texto del contador por pimera vez
        setTextoContador();
        //Inicio el texto de ganar a vacío
        textoGanar.text = "";
    }
    // Para que se sincronice con los frames de física del motor
    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f,
        movimientoV);
        rb.AddForce(movimiento * velocidad);
    }
    //Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            contador = contador + 1;
            //Actualizo elt exto del contador
            setTextoContador();
            StartCoroutine(PlayAndTurnOff(other));
        }
    }

    IEnumerator PlayAndTurnOff(Collider other)
    {
        other.gameObject.GetComponent<BoxCollider>().enabled = false;
        other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        other.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(other.GetComponent<AudioSource>().clip.length);
        other.gameObject.SetActive(false);
    }
    void setTextoContador()
    {
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            textoGanar.text = "¡Ganaste!";
            background.SetActive(true);
            StartCoroutine(ChangeText());
            StartCoroutine(SendToMainScene());
        }
    }

    IEnumerator ChangeText(){
        textoGanar.text = "¡Ganaste!";
        yield return new WaitForSeconds(2);
        textoGanar.text = "Redirigiendo a la escena principal...";
    }

    IEnumerator SendToMainScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Inicio");
    }
}
