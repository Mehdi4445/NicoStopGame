using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CollectScript : MonoBehaviour
{
    CharacterController controller;
    public GameObject Questionspanel;
    public GameObject Object1, Object2, Object3;
    public GameObject Ques1, Ques2, Ques3;

    public int health;
    public int numHearts;
    public Image[] heartsImg;
    public Sprite fullHeart;
    public Sprite EmptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        Questionspanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HealthController();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Object1)
        {
            Destroy(other.gameObject);
            Ques1.SetActive(true);
            Questionspanel.SetActive(true);


        }

        if (other.gameObject == Object2)
        {
            Destroy(other.gameObject);
            Ques2.SetActive(true);
            Questionspanel.SetActive(true);

        }

        if (other.gameObject == Object3)
        {
            Destroy(other.gameObject);
            Ques3.SetActive(true);
            Questionspanel.SetActive(true);


        }
    }
   
    void HealthController()
    {
        if (health > numHearts)
        {
            health = numHearts;
        }

        for(int i=0; i < heartsImg.Length; i++)
        {
            if (i < health)
            {
                heartsImg[i].sprite = fullHeart;
            }
            else
            {
                heartsImg[i].sprite = EmptyHeart;

            }
            if (i < numHearts)
            {
                heartsImg[i].enabled = true;
            }
            else
            {
                heartsImg[i].enabled = false;

            }

        }
    }

    public void WrongAnswer()
    {
        health -= 1;
    }
    }
    
