using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RedBlueGames.Tools.TextTyper;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class that tests TextTyper and shows how to interface with it.
/// </summary>
[ExecuteAlways]
public class MonitorTextTyper : MonoBehaviour
{
#pragma warning disable 0649 // Ignore "Field is never assigned to" warning, as these are assigned in inspector
    [SerializeField]
    private AudioClip printSoundEffect;

    [Header("UI References")]

    [SerializeField]
    private float delayTimeCharacter;

    [SerializeField]
    private float delayBetweenLines;

    private Queue<string> dialogueLines = new Queue<string>();

    [SerializeField]
    [Tooltip("The text typer element to test typing with")]
    private TextTyper testTextTyper;


#pragma warning restore 0649
    public void StartTypingText()
    {

        Debug.Log("Start typing");
        this.testTextTyper.CharacterPrinted.AddListener(this.HandleCharacterPrinted);
        //testTextTyper.Skip();
        dialogueLines.Clear();
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("<delay = 0.1>...</delay>");
        dialogueLines.Enqueue("Сигнал отсутствует." +
            "\nЗапуск протокола №4...." +
            "\nПеревод управления ИИ......" +
            "\nПроверка систем корабля......." +
            "\nСистемы корабля в удовлетворительном состоянии." +
            "\nПроверка вооружения...." +
            "\nВооружение в норме.");
        dialogueLines.Enqueue("Запуск реактора......................." +
            "\nРеактор запущен.\nПодготовка к варп-прыжку.");
        StartCoroutine(DelayBetweenLines());
    }

    public void StartTypingTextCoroutine()
    {
        StartCoroutine(DelayBetweenLines());
    }
    
    private IEnumerator DelayBetweenLines()
    {
        if (!testTextTyper.IsTyping)
        {
            ShowScript(delayTimeCharacter);
        }
        yield return new WaitForSeconds(delayBetweenLines);
        yield return StartCoroutine(DelayBetweenLines());
    }

    
    private void ShowScript(float delayTimesLines)
    {
        if (dialogueLines.Count <= 0)
        {
            return;
        }

        this.testTextTyper.TypeText(dialogueLines.Dequeue(), delayTimesLines);
    }

    private void HandleCharacterPrinted(string printedCharacter)
    {
        // Do not play a sound for whitespace
        if (printedCharacter == " " || printedCharacter == "\n")
        {
            return;
        }

        var audioSource = this.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = this.gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = this.printSoundEffect;
        audioSource.Play();
    }

}
