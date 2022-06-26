using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyProducer : MonoBehaviour
{

    [SerializeField] private GameObject moneyPrefab;
    [SerializeField] private Transform moneyLocationTransform;

    private bool canProduce = true;

    public List<GameObject> moneyList = new List<GameObject>();

    void Start()
    {
        StartCoroutine(ProduceMoney());
    }

    private void Update()
    {
        canProduce = moneyList.Count != 40;
    }

    public void RemoveLast()
    {
        if (moneyList.Count > 0)
        {
            moneyList.RemoveAt(moneyList.Count - 1);
        }
    }

    private IEnumerator ProduceMoney()
    {
        while (true)
        {
            if (canProduce && this.enabled)
            {
                GameObject money = Instantiate(moneyPrefab);

                money.transform.position = new Vector3(moneyLocationTransform.position.x,
                                                       moneyLocationTransform.position.y + ((moneyList.Count % 5) / 1.3f),
                                                       moneyLocationTransform.position.z) + (moneyLocationTransform.forward * ((moneyList.Count / 5) / 0.5f));

                moneyList.Add(money);

            }
            yield return new WaitForSeconds(1f);


        }
    }
}
