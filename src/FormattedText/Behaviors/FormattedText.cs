using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace FormattedText.Behaviors
{
    public class FormattedText
    {

        [AttachedPropertyBrowsableForType(typeof(TextBlock))]
        public static string GetText(DependencyObject obj)
        {
            return (string)obj.GetValue(TextProperty);
        }

        public static void SetText(DependencyObject obj, string value)
        {
            obj.SetValue(TextProperty, value);
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached("Text", typeof(string), typeof(FormattedText), new PropertyMetadata(null, OnFormattedTextChanged));

        private static void OnFormattedTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBlock textBlock)
            {
                textBlock.Inlines.Clear();
                var text = e.NewValue as string;
                if (string.IsNullOrWhiteSpace(text) == false)
                {
                    var subscriptSymbol = GetSubscriptSymbol(textBlock);
                    var re = new Regex($"{subscriptSymbol}(\\d*)", RegexOptions.CultureInvariant);
                    var segments = re.Split(text);
                    var inlines = new Inline[segments.Length];
                    for (int i = 0; i < segments.Length; i++)
                    {
                        Inline inline = new Run(segments[i]);
                        if (i % 2 != 0)
                        {
                            inline.SetValue(Typography.VariantsProperty, FontVariants.Subscript);
                        }
                        inlines[i] = inline;
                    }
                    textBlock.Inlines.AddRange(inlines);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        [AttachedPropertyBrowsableForType(typeof(TextBlock))]
        public static char GetSubscriptSymbol(DependencyObject obj)
        {
            return (char)obj.GetValue(SubscriptSymbolProperty);
        }

        public static void SetSubscriptSymbol(DependencyObject obj, char value)
        {
            obj.SetValue(SubscriptSymbolProperty, value);
        }

        // Using a DependencyProperty as the backing store for SubscriptSymbol.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubscriptSymbolProperty =
            DependencyProperty.RegisterAttached("SubscriptSymbol", typeof(char), typeof(FormattedText), new PropertyMetadata('ˇ'));
    }
}
