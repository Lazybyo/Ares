using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum battleState { SHOP, B, R, PS, ES}

public class UI : MonoBehaviour
{
    public bool yes = false;
    bool yesyes = true;
    public Image Sunit1;
    public Image Sunit2;
    public Image Sunit3;
    public Image Sunit4;
    public Image Sunit5;
    public Image Sunit6;
    public Image Sunit7;
    public Image Sunit8;
    public Image ESunit4;
    public Image ESunit5;
    public Image ESunit6;
    public Image ESunit7;
    public Image ESunit8;
    public Sprite shark;
    public Sprite dog;
    public Sprite sunfish;
    public Sprite blank;
    public Sprite cleaner;
    public Sprite puffer;
    public Sprite cow;
    public Sprite elephant;
    public Sprite skunk;
    public Sprite eagle;
    public Sprite swan;
    public Sprite vulture;
    public Sprite penguin;
    private Transform currentplat;
    public TMP_Text goldText;
    public int gold = 5;
    public string spu1 = "shark";
    public string spu2 = "dog";
    public string spu3 = "sunfish";
    public string pu1 = " ";
    public string pu2 = " ";
    public string pu3 = " ";
    public string pu4 = " ";
    public string pu5 = " ";
    public string currentPu;
    private int prevousSPu;
    private bool isPlat = false;
    private bool isSplat = false;
    private int num;
    private int number;
    private int prenum;
    public string Prepu = " ";
    public string currentpu;
    int numbar = 0;
    public GameObject sell;
    public battleState state;
    public Stats unit1stats;
    public Stats unit2stats;
    public Stats unit3stats;
    public Stats unit4stats;
    public Stats unit5stats;
    public GameObject shop;
    public GameObject battle;
    public Transform units;
    public bool yesable = true;
    public string saveu1 = " ";
    public string saveu2 = " ";
    public string saveu3 = " ";
    public string saveu4 = " ";
    public string saveu5 = " ";
    public Stats Eunit1stats;
    public Stats Eunit2stats;
    public Stats Eunit3stats;
    public Stats Eunit4stats;
    public Stats Eunit5stats;
    public float timeBetween = 0.4f;
    public Animator Uani;
    public Animator EUani;
    public int round = -1;
    public int wins = 0;
    public int lives = 6;
    private bool ok = false;
    bool otherok = true;
    int random;
    public float timescale = 1.0f;
    public GameObject descript;
    public TMP_Text nameText;
    public TMP_Text classText;
    public TMP_Text descriptText;
    public Stats Sunit1stats;
    public Stats Sunit2stats;
    public Stats Sunit3stats;
    bool checkable = true;
    public TMP_Text damageText1;
    public TMP_Text HpText1;
    public GameObject stats1;
    public TMP_Text damageText2;
    public TMP_Text HpText2;
    public GameObject stats2;
    public TMP_Text damageText3;
    public TMP_Text HpText3;
    public GameObject stats3;
    public TMP_Text damageTex4;
    public TMP_Text HpText4;
    public GameObject stats4;
    public TMP_Text damageText5;
    public TMP_Text HpText5;
    public GameObject stats5;

    void Start()
    {
        state = battleState.B;
        reroll();
    }


    void move()
    {
        if (state != battleState.SHOP)
        {
            if (unit5stats.unit == " " && unit4stats.unit != " ")
            {
                pu5 = unit4stats.unit;
                unit5stats.unit = unit4stats.unit;
                unit5stats.maxHp = unit4stats.maxHp;
                unit5stats.currentHp = unit4stats.currentHp;
                unit5stats.damage = unit4stats.damage;
                unit5stats.type = unit4stats.type;
                pu4 = " ";
                unit4stats.unit = " ";
                unit4stats.maxHp = 0;
                unit4stats.currentHp = 0;
                unit4stats.damage = 0;
                unit4stats.type = "";
            }
            if (unit4stats.unit == " " && unit3stats.unit != " ")
            {
                pu4 = unit3stats.unit;
                unit4stats.unit = unit3stats.unit;
                unit4stats.maxHp = unit3stats.maxHp;
                unit4stats.currentHp = unit3stats.currentHp;
                unit4stats.damage = unit3stats.damage;
                unit4stats.type = unit3stats.type;
                pu3 = " ";
                unit3stats.unit = " ";
                unit3stats.maxHp = 0;
                unit3stats.currentHp = 0;
                unit3stats.damage = 0;
                unit3stats.type = "";
            }
            if (unit3stats.unit == " " && unit2stats.unit != " ")
            {
                pu3 = unit2stats.unit;
                unit3stats.unit = unit2stats.unit;
                unit3stats.maxHp = unit2stats.maxHp;
                unit3stats.currentHp = unit2stats.currentHp;
                unit3stats.damage = unit2stats.damage;
                unit3stats.type = unit2stats.type;
                pu2 = " ";
                unit2stats.unit = " ";
                unit2stats.maxHp = 0;
                unit2stats.currentHp = 0;
                unit2stats.damage = 0;
                unit2stats.type = "";
            }
            if (unit2stats.unit == " " && unit1stats.unit != " ")
            {
                pu2 = unit1stats.unit;
                unit2stats.unit = unit1stats.unit;
                unit2stats.maxHp = unit1stats.maxHp;
                unit2stats.currentHp = unit1stats.currentHp;
                unit2stats.damage = unit1stats.damage;
                unit2stats.type = unit1stats.type;
                pu1 = " ";
                unit1stats.unit = " ";
                unit1stats.maxHp = 0;
                unit1stats.currentHp = 0;
                unit1stats.damage = 0;
                unit1stats.type = "";
            }
            if (Eunit5stats.unit == " " && Eunit4stats.unit != " ")
            {
                Eunit5stats.unit = Eunit4stats.unit;
                Eunit5stats.maxHp = Eunit4stats.maxHp;
                Eunit5stats.currentHp = Eunit4stats.currentHp;
                Eunit5stats.damage = Eunit4stats.damage;
                Eunit5stats.type = Eunit4stats.type;
                Eunit4stats.unit = " ";
                Eunit4stats.maxHp = 0;
                Eunit4stats.currentHp = 0;
                Eunit4stats.damage = 0;
                Eunit4stats.type = "";
            }
            if (Eunit4stats.unit == " " && Eunit3stats.unit != " ")
            {
                Eunit4stats.unit = Eunit3stats.unit;
                Eunit4stats.maxHp = Eunit3stats.maxHp;
                Eunit4stats.currentHp = Eunit3stats.currentHp;
                Eunit4stats.damage = Eunit3stats.damage;
                Eunit4stats.type = Eunit3stats.type;
                Eunit3stats.unit = " ";
                Eunit3stats.maxHp = 0;
                Eunit3stats.currentHp = 0;
                Eunit3stats.damage = 0;
                Eunit3stats.type = "";
            }
            if (Eunit3stats.unit == " " && Eunit2stats.unit != " ")
            {
                Eunit3stats.unit = Eunit2stats.unit;
                Eunit3stats.maxHp = Eunit2stats.maxHp;
                Eunit3stats.currentHp = Eunit2stats.currentHp;
                Eunit3stats.damage = Eunit2stats.damage;
                Eunit3stats.type = Eunit2stats.type;
                Eunit2stats.unit = " ";
                Eunit2stats.maxHp = 0;
                Eunit2stats.currentHp = 0;
                Eunit2stats.damage = 0;
                Eunit2stats.type = "";
            }
            if (Eunit2stats.unit == " " && Eunit1stats.unit != " ")
            {
                Eunit2stats.unit = Eunit1stats.unit;
                Eunit2stats.maxHp = Eunit1stats.maxHp;
                Eunit2stats.currentHp = Eunit1stats.currentHp;
                Eunit2stats.damage = Eunit1stats.damage;
                Eunit2stats.type = Eunit1stats.type;
                Eunit1stats.unit = " ";
                Eunit1stats.maxHp = 0;
                Eunit1stats.currentHp = 0;
                Eunit1stats.damage = 0;
                Eunit1stats.type = "";
            }
        }
    }

