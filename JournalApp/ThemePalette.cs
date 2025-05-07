using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalApp
{
    public class ThemePalette
    {
        // Фоны
        public Color BackgroundForm { get; set; } = ColorTranslator.FromHtml("#f8fafc");
        public Color BackgroundSplitContainer { get; set; } = ColorTranslator.FromHtml("#e0f0f0");
        public Color BackgroundSearchPanel { get; set; } = ColorTranslator.FromHtml("#f1f5f9");
        public Color BackgroundList { get; set; } = Color.White;
        public Color BackgroundDateLabel { get; set; } = ColorTranslator.FromHtml("#e0f4ff");
        public Color BackgroundMessage { get; set; } = ColorTranslator.FromHtml("#f3f4f6");//= Color.White;
        public Color BackgroundMessageSelected { get; set; } = ColorTranslator.FromHtml("#d4f0fc");
        public Color BackgroundPinnedMessage { get; set; } = ColorTranslator.FromHtml("#F2F0F0");//"#E2E0E0");//ColorTranslator.FromHtml("#f3f4f6");

        // Текст
        public Color TextPrimary { get; set; } = ColorTranslator.FromHtml("#111827");
        public Color TextSecondary { get; set; } = ColorTranslator.FromHtml("#6b7280");

        // Бордеры / отделители
        public Color MessageBorderColor { get; set; } = ColorTranslator.FromHtml("#e1e5eb");
        public ButtonBorderStyle MessageBorderStyle { get; set; } = ButtonBorderStyle.Solid;

        // Акценты (например, кнопки)
        public Color AccentColor { get; set; } = ColorTranslator.FromHtml("#2563eb");

        // Шрифты
        public Font MessageFont { get; set; } = new Font("Segoe UI", 12f, FontStyle.Regular);
        public Font PinnedMessageFont { get; set; } = new Font("Segoe UI", 14f, FontStyle.Bold);
        public Font SecondaryTextFont { get; set; } = new Font("Segoe UI", 10f, FontStyle.Regular);
    }
}
