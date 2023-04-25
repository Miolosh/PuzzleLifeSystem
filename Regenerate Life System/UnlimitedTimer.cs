using UnityEngine;
using TMPro;

public class UnlimitedTimer : MonoBehaviour
{
    public Life life_controller;

    [SerializeField] GameObject normal_life_counter;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject timer_capsule;


    // Update is called once per frame
    void Update()
    {
        checkLifeController();
    }

    public void checkLifeController()
    {
        if (life_controller.checkUnlimitedTime().TotalSeconds > 0)
        {
            timer_capsule.SetActive(true);
            normal_life_counter.SetActive(false);

            timer.text = "" + Mathf.FloorToInt((float)life_controller.checkUnlimitedTime().TotalHours) + " : " + life_controller.checkUnlimitedTime().Minutes;
            return;
        }
        else
        {
            timer_capsule.SetActive(false);
            normal_life_counter.SetActive(true);
        }
    }
}
