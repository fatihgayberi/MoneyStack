using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    Rigidbody banknoteRB;
    public float banknoteSpeed;
    public float laneChangeSpeed;
    float firstX;
    float endX;
    float currentX;
    bool change;
    Vector3 targetPath;

    // Start is called before the first frame update
    void Start()
    {
        banknoteRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        BanknoteController();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BanknoteMove();
        LaneChange();
    }

    void BanknoteMove()
    {
        banknoteRB.velocity = new Vector3(0, 0, banknoteSpeed);
    }

    void BanknoteController()
    {
        if (Input.GetMouseButtonDown(0) && !change)
        {
            firstX = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0) && !change)
        {
            endX = Input.mousePosition.x;

            if (endX - firstX > 50)
            {
                // RIGHT
                currentX = transform.position.x + 5f;

                if (currentX <= 5)
                {
                    change = true;
                }
            }
            if (endX - firstX < -50)
            {
                // LEFT
                currentX = transform.position.x - 5f;

                if (currentX >= -5)
                {
                    change = true;
                }
            }
        }
    }

    void LaneChange()
    {
        if (change)
        {
            targetPath = new Vector3(currentX, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPath, Time.deltaTime * laneChangeSpeed);

            if (transform.position.x >= 5f || transform.position.x == 0 || transform.position.x <= -5f)
            {
                transform.position = targetPath;
                change = false;
            }
        }
    }
}
