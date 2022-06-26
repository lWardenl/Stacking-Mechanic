using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollector : MonoBehaviour
{
    private MoneyProducer moneyProducer;
    private int maxAmount = 10;

    private void Start()
    {
        StartCoroutine(Collect());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectableZone")
        {
            moneyProducer = other.GetComponent<MoneyProducer>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CollectableZone")
        {
            moneyProducer = null;
        }
    }


    IEnumerator Collect()
    {
        while (true)
        {
            if (moneyProducer != null && moneyProducer.enabled && moneyProducer.moneyList.Count > 0 && CollectedList.Instance.playerMoneyList.Count <= maxAmount)
            {
                CollectedList.Instance.AddToList(moneyProducer.moneyList[moneyProducer.moneyList.Count - 1]);

                moneyProducer.RemoveLast();
            }
            yield return new WaitForSeconds(0.2f);
        }

    }
}
