using System;
using UnityEngine;

public class Life : MonoBehaviour
{
    int lifes = STANDARD_MAX_LIFE;
    int bought_lifes = 0;

    const int MAX_LIFE_RESPAWN = 15;
    const int STANDARD_MAX_LIFE = 10;

    DateTime last_life_up;
    DateTime unlimited_life_timer;


    private void Update()
    {
        restoreLifeOverTime();
    }

    public void loseLife()
    {
        if (unlimited_life_timer > DateTime.UtcNow)
        {
            return;
        }

        if (lifes > 0)
        {
            lifes--;
        }
        else
        {
            bought_lifes--;
        }

        if (2023 > last_life_up.Year)
        {
            last_life_up = DateTime.UtcNow;
        }

    }

    void restoreLifeOverTime()
    {
        if (lifes >= STANDARD_MAX_LIFE)
        {
            return;
        }

        TimeSpan differenceTimes = DateTime.UtcNow - last_life_up;
        if (differenceTimes.TotalMinutes > MAX_LIFE_RESPAWN)
        {
            int newLives = (int)Mathf.Round((float)differenceTimes.TotalMinutes / MAX_LIFE_RESPAWN);
            lifes += newLives;

            last_life_up = DateTime.UtcNow;
            last_life_up = last_life_up.Subtract(new TimeSpan(0, (int)(differenceTimes.TotalMinutes % MAX_LIFE_RESPAWN), 0));
            if (lifes >= STANDARD_MAX_LIFE)
            {
                lifes = STANDARD_MAX_LIFE;
                last_life_up = new DateTime(1, 1, 1, 1, 1, 0);
            }
        }
    }

    public int checkLifes()
    {
        return lifes;
    }

    public int check_bought_lifes()
    {
        return bought_lifes;
    }

    public bool lifesNull()
    {
        if (checkLifes() <= 0 && check_bought_lifes() <= 0)
        {
            return true;
        }

        return false;
    }

    public void AddBoughtLifes(int amount)
    {
        bought_lifes += amount;
    }

    public void addUnlimitedTime(int minutes)
    {
        if (unlimited_life_timer < DateTime.UtcNow)
        {
            unlimited_life_timer = DateTime.UtcNow + new TimeSpan(0, minutes, 0);
        }
        else
        {
            unlimited_life_timer += new TimeSpan(0, minutes, 0);
        }
    }

    public TimeSpan checkUnlimitedTime()
    {
        TimeSpan duration = unlimited_life_timer - DateTime.UtcNow;
        return duration;
    }

}
