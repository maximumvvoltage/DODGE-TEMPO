using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienBeatTest : MonoBehaviour
{
	private Animator anim;

	private void Start(){
		anim = GetComponentInChildren<Animator>();
	}
	public void Dance(){
		anim.Play("beat", 0, 0f);
	}
}
