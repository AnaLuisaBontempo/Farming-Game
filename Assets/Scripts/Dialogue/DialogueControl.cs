﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }

    public idiom language;



    [Header("Components")]
    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite; // sprite do perfil
    public Text speechText; //texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typinSpeed; //velocidade da fala


    //variáveis de controle
    private bool isShowing; //se a janela está visível
    private int index; //index das setenças 
    private string[] sentences;


    public static DialogueControl instance;

    //awake é chamado antes de todos os Star() na hierarquia de scripts
    private void Awake()
    {
        instance = this;
    }

    //é chamado ao inicializar
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index]. ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typinSpeed);

        }
    }

    //pular pra próxima frase/fala
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //quando terminam os textos
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //chamar a fala do npc
    public void Speech(string[] txt)
    {
        if(!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
