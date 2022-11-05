using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button Iniciar, Controles;
    public GameObject PanelPrefab;
    void Start()
    {
        Iniciar.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Juego");
        });
        Controles.onClick.AddListener(() => {
            GameObject child = Instantiate(PanelPrefab);
            child.transform.SetParent(gameObject.transform, false);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