    public IEnumerator brawl()
    {
        yield return new WaitForSeconds(timeBetween);
        if (unit5stats.type == "brawler"  && state == battleState.B || unit5stats.type == "ranged" && state == battleState.B)
        {
            Eunit5stats.currentHp -= unit5stats.damage;
            Uani.SetTrigger("attack");
        }
        if (unit5stats.type == "tank")
        {
            Eunit5stats.currentHp -= 1;
            Uani.SetTrigger("attack");
        }
        if (Eunit5stats.type == "brawler" && state == battleState.B || Eunit5stats.type == "ranged" && state == battleState.B)
        {
            unit5stats.currentHp -= Eunit5stats.damage;
            EUani.SetTrigger("Eattack");
        }
        if (Eunit5stats.type == "tank" && state == battleState.B)
        {
            unit5stats.currentHp -= 1;
            EUani.SetTrigger("Eattack");
        }
        yield return new WaitForSeconds(timeBetween);
        if (unit5stats.currentHp <= 0 && state != battleState.SHOP)
        {
            pu5 = " ";
            unit5stats.unit = " ";
        }
        if (Eunit5stats.currentHp <= 0 && state != battleState.SHOP)
        {
            Eunit5stats.unit = " ";
        }
        if (ok && state != battleState.SHOP)
        {
            move();
            yield return new WaitForSeconds(timeBetween / 2);
            state = battleState.R;
            yesable = true;
        }
    }

    public IEnumerator ranged()
    {
        yield return new WaitForSeconds(timeBetween);
        if (unit4stats.type == "ranged" && state == battleState.R)
        {
            Eunit5stats.currentHp -= unit4stats.damage;
            Uani.SetTrigger("ranged");
        }
        if (Eunit4stats.type == "ranged" && state == battleState.R)
        {
            unit5stats.currentHp -= Eunit4stats.damage;
            EUani.SetTrigger("ERanged");
        }
        yield return new WaitForSeconds(timeBetween);
        if (unit5stats.currentHp <= 0 && state != battleState.SHOP)
        {
            pu5 = " ";
            unit5stats.unit = " ";
        }
        if (Eunit5stats.currentHp <= 0 && state != battleState.SHOP)
        {
            Eunit5stats.unit = " ";
        }
        if (ok && state != battleState.SHOP)
        {
            move();
            yield return new WaitForSeconds(timeBetween / 2);
            state = battleState.B;
            yesable = true;
        }
    }

    public IEnumerator support()
    {
        yield return new WaitForSeconds(timeBetween);
        if (unit1stats.unit == "swan")
        {
            unit2stats.damage += unit1stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu1 = " ";
            unit1stats.unit = " ";
            unit1stats.maxHp = 0;
            unit1stats.currentHp = 0;
            unit1stats.damage = 0;
            unit1stats.type = "";
        }
        if (unit1stats.unit == "dog")
        {
            unit2stats.damage += unit1stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu1 = " ";
            unit1stats.unit = " ";
            unit1stats.maxHp = 0;
            unit1stats.currentHp = 0;
            unit1stats.damage = 0;
            unit1stats.type = "";
        }
        if (unit1stats.unit == "cleaner")
        {
            unit2stats.currentHp += unit1stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu1 = " ";
            unit1stats.unit = " ";
            unit1stats.maxHp = 0;
            unit1stats.currentHp = 0;
            unit1stats.damage = 0;
            unit1stats.type = "";
        }
        if (unit2stats.unit == "swan")
        {
            unit3stats.damage += unit2stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu2 = " ";
            unit2stats.unit = " ";
            unit2stats.maxHp = 0;
            unit2stats.currentHp = 0;
            unit2stats.damage = 0;
            unit2stats.type = "";
        }
        if (unit2stats.unit == "dog")
        {
            unit3stats.damage += unit2stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu2 = " ";
            unit2stats.unit = " ";
            unit2stats.maxHp = 0;
            unit2stats.currentHp = 0;
            unit2stats.damage = 0;
            unit2stats.type = "";
        }
        if (unit2stats.unit == "cleaner")
        {
            unit3stats.currentHp += unit2stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu2 = " ";
            unit2stats.unit = " ";
            unit2stats.maxHp = 0;
            unit2stats.currentHp = 0;
            unit2stats.damage = 0;
            unit2stats.type = "";
        }
        if (unit3stats.unit == "swan")
        {
            unit4stats.damage += unit3stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu3 = " ";
            unit3stats.unit = " ";
            unit3stats.maxHp = 0;
            unit3stats.currentHp = 0;
            unit3stats.damage = 0;
            unit3stats.type = "";
        }
        if (unit3stats.unit == "dog")
        {
            unit4stats.damage += unit3stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu3 = " ";
            unit3stats.unit = " ";
            unit3stats.maxHp = 0;
            unit3stats.currentHp = 0;
            unit3stats.damage = 0;
            unit3stats.type = "";
        }
        if (unit3stats.unit == "cleaner")
        {
            unit4stats.currentHp += unit3stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu3 = " ";
            unit3stats.unit = " ";
            unit3stats.maxHp = 0;
            unit3stats.currentHp = 0;
            unit3stats.damage = 0;
            unit3stats.type = "";
        }
        if (unit4stats.unit == "swan")
        {
            unit5stats.damage += unit4stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu4 = " ";
            unit4stats.unit = " ";
            unit4stats.maxHp = 0;
            unit4stats.currentHp = 0;
            unit4stats.damage = 0;
            unit4stats.type = "";
        }
        if (unit4stats.unit == "dog")
        {
            unit5stats.damage += unit4stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu4 = " ";
            unit4stats.unit = " ";
            unit4stats.maxHp = 0;
            unit4stats.currentHp = 0;
            unit4stats.damage = 0;
            unit4stats.type = "";
        }
        if (unit4stats.unit == "cleaner")
        {
            unit5stats.currentHp += unit4stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu4 = " ";
            unit4stats.unit = " ";
            unit4stats.maxHp = 0;
            unit4stats.currentHp = 0;
            unit4stats.damage = 0;
            unit4stats.type = "";
        }
        move();
        yield return new WaitForSeconds(timeBetween / 2);
        move();
        state = battleState.ES;
        yesable = true;
    }

