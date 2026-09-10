using UnityEngine;
using TMPro;

public class ContadorMonedas : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;

    public int monedas = 0;

    void Start()
    {
        monedas = 0;
        ActualizarTexto();
    }

    public void SumarMoneda()
    {
        monedas++;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        textoMonedas.text = "Monedas: " + monedas + "/3";
    }
}