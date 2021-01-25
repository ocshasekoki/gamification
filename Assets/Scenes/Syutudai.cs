using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Syutudai : MonoBehaviour
{
    private Mondai m;
    [SerializeField]GameObject[] bottons;
    [SerializeField] Text mondaiText;
    [SerializeField] Text answerText;
    [SerializeField] GameObject mondai;
    [SerializeField] GameObject InputFieldArea;
    [SerializeField] GameObject ansButton;
    private InputField inputField;
    GameObject[] mondaiList;
    private int count;

    private void Start()
    {
        inputField = InputFieldArea.GetComponent<InputField>();
        InputFieldArea.SetActive(false);
        ansButton.SetActive(false);
        foreach (GameObject b in bottons)
        {
            b.SetActive(false);
            Debug.Log(b.name);
        }
        InputFieldArea.SetActive(false);
        count = 0;
        mondaiList = new GameObject[mondai.transform.childCount];
        for (int i = 0; i < mondai.transform.childCount; i++)
        {
            mondaiList[i] = mondai.transform.GetChild(i).gameObject;
        }
        m = mondaiList[count].GetComponent<Mondai>();
        Set();
    }
    public void Set()
    {
        mondaiText.text = m.MondaiText;
        switch (m.genre)
        {
            case Genre.SELECT:
                SetButton();
                break;
            case Genre.NUMBER:
                SetInputField();
                inputField.contentType = InputField.ContentType.DecimalNumber;
                break;
            case Genre.STRING:
                SetInputField();
                inputField.contentType = InputField.ContentType.Standard;
                break;
        }

    }
    /**/
    public void BackQuestion()
    {
        if (count - 1 >= 0)
        {
            count--;
            m = mondaiList[count].GetComponent<Mondai>();
            Set();
        }
        else
        {
            Debug.Log("まえのもんだいはありません");
        }
    }
    public void nextQuestion()
    {
        if(count + 1 < mondaiList.Length){
            count++;
            m = mondaiList[count].GetComponent<Mondai>();
            Set();
        }
        else
        {
            Debug.Log("つぎのもんだいはありません");
        }
    }

    /**
     * 
     *   ボタンで答える場合、
     *   ボタンをランダムに配置する 
     * 
     */
    void SetButton()
    {
        //ボタン可視化

        foreach (GameObject b in bottons)
        {
            b.SetActive(true);
        }
        ansButton.SetActive(false);
        InputFieldArea.SetActive(false);
        //リスト初期化
        List<int> numbers = new List<int>();
        //ボタンの数だけ数値を用意({0,1,2,3})
        for(int i = 0; i < m.b; i++)
        {
            numbers.Add(i);
        }
        int btncount = 0;
        while (numbers.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, numbers.Count);
            int ransu = numbers[index];
            bottons[btncount].gameObject.transform.Find("Text").GetComponent<Text>().text = m.t[ransu];
            btncount++;
            numbers.RemoveAt(index);
        }
    }
    /*
     
         入力形式で答える場合
         
         */

    void SetInputField()
    {
       　foreach(GameObject b in bottons)
         {
            b.SetActive(false);
         }
         ansButton.SetActive(true);
         InputFieldArea.SetActive (true);
    }

    /*
     
        ボタンの場合の答え合わせ 

    */
    public void Answer(string ans)
    {
       if(ans == m.answer)
        {
            Debug.Log("正解");
            nextQuestion();
            Set();
        }
        else
        {
            Debug.Log("不正解");
            if (m.genre == Genre.SELECT)
            {
                SetButton();
            }
        }
    }
    /*
     
         入力での答え合わせ
         
         */
    public void AnsButton()
    {
        Answer(inputField.text);
    }
}
