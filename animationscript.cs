﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationscript : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        var animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("ArrowDraw");
    }
}
