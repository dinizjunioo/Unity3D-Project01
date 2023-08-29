using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private float BackspinDrag = 0.2f; // Valor inicial de BackspinDrag
    private Rigidbody rb;
    // private float newForce;
    //private Rigidbody rb;
    public bool colidiuHotUp = false;
    //public Transform posBala;       // posicao da bala
    // Start is called before the first frame update
    void Start()
    {
        //posBala = posBala.GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 10);
        Debug.Log("BackspinDrag Atual: " + BackspinDrag);
    }

    void Update()
    {
        //float velocidadeFPS = Mathf.Sqrt((2 * 1.49f) / (0.2f / 1000.0f));
        // Debug.Log("Velocidade Atual: " + velocidadeFPS * posBala.forward * (0.2f / 1000.0f));
        //rb.AddForce(posBala.forward * velocidadeFPS * 0.0002f, ForceMode.Force);

        //if (colidiuHotUp)
        //{
        //float velocidadeNoPlanoXZ = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        // Calcule a força de sustentação com base na velocidade da BB no plano X-Z
        //float forcaDeSustentacao = Mathf.Sqrt(velocidadeNoPlanoXZ) * BackspinDrag;
        // Aplica a força de sustentação 
        //rb.AddForce(Vector3.up * forcaDeSustentacao * Time.deltaTime);
        //}

        Vector3 magnusDirection = Vector3.Cross(rb.velocity, transform.up).normalized;
        Vector3 magnusForce = Mathf.Sqrt(rb.velocity.magnitude) * magnusDirection * BackspinDrag * Time.fixedDeltaTime;
        //Debug.DrawRay(transform.position, magnusForce * 1000, Color.red, Mathf.Infinity);
        rb.AddForce(magnusForce);

    }

    private void OnTriggerEnter(Collider other)
    {
        // se ele não se colidiu com nenhum objeto com a tag Gun (todas as partes da geometria da arma
        // e o HotUp tem tag Gun) então destrua o objeto bala imediatamente.
        if (other.gameObject.CompareTag("HotUp"))
        {
            Debug.Log("trigger com o HotUp ");
            colidiuHotUp = true;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("HotUp"))
        {
            Debug.Log("Trigger com o HotUp");
            colidiuHotUp = true;
        }
    }

   


}