    public IEnumerator Esupport()
    {
        yield return new WaitForSeconds(timeBetween);
        if (Eunit1stats.unit == "swan")
        {
            Eunit2stats.damage += Eunit1stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu1 = " ";
            Eunit1stats.unit = " ";
            Eunit1stats.maxHp = 0;
            Eunit1stats.currentHp = 0;
            Eunit1stats.damage = 0;
            Eunit1stats.type = "";
        }
        if (Eunit1stats.unit == "dog")
        {
            Eunit2stats.damage += Eunit1stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu1 = " ";
            Eunit1stats.unit = " ";
            Eunit1stats.maxHp = 0;
            Eunit1stats.currentHp = 0;
            Eunit1stats.damage = 0;
            Eunit1stats.type = "";
        }
        if (Eunit1stats.unit == "cleaner")
        {
            Eunit2stats.currentHp += Eunit1stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu1 = " ";
            Eunit1stats.unit = " ";
            Eunit1stats.maxHp = 0;
            Eunit1stats.currentHp = 0;
            Eunit1stats.damage = 0;
            Eunit1stats.type = "";
        }
        if (Eunit2stats.unit == "swan")
        {
            Eunit3stats.damage += Eunit2stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu2 = " ";
            Eunit2stats.unit = " ";
            Eunit2stats.maxHp = 0;
            Eunit2stats.currentHp = 0;
            Eunit2stats.damage = 0;
            Eunit2stats.type = "";
        }
        if (Eunit2stats.unit == "dog")
        {
            Eunit3stats.damage += Eunit2stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu2 = " ";
            Eunit2stats.unit = " ";
            Eunit2stats.maxHp = 0;
            Eunit2stats.currentHp = 0;
            Eunit2stats.damage = 0;
            Eunit2stats.type = "";
        }
        if (Eunit2stats.unit == "cleaner")
        {
            Eunit3stats.currentHp += Eunit2stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu2 = " ";
            Eunit2stats.unit = " ";
            Eunit2stats.maxHp = 0;
            Eunit2stats.currentHp = 0;
            Eunit2stats.damage = 0;
            Eunit2stats.type = "";
        }
        if (Eunit3stats.unit == "swan")
        {
            Eunit4stats.damage += Eunit3stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu3 = " ";
            Eunit3stats.unit = " ";
            Eunit3stats.maxHp = 0;
            Eunit3stats.currentHp = 0;
            Eunit3stats.damage = 0;
            Eunit3stats.type = "";
        }
        if (Eunit3stats.unit == "dog")
        {
            Eunit4stats.damage += Eunit3stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu3 = " ";
            Eunit3stats.unit = " ";
            Eunit3stats.maxHp = 0;
            Eunit3stats.currentHp = 0;
            Eunit3stats.damage = 0;
            Eunit3stats.type = "";
        }
        if (Eunit3stats.unit == "cleaner")
        {
            Eunit4stats.currentHp += Eunit3stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu3 = " ";
            Eunit3stats.unit = " ";
            Eunit3stats.maxHp = 0;
            Eunit3stats.currentHp = 0;
            Eunit3stats.damage = 0;
            Eunit3stats.type = "";
        }
        if (Eunit4stats.unit == "swan")
        {
            Eunit5stats.damage += Eunit4stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu4 = " ";
            Eunit4stats.unit = " ";
            Eunit4stats.maxHp = 0;
            Eunit4stats.currentHp = 0;
            Eunit4stats.damage = 0;
            Eunit4stats.type = "";
        }
        if (Eunit4stats.unit == "dog")
        {
            Eunit5stats.damage += Eunit4stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu4 = " ";
            Eunit4stats.unit = " ";
            Eunit4stats.maxHp = 0;
            Eunit4stats.currentHp = 0;
            Eunit4stats.damage = 0;
            Eunit4stats.type = "";
        }
        if (Eunit4stats.unit == "cleaner")
        {
            Eunit5stats.currentHp += Eunit4stats.damage;
            yield return new WaitForSeconds(timeBetween / 2);
            pu4 = " ";
            Eunit4stats.unit = " ";
            Eunit4stats.maxHp = 0;
            Eunit4stats.currentHp = 0;
            Eunit4stats.damage = 0;
            Eunit4stats.type = "";
        }
        move();
        yield return new WaitForSeconds(timeBetween / 2);
        move();
        state = battleState.B;
        yesable = true;
    }


    public void continueClick()
    {
        unit1stats.updateUnit();
        unit2stats.updateUnit();
        unit3stats.updateUnit();
        unit4stats.updateUnit();
        unit5stats.updateUnit();
        unit1stats.heal();
        unit2stats.heal();
        unit3stats.heal();
        unit4stats.heal();
        unit5stats.heal();

        random = Random.Range(1, 4);
        if (random == 1)
        {
            if (round == 1)
            {
                Eunit5stats.unit = "shark";
                Eunit4stats.unit = "cow";
                Eunit3stats.unit = " ";
                Eunit2stats.unit = " ";
                Eunit1stats.unit = " ";
            }
            if (round == 2)
            {
                Eunit5stats.unit = "shark";
                Eunit4stats.unit = "dog";
                Eunit3stats.unit = "cow";
                Eunit2stats.unit = "dog";
                Eunit1stats.unit = " ";
            }
            if (round == 3)
            {
                Eunit5stats.unit = "eagle";
                Eunit4stats.unit = "cleaner";
                Eunit3stats.unit = "dog";
                Eunit2stats.unit = "shark";
                Eunit1stats.unit = "dog";
            }
            if (round >= 4)
            {
                Eunit5stats.unit = "eagle";
                Eunit4stats.unit = "cleaner";
                Eunit3stats.unit = "dog";
                Eunit2stats.unit = "dog";
                Eunit1stats.unit = "dog";
            }
        }
        if (random == 2)
        {
            if (round == 1)
            {
                Eunit5stats.unit = "sunfish";
                Eunit4stats.unit = "skunk";
                Eunit3stats.unit = " ";
                Eunit2stats.unit = " ";
                Eunit1stats.unit = " ";
            }
            if (round == 2)
            {
                Eunit5stats.unit = "sunfish";
                Eunit4stats.unit = "skunk";
                Eunit3stats.unit = "swan";
                Eunit2stats.unit = " ";
                Eunit1stats.unit = " ";
            }
            if (round == 3)
            {
                Eunit5stats.unit = "penguin";
                Eunit4stats.unit = "cleaner";
                Eunit3stats.unit = "skunk";
                Eunit2stats.unit = "swan";
                Eunit1stats.unit = "dog";
            }
            if (round >= 4)
            {
                Eunit5stats.unit = "sunfish";
                Eunit4stats.unit = "cleaner";
                Eunit3stats.unit = "swan";
                Eunit2stats.unit = "puffer";
                Eunit1stats.unit = "dog";
            }
        }
        if (random == 3)
        {
            if (round == 1)
            {
                Eunit5stats.unit = "eagle";
                Eunit4stats.unit = "vulture";
                Eunit3stats.unit = " ";
                Eunit2stats.unit = " ";
                Eunit1stats.unit = " ";
            }
            if (round == 2)
            {
                Eunit5stats.unit = "eagle";
                Eunit4stats.unit = "cleaner";
                Eunit3stats.unit = "vulture";
                Eunit2stats.unit = "dog";
                Eunit1stats.unit = " ";
            }
            if (round == 3)
            { 
                Eunit5stats.unit = "eagle";
                Eunit4stats.unit = "cleaner";
                Eunit3stats.unit = "vulture";
                Eunit2stats.unit = "dog";
                Eunit1stats.unit = "dog";
            }
            if (round >= 4)
            {
                Eunit5stats.unit = "eagle";
                Eunit4stats.unit = "eagle";
                Eunit3stats.unit = "eagle";
                Eunit2stats.unit = "cleaner";
                Eunit1stats.unit = "dog";
            }
        }

        Eunit1stats.updateUnit();
        Eunit2stats.updateUnit();
        Eunit3stats.updateUnit();
        Eunit4stats.updateUnit();
        Eunit5stats.updateUnit();
        Eunit1stats.heal();
        Eunit2stats.heal();
        Eunit3stats.heal();
        Eunit4stats.heal();
        Eunit5stats.heal();
        shop.SetActive(false);
        battle.SetActive(true);
        units.localScale = new Vector3(0.68f, 0.7f, 0f);
        units.position += new Vector3(-207f, -40f, 0f);
        saveu1 = pu1;
        saveu2 = pu2;
        saveu3 = pu3;
        saveu4 = pu4;
        saveu5 = pu5;
        yesable = true;
        ok = true;
        otherok = true;
        state = battleState.PS;
    }

