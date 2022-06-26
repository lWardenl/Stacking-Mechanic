using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedList : MonoBehaviour
{
    private static CollectedList instance;
    public static CollectedList Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] private Transform moneyHolderTransform;

    public List<GameObject> playerMoneyList = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void RemoveLast()
    {
        if (playerMoneyList.Count > 0)
        {
            GameObject money = playerMoneyList[playerMoneyList.Count - 1];
            playerMoneyList.RemoveAt(playerMoneyList.Count - 1);
            Destroy(money);
        }
    }

    public void AddToList(GameObject obj)
    {
        obj.transform.parent = moneyHolderTransform;


        Vector3 position = moneyHolderTransform.position;

        if (playerMoneyList.Count > 0)
            position = playerMoneyList[playerMoneyList.Count - 1].transform.position;

        position.y += 1f;

        obj.transform.position = new Vector3(moneyHolderTransform.position.x, position.y, moneyHolderTransform.position.z);

        obj.transform.localRotation = Quaternion.identity;

        playerMoneyList.Add(obj);
    }
}
