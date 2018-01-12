using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public static PlayerJump instance;
    public bool isPressHold,jumped;

    [SerializeField]
    private float jumpX = 20f;
    [SerializeField]
    private float jumpY = 40f;

    [SerializeField]
    private float forceX, forceY;
    private Rigidbody2D mybody;

    private Animator anim;

	// Use this for initialization
	void Awake () {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Debug.Log("Player Created");
        MakeSingiton();	
	}
	
    void MakeSingiton()
    {
        if (!instance)
        {
            instance = this;
        }
    }
	// Update is called once per frame
	void Update () {
        SetPower();
	}

    public void SetPower(bool isPressed) {
        this.isPressHold = isPressed;
        
        if (!isPressed)
        {
            Jump();
            jumped = true;
        }
    }
    void SetPower()
    {
        if (isPressHold)
        {
            forceX += jumpX * Time.deltaTime;
            forceY += jumpY * Time.deltaTime;

            if (forceX > 65f)
            {
                forceX = 65f;
            }
            if (forceY > 120f)
            {
                forceY = 120f;
            }
            //forceX = Mathf.Clamp(0, 120, forceX);
            //forceY = Mathf.Clamp(0, 120, forceY);
        }
    }

    void Jump() {
        
         mybody.velocity = new Vector2(forceX,forceY);
        //if we don't set forcex,forceY to zero our player flys
        forceX = forceY = 0f;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag=="PlatForm")
        {
            Debug.Log("entered the platform");
        }
    }
}
