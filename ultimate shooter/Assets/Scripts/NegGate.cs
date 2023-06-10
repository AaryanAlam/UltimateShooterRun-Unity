using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NegGate : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public int[] takeNum = new int[] { 10, 15, 20, 25, 30 };

    [SerializeField]
    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        int randomIndex = Random.Range(0, takeNum.Length);

        int randomNumber = takeNum[randomIndex];
        text.text = " -" + randomNumber.ToString();
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
                playerManager.instantiationInterval *= parsedInt;
            }
        }
    }
}
