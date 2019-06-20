using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    

    [SerializeField]
    private float speed;

    private Rigidbody2D rb;

    private float hInput;

    private float vInput;

    [SerializeField]
    private InteractionReceiver interRecTop;

    [SerializeField]
    private InteractionReceiver interRecDown;

    [SerializeField]
    private InteractionReceiver interRecRight;

    [SerializeField]
    private InteractionReceiver interRecLeft;


    private InteractionReceiver currentInter;

    private bool lockX;

    public bool LockX{
        set{ lockX = value; }
    }


    private bool lockY;

    public bool LockY{
        set{ lockY = value; }
    }

    private bool lockLookDir;

    public bool LockLookDir{
        set{ lockLookDir = value; }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
            
            interRecRight.enabled = false;
            interRecLeft.enabled = false;
            interRecTop.enabled = false;

            interRecDown.enabled = true;

            currentInter = interRecDown;

            

            lockX = false;
            lockY = false;
            lockLookDir = false;
    }
	
	// Update is called once per frame
	void Update () {

        #region Detector Direction
        
        if(lockLookDir == false){
            if(Mathf.Abs(rb.velocity.x) > 0.01f && Mathf.Abs(rb.velocity.y) > 0.01f){
                if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) ){
                    interRecDown.enabled = true;
                    currentInter = interRecDown;
                    
                    interRecRight.enabled = false;
                    interRecLeft.enabled = false;
                    interRecTop.enabled = false;
                }
                if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) ){
                    interRecTop.enabled = true;
                    currentInter = interRecTop;
                    
                    interRecRight.enabled = false;
                    interRecLeft.enabled = false;
                    interRecDown.enabled = false;
                }

                if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) ){
                    interRecLeft.enabled = true;
                    currentInter = interRecLeft;
                    
                    interRecRight.enabled = false;
                    interRecTop.enabled = false;
                    interRecDown.enabled = false;
                }
                if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) ){
                    interRecRight.enabled = true;
                    currentInter = interRecRight;
                    
                    interRecLeft.enabled = false;
                    interRecTop.enabled = false;
                    interRecDown.enabled = false;
                }
            }else{

                if(rb.velocity.y > 0.01f){
                    interRecTop.enabled = true;
                    currentInter = interRecTop;
                    
                    interRecRight.enabled = false;
                    interRecLeft.enabled = false;
                    interRecDown.enabled = false;
                }else if(rb.velocity.y < -0.01f){
                    interRecDown.enabled = true;
                    currentInter = interRecDown;
                    
                    interRecRight.enabled = false;
                    interRecLeft.enabled = false;
                    interRecTop.enabled = false;
                }

                if(rb.velocity.x > 0.1f){
                    interRecRight.enabled = true;
                    currentInter = interRecRight;
                    
                    interRecLeft.enabled = false;
                    interRecTop.enabled = false;
                    interRecDown.enabled = false;
                }else if(rb.velocity.x < -0.1f){
                    interRecLeft.enabled = true;
                    currentInter = interRecLeft;
                    
                    interRecRight.enabled = false;
                    interRecTop.enabled = false;
                    interRecDown.enabled = false;
                }
            }
        }
        #endregion

       currentInter.Interact = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X);
	}

    private void FixedUpdate()
    {

        if(lockX == false){
            hInput = Input.GetAxisRaw("Horizontal");
        }else{
            hInput = 0;
        }

        if(lockY == false){
            vInput = Input.GetAxisRaw("Vertical");
        }else{
            vInput = 0;
        }

        rb.velocity = (new Vector2(hInput, vInput)).normalized * speed * Time.fixedDeltaTime;
    }
}
