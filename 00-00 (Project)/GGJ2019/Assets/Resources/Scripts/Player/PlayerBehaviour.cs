using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField]
    private LayerMask lightLayer;

    [SerializeField]
    private LayerMask darkLayer;

    [SerializeField]
    private int sanityTime;

    private bool hasKey;

    public bool HasKey{
        get{return hasKey;}
        set{hasKey = value;}
    }

    public int SanityTime{
        set { sanityTime = value; }
        get { return sanityTime; }
    }

    private float currentSanity;

    public float CurrentSanity
    {
        set { currentSanity = value; }
        get { return currentSanity; }
    }

    private bool inLight = true;

    private IEnumerator insaneRoutine;

    private IEnumerator saneRoutine;


    private Rigidbody2D rb;

    [SerializeField]
    private Animator anim;

    private PlayerController ctrl;

    private bool lockLookDir = false;

    private List<GameObject> lightStuff;


    public void KillPlayer(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    // Use this for initialization
    void Start()
    {
        currentSanity = sanityTime;

        rb = GetComponent<Rigidbody2D>();

        ctrl = GetComponent<PlayerController>();
        //anim = GetComponentInChildren<Animator>();


        lightStuff = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(rb.velocity);



        if (lightStuff.Count > 0)
        {
            inLight = true;
        }
        else {
            inLight = false;
        }

        #region Animation Control
        if(lockLookDir == false){
            if(Mathf.Abs(rb.velocity.x) < 0.01f && Mathf.Abs(rb.velocity.y) < 0.01f){


                if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) ){
                    anim.SetFloat("Y", -1);
                    anim.SetFloat("X", 0);
                }
                if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) ){
                    anim.SetFloat("Y", 1);
                    anim.SetFloat("X", 0);
                }

                if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) ){
                    anim.SetFloat("X", -1);
                    anim.SetFloat("Y", 0);
                }
                if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) ){
                    anim.SetFloat("X", 1);
                    anim.SetFloat("Y", 0);
                }

                anim.SetBool("Andando", false);

            }else{
                anim.SetBool("Andando", true);

                if(rb.velocity.y != 0){
                    anim.SetFloat("X", 0);
                    anim.SetFloat("Y", Mathf.Sign(rb.velocity.y));
                }

                if(rb.velocity.x != 0){
                    anim.SetFloat("Y", 0);
                    anim.SetFloat("X", Mathf.Sign(rb.velocity.x));
                }

            }
        }
        #endregion

        #region Interactions
        
        #endregion

        #region Light Behaviour
        if (inLight == false)
        {
            if (saneRoutine != null)
            {
                StopCoroutine(saneRoutine);
                saneRoutine = null;
            }


            if (insaneRoutine == null)
            {
                insaneRoutine = goInsane();
                StartCoroutine(insaneRoutine);
            }



            if (currentSanity <= 0)
            {
                //Destroy(gameObject);
                //Application.LoadLevel(Application.loadedLevel);
                KillPlayer();
            }

        }
        else
        {
            if (insaneRoutine != null)
            {
                StopCoroutine(insaneRoutine);
                insaneRoutine = null;
            }

            if (saneRoutine == null)
            {
                saneRoutine = goSane();
                StartCoroutine(saneRoutine);
            }
        }
        #endregion
    }
    
    public void LockAxis(){
        if(anim.GetFloat("X") != 0){
            ctrl.LockY = true;
        }else if(anim.GetFloat("Y") != 0){
            ctrl.LockX = true;
        }
    }

    public void FreeAxis(){
        ctrl.LockX = false;
        ctrl.LockY = false;
    }

    public void LoockLookDirection(){
        lockLookDir = true;
        ctrl.LockLookDir = true;
    }

    public void FreeLookDirection(){
        lockLookDir = false;
        ctrl.LockLookDir = false;
    }

    public Vector2 GetDirection(){

        Vector2 dir = new Vector2(0, 0);

        if(anim.GetFloat("X") > 0){
            dir.x = 1;
        }else if(anim.GetFloat("X") < 0){
            dir.x = -1;
        }

        if(anim.GetFloat("Y") > 0){
            dir.y = 1;
        }else if(anim.GetFloat("Y") < 0){
            dir.y = -1;
        }

        return dir;
    }




    IEnumerator goInsane()
    {
        while (inLight == false && currentSanity >= 0)
        {
            currentSanity -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        if (currentSanity <= 0)
        {
            currentSanity = 0;
        }
    }

    IEnumerator goSane()
    {
        while (inLight == true && currentSanity <= sanityTime)
        {
            currentSanity += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        if (currentSanity > sanityTime)
        {
            currentSanity = sanityTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (Utils.CheckLayer(lightLayer, collision.gameObject) || Utils.CheckLayer(darkLayer, collision.gameObject)) {
            if (!lightStuff.Contains(collision.gameObject)) {
                lightStuff.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Utils.CheckLayer(lightLayer, collision.gameObject) || Utils.CheckLayer(darkLayer, collision.gameObject))
        {
            if (!lightStuff.Contains(collision.gameObject))
            {
                lightStuff.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Utils.CheckLayer(lightLayer, collision.gameObject) || Utils.CheckLayer(darkLayer, collision.gameObject))
        {
            if (lightStuff.Contains(collision.gameObject))
            {
                lightStuff.Remove(collision.gameObject);
            }
        }
    }
}
