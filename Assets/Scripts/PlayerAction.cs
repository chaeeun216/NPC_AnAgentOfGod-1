using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour 
{
    public float Speed;

    Rigidbody2D rigid;
    float h;
    float v;
    bool isHorizonMove;
    Animator anim;

    Vector3 dirVec;
    public GameObject scanObj;
    public int checkScan;

    InteractionController theInteractionController;

     void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theInteractionController = FindObjectOfType<InteractionController>();

        if (theInteractionController == null)
        {
            Debug.LogError("InteractionController not found in the scene.");
        }
    }

    void Update()
    {
        // Move value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonDown("Horizontal");
        bool vUp = Input.GetButtonDown("Vertical");

        // Check Horizontal Move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        // Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        // Direction
        if(vDown && v == 1)
        {
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1)
        {
            dirVec = Vector3.down;
        }
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && h == 1)
        {
            dirVec = Vector3.right;
        }

        // Scan Object
        if (Input.GetKeyDown(KeyCode.Z) && scanObj != null)
        {
            Debug.Log(scanObj.name);
            theInteractionController.CheckObject(scanObj);
            theInteractionController.ZClick();
        }
    }

    void FixedUpdate()
    {
        // Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        // Ray
        Debug.DrawRay(rigid.position, dirVec * 1.2f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1.2f, LayerMask.GetMask("EventObj"));

        if (rayHit.collider != null) // 사물을 스캔함
        {
            scanObj = rayHit.collider.gameObject;
        }
        else // 스캔된 사물이 없음
        {
            scanObj = null;
        }
    }
}
