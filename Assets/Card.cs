using System;
using System.Collections;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] float speed;
    Sprite upSprite;
    Sprite downSprite;

    public void Set(Sprite downSprite, Sprite upSprite)
    {
        this.upSprite = upSprite;
        this.downSprite = downSprite;
    }
    public bool Check(Card a, Card b)
    {
        if(a == null || b == null) { return false; }
        return a.downSprite == b.downSprite;
    }
    public IEnumerator View()
    {
        float angle = -90f;

        int dir;

        Sprite sprite;
        if (transform.rotation.eulerAngles.y > 0f) { dir = 0; sprite = upSprite; }
        else { dir = 2; sprite = downSprite; }

        while (transform.rotation != Quaternion.Euler(0f, angle, 0f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, angle, 0f), speed);
            yield return new WaitForFixedUpdate();
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;

        while (transform.rotation != Quaternion.Euler(0f, angle * dir, 0f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, angle * dir, 0f), speed);
            yield return new WaitForFixedUpdate();
        }
        transform.rotation = Quaternion.Euler(0f, angle * dir, 0f);

        yield break;
    }
}