    public void sells()
    {
        if (state == battleState.SHOP)
        {
            if (numbar == 1 && pu1 != " ")
            {
                pu1 = " ";
                gold += 1;
            }
            if (numbar == 2 && pu2 != " ")
            {
                pu2 = " ";
                gold += 1;
            }
            if (numbar == 3 && pu3 != " ")
            {
                pu3 = " ";
                gold += 1;
            }
            if (numbar == 4 && pu4 != " ")
            {
                pu4 = " ";
                gold += 1;
            }
            if (numbar == 5 && pu5 != " ")
            {
                pu5 = " ";
                gold += 1;
            }
        }
    }

    public void platClick(int numba)
    {
        if (state == battleState.SHOP)
        {
            numbar = numba;
            sell.SetActive(true);
        }
    }
    public void rerollClick()
    {
        if (gold > 0 && state == battleState.SHOP)
        {
            gold -= 1;
            reroll();
        }
    }

    public void reroll()
    {
        int s1 = Random.Range(1, 13);
        int s2 = Random.Range(1, 13);
        int s3 = Random.Range(1, 13);
        if (s1 == 1)
        {
            spu1 = "shark";
        }
        if (s1 == 2)
        {
            spu1 = "dog";
        }
        if (s1 == 3)
        {
            spu1 = "sunfish";
        }
        if (s1 == 4)
        {
            spu1 = "cleaner";
        }
        if (s1 == 5)
        {
            spu1 = "puffer";
        }
        if (s1 == 6)
        {
            spu1 = "cow";
        }
        if (s1 == 7)
        {
            spu1 = "elephant";
        }
        if (s1 == 8)
        {
            spu1 = "skunk";
        }
        if (s1 == 9)
        {
            spu1 = "eagle";
        }
        if (s1 == 10)
        {
            spu1 = "swan";
        }
        if (s1 == 11)
        {
            spu1 = "vulture";
        }
        if (s1 == 12)
        {
            spu1 = "penguin";
        }
        if (s2 == 1)
        {
            spu2 = "shark";
        }
        if (s2 == 2)
        {
            spu2 = "dog";
        }
        if (s2 == 3)
        {
            spu2 = "sunfish";
        }
        if (s2 == 4)
        {
            spu2 = "cleaner";
        }
        if (s2 == 5)
        {
            spu2 = "puffer";
        }
        if (s2 == 6)
        {
            spu2 = "cow";
        }
        if (s2 == 7)
        {
            spu2 = "elephant";
        }
        if (s2 == 8)
        {
            spu2 = "skunk";
        }
        if (s2 == 9)
        {
            spu2 = "eagle";
        }
        if (s2 == 10)
        {
            spu2 = "swan";
        }
        if (s2 == 11)
        {
            spu2 = "vulture";
        }
        if (s2 == 12)
        {
            spu2 = "penguin";
        }
        if (s3 == 1)
        {
            spu3 = "shark";
        }
        if (s3 == 2)
        {
            spu3 = "dog";
        }
        if (s3 == 3)
        {
            spu3 = "sunfish";
        }
        if (s3 == 4)
        {
            spu3 = "cleaner";
        }
        if (s3 == 5)
        {
            spu3 = "puffer";
        }
        if (s3 == 6)
        {
            spu3 = "cow";
        }
        if (s3 == 7)
        {
            spu3 = "elephant";
        }
        if (s3 == 8)
        {
            spu3 = "skunk";
        }
        if (s3 == 9)
        {
            spu3 = "eagle";
        }
        if (s3 == 10)
        {
            spu3 = "swan";
        }
        if (s3 == 11)
        {
            spu3 = "vulture";
        }
        if (s3 == 12)
        {
            spu3 = "penguin";
        }
    }

    public void shopclick2(int number)
    {
        num = number;
    }

    public void shopclick(Transform self)
    {
        state = battleState.SHOP;
        if (state == battleState.SHOP)
        {
            yes = true;
            currentplat = self;
            if (num == 1)
            {
                currentPu = spu1;
                prevousSPu = 1;
                nameText.SetText(Sunit1stats.unit);
                classText.SetText(Sunit1stats.type);
                descriptText.SetText(Sunit1stats.descript);
            }
            if (num == 2)
            {
                currentPu = spu2;
                prevousSPu = 2;
                nameText.SetText(Sunit2stats.unit);
                classText.SetText(Sunit2stats.type);
                descriptText.SetText(Sunit2stats.descript);
            }
            if (num == 3)
            {
                currentPu = spu3;
                prevousSPu = 3;
                nameText.SetText(Sunit3stats.unit);
                classText.SetText(Sunit3stats.type);
                descriptText.SetText(Sunit3stats.descript);
            }
            yesyes = false;
            isPlat = false;
            isSplat = true;
        }
    }

    public void platformclick2(int numbr)
    {
        prenum = number;
        if (number == 1)
        {
            Prepu = pu1;
        }
        if (number == 2)
        {
            Prepu = pu2;
        }
        if (number == 3)
        {
            Prepu = pu3;
        }
        if (number == 4)
        {
            Prepu = pu4;
        }
        if (number == 5)
        {
            Prepu = pu5;
        }
        number = numbr;
        if (number == 1)
        {
            nameText.SetText(unit1stats.unit);
            classText.SetText(unit1stats.type);
            descriptText.SetText(unit1stats.descript);
            currentpu = pu1;
        }
        if (number == 2)
        {
            nameText.SetText(unit2stats.unit);
            classText.SetText(unit2stats.type);
            descriptText.SetText(unit2stats.descript);
            currentpu = pu2;
        }
        if (number == 3)
        {
            nameText.SetText(unit3stats.unit);
            classText.SetText(unit3stats.type);
            descriptText.SetText(unit3stats.descript);
            currentpu = pu3;
        }
        if (number == 4)
        {
            nameText.SetText(unit4stats.unit);
            classText.SetText(unit4stats.type);
            descriptText.SetText(unit4stats.descript);
            currentpu = pu4;
        }
        if (number == 5)
        {
            nameText.SetText(unit5stats.unit);
            classText.SetText(unit5stats.type);
            descriptText.SetText(unit5stats.descript);
            currentpu = pu5;
        }
    }

