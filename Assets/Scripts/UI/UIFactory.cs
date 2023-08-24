using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFactory
{
    public static void ElementUIFactory(RectTransform parent, GameObject pref, int count, UISettings settings, Action<GameObject, int> action)
    {
        Vector3 position = settings.startPosition;

        for (int i = 0; i < count; i++)
        {
            var element = GameObject.Instantiate(pref, parent);
            var rectTransformLevel = element.GetComponent<RectTransform>();
            rectTransformLevel.localPosition = new Vector3(position.x,
                                                           position.y + settings.offsetPosition,
                                                           position.z);

            position.y -= settings.deltaPosition;

            action(element, i);
        }
    }

    public struct UISettings
    {
        public readonly Vector3 startPosition;
        public readonly float sizeElement;
        public readonly float offsetPosition;
        public readonly float fullSizeOffset;

        public float deltaPosition { get => fullSizeOffset + sizeElement / 2; }

        public UISettings(Vector3 startPosition, float sizeButton, float offsetPosition, float fullSizeOffset)
        {
            this.startPosition = startPosition;
            this.sizeElement = sizeButton;
            this.offsetPosition = offsetPosition;
            this.fullSizeOffset = fullSizeOffset;
        }
    }
}
