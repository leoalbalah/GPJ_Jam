using UnityEngine;

public class ColorExtension : MonoBehaviour {
    private static int HexToDec(string hex) {
        var dec = System.Convert.ToInt32(hex, 16);
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
        var red = HexToFloatNormalized(hexString.Substring(0, 2));
        var green = HexToFloatNormalized(hexString.Substring(2, 2));
        var blue = HexToFloatNormalized(hexString.Substring(4, 2));
        var alpha = 1f;
        if (hexString.Length >= 8) {
            alpha = HexToFloatNormalized(hexString.Substring(6, 2));
        }
        return new Color(red, green, blue, alpha);
    }

    private string GetStringFromColor(Color color, bool useAlpha = false) {
        var red = FloatNormalizedToHex(color.r);
        var green = FloatNormalizedToHex(color.g);
        var blue = FloatNormalizedToHex(color.b);
        if (!useAlpha) {
            return red + green + blue;
        } else {
            var alpha = FloatNormalizedToHex(color.a);
            return red + green + blue + alpha;
        }
    }
}
