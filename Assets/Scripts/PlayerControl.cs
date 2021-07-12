using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    CharacterController controller;
    Animator anim;

    //public Camera cam;
    public Animator camAnim;

    //end game
    [SerializeField]
    private GameObject headlthBar;
    [SerializeField]
    private GameObject endGamePanel;
    [SerializeField]
    private Animator endGameAnimator;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public GameObject replayButton;
    float turnSmoothVelocity;
    bool triggerEnter = false;
    bool triggerEnter2 = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        if(GameManager.score <= 0)
        {
            GameManager.gameStarted = false;
            replayButton.SetActive(true);
            anim.SetTrigger("lose");
            AudioManager.instance.PlaySFX("lose");

        }
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = 1;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f && triggerEnter == false)
        {
            direction = new Vector3(horizontal, 0f, vertical).normalized;


            if(GameManager.gameStarted)
            //move
            transform.Translate(direction * speed * Time.deltaTime);


            
        }
        if (triggerEnter == true){

            //rotate
            transform.Rotate(0,90,0,Space.World);
            TestCmeraController.horizontal = true;
            triggerEnter = false;

        }
        if (triggerEnter2 == true )
        {
            TestCmeraController.horizontal = false;
           // cam.transform.Rotate(0, -90, 0, Space.World);

            transform.Rotate(0, -90, 0, Space.World);
            triggerEnter2 = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("sense"))
        {
            triggerEnter = true;

        }
        if (other.tag.Equals("sence"))
        {
            triggerEnter2 = true;
        }
        if (other.tag.Equals("endg"))
        {
            GameManager.gameStarted = false;
            anim.SetTrigger("dance");
            AudioManager.instance.PlayMusic("win");
            endGamePanel.SetActive(true);
            headlthBar.SetActive(false);
            endGameAnimator.SetTrigger("endgame");

            replayButton.SetActive(true);
            camAnim.SetTrigger("rotate");
            transform.Rotate(0, -180, 0, Space.World);

        }
    }
}
