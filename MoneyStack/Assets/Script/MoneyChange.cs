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

            if (endY - firstY < -50)
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
            for (int j = 0; j < BanknoteStack.banknote.Count - i; j++)
            {
                sum += int.Parse(BanknoteStack.banknote[j].tag);

                for (int k = 0; k < moneyPrice.Length; k++)
                {
                    if (sum > maxSum && sum == moneyPrice[k])
                    {
                        maxSum = sum;
                        startIdx = i;
                        endIdx = j;
                        Debug.Log(maxSum);
                        //break;
                    }
                }
            }
        }
        //MoneyMerge(maxSum, startIdx, endIdx);
    }

    void MoneyMerge(int maxSum, int startIdx, int endIdx)
    {
        GameObject newMoney;

        for (int i = 0; i < allMoney.Length; i++)
        {
            if (allMoney[i].CompareTag(maxSum.ToString()))
            {
                newMoney = Instantiate(allMoney[i], BanknoteStack.banknote[startIdx].transform.position, Quaternion.identity);
            }
        }

        for (int i = 0; i < endIdx - startIdx; i++)
        {
            BanknoteStack.banknote.Remove(BanknoteStack.banknote[i]);
            Destroy(BanknoteStack.banknote[i]);
        }
    }
}
