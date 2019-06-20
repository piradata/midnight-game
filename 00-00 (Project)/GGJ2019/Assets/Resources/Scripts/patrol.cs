using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{

    [SerializeField]
    private int speed;

    [SerializeField]
    private GameObject caminho;

    private Rigidbody2D rb;

    private Transform[] pontos;

    private int proximo = 1;

    private float Vspeed, Hspeed;

    private Vector2 direção;



    // Use this for initialization
    void Start()
    {

        caminho.name = "Caminho de " + name;

        caminho.transform.SetParent(null);

        pontos = new Transform[caminho.transform.childCount];
        for (int i = 0; i < caminho.transform.childCount; i++)
        {
            pontos[i] = caminho.transform.GetChild(i).transform;
        }

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Debug.Log(pontos[1]);

        Vspeed = pontos[proximo].position.y - transform.position.y;
        Hspeed = pontos[proximo].position.x - transform.position.x;
        direção = new Vector2(Hspeed, Vspeed);

       //Debug.Log(direção.normalized);

       rb.velocity = direção.normalized * Time.deltaTime * speed;
        if (direção.magnitude <= .5f)
        {
            proximo++;
            if (proximo >= caminho.transform.childCount) {
                proximo = 0;
            }
        }
        
    }
}
