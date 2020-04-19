using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comment : MonoBehaviour
{

    public string[] comments;

    // Start is called before the first frame update
    void OnEnable()
    {
        Text commentText = GetComponent<Text>();

        if (!Manager.newHighscore)
        {
            commentText.text = chosenComment();
        } else
        {
            commentText.text = "New highscore!";
        }
    }

    string chosenComment()
    {
        string _comment = comments[Random.Range(0, comments.Length)];
        return _comment;
    }
}
