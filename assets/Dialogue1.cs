using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue1 : MonoBehaviour
{
    [Tooltip("TextMeshProUGUI component that will display dialogue.")]
    public TextMeshProUGUI textComponent;

    [Tooltip("Lines of dialogue to display.")]
    public string[] lines;

    [Tooltip("Seconds between each character when typing.")]
    public float textSpeed = 0.05f;

    [Tooltip("Automatically start showing dialogue on Start().")]
    public bool autoStart = true;

    private int index;
    private bool isTyping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (textComponent == null)
        {
            Debug.LogError("Dialogue1: TextComponent is not assigned. Assign a TextMeshProUGUI in the Inspector.", this);
            return;
        }

        if (lines == null || lines.Length == 0)
        {
            Debug.LogWarning("Dialogue1: Lines array is empty. Add dialogue lines in the Inspector.", this);
            textComponent.text = string.Empty;
            return;
        }

        if (autoStart)
        {
            textComponent.text = string.Empty;
            StartDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Press Space to advance to the next line after current line finishes typing
        if (!isTyping && Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Reached end of dialogue, optionally disable this component
            enabled = false;
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = string.Empty;

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

}



