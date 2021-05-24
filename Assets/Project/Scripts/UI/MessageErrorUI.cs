using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MessageErrorUI : MonoBehaviour
{
    [SerializeField] private Button close_button;
    [SerializeField] private TextMeshProUGUI title_text;
    [SerializeField] private TextMeshProUGUI message_text;

    public void Create(string title, string msg)
    {
        title_text.text = title;
        message_text.text = msg.Replace("\"", "");
        close_button.onClick.AddListener(() => Close());
    }
    public void Close()
    {
        Destroy(this.gameObject);
    }
}
