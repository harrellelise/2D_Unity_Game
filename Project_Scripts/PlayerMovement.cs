using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;


public class PlayerMovement : MonoBehaviour{
    [SerializeField] private float speed;
    [SerializeField] private AudioClip hitEnemy;
    [SerializeField] private AudioClip falling;
    [SerializeField] private AudioClip jumping;
   
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool dead;
    private GameObject movingObject;
    private AudioSource audioSource;
    private bool hitE;
    private bool fell;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        hitE = false;
        dead = false;
        fell = false;
    }
    
    
    private void Update(){
        if (!dead){
            anim.SetBool("NotDead", true);
        }
        Offscreen();
//jump control
        if (grounded){
            anim.SetBool("Jump", false);
        }
//side to side movement
        float horizontalInput = Input.GetAxis("Horizontal");
//speed and side to side movement
        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);

//flips the character image
        if (horizontalInput > 0.01f){
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (horizontalInput < -0.01f){
            transform.rotation= Quaternion.Euler(0,180,0);
        }
        
//jump control
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)){
            if (grounded){
                Jump();
                anim.SetBool("Jump", true);
            }
        }
//restart control
        if (Input.GetKey(KeyCode.R)){
            Debug.Log("Restart");
            Restart();
        }
//main menu control
        
        if (Input.GetKey(KeyCode.M)){
            Debug.Log("MainMenu");
            SceneManager.LoadScene(0);
        }   

//set animator prarameters
        anim.SetBool("Run", horizontalInput != 0);    
    }


    private void Restart(){
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void Jump(){
            audioSource.PlayOneShot(jumping);
            body.velocity = new Vector2(body.velocity.x, speed);
            grounded = false;
    }

    private void OnCollisionEnter2D (Collision2D collision){
        if(collision.gameObject.tag == "Ground" && collision.contacts[0].normal.y >0.5f){
            grounded = true; 
            
        }
        if (collision.gameObject.tag == "MovingPlat"){
                movingObject = collision.gameObject;
                transform.SetParent(movingObject.transform,true);
                grounded = true;
                Debug.Log("Parent Set");
        }
        if(collision.gameObject.tag == "Enemy" && hitE == false){
            hitE = true;
            audioSource.PlayOneShot(hitEnemy);
            anim.SetTrigger("Dead");
            anim.SetBool("NotDead", false);
            Debug.Log("Death Loading");
            Death();
        }
    }
    private void OnCollisionExit2D (Collision2D collision){
        if (collision.gameObject == movingObject){
            transform.SetParent(null);
            movingObject=null;
        }
    }

    private void Death(){

         if (!dead){
            dead = true;
            // anim.SetTrigger("Dead");
            Debug.Log("Character is dead");
            StartCoroutine(WaitForDeathAnimation());
        }
        
    }

    // Coroutine to wait for the death animation to finish
    private IEnumerator WaitForDeathAnimation()
    {
        // Wait until the death animation is finished
        // Debug.Log("waiting for 1");
        yield return new WaitForSeconds(1.5f);

        // After the death animation ends, reload the scene
        // Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void Offscreen(){
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position); 

        if (screenPos.y < 0 ) {
            if (fell == false)
            {
                audioSource.PlayOneShot(falling);
                fell=true;
            }
            // Character falls off-screen
            // Debug.Log("Character is off-screen"); 
            Death();
        }
    }

}
