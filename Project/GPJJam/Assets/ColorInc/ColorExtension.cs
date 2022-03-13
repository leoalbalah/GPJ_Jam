using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorExtension : MonoBehaviour {

    // [SerializeField] private GameObject spriteGameObject;

    // private void Awake() {
    //     SpriteRenderer spriteRenderer = spriteGameObject.GetComponent<SpriteRenderer>();
    //     spriteRenderer.color = GetColorFromString("FFFF0088");
    //     
    //     Debug.Log(GetColorFromString("FFFF0088"));
    //     Debug.Log(GetStringFromColor(new Color(1, 1, 0, .5f), true));
    // }

    private static int HexToDec(string hex) {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }

    private string DecToHex(int value) {
        return value.ToString("X2");
    }

    private string FloatNormalizedToHex(float value) {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }

    private static float HexToFloatNormalized(string hex) {
        return HexToDec(hex) / 255f;
    }

    public static Color GetColorFromString(string hexString) {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));
        float alpha = 1f;
        if (hexString.Length >= 8) {
            alpha = HexToFloatNormalized(hexString.Substring(6, 2));
        }
        return new Color(red, green, blue, alpha);
    }

    private string GetStringFromColor(Color color, bool useAlpha = false) {
        string red = FloatNormalizedToHex(color.r);
        string green = FloatNormalizedToHex(color.g);
        string blue = FloatNormalizedToHex(color.b);
        if (!useAlpha) {
            return red + green + blue;
        } else {
            string alpha = FloatNormalizedToHex(color.a);
            return red + green + blue + alpha;
        }
    }
}
