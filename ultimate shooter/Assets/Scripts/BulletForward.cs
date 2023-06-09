using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForward : MonoBehaviour
{

    public float velocity = 1400f;

    private void Awake()
    {
        StartCoroutine(destroyBullet());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocity * Time.deltaTime);
    }
    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(12.5f);
        Destroy(gameObject);
    }
}
