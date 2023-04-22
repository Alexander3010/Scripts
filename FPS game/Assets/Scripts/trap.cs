using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    [SerializeField] private float trapSpeed; 
    
    [SerializeField] private float movingTimer;
    [SerializeField] private float reloadTrapTimer;

    private Transform trapTransform;

    private bool active = false;
    private bool up = false;
    private bool down = true;

    private void Start() {
        trapTransform = GetComponent<Transform>();
        StartCoroutine(swap());
    }
    private void FixedUpdate(){
        if(active){
            if(up){
                trapTransform.Translate(0f,trapSpeed,0f);
            }
            else if(down){
                trapTransform.Translate(0f,-trapSpeed,0f);
            }
        }
    }
    private IEnumerator swap(){
        
        //making random start time
        yield return new WaitForSeconds(Random.Range(0,4));

        while(true){
            yield return new WaitForSeconds(reloadTrapTimer);

            active = !active;

            up = !up;
            down = !down;
            yield return new WaitForSeconds(movingTimer);

            up = !up;
            down = !down;
            yield return new WaitForSeconds(movingTimer);

            active = !active;
        }
    }
}
