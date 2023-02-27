using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;
public class GetText : MonoBehaviour
{
    [SerializeField] private TextAsset text;
    [SerializeField] private TextMeshProUGUI textUI;
    void Start()
    {
        textUI.text = text.text;
    }


}
