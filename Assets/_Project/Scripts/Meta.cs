using UnityEngine;
using TMPro;

public class Meta : MonoBehaviour
{
    public TextMeshProUGUI textoGanaste;
    public ContadorMonedas contador;

    private void Start()
    {
        textoGanaste.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (contador.monedas >= 3)
            {
                textoGanaste.gameObject.SetActive(true);
                Debug.Log("GANASTE NIVEL COMPLETADO");

                Time.timeScale = 0f;
            }
            else
            {
                Debug.Log("Faltan monedas");
            }
        }
    }
}