using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory1 inventory;
    public GameObject itemButton;
    public string item;
    // Start is called before the first frame update
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory1>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yoyooyo");
        if (other.CompareTag("Player"))
        {
            Debug.Log("sigh");
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                Debug.Log("bruh");
                if (inventory.isFull[i] == false)
                {
                    Debug.Log("my guy it works");
                    bool flag = false;
                    if (inventory.items.Count > 0)
                    {
                        for (int j = 0; j < inventory.items.Count; j++)
                        {
                            if (inventory.items[j].itemType.Equals(item))
                            {
                                inventory.items[j].amount++;
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (!flag)
                        inventory.items.Add(new Item(item, 1));

                    Debug.Log("buddy");
                    inventory.isFull[i] = true;
                    float myScale = 0.6f;
                    itemButton.transform.localScale = new Vector3(myScale, myScale, myScale);
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
    
}
