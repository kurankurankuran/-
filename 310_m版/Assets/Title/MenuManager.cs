using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    GameObject menuObj;

    GameObject optionArrowRObj;
    GameObject optionArrowLObj;
    GameObject option;


    private bool bMenu;

    // Start is called before the first frame update
    void Start()
    {
        menuObj = GameObject.Find("MenuManager");

        optionArrowRObj = GameObject.Find("Option_arrowR");
        optionArrowLObj = GameObject.Find("Option_arrowL");
        option = GameObject.Find("Option");

        optionArrowRObj.SetActive(false);
        optionArrowLObj.SetActive(false);
        option.SetActive(false);

        bMenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(bMenu)
        {

            menuObj.GetComponent<TitleMenu>().TitleControll();
        }
        else
        {
            menuObj.GetComponent<OptionMenu>().OptionControll();
        }
    }

    public void SwitchMenu()
    {
        if(bMenu)
        {
            bMenu = false;
        }
        else
        {
            bMenu = true;
        }
    }
}
