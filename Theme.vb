Imports System.Drawing

''' <summary>
''' Central colour palette for the application. Keeping every ARGB value in one
''' place removes the duplicated <c>Color.FromArgb(...)</c> literals that were
''' previously scattered across the form code-behind and its Designer partial.
''' </summary>
Friend Module Theme

    ' Brand / accent colours
    Public ReadOnly Primary As Color = Color.FromArgb(28, 57, 101)      ' Deep navy
    Public ReadOnly PrimaryGradientEnd As Color = Color.FromArgb(41, 82, 140)
    Public ReadOnly Secondary As Color = Color.FromArgb(41, 128, 185)   ' Sky blue
    Public ReadOnly SecondaryHover As Color = Color.FromArgb(52, 152, 219)
    Public ReadOnly Accent As Color = Color.FromArgb(39, 174, 96)       ' Emerald
    Public ReadOnly AccentHover As Color = Color.FromArgb(46, 204, 113)
    Public ReadOnly Teal As Color = Color.FromArgb(26, 188, 156)
    Public ReadOnly TealHover As Color = Color.FromArgb(22, 160, 133)
    Public ReadOnly Danger As Color = Color.FromArgb(192, 57, 43)       ' Red
    Public ReadOnly DangerHover As Color = Color.FromArgb(231, 76, 60)
    Public ReadOnly NeutralHover As Color = Color.FromArgb(149, 165, 166)

    ' Surfaces
    Public ReadOnly Background As Color = Color.FromArgb(245, 247, 250)
    Public ReadOnly Surface As Color = Color.FromArgb(255, 255, 255)
    Public ReadOnly InputBack As Color = Color.FromArgb(250, 251, 252)
    Public ReadOnly StatusBarBack As Color = Color.FromArgb(236, 240, 241)
    Public ReadOnly Border As Color = Color.FromArgb(213, 219, 229)

    ' Text
    Public ReadOnly TextPrimary As Color = Color.FromArgb(44, 62, 80)
    Public ReadOnly TextSecondary As Color = Color.FromArgb(127, 140, 141)
    Public ReadOnly TextMuted As Color = Color.FromArgb(89, 103, 115)

    ' Grid
    Public ReadOnly GridHeader As Color = Color.FromArgb(52, 73, 94)
    Public ReadOnly GridAlt As Color = Color.FromArgb(236, 243, 254)
    Public ReadOnly Highlight As Color = Color.FromArgb(174, 214, 241)

    ' Semantic cell colours
    Public ReadOnly ZeroQty As Color = Color.FromArgb(211, 84, 0)

End Module
