using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {

    private PlayerBehaviour player;

    Image image;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();


        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        image.fillAmount = player.CurrentSanity/player.SanityTime;
	}
}
