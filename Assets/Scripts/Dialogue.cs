[System.Serializable]
public struct Dialogue
{
    public string speaker;
    public string text;
    [UnityEngine.Min(0.1f)]
    public float charactersPerSecond;
}
