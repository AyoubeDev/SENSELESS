using UnityEngine;

public class FrameLoader : MonoBehaviour
{
    public Sprite[] Frames;

    void Awake()
    {
        Frames = Resources.LoadAll<Sprite>("AnimFrames");
        System.Array.Sort(Frames, (a, b) => a.name.CompareTo(b.name));
    }
}