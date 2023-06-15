using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private GameObject bulletHolder;
    public int instantiationInterval;

    void Start()
    {
        //bullet = GameObject.FindWithTag("bullet");
        bulletHolder = GameObject.FindWithTag("bulletHolder");
        StartCoroutine(InstantiateRepeatedly());

    }
    private void Awake()
    {
        //StartCoroutine(InstantiateRepeatedly());

    }

    private void Update()
    {
        //StartCoroutine(InstantiateRepeatedly());

    }

   public IEnumerator InstantiateRepeatedly()
    {
        while (true)
        {
            Instantiate(bullet, bulletHolder.transform.position, Quaternion.Euler(90, 0, 0));
            yield return new WaitForSeconds(instantiationInterval);
            
        }
    }

}
