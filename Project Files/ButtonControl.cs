using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour{
    [SerializeField] private AudioClip button_noise;
    public GameObject Button;
    public GameObject Ground_1;

    private Rigidbody2D body;
    private Animator anim_b;
    private Animator anim_g;
    private bool hit = false;
    private bool pushed = false;
    private Vector2 button;
    private Vector2 button_down;
    private AudioSource audioSource;
    
   
    void Awake(){
        audioSource = GetComponent<AudioSource>();
        body=GetComponent<Rigidbody2D>();
        anim_b=Button.GetComponent<Animator>(); 
        anim_g=Ground_1.GetComponent<Animator>();
        button = new Vector2 (transform.position.x, transform.position.y);
        button_down= new Vector2 (transform.position.x, transform.position.y - 0.5f);
    }


    // Update is called once per frame
    void Update(){
    
    }
    

    private void OnTriggerEnter2D (Collider2D collision){
        if(collision.gameObject.tag == "MainPlayer" && !hit){
            if (pushed){
                audioSource.PlayOneShot(button_noise);
                transform.position = button;
                anim_g.SetTrigger("Unpush_plat");
                pushed = false;
                // Debug.Log("unpush");
            }else{
                audioSource.PlayOneShot(button_noise);
                transform.position = button_down;
                anim_g.SetTrigger("Push_plat");
                pushed = true;
                // Debug.Log("push");
            }
            StartCoroutine(ButtonDelay());
            
            // Debug.Log("triggered");
        }
    }
    
    private IEnumerator ButtonDelay(){
        hit=true;
        yield return new WaitForSeconds(1f);
        hit=false;
        Debug.Log("Button On");   
    }
}

