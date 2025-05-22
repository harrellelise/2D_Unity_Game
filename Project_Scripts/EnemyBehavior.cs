using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;

public class EnemyBehavior : MonoBehaviour{
    [SerializeField] private float speed;
    [SerializeField] private float unitsToMove;

    private Rigidbody2D body;
    private Animator anim;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool moveRight;
    

    private void Awake(){
        body=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        startPos = new Vector2 (transform.position.x, transform.position.y);
        endPos =  new Vector2 (transform.position.x + unitsToMove, transform.position.y);
        moveRight = true;
    }

    private void Update (){
        if (moveRight){
            Patrol(endPos);
            // Debug.Log("Moved Right");
        } else{
            Patrol(startPos);
            // Debug.Log("Moved Left");
        }
        
    }

    private void Patrol(Vector2 targetPos){
        Vector2 direction = (targetPos - body.position).normalized;
        body.MovePosition(body.position + direction * speed * Time.deltaTime);
        
        if (Vector2.Distance(body.position, targetPos)< 0.1f){
                moveRight = !moveRight;
                //anim.flipS
            }
    }




}
