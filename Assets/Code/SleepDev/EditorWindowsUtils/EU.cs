using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SleepDev
{
#if UNITY_EDITOR
    /// <summary>
    /// Useful editor methods for building editor classes
    /// </summary>
    public static partial class EU
    {
   
#region Public Buttons

        public static bool Button(string label, float width, float height, Color color, int fontSize = -1)
        {
            var style = GetButtonStyle(width, height);
            style.fontStyle = FontStyle.Bold;
            if (fontSize > 0)
                style.fontSize = fontSize;
            var prevColor = GUI.color;
            GUI.color = color;
            SetButtonTextColor(style,color);
            
            var clicked = GUILayout.Button(label, style);
            GUI.color = prevColor;
            return clicked;
        }
        
        public static bool Button(GUIContent content, float width, float height, Color color, int fontSize = -1)
        {
            var style = GetButtonStyle(width, height);
            style.fontStyle = FontStyle.Bold;
            if (fontSize > 0)
                style.fontSize = fontSize;
            var prevColor = GUI.color;
            GUI.color = color;
            SetButtonTextColor(style,color);
            var clicked = GUILayout.Button(content, style);
            GUI.color = prevColor;
            return clicked;
        }

        /// <summary>
        /// Small Square button. Use this with no text or one character
        /// </summary>
        public static bool BtnSmallSquare(string label, Color color, int fontSize = -1)
        {
            return Button(label, btn_w_small, btn_h_small, color, fontSize);
        }
        
        public static bool BtnSquare(string label, Color color, int squareSide, int fontSize = -1)
        {
            return Button(label, squareSide, squareSide, color, fontSize);
        }
        /// <summary>
        /// Normal sized button, suitable for 1-word text
        /// </summary>
        public static bool BtnMid1(string label, Color color, int fontSize = -1)
        {
            return Button(label, btn_w_middle, btn_h_middle, color, fontSize);
        }
        
        public static bool BtnMidSmallHeight(string label, Color color, int fontSize = -1)
        {
            return Button(label, btn_w_middle, btn_h_small, color, fontSize);
        }
        
        /// <summary>
        /// Big Width, mid width
        /// </summary>
        public static bool BtnMidWide(string label, Color color, int fontSize = -1)
        {
            return Button(label, btn_w_big, btn_h_middle, color, fontSize);
        }
        
        /// <summary>
        /// Large Width, mid width
        /// </summary>
        public static bool BtnMidWide2(string label, Color color, int fontSize = -1)
        {
            return Button(label, btn_w_large, btn_h_middle, color, fontSize);
        }
        
        /// <summary>
        /// Extra Large Width, mid width
        /// </summary>
        public static bool BtnMidWide3(string label, Color color, int fontSize = -1)
        {
            return Button(label, btn_w_XL, btn_h_middle, color, fontSize);
        }

        /// <summary>
        ///  Big Width, Big Height
        /// </summary>
        public static bool BtnBigWide(string label, Color color, int fontSize = -1)
        {
            return Button(label, btn_w_big, btn_h_big, color, fontSize);
        }
        
        /// <summary>
        ///  Large Width, Big Height
        /// </summary>
        public static bool BtnLargeWide(string label, Color color)
        {
            return Button(label, btn_w_large, btn_h_big, color);
        }
#endregion


#region Public Labels
        public static void Label(string text, char align = 'c', bool bold = true)
        {
            var style = GetLabelStyle(align, bold);
            GUILayout.Label(text, style);
        }

        public static void Label(string text, Color color, char align = 'c', bool bold = true)
        {
            var prevColor = GUI.color;
            GUI.color = color;
            Label(text, align, bold);
            GUI.color = prevColor;
        }
        
        public static void Label(string text, Color color, int fontSize, char align = 'c', bool bold = true)
        {
            var prevColor = GUI.color;
            GUI.color = color;
            Label(text, fontSize, align, bold);
            GUI.color = prevColor;
        }
        
        public static void Label(string text, Color color, int fontSize, int width, char align = 'c', bool bold = true)
        {
            var prevColor = GUI.color;
            GUI.color = color;
            var style = GetLabelStyle(align, bold, fontSize);
            GUILayout.Label(text, style, GUILayout.Width(width));
            GUI.color = prevColor;
        }

                
        public static void Label(string text, int fontSize = font_normal, char align = 'c', bool bold = true)
        {
            var style = GetLabelStyle(align, bold, fontSize);
            GUILayout.Label(text, style);
        }
        
        public static void LabelRect(Rect rect, string label, int fontSize, Color color, char align, bool bold)
        {
            var prevColor = GUI.color;
            GUI.color = color;
            var style = GetLabelStyle(align, bold, fontSize);
            EditorGUI.LabelField(rect, label, style);
            GUI.color = prevColor;
        }        
        
#endregion


#region Spaces
        public static void Space(int size = space_small) => GUILayout.Space(size);
        public static void SpaceMid() => GUILayout.Space(space_middle);
        public static void SpaceBig() => GUILayout.Space(space_big);
#endregion


        #region Button With Label

        public static bool ButtonWithLabelSmall(string buttonText, string labelText, Color buttonColor)
        {
            return ButtonWithLabel(buttonText, labelText, buttonColor, Color.white);
        }
        
        public static bool ButtonWithLabelMidSize(string buttonText, string labelText, Color buttonColor)
        {
            return ButtonWithLabel(buttonText, labelText, buttonColor, Color.white, square_btn_size_mid);
        }

        public static bool ButtonWithLabelBig(string buttonText, string labelText, Color buttonColor)
        {
            return ButtonWithLabel(buttonText, labelText, buttonColor, Color.white, square_btn_size_big);
        }
        
        public static bool ButtonWithLabelLarge(string buttonText, string labelText, Color buttonColor)
        {
            return ButtonWithLabel(buttonText, labelText, buttonColor, Color.white, square_btn_size_large);
        }
        
        public static bool ButtonWithLabel(string buttonText, string labelText, 
                            Color buttonColor, Color labelColor,
                            int buttonSize = square_btn_size_small, int fontSize = font_normal)
        {
            var prevColor = GUI.color;
            var buttonStyle = GetButtonStyle(buttonSize, buttonSize);
            var labelStyle = GetLabelStyle('l', true, fontSize);
            labelStyle.fixedHeight = buttonSize;
            GUILayout.BeginHorizontal();
            GUI.color = buttonColor;
            SetButtonTextColor(buttonStyle, buttonColor);
            var pressed = GUILayout.Button(buttonText, buttonStyle);
            GUI.color = labelColor;
            GUILayout.Label(labelText, labelStyle);
            GUILayout.EndHorizontal();
            GUI.color = prevColor;
            return pressed;
        }

        public static bool LabelWithButton(string buttonText, string labelText, 
            Color buttonColor, Color labelColor,
            int buttonSize = square_btn_size_small, int fontSize = font_normal)
        {
            var prevColor = GUI.color;
            var buttonStyle = GetButtonStyle(buttonSize, buttonSize);
            var labelStyle = GetLabelStyle('r', true, fontSize);
            labelStyle.fixedHeight = buttonSize;
            GUILayout.BeginHorizontal();
            GUI.color = buttonColor;
            GUILayout.Label(labelText, labelStyle);
            SetButtonTextColor(buttonStyle, buttonColor);
            var pressed = GUILayout.Button(buttonText, buttonStyle);
            GUI.color = labelColor;
            GUILayout.EndHorizontal();
            GUI.color = prevColor;
            return pressed;
        }
        
        public static void TwoButtonAndLabel(string buttonText1, string buttonText2, string labelText, 
            Color buttonColor1, Color buttonColor2, Color labelColor,
            Action onClick1, Action onClick2,
            int buttonSize = square_btn_size_small, int fontSize = font_normal)
        {
            var prevColor = GUI.color;
            var buttonStyle = GetButtonStyle(buttonSize, buttonSize);

            var labelStyle = GetLabelStyle('l', true, fontSize);
            labelStyle.fixedHeight = buttonSize;
            GUILayout.BeginHorizontal();
            
            GUI.color = buttonColor1;
            SetButtonTextColor(buttonStyle, buttonColor1);
            if(GUILayout.Button(buttonText1, buttonStyle))
                onClick1?.Invoke();
            GUI.color = buttonColor2;
            SetButtonTextColor(buttonStyle, buttonColor2);
            if(GUILayout.Button(buttonText2, buttonStyle))
                onClick2?.Invoke();
            
            GUI.color = labelColor;
            GUILayout.Label(labelText, labelStyle);

            GUILayout.EndHorizontal();
            GUI.color = prevColor;
        }
        
        public static void LabelAndTwoButton(string buttonText1, string buttonText2, string labelText, 
            Color buttonColor1, Color buttonColor2, Color labelColor,
            Action onClick1, Action onClick2,
            int buttonSize = square_btn_size_small, int fontSize = font_normal)
        {
            var prevColor = GUI.color;
            var buttonStyle = GetButtonStyle(buttonSize, buttonSize);
            var labelStyle = GetLabelStyle('r', true, fontSize);
            labelStyle.fixedHeight = buttonSize;
            GUILayout.BeginHorizontal();
            
            GUI.color = labelColor;
            GUILayout.Label(labelText, labelStyle);
            
            GUI.color = buttonColor1;
            SetButtonTextColor(buttonStyle, buttonColor1);
            if(GUILayout.Button(buttonText1, buttonStyle))
                onClick1?.Invoke();
            GUI.color = buttonColor2;
            SetButtonTextColor(buttonStyle, buttonColor2);
            if(GUILayout.Button(buttonText2, buttonStyle))
                onClick2?.Invoke();

            GUILayout.EndHorizontal();
            GUI.color = prevColor;
        }
        
        public static void ThreeButtonAndLabel(string buttonText1, string buttonText2,  string buttonText3, string labelText, 
            Color buttonColor1, Color buttonColor2, Color buttonColor3, Color labelColor,
            Action onClick1, Action onClick2, Action onClick3,
            int buttonSize = square_btn_size_small, int fontSize = font_normal)
        {
            var prevColor = GUI.color;
            var buttonStyle = GetButtonStyle(buttonSize, buttonSize);
            var labelStyle = GetLabelStyle('l', true, fontSize);
            labelStyle.fixedHeight = buttonSize;
            GUILayout.BeginHorizontal();
            
            GUI.color = buttonColor1;
            SetButtonTextColor(buttonStyle, buttonColor1);
            if(GUILayout.Button(buttonText1, buttonStyle))
                onClick1?.Invoke();
            GUI.color = buttonColor2;
            SetButtonTextColor(buttonStyle, buttonColor2);
            if(GUILayout.Button(buttonText2, buttonStyle))
                onClick2?.Invoke();
            GUI.color = buttonColor3;
            SetButtonTextColor(buttonStyle, buttonColor3);
            if(GUILayout.Button(buttonText3, buttonStyle))
                onClick3?.Invoke();
            
            GUI.color = labelColor;
            GUILayout.Label(labelText, labelStyle);

            GUILayout.EndHorizontal();
            GUI.color = prevColor;
        }

        private static void SetButtonTextColor(GUIStyle style, Color buttonColor)
        {
            var cl = (buttonColor.r + buttonColor.g + buttonColor.b) * buttonColor.a;
            if (cl > 50)
                style.normal.textColor = Black;
            else
                style.normal.textColor = Color.white;
        }
        #endregion
        
        
        #region Style Getters
        public static GUIStyle GetButtonStyle(float width, float height, int fontSize = font_normal)
        {
            var style = GetButtonStyle();
            style.fixedWidth = width;
            style.fixedHeight = height;
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = fontSize;
            return style;
        }
        
        public static GUIStyle GetButtonStyle()
        {
            var style = new GUIStyle(GUI.skin.button);
            return style;
        }
        
        public static GUIStyle GetLabelStyle(char align, bool bold, int fontSize = font_normal)
        {
            var style = GetLabelStyle();
            switch (align)
            {
                case 'l':
                    style.alignment = TextAnchor.MiddleLeft;
                    break;
                case 'c':
                    style.alignment = TextAnchor.MiddleCenter;
                    break;
                case 'r':
                    style.alignment = TextAnchor.MiddleRight;
                    break;
            }
            if (bold)
                style.fontStyle = FontStyle.Bold;
            style.fontSize = fontSize;
            return style;    
        }
        
        public static GUIStyle GetLabelStyle()
        {
            var style = new GUIStyle(GUI.skin.label);
            return style;
        }    
        #endregion


        #region Coloumns

        public class EU_ColumnElement
        {
            public string content;
            public int fontSize;
            public Color color;
            public char align;
            public bool bold;

            public EU_ColumnElement(string content)
            {
                this.content = content;
            }
            
            public EU_ColumnElement(string content, int fontSize, Color color, char align = 'l', bool bold = true)
            {
                this.content = content;
                this.fontSize = fontSize;
                this.color = color;
                this.align = align;
                this.bold = bold;
            }

            public void CopyStyle(EU_ColumnElement source)
            {
                this.fontSize = source.fontSize;
                this.color = source.color;
                this.align = source.align;
                this.bold = source.bold;

            }
        }

        public class EU_Column
        {
            public List<EU_ColumnElement> elements;
            public EU_ColumnElement defaultElement;
            public Rect rect;
            
            public EU_Column(Rect rect)
            {
                this.rect = rect;
                elements = new List<EU_ColumnElement>();
            }
            
            public EU_Column(Rect rect, EU_ColumnElement defaultElement)
            {
                this.rect = rect;
                this.defaultElement = defaultElement;
                elements = new List<EU_ColumnElement>();
            }

            public void SetDefaultElement(EU_ColumnElement defaultElement, bool copyForOthers)
            {
                this.defaultElement = defaultElement;
                if (copyForOthers)
                {
                    foreach (var el in elements)
                        el.CopyStyle(defaultElement);
                }
            }

            public void AddElement(string content)
            {
                var el = new EU_ColumnElement(content);
                el.CopyStyle(defaultElement);
                AddElement(el);
            }

            public void AddElement(EU_ColumnElement element)
            {
                elements.Add(element);
            }

            public void Show()
            {
                GUILayout.BeginArea(rect);
                foreach (var el in elements)
                    Label(el.content, el.color, el.fontSize, el.align, el.bold);
                GUILayout.EndArea();
            }
        }

        public static bool Toggle(string label, int fontsize, Color color, float width, bool value)
        {
            var skin = new GUIStyle(GUI.skin.label);
            skin.alignment = TextAnchor.MiddleLeft;
            skin.fontSize = fontsize;
            var oldColor = GUI.color;
            GUILayout.BeginHorizontal();
            GUI.color = color;
            GUILayout.Label(label,skin, GUILayout.Width(width));
            GUI.color = oldColor;
            var val = EditorGUILayout.Toggle(value);
            GUILayout.EndHorizontal();
            return val;
        }
        
        public static string TextField(string label, int fontsize, Color color, float width, string value)
        {
            var skin = new GUIStyle(GUI.skin.label);
            skin.alignment = TextAnchor.MiddleLeft;
            skin.fontSize = fontsize;
            var oldColor = GUI.color;
            GUILayout.BeginHorizontal();
            GUI.color = color;
            GUILayout.Label(label,skin, GUILayout.Width(width));
            GUI.color = oldColor;
            var val = EditorGUILayout.TextField(value);
            GUILayout.EndHorizontal();
            return val;
        }

        public static UnityEngine.Object ObjectField(string label, int fontsize, Color color, float width, 
            UnityEngine.Object obj, Type objType)
        {
            var skin = new GUIStyle(GUI.skin.label);
            skin.alignment = TextAnchor.MiddleLeft;
            skin.fontSize = fontsize;
            var oldColor = GUI.color;
            GUILayout.BeginHorizontal();
            GUI.color = color;
            GUILayout.Label(label,skin, GUILayout.Width(width));
            GUI.color = oldColor;
            var val = EditorGUILayout.ObjectField(obj, objType);
            GUILayout.EndHorizontal();
            return val;
        }
        #endregion

        #region Utils
        public static Rect SetRectX(Rect rect, float x)
        {
            var rect2 = new Rect(rect);
            rect2.x = x;
            rect2.width -= x;
            return rect2;
        }

        #endregion
        
    }
    #endif
}