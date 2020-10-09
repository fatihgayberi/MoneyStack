using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyChange : MonoBehaviour
{
    BanknoteStack BanknoteStack;
    float firstY;
    float endY;

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
            firstY = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endY = Input.mousePosition.x;

            if (endY - firstY < 0)
            {
                // RIGHT
                Debug.Log("Down");
                //currentX = transform.position.x + 5f;
                //
                //if (currentX <= 5)
                //{
                //    change = true;
                //}
            }
            if (endY - firstY > 0)
            {
                // LEFT
                Debug.Log("Down");
                //currentX = transform.position.x - 5f;
                //
                //if (currentX >= -5)
                //{
                //    change = true;
                //}
            }
        }
    }

    void Exchange()
    {
        int sum = 0;

        for (int i = 0; i < BanknoteStack.banknote.Count - 1; i++)
        {
            for (int j = i; j < BanknoteStack.banknote.Count;  j++)
            {
                sum += int.Parse(BanknoteStack.banknote[j].tag);
            }
        }
    }
}
