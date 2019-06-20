using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TeddyBeer : MonoBehaviour {

    private PlayerBehaviour player;

    [SerializeField]
    private int increase;

    [SerializeField]
    private Image rendUI;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        rendUI = GameObject.FindGameObjectWithTag("BearUI").GetComponent<Image>();
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            rendUI.enabled = true;

            player.SanityTime += increase;

            player.CurrentSanity = player.SanityTime;

        }
    }
}
