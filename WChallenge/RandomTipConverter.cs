using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WChallenge
{
    public class RandomTipConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            string originalText = (string)value;
            int lineLength = 27;
            int maxLines = 5;
            char cutterCharacter = '.'; //'…';  // (char)133;

            String outputText = WrapToLinesAndCut(originalText, lineLength, maxLines, cutterCharacter);
            return outputText;
        }

        private static string WrapToLinesAndCut(string originalText, int lineLength, int maxLines, char cutterCharacter)
        {
            StringBuilder stringBuilder = new StringBuilder(originalText);

            int lineCount = 0;
            int minIndexOfLine = 0;
            int maxIndexOfLine;
            while (minIndexOfLine < stringBuilder.Length - 2 && lineCount < maxLines)
            {
                

                maxIndexOfLine = originalText.LastIndexOfAny(new char[] { ' ', '\n' },
                                                    Math.Min(minIndexOfLine + lineLength - 1, stringBuilder.Length - 1),
                                                    Math.Min(minIndexOfLine + lineLength - 1, stringBuilder.Length - 1) - minIndexOfLine+1);//+1 or not?

                if (maxIndexOfLine != -1 && maxIndexOfLine < stringBuilder.Length - 1)
                {
                    if (stringBuilder.Length - 1 > minIndexOfLine + lineLength-1)
                    {
                        stringBuilder[maxIndexOfLine] = '\n';
                    }
                    
                    lineCount++;
                    if (lineCount == maxLines)
                    {
                        if (maxIndexOfLine < stringBuilder.Length - 1)
                        {
                            for (int i = maxIndexOfLine; i >= minIndexOfLine && i >= maxIndexOfLine - 2; i--)
                            {
                                stringBuilder[i] = cutterCharacter;
                            }
                        }

                        stringBuilder.Remove(maxIndexOfLine+1, stringBuilder.Length-(maxIndexOfLine+1));
                        break;
                    }
                    // stringBuilder.Replace(maxIndexOfLine, '\n');
                    minIndexOfLine = maxIndexOfLine + 1;
                    
                }
                else
                {
                    minIndexOfLine = stringBuilder.Length;
                }

            }

            String outputText = stringBuilder.ToString();
            return outputText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
            /*
            string originalText = (string)value;
            StringBuilder stringBuilder = new StringBuilder(originalText);

            stringBuilder.Replace("\n", "");

            return stringBuilder.ToString(); 
            */
        }
    }
}
