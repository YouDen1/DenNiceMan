using UnityEngine;

public class Load : MonoBehaviour
{
    public void Telegram()
    {
        Application.OpenURL("https://t.me/you_den");
    }
    public void Twitch()
    {
        Application.OpenURL("https://www.twitch.tv/you_den");
    }

    public void Donate()
    {
        Application.OpenURL("https://www.donationalerts.com/r/you_den");
    }

    public void YouTube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCwNaHvSYORpj8DG7qyX9JuQ");
    }
}
