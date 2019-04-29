using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug2 : MonoBehaviour {

    private Animator animator;
    private Transform pPos;

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        pPos = GameObject.FindGameObjectWithTag("Player").transform;

    }
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(this.transform.position, pPos.position) > 6)
        {
            animator.SetBool("isChasing", false);
        }

        if (Vector3.Distance(this.transform.position, pPos.position) < 6)
        {
            animator.SetBool("isChasing", true);
        }
    }
}
