using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyBehaviour : MonoBehaviour
{
    [SerializeField] protected Animator enemyAnimator;

    [SerializeField] protected AudioSource deadSound;

    // hp values
    protected playerHelth playerHP;
    [SerializeField] protected int reducingPlayerHP;
    [SerializeField] protected int enemyHP;

    [SerializeField] protected float deadTimer;
    protected bool dead = false;

    protected Transform playerTransform;
    protected Transform enemyTransform;

    protected void Update() {
        if(enemyHP<=0 && !dead){
            dead = true;

            StartCoroutine(deadCoroutine());
        }
    }

    protected void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("bullet1")){
            enemyHP -= 2;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("bullet2")){
            enemyHP -= 3;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("bullet3")){
            enemyHP -= 4;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("bullet4")){
            enemyHP -= 5;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("bullet5")){
            enemyHP -= 8;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("bullet6")){
            enemyHP -= 10;
            Destroy(other.gameObject);
        }
    }
    protected IEnumerator deadCoroutine(){
        deadSound.Play();
        enemyAnimator.SetTrigger("deadTrigger");

        yield return new WaitForSeconds(deadTimer);

        playerHP.PlayerHP += reducingPlayerHP;

        Destroy(gameObject);
    }
}
