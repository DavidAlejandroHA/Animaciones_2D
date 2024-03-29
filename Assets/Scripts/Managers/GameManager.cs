using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Si hay alguna instancia, y dicha instancia no soy yo, me la cargo
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            // En caso contrario, yo me asocio como instancia �nica y global
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void paralizarTiempo()
    {
        Time.timeScale = 0f;
    }
    public void renaudarTiempo()
    {
        Time.timeScale = 0f;
    }

    public void terminarJuego()
    {
        Time.timeScale = 0f;
        UIManager.Instance.mostrarPantallaPerder();
    }

    public void pausarJuego()
    {
        Time.timeScale = 0f;
    }

    public void renaudarJuego()
    {
        Time.timeScale = 1f;
    }
    public void renaudarJuego(float delay)
    {
        Invoke("renaudarJuego", delay);
    }
}
