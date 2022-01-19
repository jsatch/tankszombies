using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{ 
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color)
    {
        GameObject gameObject = new GameObject("WorldText", typeof(TextMesh));
        gameObject.transform.SetParent(parent);
        gameObject.transform.localPosition = localPosition;
        gameObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;

        return textMesh;
    }
}
