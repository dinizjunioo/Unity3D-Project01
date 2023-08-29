using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Arma : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform posBala;       // posicao da bala
    public GameObject bala;       // posicao da bala
    private GameObject bullet;
    private Rigidbody rb;
    public float EnergiaCinetica = 1.49f;
    public float massa;
    //private Vector3 forcaAplicada;
    float veloAtual;
    void Start()
    {
        posBala = posBala.GetComponent<Transform>();
        massa = 0.2f / 1000.0f;
        veloAtual = 0.0f;
    }

    void Update()
    {
        fire();
        
        if (rb != null)
        {
            veloAtual = rb.velocity.magnitude;
            //Debug.Log("Velocidade Atual: " + massa);
        }
    }
    void fire()
    {
        // antes do contato com o hopUp s� existe a velocidade linear
        // depois do contato existe tamb�m a velocidade angular, fazendo a bala girar chamado de backSpin
        if (Input.GetButtonDown("Fire1"))
        {
            // instanciei o objeto bala
            //Instantiate(bala, new Vector3(posBala.position.x, posBala.position.y, posBala.position.z), Quaternion.identity);
            bullet = Instantiate(bala, posBala.position, posBala.rotation);

            // pegando o rigidbody do objeto bala
            rb = bullet.GetComponent<Rigidbody>();

            // Calcula a velocidade inicial em p�s por segundo
            float velocidadeFPS = Mathf.Sqrt((2 * EnergiaCinetica) / massa);
            Debug.Log("Velocidade Atual: " + velocidadeFPS);
            Vector3 forcaNecessaria = massa * velocidadeFPS * posBala.forward.normalized;
            // Aplica a for�a no sentido do cano da arma
            rb.AddForce(forcaNecessaria, ForceMode.Impulse);
            //Debug.Log("Cliquei!" + teste);

            // Calculando a for�a de arrasto (drag) oposta � dire��o da velocidade atual do objeto
            //Vector3 forcaDeArrasto = -rb.velocity.normalized * rb.drag;

            // Calculando a for�a resultante que ser� aplicada ao objeto (for�a desejada + for�a de arrasto)
            //Vector3 forcaResultante = new Vector3(0, 0, aceleracao) + forcaDeArrasto;

            // Aplicando a for�a no objeto
            //rb.AddForce(forcaResultante);

            // rb.AddForce(forcaAplicada.normalized * (EnergiaCinetica - rb.drag * rb.velocity.magnitude));
      
            // aqui o c�digo para movimentar o gatilho da arma
            // ------------------------------------------------
            // ....
            // ------------------------------------------------
        }
    }
}
