using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyChange : MonoBehaviour
{
    BanknoteStack BanknoteStack;
    float firstY;
    float endY;
    int[] moneyPrice = { 10, 20, 50, 100, 200 };
    [SerializeField] GameObject[] allMoney;

    // Start is called before the first frame update
    void Start()
    {
        BanknoteStack = GetComponent<BanknoteStack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstY = Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endY = Input.mousePosition.y;

            if (endY - firstY < -50 && BanknoteStack.banknote.Count > 1)
            {
                // DOWN

                Exchange();
            }
        }
    }

    void Exchange()
    {
        int maxSum = 0;
        int startIdx = 0;
        int endIdx = 0;
        for (int i = 0; i < BanknoteStack.banknote.Count - 1; i++)
        {
            int sum = 0;

            for (int j = i; j < BanknoteStack.banknote.Count; j++)
            {
                sum += int.Parse(BanknoteStack.banknote[j].tag);

                if (i != j)
                {
                    for (int k = 0; k < moneyPrice.Length; k++)
                    {
                        if (/*sum > maxSum && */sum == moneyPrice[k])
                        {
                            maxSum = sum;
                            startIdx = i;
                            endIdx = j;
                            Debug.Log("startIdx: " + startIdx);
                            Debug.Log("endIdx: " + endIdx);
                            Debug.Log("maxSum: " + maxSum);
                            MoneyMerge(maxSum, startIdx, endIdx);
                            sum = 0;
                        }
                    }
                }
            }
        }
    }

    void MoneyMerge(int maxSum, int startIdx, int endIdx)
    {
        GameObject newMoney;

        for (int i = 0; i <= endIdx - startIdx; i++)
        {
            Destroy(BanknoteStack.banknote[startIdx]);
            BanknoteStack.banknote.Remove(BanknoteStack.banknote[startIdx]);
        }

        for (int i = 0; i < allMoney.Length; i++)
        {
            if (allMoney[i].CompareTag(maxSum.ToString()))
            {
                newMoney = Instantiate(allMoney[i]);
                BanknoteStack.banknote.Insert(startIdx, newMoney);
                newMoney.transform.parent = transform;
                break;
            }
        }

        PositionEditor();
    }

    void PositionEditor()
    {
        float banknoteHeight = 0.25f;

        for (int i = 0; i < BanknoteStack.banknote.Count; i++)
        {
            BanknoteStack.banknote[i].transform.position = new Vector3(transform.position.x, banknoteHeight, transform.position.z);
            banknoteHeight += 0.5f;
        }

        BanknoteStack.SetBanknoteHeight(banknoteHeight - 0.5f);
    }
}
