using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    private float health = 100f;
    public int combo = 0;

    //singleton
    public static Player Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Cheater(7));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            anim.SetBool("Left", true);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)){
            anim.SetBool("Left", false);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            anim.SetBool("Right", true);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)){
            anim.SetBool("Right", false);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            anim.SetBool("Duck", true);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)){
            anim.SetBool("Duck", false);
        }
    }

    private IEnumerator Cheater(int secs){
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            yield return new WaitForSeconds(secs);
            gameObject.SetActive(false);
        }

    }
}
