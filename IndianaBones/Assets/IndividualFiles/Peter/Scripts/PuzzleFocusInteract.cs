﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]

public class PuzzleFocusInteract : MonoBehaviour {
    public GameObject focusPoint;
    public float focusDuration = 3;

    public bool impairMovement;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            PlayerMovement plm = other.GetComponent<PlayerMovement>();
            if (Input.GetButtonDown("E"))
            {
                if (impairMovement)
                {
                    plm.enabled = false;
                }
                Camera.main.GetComponent<PlayerCamera>().PuzzleFocus(focusPoint, focusDuration);
            }

            if(plm.x < -.6F || plm.x > .6F && !Camera.main.GetComponent<PlayerCamera>().focusPlayer)
            {
                Camera.main.GetComponent<PlayerCamera>().focussing = false;
                Camera.main.GetComponent<PlayerCamera>().focusPlayer = true;
            }
        }
       
    }
}
