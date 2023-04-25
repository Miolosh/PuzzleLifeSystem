using UnityEngine;
using TMPro;

public class BoughtLifeShow : MonoBehaviour
{
    public Life life_controller;
    
    public GameObject bought_life_view;
    public TextMeshProUGUI text_object;

    // Update is called once per frame
    void Update()
    {
        int amount =  life_controller.check_bought_lifes();
        

        if (amount > 0)
        {
            bought_life_view.SetActive(true);
            text_object.text = "" + amount;
        }
        else
        {
            bought_life_view.SetActive(false);
        }
    }

    public void checkLifeController()
    {
        int amount = life_controller.check_bought_lifes();


        if (amount > 0)
        {
            bought_life_view.SetActive(true);
            text_object.text = "" + amount;
        }
        else
        {
            bought_life_view.SetActive(false);
        }
    }
}
