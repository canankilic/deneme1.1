using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float walkingSpeed = 2.0f;

    private Animator animator;
    private bool walking = false;
    private bool arrivedAtPointA = false;
    private bool inConversation = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Walking", walking);
    }

    private void Update()
    {
        if (walking && !inConversation)
        {
            if (arrivedAtPointA)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, walkingSpeed * Time.deltaTime);

                if (transform.position == pointB.position)
                {
                    arrivedAtPointA = false;
                    animator.SetBool("Walking", false);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, walkingSpeed * Time.deltaTime);

                if (transform.position == pointA.position)
                {
                    arrivedAtPointA = true;
                    animator.SetBool("Walking", false);
                }
            }
        }
    }

    private void OnGUI()
    {
        if (walking && !inConversation)
        {
            GUI.Label(new Rect(10, 10, 200, 20), "Type 'answer' to talk to NPC.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (walking && !inConversation && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Player entered 'answer'.");
            inConversation = true;
            animator.SetBool("Walking", false);
            // Insert NPC dialogue here.
        }
    }

    public void StartWalking()
    {
        walking = true;
        animator.SetBool("Walking", walking);
    }
}
