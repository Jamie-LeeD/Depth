[System.Serializable]
public class Dialogue
{
    [System.Serializable]
    public enum Type
    {
        Speaking,
        Action
    }

    public string title;
    public Type type;
    public UnityEngine.Sprite backgroundImage;
    public string speaker;
    public UnityEngine.Sprite speakerImage;
    public System.Collections.Generic.List<string> tags = new System.Collections.Generic.List<string>();
    [UnityEngine.TextArea]
    public string text;
    [UnityEngine.Min(1f)]
    public float charactersPerSecond;
    [UnityEngine.Min(1f)]
    public float fontSize;
}
