using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    public GameObject askToBuild, askForFreeBuilding;

    public Game game;

    public GameObject buildBtn1, buildBtn2, buildBtn3, buildBtn4, buildBtn5, buildBtn6, buildBtn7;

    public GameObject buildFreeBtn1, buildFreeBtn2, buildFreeBtn3, buildFreeBtn4, buildFreeBtn5, buildFreeBtn6, buildFreeBtn7;

    public GameObject building1, building2, building3, building4, building5, building6, building7, building8, building9, building10, building11, building12, building13, building14, building15, building16, building17, building18, building19, building20, building21, building22, building23, building24, building25, building26, building27, building28;

    public Player_Information_panel_logic inf;

    public RegionList regL;

    public ViewPanelLogic viewUI;

    public bool reg1, reg2, reg3, reg4, reg5, reg6, reg7;

    // Start is called before the first frame update
    void Start()
    {
        askToBuild = GameObject.Find("Choosing-Building-Panel");

        askForFreeBuilding = GameObject.Find("Choosing-Free-Building-Panel");

        buildBtn1 = GameObject.Find("Canvas-build1");

        buildBtn2 = GameObject.Find("Canvas-build2");

        buildBtn3 = GameObject.Find("Canvas-build3");

        buildBtn4 = GameObject.Find("Canvas-build4");

        buildBtn5 = GameObject.Find("Canvas-build5");

        buildBtn6 = GameObject.Find("Canvas-build6");

        buildBtn7 = GameObject.Find("Canvas-build7");

        buildFreeBtn1 = GameObject.Find("Canvas-buildFree1");

        buildFreeBtn2 = GameObject.Find("Canvas-buildFree2");

        buildFreeBtn3 = GameObject.Find("Canvas-buildFree3");

        buildFreeBtn4 = GameObject.Find("Canvas-buildFree4");

        buildFreeBtn5 = GameObject.Find("Canvas-buildFree5");

        buildFreeBtn6 = GameObject.Find("Canvas-buildFree6");

        buildFreeBtn7 = GameObject.Find("Canvas-buildFree7");

        building1 = GameObject.Find("Building1");

        building2 = GameObject.Find("Building2");

        building3 = GameObject.Find("Building3");

        building4 = GameObject.Find("Building4");

        building5 = GameObject.Find("Building5");

        building6 = GameObject.Find("Building6");

        building7 = GameObject.Find("Building7");

        building8 = GameObject.Find("Building8");

        building9 = GameObject.Find("Building9");

        building10 = GameObject.Find("Building10");

        building11 = GameObject.Find("Building11");

        building12 = GameObject.Find("Building12");

        building13 = GameObject.Find("Building13");

        building14 = GameObject.Find("Building14");

        building15 = GameObject.Find("Building15");

        building16 = GameObject.Find("Building16");

        building17 = GameObject.Find("Building17");

        building18 = GameObject.Find("Building18");

        building19 = GameObject.Find("Building19");

        building20 = GameObject.Find("Building20");

        building21 = GameObject.Find("Building21");

        building22 = GameObject.Find("Building22");

        building23 = GameObject.Find("Building23");

        building24 = GameObject.Find("Building24");

        building25 = GameObject.Find("Building25");

        building26 = GameObject.Find("Building26");

        building27 = GameObject.Find("Building27");

        building28 = GameObject.Find("Building28");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NoBTN()
    {
        Deactivate();
        game.dicePanel.btnD6.SetActive(true);
    }

    public void NoFreeBTN()
    {
        DeactivateFree();
        game.dicePanel.btnD6.SetActive(true);
    }

    public void YesBTN()
    {
        Deactivate();
        for (int i = 0; i < inf.regionsOwned.Count; i++) {
            for (int j = 0; j < regL.regionsIOwn.Count; j++) {
                if (inf.regionsOwned[i] == regL.regionsIOwn[j].regNumber)
                {
                    if (regL.regionsIOwn[j].buildingsOwned < 4)
                    {
                        if (regL.regionsIOwn[j].regNumber == 1) {
                            buildBtn1.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 2)
                        {
                            buildBtn2.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 3)
                        {
                            buildBtn3.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 4)
                        {
                            buildBtn4.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 5)
                        {
                            buildBtn5.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 6)
                        {
                            buildBtn6.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 7)
                        {
                            buildBtn7.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    public void YesFreeBTN()
    {
        DeactivateFree();
        for (int i = 0; i < inf.regionsOwned.Count; i++)
        {
            for (int j = 0; j < regL.regionsIOwn.Count; j++)
            {
                if (inf.regionsOwned[i] == regL.regionsIOwn[j].regNumber)
                {
                    if (regL.regionsIOwn[j].buildingsOwned < 4)
                    {
                        if (regL.regionsIOwn[j].regNumber == 1)
                        {
                            buildFreeBtn1.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 2)
                        {
                            buildFreeBtn2.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 3)
                        {
                            buildFreeBtn3.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 4)
                        {
                            buildFreeBtn4.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 5)
                        {
                            buildFreeBtn5.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 6)
                        {
                            buildFreeBtn6.SetActive(true);
                        }
                        if (regL.regionsIOwn[j].regNumber == 7)
                        {
                            buildFreeBtn7.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    public void Deactivate()
    {
        askToBuild.SetActive(false);
    }

    public void DeactivateFree()
    {
        askForFreeBuilding.SetActive(false);
    }

    public void DeactivateBuildingBtn()
    {
        buildBtn1.SetActive(false);
        buildBtn2.SetActive(false);
        buildBtn3.SetActive(false);
        buildBtn4.SetActive(false);
        buildBtn5.SetActive(false);
        buildBtn6.SetActive(false);
        buildBtn7.SetActive(false);
    }

    public void DeactivateFreeBuildingBtn()
    {
        buildFreeBtn1.SetActive(false);
        buildFreeBtn2.SetActive(false);
        buildFreeBtn3.SetActive(false);
        buildFreeBtn4.SetActive(false);
        buildFreeBtn5.SetActive(false);
        buildFreeBtn6.SetActive(false);
        buildFreeBtn7.SetActive(false);
    }

    public void BuildReg1()
    {
        reg1 = true;
        for (int i = 0; i < regL.regionsIOwn.Count; i++) {
            if (regL.regionsIOwn[i].regNumber == 1)
            {
                viewUI.btnBuild.SetActive(true);
                DeactivateBuildingBtn();
            }
        }
    }

    public void BuildReg2()
    {
        reg2 = true;
        BuildRegX(2);
    }

    public void BuildReg3()
    {
        reg3 = true;
        BuildRegX(3);
    }

    public void BuildReg4()
    {
        reg4 = true;
        BuildRegX(4);
    }

    public void BuildReg5()
    {
        reg5 = true;
        BuildRegX(5);
    }

    public void BuildReg6()
    {
        reg6 = true;
        BuildRegX(6);
    }

    public void BuildReg7()
    {
        reg7 = true;
        BuildRegX(7);
    }

    void BuildRegX(int reg)
    {
                viewUI.btnBuild.SetActive(true);
                DeactivateBuildingBtn();
    }

    public void BuildFree1() {
        for (int i = 0; i < regL.regionsIOwn.Count; i++)
        {
            if (regL.regionsIOwn[i].regNumber == 1)
            {
                DeactivateFreeBuildingBtn();
                if (regL.regionsIOwn[0].buildingsOwned == 0)
                {
                    regL.regionsIOwn[0].buildingsOwned += 1;
                    building1.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[0].buildingsOwned == 1)
                {
                    regL.regionsIOwn[0].buildingsOwned += 1;
                    building2.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[0].buildingsOwned == 2)
                {
                    regL.regionsIOwn[0].buildingsOwned += 1;
                    building3.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[0].buildingsOwned == 3)
                {
                    regL.regionsIOwn[0].buildingsOwned += 1;
                    building4.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }

            }
        }
    }

    public void BuildFree2()
    {
        for (int i = 0; i < regL.regionsIOwn.Count; i++)
        {
            if (regL.regionsIOwn[i].regNumber == 1)
            {
                DeactivateFreeBuildingBtn();
                if (regL.regionsIOwn[1].buildingsOwned == 0)
                {
                    regL.regionsIOwn[1].buildingsOwned += 1;
                    building5.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[1].buildingsOwned == 1)
                {
                    regL.regionsIOwn[1].buildingsOwned += 1;
                    building6.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[1].buildingsOwned == 2)
                {
                    regL.regionsIOwn[1].buildingsOwned += 1;
                    building7.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[1].buildingsOwned == 3)
                {
                    regL.regionsIOwn[1].buildingsOwned += 1;
                    building8.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }

            }
        }
    }
    public void BuildFree3()
    {
        for (int i = 0; i < regL.regionsIOwn.Count; i++)
        {
            if (regL.regionsIOwn[i].regNumber == 1)
            {
                DeactivateFreeBuildingBtn();
                if (regL.regionsIOwn[2].buildingsOwned == 0)
                {
                    regL.regionsIOwn[2].buildingsOwned += 1;
                    building9.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[2].buildingsOwned == 1)
                {
                    regL.regionsIOwn[2].buildingsOwned += 1;
                    building10.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[2].buildingsOwned == 2)
                {
                    regL.regionsIOwn[2].buildingsOwned += 1;
                    building11.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[2].buildingsOwned == 3)
                {
                    regL.regionsIOwn[2].buildingsOwned += 1;
                    building12.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }

            }
        }
    }
    public void BuildFree4()
    {
        for (int i = 0; i < regL.regionsIOwn.Count; i++)
        {
            if (regL.regionsIOwn[i].regNumber == 1)
            {
                DeactivateFreeBuildingBtn();
                if (regL.regionsIOwn[3].buildingsOwned == 0)
                {
                    regL.regionsIOwn[3].buildingsOwned += 1;
                    building13.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[3].buildingsOwned == 1)
                {
                    regL.regionsIOwn[3].buildingsOwned += 1;
                    building14.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[3].buildingsOwned == 2)
                {
                    regL.regionsIOwn[3].buildingsOwned += 1;
                    building15.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[3].buildingsOwned == 3)
                {
                    regL.regionsIOwn[3].buildingsOwned += 1;
                    building16.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }

            }
        }
    }
    public void BuildFree5()
    {
        for (int i = 0; i < regL.regionsIOwn.Count; i++)
        {
            if (regL.regionsIOwn[i].regNumber == 1)
            {
                DeactivateFreeBuildingBtn();
                if (regL.regionsIOwn[4].buildingsOwned == 0)
                {
                    regL.regionsIOwn[4].buildingsOwned += 1;
                    building17.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[4].buildingsOwned == 1)
                {
                    regL.regionsIOwn[4].buildingsOwned += 1;
                    building18.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[4].buildingsOwned == 2)
                {
                    regL.regionsIOwn[4].buildingsOwned += 1;
                    building19.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[4].buildingsOwned == 3)
                {
                    regL.regionsIOwn[4].buildingsOwned += 1;
                    building20.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }

            }
        }
    }
    public void BuildFree6()
    {
        for (int i = 0; i < regL.regionsIOwn.Count; i++)
        {
            if (regL.regionsIOwn[i].regNumber == 1)
            {
                DeactivateFreeBuildingBtn();
                if (regL.regionsIOwn[5].buildingsOwned == 0)
                {
                    regL.regionsIOwn[5].buildingsOwned += 1;
                    building21.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[5].buildingsOwned == 1)
                {
                    regL.regionsIOwn[5].buildingsOwned += 1;
                    building22.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[5].buildingsOwned == 2)
                {
                    regL.regionsIOwn[5].buildingsOwned += 1;
                    building23.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[5].buildingsOwned == 3)
                {
                    regL.regionsIOwn[5].buildingsOwned += 1;
                    building24.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }

            }
        }
    }
    public void BuildFree7()
    {
        for (int i = 0; i < regL.regionsIOwn.Count; i++)
        {
            if (regL.regionsIOwn[i].regNumber == 1)
            {
                DeactivateFreeBuildingBtn();
                if (regL.regionsIOwn[6].buildingsOwned == 0)
                {
                    regL.regionsIOwn[6].buildingsOwned += 1;
                    building25.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[6].buildingsOwned == 1)
                {
                    regL.regionsIOwn[6].buildingsOwned += 1;
                    building26.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[6].buildingsOwned == 2)
                {
                    regL.regionsIOwn[6].buildingsOwned += 1;
                    building27.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }
                else if (regL.regionsIOwn[6].buildingsOwned == 3)
                {
                    regL.regionsIOwn[6].buildingsOwned += 1;
                    building28.SetActive(true);
                    viewUI.btnD6.SetActive(true);
                }

            }
        }
    }

}
