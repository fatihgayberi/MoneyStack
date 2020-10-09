using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanknoteStack : MonoBehaviour
{
    public List<GameObject> banknote = new List<GameObject>();
    float banknoteHeight = 0.25f;
    float downHeight = 0.25f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Saw"))
        {
            other.GetComponent<Collider>().enabled = false;
            Destroy(banknote[0]);
            banknote.Remove(banknote[0]);
            for (int i = 0; i < banknote.Count; i++)
            {
                banknote[i].transform.position = new Vector3(transform.position.x, downHeight, transform.position.z);
                downHeight += 0.5f;
            }
            banknoteHeight -= 0.5f;
            downHeight = 0.25f;
        }
        else// (other.tag.Contains("Money"))
        {
            banknote.Add(other.gameObject);
            other.gameObject.transform.parent = transform;
            banknoteHeight += 0.5f;
            other.gameObject.transform.position = new Vector3(transform.position.x, banknoteHeight, transform.position.z);
        }
    }
}
