using System.Collections;
using UnityEngine;

public class Cursor : MonoBehaviour, Counter
{
    Card temp;
    IEnumerator enumerator;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                if (enumerator == null) {
                    Card card = hit.collider.GetComponent<Card>();
                    if (card != temp)
                    {
                        enumerator = Check(hit.collider, card);
                        StartCoroutine(enumerator);
                    }
                }
            }
        }
    }
    IEnumerator Check(Collider2D collider, Card card)
    {
        yield return card.View();
        
        if (temp == null) { temp = card; }
        else
        {
            if (card.Check(temp, card))
            {
                temp.gameObject.SetActive(false);
                card.gameObject.SetActive(false);
                Counter.AddCounter();
            }
            else
            {
                StartCoroutine(temp.View());
                yield return card.View();
            }
            temp = null;
        }
        enumerator = null;
        yield break;
    }
}
