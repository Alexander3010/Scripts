using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowflake : MonoBehaviour
{
    [SerializeField] private Animator snowflakeAnimator;

    private float randomValue;

    void Start()
    {
        StartCoroutine(deleteTimer());

        randomValue = Random.Range(1,2);

        snowflakeAnimator.SetTrigger("moveSet1");
    }
    private void FixedUpdate() {
        transform.position = new Vector3(transform.position.x-0.01f*randomValue, transform.position.y-0.01f*randomValue, transform.position.z);
    }

    private IEnumerator deleteTimer(){
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
