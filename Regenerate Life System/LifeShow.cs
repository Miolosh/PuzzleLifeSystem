using UnityEngine;
using TMPro;

public class LifeShow : MonoBehaviour
{
    public TextMeshProUGUI counter_text;
    public Life life_controller;


    // Update is called once per frame
    void Update()
    {
        int amountOfLifes = life_controller.checkLifes();
        counter_text.text = "" + amountOfLifes;
    }
}
