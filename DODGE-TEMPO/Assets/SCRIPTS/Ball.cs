using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    public enum ballDirection { Left, Right, Up };
    public ballDirection currentDirection;
    private Player player;

    private void Start()
    {
        HitCheck();
        StartCoroutine("Destroy");
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().DOFade(0f, 0.1f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

    public void HitCheck()
    {
        switch (currentDirection)
        {
            case ballDirection.Left:
                if (Player.Instance.anim.GetCurrentAnimatorStateInfo(0).IsName("left"))
                {
                    Debug.Log("Hit!!!!!!!!!!!!!!");
                    AuraLoss();

                }
                else
                {
                    IncrementCombo();
                }
                break;
            case ballDirection.Right:
                if (Player.Instance.anim.GetCurrentAnimatorStateInfo(0).IsName("right"))
                {
                    Debug.Log("Hit!!!!!!!!!!!!!!");
                    AuraLoss();
                }
                else
                {
                    IncrementCombo();
                }
                break;
            case ballDirection.Up:
                if (Player.Instance.anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                    {
                        Debug.Log("Hit!!!!!!!!!!!!!!");
                        AuraLoss();
                    }
                    else
                    {
                        IncrementCombo();
                    }
                break;
        }
        Debug.Log(Player.Instance.combo);
    }

    private void IncrementCombo(){
        Player.Instance.combo += 1;
    }
    private void AuraLoss(){
        Player.Instance.combo = 0;
    }
}
