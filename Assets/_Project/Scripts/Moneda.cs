using UnityEngine;

public class Moneda : MonoBehaviour
{
    public ContadorMonedas contador;
    public AudioClip sonidoMoneda;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // sumar moneda
            contador.SumarMoneda();

            // reproducir sonido antes de destruir
            if (sonidoMoneda != null)
            {
                AudioSource.PlayClipAtPoint(sonidoMoneda, transform.position);
            }

            // desaparecer moneda
            Destroy(gameObject);
        }
    }
}