    public void platformclick(Transform self)
    {
        bool able = true;
        yesyes = false;
        if (number == 1)
        {

            if (pu1 != " ")
            {
                able = false;
            }
        }
        if (number == 2)
        {
            if (pu2 != " ")
            {
                able = false;
            }
        }
        if (number == 3)
        {
            if (pu3 != " ")
            {
                able = false;
            }
        }
        if (number == 4)
        {
            if (pu4 != " ")
            {
                able = false;
            }
        }
        if (number == 5)
        {
            if (pu5 != " ")
            {
                able = false;
            }
        }
        if (yes && gold > 1 && isSplat && currentPu != " " && able && state == battleState.SHOP)
        {
            yes = false;
            gold -= 2;
            if (number == 1)
            {

                if (prevousSPu == 1)
                {
                    spu1 = pu1;
                }
                if (prevousSPu == 2)
                {
                    spu2 = pu1;
                }
                if (prevousSPu == 3)
                {
                    spu3 = pu1;
                }
                pu1 = currentPu;
                unit1stats.unit = pu1;
                unit1stats.updateUnit();
            }
            if (number == 2)
            {

                if (prevousSPu == 1)
                {
                    spu1 = pu2;
                }
                if (prevousSPu == 2)
                {
                    spu2 = pu2;
                }
                if (prevousSPu == 3)
                {
                    spu3 = pu2;
                }
                pu2 = currentPu;
                unit2stats.unit = pu2;
                unit2stats.updateUnit();
            }
            if (number == 3)
            {

                if (prevousSPu == 1)
                {
                    spu1 = pu3;
                }
                if (prevousSPu == 2)
                {
                    spu2 = pu3;
                }
                if (prevousSPu == 3)
                {
                    spu3 = pu3;
                }
                pu3 = currentPu;
                unit3stats.unit = pu3;
                unit3stats.updateUnit();
            }
            if (number == 4)
            {

                if (prevousSPu == 1)
                {
                    spu1 = pu4;
                }
                if (prevousSPu == 2)
                {
                    spu2 = pu4;
                }
                if (prevousSPu == 3)
                {
                    spu3 = pu4;
                }
                pu4 = currentPu;
                unit4stats.unit = pu4;
                unit4stats.updateUnit();
            }
            if (number == 5)
            {

                if (prevousSPu == 1)
                {
                    spu1 = pu5;
                }
                if (prevousSPu == 2)
                {
                    spu2 = pu5;
                }
                if (prevousSPu == 3)
                {
                    spu3 = pu5;
                }
                pu5 = currentPu;
                unit5stats.unit = pu5;
                unit5stats.updateUnit();
            }
        }
        if (isPlat && yes && state == battleState.SHOP)
        {
            if (prenum == 1)
            {
                pu1 = currentpu;
                unit1stats.unit = pu1;
                unit1stats.updateUnit();
            }
            if (prenum == 2)
            {
                pu2 = currentpu;
                unit2stats.unit = pu2;
                unit2stats.updateUnit();
            }
            if (prenum == 3)
            {
                pu3 = currentpu;
                unit3stats.unit = pu3;
                unit3stats.updateUnit();
            }
            if (prenum == 4)
            {
                pu4 = currentpu;
                unit4stats.unit = pu4;
                unit4stats.updateUnit();
            }
            if (prenum == 5)
            {
                pu5 = currentpu;
                unit5stats.unit = pu5;
                unit5stats.updateUnit();
            }
            if (number == 1)
            {
                pu1 = Prepu;
                unit1stats.unit = pu1;
                unit1stats.updateUnit();
            }
            if (number == 2)
            {
                pu2 = Prepu;
                unit2stats.unit = pu2;
                unit2stats.updateUnit();
            }
            if (number == 3)
            {
                pu3 = Prepu;
                unit3stats.unit = pu3;
                unit3stats.updateUnit();
            }
            if (number == 4)
            {
                pu4 = Prepu;
                unit4stats.unit = pu4;
                unit4stats.updateUnit();
            }
            if (number == 5)
            {
                pu5 = Prepu;
                unit5stats.unit = pu5;
                unit5stats.updateUnit();
            }
        }
        isPlat = true;
        isSplat = false;
        yes = true;
    }

    IEnumerator delaycheck()
    {
        otherok = false;
        yield return new WaitForSeconds(timeBetween / 4);
        otherok = true;
        if (Eunit5stats.unit == " " && unit5stats.unit == " " || Eunit5stats.unit == "" && unit5stats.unit == " " || Eunit5stats.unit == " " && Eunit5stats.unit == "" || Eunit5stats.unit == "" && Eunit5stats.unit == "")
        {
            Tie();
        }
        else if (Eunit5stats.unit == " " || Eunit5stats.unit == "")
        {
            Win();
        }
        else if (unit5stats.unit == " " || unit5stats.unit == "")
        {
            Lose();
        }
        else
        {
            checkable = true;
        }
    }

    public void Tie()
    {
        round += 1;
        gold = 7;
        shop.SetActive(true);
        battle.SetActive(false);
        units.localScale = new Vector3(1, 1, 1);
        units.position -= new Vector3(-207f, -40f, 0f);
        pu1 = saveu1;
        pu2 = saveu2;
        pu3 = saveu3;
        pu4 = saveu4;
        pu5 = saveu5;
        unit1stats.unit = saveu1;
        unit2stats.unit = saveu2;
        unit3stats.unit = saveu3;
        unit4stats.unit = saveu4;
        unit5stats.unit = saveu5;
        unit1stats.updateUnit();
        unit2stats.updateUnit();
        unit3stats.updateUnit();
        unit4stats.updateUnit();
        unit5stats.updateUnit();
        unit1stats.heal();
        unit2stats.heal();
        unit3stats.heal();
        unit4stats.heal();
        unit5stats.heal();
        yesable = false;
        ok = false;
        checkable = true;
        state = battleState.SHOP;
        reroll();
    }

    public void Lose()
    {
        round += 1;
        lives -= 1;
        gold = 7;
        shop.SetActive(true);
        battle.SetActive(false);
        units.localScale = new Vector3(1, 1, 1);
        units.position -= new Vector3(-207f, -40f, 0f);
        pu1 = saveu1;
        pu2 = saveu2;
        pu3 = saveu3;
        pu4 = saveu4;
        pu5 = saveu5;
        unit1stats.unit = saveu1;
        unit2stats.unit = saveu2;
        unit3stats.unit = saveu3;
        unit4stats.unit = saveu4;
        unit5stats.unit = saveu5;
        unit1stats.updateUnit();
        unit2stats.updateUnit();
        unit3stats.updateUnit();
        unit4stats.updateUnit();
        unit5stats.updateUnit();
        unit1stats.heal();
        unit2stats.heal();
        unit3stats.heal();
        unit4stats.heal();
        unit5stats.heal();
        yesable = false;
        ok = false;
        checkable = true;
        state = battleState.SHOP;
        reroll();
    }

    public void Win()
    {
        round += 1;
        wins += 1;
        gold = 7;
        shop.SetActive(true);
        battle.SetActive(false);
        units.localScale = new Vector3(1, 1, 1);
        units.position -= new Vector3(-207f, -40f, 0f);
        pu1 = saveu1;
        pu2 = saveu2;
        pu3 = saveu3;
        pu4 = saveu4;
        pu5 = saveu5;
        unit1stats.unit = saveu1;
        unit2stats.unit = saveu2;
        unit3stats.unit = saveu3;
        unit4stats.unit = saveu4;
        unit5stats.unit = saveu5;
        unit1stats.updateUnit();
        unit2stats.updateUnit();
        unit3stats.updateUnit();
        unit4stats.updateUnit();
        unit5stats.updateUnit();
        unit1stats.heal();
        unit2stats.heal();
        unit3stats.heal();
        unit4stats.heal();
        unit5stats.heal();
        yesable = false;
        ok = false;
        checkable = true;
        state = battleState.SHOP;
        reroll();
    }

