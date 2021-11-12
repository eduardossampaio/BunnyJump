using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;

    [Header("Audio")]
    [SerializeField] private AudioSource jumpAudio;

    private List<IPlayerEventListenner> playerListeners = new List<IPlayerEventListenner>();

    private bool isGrounded = true;
    private Animator animator;
   void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.AddForce(new Vector2(0, jumpForce));
            jumpAudio.Play();
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case Constants.TAGS.Collectable:
                Collectable collectable = collision.GetComponent<Collectable>();
                if(collectable != null)
                {
                    collectable.OnCollect();
                    foreach (var eventListener in playerListeners)
                    {
                        eventListener.OnPlayerCollectItem(collectable);
                    }
                }
                
                break;
            case Constants.TAGS.Hurtable:
                foreach(var eventListener in playerListeners)
                {
                    animator.SetTrigger("die");
                    eventListener.OnPlayerDeath();
                }
                break;
        }
    }

    #region
    public void RegisterPlayerEventListener(IPlayerEventListenner listenner)
    {
        playerListeners.Add(listenner);
    }
    #endregion
}
