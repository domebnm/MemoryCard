using UnityEngine;
interface Counter
{
    public static int counter;
    static int nowCounter = 0;

    public static void AddCounter()
    {
        nowCounter++;
        if (counter == nowCounter) { Debug.Log("end game"); }
    }
}
