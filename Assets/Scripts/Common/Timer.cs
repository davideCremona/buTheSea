﻿using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	Animator animator;

	static public float timeAnimationBase = 0.19f;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> () as Animator;
		
	}
	
	void StartTiming(float waiting_time){
		StartCoroutine (StartTimingCoroutine(waiting_time));
	}

	// The Timer starts waiting for the right amount of time and then triggers the event "NewWave"
	IEnumerator StartTimingCoroutine(float waiting_time){
		animator.speed = Timer.timeAnimationBase / waiting_time;
		animator.SetTrigger ("Start");
		yield return new WaitForSeconds (waiting_time);

		EventManager.TriggerEvent ("NewWave");
	}


}