    void FixedUpdate()
    {
        Sunit1stats.unit = spu1;
        Sunit1stats.updateUnit();
        Sunit2stats.unit = spu2;
        Sunit2stats.updateUnit();
        Sunit3stats.unit = spu3;
        Sunit3stats.updateUnit();

        if (yes)
        {
            descript.SetActive(true);
        }
        else
        {
            descript.SetActive(false);
        }

        if (state == battleState.SHOP)
        {
            units.position = new Vector3(400, 190, 0);
        }

        if (state == battleState.PS && yesable == true)
        {
            StartCoroutine(support());
            yesable = false;
        }

        if (state == battleState.ES && yesable == true)
        {
            StartCoroutine(Esupport());
            yesable = false;
        }

        if (state == battleState.B && yesable == true)
        {
            StartCoroutine(brawl());
            yesable = false;
        }

        if (state == battleState.R && yesable == true)
        {
            StartCoroutine(ranged());
            yesable = false;
        }

        if (!yes)
        {
            sell.SetActive(false);
        }

        if (state != battleState.SHOP && state != battleState.ES && state != battleState.PS && checkable)
        {
            if (Eunit5stats.unit == " " && otherok || Eunit5stats.unit == "" && otherok || unit5stats.unit == " " && otherok || unit5stats.unit == "" && otherok)
            {
                if (Eunit4stats.unit == " " && otherok || Eunit4stats.unit == "" && otherok || unit4stats.unit == " " && otherok || unit4stats.unit == "" && otherok)
                {
                    if (Eunit3stats.unit == " " && otherok || Eunit3stats.unit == "" && otherok || unit3stats.unit == " " && otherok || unit3stats.unit == "" && otherok)
                    {
                        if (Eunit2stats.unit == " " && otherok || Eunit2stats.unit == "" && otherok || unit2stats.unit == " " && otherok || unit2stats.unit == "" && otherok)
                        {
                            if (Eunit1stats.unit == " " && otherok || Eunit1stats.unit == "" && otherok || unit1stats.unit == " " && otherok || unit1stats.unit == "" && otherok)
                            {
                                checkable = false;
                                StartCoroutine(delaycheck());
                            }
                        }
                    }
                }
            }
        }

        if (unit1stats.unit == " " || unit1stats.unit == "")
        {
            stats1.SetActive(false);
        }
        else
        {
            stats1.SetActive(true);
            HpText1.SetText(unit1stats.currentHp + " ");
            damageText1.SetText(unit1stats.damage + " ");
        }
        if (unit2stats.unit == " " || unit2stats.unit == "")
        {
            stats2.SetActive(false);
        }
        else
        {
            stats2.SetActive(true);
            HpText2.SetText(unit2stats.currentHp + " ");
            damageText2.SetText(unit2stats.damage + " ");
        }
        if (unit3stats.unit == " " || unit3stats.unit == "")
        {
            stats3.SetActive(false);
        }
        else
        {
            stats3.SetActive(true);
            HpText3.SetText(unit3stats.currentHp + " ");
            damageText3.SetText(unit3stats.damage + " ");
        }
        if (unit4stats.unit == " " || unit4stats.unit == "")
        {
            stats4.SetActive(false);
        }
        else
        {
            stats4.SetActive(true);
            HpText4.SetText(unit4stats.currentHp + " ");
            damageTex4.SetText(unit4stats.damage + " ");
        }
        if (unit5stats.unit == " " || unit5stats.unit == "")
        {
            stats5.SetActive(false);
        }
        else
        {
            stats5.SetActive(true);
            HpText5.SetText(unit5stats.currentHp + " ");
            damageText5.SetText(unit5stats.damage + " ");
        }

        if (spu1 == "shark")
        {
            Sunit1.sprite = shark;
        }
        if (spu2 == "shark")
        {
            Sunit2.sprite = shark;
        }
        if (spu3 == "shark")
        {
            Sunit3.sprite = shark;
        }
        if (pu1 == "shark")
        {
            Sunit4.sprite = shark;
        }
        if (pu2 == "shark")
        {
            Sunit5.sprite = shark;
        }
        if (pu3 == "shark")
        {
            Sunit6.sprite = shark;
        }
        if (pu4 == "shark")
        {
            Sunit7.sprite = shark;
        }
        if (pu5 == "shark")
        {
            Sunit8.sprite = shark;
        }
        if (spu1 == "dog")
        {
            Sunit1.sprite = dog;
        }
        if (spu2 == "dog")
        {
            Sunit2.sprite = dog;
        }
        if (spu3 == "dog")
        {
            Sunit3.sprite = dog;
        }
        if (pu1 == "dog")
        {
            Sunit4.sprite = dog;
        }
        if (pu2 == "dog")
        {
            Sunit5.sprite = dog;
        }
        if (pu3 == "dog")
        {
            Sunit6.sprite = dog;
        }
        if (pu4 == "dog")
        {
            Sunit7.sprite = dog;
        }
        if (pu5 == "dog")
        {
            Sunit8.sprite = dog;
        }
        if (spu1 == "dog")
        {
            Sunit1.sprite = dog;
        }
        if (spu2 == "dog")
        {
            Sunit2.sprite = dog;
        }
        if (spu3 == "dog")
        {
            Sunit3.sprite = dog;
        }
        if (pu1 == "dog")
        {
            Sunit4.sprite = dog;
        }
        if (pu2 == "dog")
        {
            Sunit5.sprite = dog;
        }
        if (pu3 == "dog")
        {
            Sunit6.sprite = dog;
        }
        if (pu4 == "dog")
        {
            Sunit7.sprite = dog;
        }
        if (pu5 == "dog")
        {
            Sunit8.sprite = dog;
        }
        if (spu1 == "sunfish")
        {
            Sunit1.sprite = sunfish;
        }
        if (spu2 == "sunfish")
        {
            Sunit2.sprite = sunfish;
        }
        if (spu3 == "sunfish")
        {
            Sunit3.sprite = sunfish;
        }
        if (pu1 == "sunfish")
        {
            Sunit4.sprite = sunfish;
        }
        if (pu2 == "sunfish")
        {
            Sunit5.sprite = sunfish;
        }
        if (pu3 == "sunfish")
        {
            Sunit6.sprite = sunfish;
        }
        if (pu4 == "sunfish")
        {
            Sunit7.sprite = sunfish;
        }
        if (pu5 == "sunfish")
        {
            Sunit8.sprite = sunfish;
        }
        if (spu1 == "sunfish")
        {
            Sunit1.sprite = sunfish;
        }
        if (spu2 == "sunfish")
        {
            Sunit2.sprite = sunfish;
        }
        if (spu3 == "sunfish")
        {
            Sunit3.sprite = sunfish;
        }
        if (pu1 == "sunfish")
        {
            Sunit4.sprite = sunfish;
        }
        if (pu2 == "sunfish")
        {
            Sunit5.sprite = sunfish;
        }
        if (pu3 == "sunfish")
        {
            Sunit6.sprite = sunfish;
        }
        if (pu4 == "sunfish")
        {
            Sunit7.sprite = sunfish;
        }
        if (pu5 == "sunfish")
        {
            Sunit8.sprite = sunfish;
        }
        if (spu1 == " ")
        {
            Sunit1.sprite = blank;
        }
        if (spu2 == " ")
        {
            Sunit2.sprite = blank;
        }
        if (spu3 == " ")
        {
            Sunit3.sprite = blank;
        }
        if (pu1 == " ")
        {
            Sunit4.sprite = blank;
        }
        if (pu2 == " ")
        {
            Sunit5.sprite = blank;
        }
        if (pu3 == " ")
        {
            Sunit6.sprite = blank;
        }
        if (pu4 == " ")
        {
            Sunit7.sprite = blank;
        }
        if (pu5 == " ")
        {
            Sunit8.sprite = blank;
        }
        if (spu1 == " ")
        {
            Sunit1.sprite = blank;
        }
        if (spu2 == " ")
        {
            Sunit2.sprite = blank;
        }
        if (spu3 == " ")
        {
            Sunit3.sprite = blank;
        }
        if (pu1 == " ")
        {
            Sunit4.sprite = blank;
        }
        if (pu2 == " ")
        {
            Sunit5.sprite = blank;
        }
        if (pu3 == " ")
        {
            Sunit6.sprite = blank;
        }
        if (pu4 == " ")
        {
            Sunit7.sprite = blank;
        }
        if (pu5 == " ")
        {
            Sunit8.sprite = blank;
        }
        if (spu1 == "cleaner")
        {
            Sunit1.sprite = cleaner;
        }
        if (spu2 == "cleaner")
        {
            Sunit2.sprite = cleaner;
        }
        if (spu3 == "cleaner")
        {
            Sunit3.sprite = cleaner;
        }
        if (pu1 == "cleaner")
        {
            Sunit4.sprite = cleaner;
        }
        if (pu2 == "cleaner")
        {
            Sunit5.sprite = cleaner;
        }
        if (pu3 == "cleaner")
        {
            Sunit6.sprite = cleaner;
        }
        if (pu4 == "cleaner")
        {
            Sunit7.sprite = cleaner;
        }
        if (pu5 == "cleaner")
        {
            Sunit8.sprite = cleaner;
        }
        if (spu1 == "puffer")
        {
            Sunit1.sprite = puffer;
        }
        if (spu2 == "puffer")
        {
            Sunit2.sprite = puffer;
        }
        if (spu3 == "puffer")
        {
            Sunit3.sprite = puffer;
        }
        if (pu1 == "puffer")
        {
            Sunit4.sprite = puffer;
        }
        if (pu2 == "puffer")
        {
            Sunit5.sprite = puffer;
        }
        if (pu3 == "puffer")
        {
            Sunit6.sprite = puffer;
        }
        if (pu4 == "puffer")
        {
            Sunit7.sprite = puffer;
        }
        if (pu5 == "puffer")
        {
            Sunit8.sprite = puffer;
        }
        if (spu1 == "cow")
        {
            Sunit1.sprite = cow;
        }
        if (spu2 == "cow")
        {
            Sunit2.sprite = cow;
        }
        if (spu3 == "cow")
        {
            Sunit3.sprite = cow;
        }
        if (pu1 == "cow")
        {
            Sunit4.sprite = cow;
        }
        if (pu2 == "cow")
        {
            Sunit5.sprite = cow;
        }
        if (pu3 == "cow")
        {
            Sunit6.sprite = cow;
        }
        if (pu4 == "cow")
        {
            Sunit7.sprite = cow;
        }
        if (pu5 == "cow")
        {
            Sunit8.sprite = cow;
        }
        if (spu1 == "elephant")
        {
            Sunit1.sprite = elephant;
        }
        if (spu2 == "elephant")
        {
            Sunit2.sprite = elephant;
        }
        if (spu3 == "elephant")
        {
            Sunit3.sprite = elephant;
        }
        if (pu1 == "elephant")
        {
            Sunit4.sprite = elephant;
        }
        if (pu2 == "elephant")
        {
            Sunit5.sprite = elephant;
        }
        if (pu3 == "elephant")
        {
            Sunit6.sprite = elephant;
        }
        if (pu4 == "elephant")
        {
            Sunit7.sprite = elephant;
        }
        if (pu5 == "elephant")
        {
            Sunit8.sprite = elephant;
        }
        if (spu1 == "skunk")
        {
            Sunit1.sprite = skunk;
        }
        if (spu2 == "skunk")
        {
            Sunit2.sprite = skunk;
        }
        if (spu3 == "skunk")
        {
            Sunit3.sprite = skunk;
        }
        if (pu1 == "skunk")
        {
            Sunit4.sprite = skunk;
        }
        if (pu2 == "skunk")
        {
            Sunit5.sprite = skunk;
        }
        if (pu3 == "skunk")
        {
            Sunit6.sprite = skunk;
        }
        if (pu4 == "skunk")
        {
            Sunit7.sprite = skunk;
        }
        if (pu5 == "skunk")
        {
            Sunit8.sprite = skunk;
        }
        if (spu1 == "eagle")
        {
            Sunit1.sprite = eagle;
        }
        if (spu2 == "eagle")
        {
            Sunit2.sprite = eagle;
        }
        if (spu3 == "eagle")
        {
            Sunit3.sprite = eagle;
        }
        if (pu1 == "eagle")
        {
            Sunit4.sprite = eagle;
        }
        if (pu2 == "eagle")
        {
            Sunit5.sprite = eagle;
        }
        if (pu3 == "eagle")
        {
            Sunit6.sprite = eagle;
        }
        if (pu4 == "eagle")
        {
            Sunit7.sprite = eagle;
        }
        if (pu5 == "eagle")
        {
            Sunit8.sprite = eagle;
        }
        if (spu1 == "swan")
        {
            Sunit1.sprite = swan;
        }
        if (spu2 == "swan")
        {
            Sunit2.sprite = swan;
        }
        if (spu3 == "swan")
        {
            Sunit3.sprite = swan;
        }
        if (pu1 == "swan")
        {
            Sunit4.sprite = swan;
        }
        if (pu2 == "swan")
        {
            Sunit5.sprite = swan;
        }
        if (pu3 == "swan")
        {
            Sunit6.sprite = swan;
        }
        if (pu4 == "swan")
        {
            Sunit7.sprite = swan;
        }
        if (pu5 == "swan")
        {
            Sunit8.sprite = swan;
        }
        if (spu1 == "vulture")
        {
            Sunit1.sprite = vulture;
        }
        if (spu2 == "vulture")
        {
            Sunit2.sprite = vulture;
        }
        if (spu3 == "vulture")
        {
            Sunit3.sprite = vulture;
        }
        if (pu1 == "vulture")
        {
            Sunit4.sprite = vulture;
        }
        if (pu2 == "vulture")
        {
            Sunit5.sprite = vulture;
        }
        if (pu3 == "vulture")
        {
            Sunit6.sprite = vulture;
        }
        if (pu4 == "vulture")
        {
            Sunit7.sprite = vulture;
        }
        if (pu5 == "vulture")
        {
            Sunit8.sprite = vulture;
        }
        if (spu1 == "penguin")
        {
            Sunit1.sprite = penguin;
        }
        if (spu2 == "penguin")
        {
            Sunit2.sprite = penguin;
        }
        if (spu3 == "penguin")
        {
            Sunit3.sprite = penguin;
        }
        if (pu1 == "penguin")
        {
            Sunit4.sprite = penguin;
        }
        if (pu2 == "penguin")
        {
            Sunit5.sprite = penguin;
        }
        if (pu3 == "penguin")
        {
            Sunit6.sprite = penguin;
        }
        if (pu4 == "penguin")
        {
            Sunit7.sprite = penguin;
        }
        if (pu5 == "penguin")
        {
            Sunit8.sprite = penguin;
        }
        if (Eunit1stats.unit == "shark")
        {
            ESunit4.sprite = shark;
        }
        if (Eunit2stats.unit == "shark")
        {
            ESunit5.sprite = shark;
        }
        if (Eunit3stats.unit == "shark")
        {
            ESunit6.sprite = shark;
        }
        if (Eunit4stats.unit == "shark")
        {
            ESunit7.sprite = shark;
        }
        if (Eunit5stats.unit == "shark")
        {
            ESunit8.sprite = shark;
        }
        if (Eunit1stats.unit == "dog")
        {
            ESunit4.sprite = dog;
        }
        if (Eunit2stats.unit == "dog")
        {
            ESunit5.sprite = dog;
        }
        if (Eunit3stats.unit == "dog")
        {
            ESunit6.sprite = dog;
        }
        if (Eunit4stats.unit == "dog")
        {
            ESunit7.sprite = dog;
        }
        if (Eunit5stats.unit == "dog")
        {
            ESunit8.sprite = dog;
        }
        if (Eunit1stats.unit == "sunfish")
        {
            ESunit4.sprite = sunfish;
        }
        if (Eunit2stats.unit == "sunfish")
        {
            ESunit5.sprite = sunfish;
        }
        if (Eunit3stats.unit == "sunfish")
        {
            ESunit6.sprite = sunfish;
        }
        if (Eunit4stats.unit == "sunfish")
        {
            ESunit7.sprite = sunfish;
        }
        if (Eunit5stats.unit == "sunfish")
        {
            ESunit8.sprite = sunfish;
        }
        if (Eunit1stats.unit == "cleaner")
        {
            ESunit4.sprite = cleaner;
        }
        if (Eunit2stats.unit == "cleaner")
        {
            ESunit5.sprite = cleaner;
        }
        if (Eunit3stats.unit == "cleaner")
        {
            ESunit6.sprite = cleaner;
        }
        if (Eunit4stats.unit == "cleaner")
        {
            ESunit7.sprite = cleaner;
        }
        if (Eunit5stats.unit == "cleaner")
        {
            ESunit8.sprite = cleaner;
        }
        if (Eunit1stats.unit == "puffer")
        {
            ESunit4.sprite = puffer;
        }
        if (Eunit2stats.unit == "puffer")
        {
            ESunit5.sprite = puffer;
        }
        if (Eunit3stats.unit == "puffer")
        {
            ESunit6.sprite = puffer;
        }
        if (Eunit4stats.unit == "puffer")
        {
            ESunit7.sprite = puffer;
        }
        if (Eunit5stats.unit == "puffer")
        {
            ESunit8.sprite = puffer;
        }
        if (Eunit1stats.unit == "cow")
        {
            ESunit4.sprite = cow;
        }
        if (Eunit2stats.unit == "cow")
        {
            ESunit5.sprite = cow;
        }
        if (Eunit3stats.unit == "cow")
        {
            ESunit6.sprite = cow;
        }
        if (Eunit4stats.unit == "cow")
        {
            ESunit7.sprite = cow;
        }
        if (Eunit5stats.unit == "cow")
        {
            ESunit8.sprite = cow;
        }
        if (Eunit1stats.unit == "elephant")
        {
            ESunit4.sprite = elephant;
        }
        if (Eunit2stats.unit == "elephant")
        {
            ESunit5.sprite = elephant;
        }
        if (Eunit3stats.unit == "elephant")
        {
            ESunit6.sprite = elephant;
        }
        if (Eunit4stats.unit == "elephant")
        {
            ESunit7.sprite = elephant;
        }
        if (Eunit5stats.unit == "elephant")
        {
            ESunit8.sprite = elephant;
        }
        if (Eunit1stats.unit == "skunk")
        {
            ESunit4.sprite = skunk;
        }
        if (Eunit2stats.unit == "skunk")
        {
            ESunit5.sprite = skunk;
        }
        if (Eunit3stats.unit == "skunk")
        {
            ESunit6.sprite = skunk;
        }
        if (Eunit4stats.unit == "skunk")
        {
            ESunit7.sprite = skunk;
        }
        if (Eunit5stats.unit == "skunk")
        {
            ESunit8.sprite = skunk;
        }
        if (Eunit1stats.unit == "eagle")
        {
            ESunit4.sprite = eagle;
        }
        if (Eunit2stats.unit == "eagle")
        {
            ESunit5.sprite = eagle;
        }
        if (Eunit3stats.unit == "eagle")
        {
            ESunit6.sprite = eagle;
        }
        if (Eunit4stats.unit == "eagle")
        {
            ESunit7.sprite = eagle;
        }
        if (Eunit5stats.unit == "eagle")
        {
            ESunit8.sprite = eagle;
        }
        if (Eunit1stats.unit == "swan")
        {
            ESunit4.sprite = swan;
        }
        if (Eunit2stats.unit == "swan")
        {
            ESunit5.sprite = swan;
        }
        if (Eunit3stats.unit == "swan")
        {
            ESunit6.sprite = swan;
        }
        if (Eunit4stats.unit == "swan")
        {
            ESunit7.sprite = swan;
        }
        if (Eunit5stats.unit == "swan")
        {
            ESunit8.sprite = swan;
        }
        if (Eunit1stats.unit == "vulture")
        {
            ESunit4.sprite = vulture;
        }
        if (Eunit2stats.unit == "vulture")
        {
            ESunit5.sprite = vulture;
        }
        if (Eunit3stats.unit == "vulture")
        {
            ESunit6.sprite = vulture;
        }
        if (Eunit4stats.unit == "vulture")
        {
            ESunit7.sprite = vulture;
        }
        if (Eunit5stats.unit == "vulture")
        {
            ESunit8.sprite = vulture;
        }
        if (Eunit1stats.unit == "penguin")
        {
            ESunit4.sprite = penguin;
        }
        if (Eunit2stats.unit == "penguin")
        {
            ESunit5.sprite = penguin;
        }
        if (Eunit3stats.unit == "penguin")
        {
            ESunit6.sprite = penguin;
        }
        if (Eunit4stats.unit == "penguin")
        {
            ESunit7.sprite = penguin;
        }
        if (Eunit5stats.unit == "penguin")
        {
            ESunit8.sprite = penguin;
        }
        if (Eunit1stats.unit == " " || Eunit1stats.unit == "")
        {
            ESunit4.sprite = blank;
        }
        if (Eunit2stats.unit == " " || Eunit2stats.unit == "")
        {
            ESunit5.sprite = blank;
        }
        if (Eunit3stats.unit == " " || Eunit3stats.unit == "")
        {
            ESunit6.sprite = blank;
        }
        if (Eunit4stats.unit == " " || Eunit4stats.unit == "")
        {
            ESunit7.sprite = blank;
        }
        if (Eunit5stats.unit == " " || Eunit5stats.unit == "")
        {
            ESunit8.sprite = blank;
        }
        if (state != battleState.SHOP)
        {
            pu1 = unit1stats.unit;
            pu2 = unit2stats.unit;
            pu3 = unit3stats.unit;
            pu4 = unit4stats.unit;
            pu5 = unit5stats.unit;
        }
    }

    void Update()
    {

        Time.timeScale = timescale;

        goldText.SetText(gold + " ");

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(delay());
        }

    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(0.1f);
        if (yesyes)
        {
            yes = false;
        }
        yesyes = true;
    }
}
