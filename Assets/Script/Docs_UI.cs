using UnityEngine;

public class Docs_UI : MonoBehaviour
{
    [Header("Assign Pages in Order")]
    [SerializeField] Transform[] pages;
    [SerializeField] Transform BG;

    int currentPage = 0;

    void Start()
    {
       // ShowPage(0);
    }

    public void NextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            currentPage++;
          
            ShowPage(currentPage);
        }
        else
        {
         //   Debug.Log("Already on last page");
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowPage(currentPage);
        
        }
        else
        {
          //  Debug.Log("Already on first page");
        }
    }

    void ShowPage(int index)
    {

        for (int i = 0; i < pages.Length; i++)
            pages[i].gameObject.SetActive(i == index);
    }

    public void ShowDocs()
    {
        BG.gameObject.SetActive(true);
        ShowPage(currentPage);
    }
    public void HideDocs()
    {
        BG.gameObject.SetActive(false);
        currentPage = 0;
    }
}
