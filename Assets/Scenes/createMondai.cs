using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class createMondai : MonoBehaviour
{
    [SerializeField] string assetPath = "Prefabs";
    List<GameObject> mondaiList;
    //科目名入力
    InputField inputField;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Search()
    {

    }
    //Prefabを生成、上書き、Variantを作る処理
    public void createOrSave()
    {
        UnityEditor.PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, assetPath, InteractionMode.AutomatedAction);
    }
    //Prefabを編集して上書き保存する処理
}
