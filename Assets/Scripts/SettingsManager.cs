using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Button[] onePointButtons;
    [SerializeField] Button[] twoPointButtons;
    [SerializeField] Button[] fivePointButtons;

    // Start is called before the first frame update
    void Start()
    {
        SelectOnePointColor();
        SelectTwoPointColor();
        SelectFivePointColor();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void SelectOnePointColor()
    {
        bool buttonFound = false;
        int index = 0;

        while (!buttonFound && index < onePointButtons.Length)
        {
            if (onePointButtons[index].colors.normalColor == GameData.Instance.BrickColors[0])
            {
                buttonFound = true;
                onePointButtons[index].interactable = false;
                onePointButtons[index].transform.GetChild(0).gameObject.SetActive(true);
            }

            index++;
        }
    }

    private void SelectTwoPointColor()
    {
        bool buttonFound = false;
        int index = 0;

        Debug.Log(twoPointButtons.Length);

        while (!buttonFound && index < twoPointButtons.Length)
        {
            if (twoPointButtons[index].colors.normalColor == GameData.Instance.BrickColors[1])
            {
                buttonFound = true;
                twoPointButtons[index].interactable = false;
                twoPointButtons[index].transform.GetChild(0).gameObject.SetActive(true);
            }

            index++;
        }
    }

    private void SelectFivePointColor()
    {
        bool buttonFound = false;
        int index = 0;

        while (!buttonFound && index < fivePointButtons.Length)
        {
            if (fivePointButtons[index].colors.normalColor == GameData.Instance.BrickColors[2])
            {
                buttonFound = true;
                fivePointButtons[index].interactable = false;
                fivePointButtons[index].transform.GetChild(0).gameObject.SetActive(true);
            }

            index++;
        }
    }

    public void OnePointColorChange(int index)
    {
        for(int i = 0; i < onePointButtons.Length; i++)
        {
            if(i == index)
            {
                onePointButtons[i].interactable = false;
                onePointButtons[i].transform.GetChild(0).gameObject.SetActive(true);
                GameData.Instance.BrickColors[0] = onePointButtons[i].colors.normalColor;
            }
            else
            {
                onePointButtons[i].interactable = true;
                onePointButtons[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    public void TwoPointColorChange(int index)
    {
        for (int i = 0; i < twoPointButtons.Length; i++)
        {
            if (i == index)
            {
                twoPointButtons[i].interactable = false;
                twoPointButtons[i].transform.GetChild(0).gameObject.SetActive(true);
                GameData.Instance.BrickColors[1] = twoPointButtons[i].colors.normalColor;
            }
            else
            {
                twoPointButtons[i].interactable = true;
                twoPointButtons[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    public void FivePointColorChange(int index)
    {
        for (int i = 0; i < fivePointButtons.Length; i++)
        {
            if (i == index)
            {
                fivePointButtons[i].interactable = false;
                fivePointButtons[i].transform.GetChild(0).gameObject.SetActive(true);
                GameData.Instance.BrickColors[2] = fivePointButtons[i].colors.normalColor;
            }
            else
            {
                fivePointButtons[i].interactable = true;
                fivePointButtons[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
