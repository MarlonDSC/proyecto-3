using UnityEngine;

public class Raqueta : MonoBehaviour
{
    //Velocidad
    public float velocidad = 30.0f;
    public int min;
    public int max;
    //Eje vertical
    public string eje;
    public string eje2;
    // Es llamado una vez cada fixed frame
    void FixedUpdate()
    {
        //Capto el valor del eje vertical de la raqueta
        float v = Input.GetAxisRaw(eje);
        float x = Input.GetAxisRaw(eje2);
        //Modifico la velocidad de la raqueta
        GetComponent<Rigidbody2D>().velocity = new Vector2(x * velocidad, v * velocidad);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min, max), transform.position.y, transform.position.z);
    }
}
