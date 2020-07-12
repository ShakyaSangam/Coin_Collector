using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour
{
    Rigidbody rigidbody;
    public Text points;
    // coin collection sound
    public AudioClip audioClip;
    public AudioSource audioSource;

    // player jump sound
    public AudioClip playeraudioClip;
    public AudioSource playeraudioSource;

    private bool isjumping = true;
    private bool increaseSpeed = false;
    public int ballSpeed = 0;
    public int jumpspeed = 0;
    private int score = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        points.text = "Coins:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        Vector3 vec3 = new Vector3(hMove, 0.0f, vMove);

        rigidbody.AddForce(vec3 * ballSpeed);


        if ((Input.GetKeyDown(KeyCode.Space)) && isjumping == true)
        {
            Debug.Log("space pressed");
            Vector3 jump = new Vector3(0.0f, 40.0f, 0.0f);
            rigidbody.AddForce(jump * jumpspeed);

            playeraudioSource.PlayOneShot(playeraudioClip);
        }
        else {
            isjumping = false;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            ballSpeed += 10;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("Speed executed");
            ballSpeed -= 10;
        }
    }

    void OnCollisionStay() {
        isjumping = true;
    }

    private void OnTriggerEnter(Collider collider){
        Debug.Log(collider.gameObject.tag);
        if(collider.gameObject.tag == "coincollision"){
            collider.gameObject.SetActive(false);

            // coin audio clip
            audioSource.PlayOneShot(audioClip);
           
            // game score
            score--;
            points.text = "Coins:" + score;
            if(score == 0){
                SceneManager.LoadScene("Conclusion");
            }
        }
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.shift)
        {
            increaseSpeed = true;
        }
    }
}
