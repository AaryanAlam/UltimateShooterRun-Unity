using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PosGate : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public int[] addNum = new int[] {10, 20, 30, 40};

    [SerializeField]
    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        int randomIndex = Random.Range(0, addNum.Length);

        int randomNumber = addNum[randomIndex];
        text.text =" x" + randomNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindWithTag("Player"))
        {
            int parsedInt;
            if (int.TryParse(text.text.Substring(2), out parsedInt))
            {
                playerManager.instantiationInterval = parsedInt / 8;
            }
        }
    }
}
