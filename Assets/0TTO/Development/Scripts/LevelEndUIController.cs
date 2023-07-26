using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelEndUIController : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static LevelEndUIController _instance;
    public static LevelEndUIController Instance { get { return _instance; } }
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            //Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        Application.targetFrameRate = 60;

    }

    #endregion
    public GameObject FinalCanvasParentObj;
    public  float number;
    public TextMeshProUGUI finalText;
    public List<FinalCollider> finalColList;
    void Start()
    {
        
        for (int i = 0; i < 250; i++)
        {
            GameObject item = Instantiate(FinalCanvasParentObj);
            item.transform.SetParent (transform);
            item.transform.localPosition = new Vector3(50.7f, -12f, (i * 47f) + 1358f);
            number =i+ Random.Range(0, 250);
            item.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = (number) + "X" + "";
            finalColList[i].value = number;

            GameObject obj = Instantiate(item);
            obj.transform.SetParent(transform);
            obj.transform.localPosition = new Vector3(-54.3f, -12f, (i * 47f) + 1358f);

            //finalText.text = FinalCollider.Instance.value .ToString();
            //FinalCollider.Instance.value = number;
        }
    }
}
