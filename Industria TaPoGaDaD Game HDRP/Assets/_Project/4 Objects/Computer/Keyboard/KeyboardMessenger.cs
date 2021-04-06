using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardMessenger : MonoBehaviour
{
    private static KeyboardMessenger _instance;
    public static KeyboardMessenger Instance { get { return _instance; } }
    [SerializeField] private TextMeshProUGUI Message;
    [SerializeField] private Image MessagePanel;
    [SerializeField] [Range(0,1)] private float backgroundTransparency;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private IEnumerator Start() {
        while (Message.color.a <= 1) {
            Message.color = new Color(Message.color.r,Message.color.g,Message.color.b,Message.color.a+.05f);
            MessagePanel.color = new Color(MessagePanel.color.r,MessagePanel.color.g,MessagePanel.color.b,MessagePanel.color.a+.05f * backgroundTransparency);
            yield return new WaitForSeconds(.03f);
        }
        yield return new WaitForSeconds(2);
        while (Message.color.a >= 0) {
            Message.color = new Color(Message.color.r,Message.color.g,Message.color.b,Message.color.a-.05f);
            MessagePanel.color = new Color(MessagePanel.color.r,MessagePanel.color.g,MessagePanel.color.b,MessagePanel.color.a-.05f * backgroundTransparency);
            yield return new WaitForSeconds(.03f);
        }
        Destroy(this.gameObject);
    }

    // private IEnumerator fadeInOut() {

    // }

    
}

