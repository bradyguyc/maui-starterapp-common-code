using DevExpress.Maui;
using DevExpress.Maui.Core;

namespace CommonCode.Helpers
{
     public  static class SetThemeColor
    {
         public static void SetAppThemeColor()
        {
            // Define the default theme seed color
            ThemeSeedColor themeSeedColor = ThemeSeedColor.DeepSeaBlue;

            // Check if a custom color theme is enabled
            bool isCustomColorTheme = Preferences.Default.Get("isCustomColorTheme", false);

            // Get the custom color or theme color from preferences
            string customColor = Preferences.Default.Get("CustomColorTheme", "#FF006C50");
            string themeColor = Preferences.Default.Get("themeColor", themeSeedColor.ToString());

            // Determine the theme color
            Theme theme;

            if (isCustomColorTheme || themeColor == "Custom")
            {
                // Attempt to parse the custom color string to a Color object
                if (Color.TryParse(customColor, out Color parsedColor))
                {
                    theme = new Theme(parsedColor);
                }
                else
                {
                    // Fallback to the default theme seed color if parsing fails
                    themeSeedColor = ThemeSeedColor.TealGreen;
                    theme = new Theme(themeSeedColor);
                }
            }
            else
            {
                // Attempt to parse the theme color string to a ThemeSeedColor enum
                if (Enum.TryParse(themeColor, out ThemeSeedColor parsedThemeSeedColor))
                {
                    themeSeedColor = parsedThemeSeedColor;
                    theme = new Theme(themeSeedColor);
                }
                else
                {
                    // Fallback to the default theme seed color if parsing fails
                    themeSeedColor = ThemeSeedColor.TealGreen;
                    theme = new Theme(themeSeedColor);
                    // Save the default value back to preferences
                    Preferences.Default.Set("themeColor", themeSeedColor.ToString());
                }
            }

            // Set the theme manager's theme
            ThemeManager.UseAndroidSystemColor = false;
            ThemeManager.Theme = theme;
        }
    }
}
