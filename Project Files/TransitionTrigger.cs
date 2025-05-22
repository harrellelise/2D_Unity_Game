
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTrigger : MonoBehaviour
{
    // [SerializeField] private AudioClip transition;

    private bool hit = false;
    public int nextLevelIndex;
    // private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        // audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit){
            // audioSource.PlayOneShot(transition);
            Debug.Log("Level Complete");
            hit = false;
            SceneManager.LoadScene(nextLevelIndex);
            //new level transition
        }
    }

     private void OnTriggerEnter2D (Collider2D collision){
        if(collision.gameObject.tag == "MainPlayer"){
            hit = true;
            // Debug.Log("triggered");
        }
    }
}
