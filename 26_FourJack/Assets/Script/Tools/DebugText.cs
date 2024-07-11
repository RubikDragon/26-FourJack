using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class DebugText
    {
        // make a games log

        private DebugText()
        {

        }

        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, Color color, int fontSize = 40, TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Center, int sortingOrder = 5000)
        {
            GameObject textObjeckt = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = textObjeckt.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;

            TextMesh textMesh = textObjeckt.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }

        public void TextLine(string text)
        {

        }
    }


}


