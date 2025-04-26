using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShestOpen : MonoBehaviour
{
    public GameObject image;
    [SerializeField] GameObject Sword1, Boots1, Shest1, Pants1;
    [SerializeField] GameObject Sword2, Boots2, Shest2, Pants2;
    [SerializeField] GameObject Sword3, Boots3, Shest3, Gloves3, Helmet3,Shoulders3, Pants3;
    [SerializeField] GameObject Sword4, Boots4, Shest4, Gloves4, Helmet4, Shoulders4, Pants4;
    [SerializeField] GameObject Sword5, Boots5, Shest5, Gloves5, Helmet5, Shoulders5, Pants5;



    public enum Loot_1_3
    {
        Sword1,
        Boots1,
        Shest1,
        Pants1
    }
    public enum Loot_4_8
    {
        Sword2,
        Boots2,
        Shest2,
        Pants2
    }
    public enum Loot_8_12
    {
        Sword3,
        Boots3,
        Shest3,
        Gloves3,
        Helmet3,
        Shoulders3,
        Pants3
    }
    public enum Loot_13_18
    {
        Sword4,
        Boots4,
        Shest4,
        Gloves4,
        Helmet4,
        Shoulders4,
        Pants4
    }
    public enum Loot_19_25
    {
        Sword5,
        Boots5,
        Shest5,
        Gloves5,
        Helmet5,
        Shoulders5,
        Pants5
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "chest")
        {
            image.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            { 
                Debug.Log("Открытие сундука");
                Destroy(other.gameObject);
                image.SetActive(false);
            }
        }
                      

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "chest")
        {
            image.SetActive(false);
            
        }
    }
}
