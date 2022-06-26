using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstruction : MonoBehaviour
{
    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private BuildingCanvas buildingCanvas;
    [SerializeField] private MoneyProducer moneyProducer;
    private bool buildingCanCollect;
    private bool HasBuilt = false;

    void Start()
    {
        StartCoroutine(CollectMoney());

        buildingPrefab.SetActive(false);
    }

    private void Update()
    {
        if (buildingCanvas.collectedAmount >= buildingCanvas.requiredAmount && HasBuilt == false)
        {
            Build();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            buildingCanCollect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            buildingCanCollect = false;
        }
    }

    private void Build()
    {
        HasBuilt = true;
        buildingPrefab.SetActive(true);
        buildingCanvas.gameObject.SetActive(false);
        moneyProducer.enabled = true;
    }

    IEnumerator CollectMoney()
    {
        while (!HasBuilt)
        {
            if (buildingCanCollect && CollectedList.Instance.playerMoneyList.Count > 0)
            {
                CollectedList.Instance.RemoveLast();
                buildingCanvas.Add(100);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
