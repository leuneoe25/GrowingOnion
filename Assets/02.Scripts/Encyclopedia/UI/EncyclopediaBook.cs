using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class EncyclopediaBook : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject EncyclopediaPagePrefab;

    [SerializeField] private Button LeftChangePageButton;
    [SerializeField] private Button RightChangePageButton;

    private int NowPage;
    List<Onion> onions;
    private void Start()
    {
        NowPage = 1;
        onions = new List<Onion>();

        LeftChangePageButton.onClick.AddListener(GoLeftPage);
        RightChangePageButton.onClick.AddListener(GoRightPage);

        var ds = new DataService("Onions.db");
        var o = ds.GetOnions();
        foreach (var item in o)
        {
            onions.Add(item);
        }

        InitPage(1);
    }

    public void GoLeftPage()
    {
        if (NowPage == 1)
            return;

        NowPage -= 1;
        InitPage(NowPage);
        ChagePage(Vector2.left);
    }
    public void GoRightPage()
    {
        if (NowPage == 7)
            return;

        NowPage += 1;
        InitPage(NowPage);
        ChagePage(Vector2.right);
    }
    private void InitPage(int index)
    {
        if(transform.childCount < index)
        {
            GameObject page =Instantiate(EncyclopediaPagePrefab, transform);

            EncyclopediaPageRange pageRange = new EncyclopediaPageRange((index - 1) * 9, ((index - 1) * 9) + 8);
            if (pageRange.end > 59)
                pageRange.end = 59;

            page.GetComponent<EncyclopediaPage>().InitContents(gameData.EncyclopediaOnion, onions, pageRange);
        }
    }
    private void ChagePage(Vector2 dir)
    {
        if (dir == Vector2.right)
            gameObject.GetComponent<RectTransform>().anchoredPosition = 
                new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x- 238, 0, 0);
        else if (dir == Vector2.left)
            gameObject.GetComponent<RectTransform>().anchoredPosition =
                new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x + 238, 0, 0);
    }
}
