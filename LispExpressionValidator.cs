public class LispExpressionValidator {
    public static bool IsValid(string input) {
        var openParenthesisCount = 0;
        var closingParenthesisCount = 0;

        foreach(var character in input) {
            if (character == '(') {
                openParenthesisCount++;
            }

            if (character == ')') {
                closingParenthesisCount++;
            }
        }

        return openParenthesisCount == closingParenthesisCount;
    }
}