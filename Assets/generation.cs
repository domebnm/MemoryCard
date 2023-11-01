using System;
using System.Collections.Generic;
using UnityEngine;
public class generation : MonoBehaviour, Counter
{
    [SerializeField] GameObject generationObj;

    Sprite UpSprite;
    [SerializeField] List<Sprite> downSprite;

    public int amountX;
    [Serializable] struct Offset {  public int x; public int y; }
    [SerializeField] Offset offset;

    void Start()
    {
        UpSprite = generationObj.GetComponent<SpriteRenderer>().sprite;
        Counter.counter = downSprite.Count;
        Generation();
    }
    void Generation()
    {
        downSprite.AddRange(downSprite);

        for (int i = 0; i < downSprite.Count; i++)
        {
            int index = UnityEngine.Random.Range(0, (downSprite.Count - 1));

            Sprite item = downSprite[index];
            downSprite[index] = downSprite[i];
            downSprite[i] = item;
        }

        int amountY = MyRound((float)downSprite.Count / amountX + .5f);
        Debug.Log((float)downSprite.Count / amountX + .5f);
        Vector3 pos = transform.position;

        int m = 0;
        for (int i = 0; i < amountY; i++)
        {
            if (i == (amountY - 1) && downSprite.Count % amountX != 0) { amountX = downSprite.Count % amountX; }

            for (int j = 0; j < amountX; j++)
            {
                GameObject card = Instantiate(generationObj, pos, transform.rotation);
                card.GetComponent<Card>().Set(downSprite[m++], UpSprite);
                pos += new Vector3(offset.x, 0, 0);
            }
            pos += new Vector3(-offset.x * amountX, -offset.y, 0);
        }
    }
    int MyRound(float a)
    {
        if(a - (int)a > 0.5f) { a += 1; }

        return (int)a;
    }
}
