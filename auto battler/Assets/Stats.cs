using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{

    public int maxHp;
    public int currentHp;
    public int damage;
    public string type;
    public string unit;
    public TMP_Text damageText;
    public TMP_Text HpText;
    public GameObject stats;
    public string descript;
    public bool showstats = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void heal()
    {
        currentHp = maxHp;
    }

    public void updateUnit()
    {
        if (unit == " ")
        {
            maxHp = 0;
            damage = 0;
            currentHp = 0;
            type = "";
        }
        if (unit == "shark")
        {
            maxHp = 4;
            damage = 3;
            type = "brawler";
        }
        if (unit == "dog")
        {
            maxHp = 2;
            damage = 2;
            type = "support";
        }
        if (unit == "sunfish")
        {
            maxHp = 7;
            damage = 1;
            type = "tank";
        }
        if (unit == "cleaner")
        {
            maxHp = 2;
            damage = 2;
            type = "support";
        }
        if (unit == "puffer")
        {
            maxHp = 1;
            damage = 2;
            type = "ranged";
        }
        if (unit == "cow")
        {
            maxHp = 3;
            damage = 4;
            type = "brawler";
        }
        if (unit == "elephant")
        {
            maxHp = 6;
            damage = 1;
            type = "tank";
        }
        if (unit == "skunk")
        {
            maxHp = 3;
            damage = 1;
            type = "ranged";
        }
        if (unit == "eagle")
        {
            maxHp = 1;
            damage = 5;
            type = "brawler";
        }
        if (unit == "swan")
        {
            maxHp = 3;
            damage = 2;
            type = "support";
        }
        if (unit == "vulture")
        {
            maxHp = 4;
            damage = 1;
            type = "ranged";
        }
        if (unit == "penguin")
        {
            maxHp = 6;
            damage = 1;
            type = "tank";
        }
        currentHp = maxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (type == "")
        {
            descript = "";
        }
        if (type == "brawler")
        {
            descript = "normal unit that does physical attacks";
        }
        if (type == "ranged")
        {
            descript = "can attack when the unit infront attacks and can also make physical attacks";
        }
        if (unit == "swan" || unit == "dog")
        {
            descript = "buffs the unit infront of its damage and then dies";
        }
        if (unit == "cleaner")
        {
            descript = "buffs the unit infront of its Hp and then dies";
        }
        if (type == "tank")
        {
            descript = "has high hp but always deals 1 damage";
        }

        if (unit == " "|| unit == "")
        {
            stats.SetActive(false);
        }
        else if (showstats)
        {
            stats.SetActive(true);
            HpText.SetText(currentHp + " ");
            damageText.SetText(damage + " ");
        }
    }
}
