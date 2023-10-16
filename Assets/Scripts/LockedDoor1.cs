using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedDoor1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskText;

    // Start is called before the first frame update
    void OnDestroy()
    {
        taskText.fontStyle = FontStyles.Strikethrough;
    }
}
