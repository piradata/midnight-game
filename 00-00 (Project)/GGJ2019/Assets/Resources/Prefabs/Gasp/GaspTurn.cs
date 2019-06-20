using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaspTurn : MonoBehaviour {

    Animator anim;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();

        anim.SetBool("baoball", true);

        //anim.GetBool("baoball");

        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (rb.velocity.x > 0) anim.SetBool("baoball", true);
        else if (rb.velocity.x < 0) anim.SetBool("baoball", false);
    }
}
