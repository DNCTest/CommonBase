Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Reusable WinForms styling helpers. These centralise the control-formatting
''' code that was previously duplicated per-control in the Designer and the
''' hover/message-box boilerplate that was duplicated per-button in the
''' code-behind.
''' </summary>
Friend Module UiHelpers

    ''' <summary>Applies the flat card border used by text inputs.</summary>
    Public Sub StyleTextBox(tb As TextBox)
        tb.BorderStyle = BorderStyle.FixedSingle
        tb.BackColor = Theme.InputBack
        tb.Font = New Font("Segoe UI", 9.5!)
    End Sub

    ''' <summary>Applies the flat coloured-button style shared by every action button.</summary>
    Public Sub StyleButton(btn As Button, bg As Color)
        btn.BackColor = bg
        btn.ForeColor = Color.White
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
        btn.Cursor = Cursors.Hand
        btn.TextAlign = ContentAlignment.MiddleLeft
        btn.Padding = New Padding(6, 0, 0, 0)
    End Sub

    ''' <summary>Applies the flat drop-down-list style and populates the combo items.</summary>
    Public Sub StyleComboBox(cmb As ComboBox, items As Object())
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        cmb.Items.AddRange(items)
        cmb.SelectedIndex = 0
        cmb.Font = New Font("Segoe UI", 9.5!)
        cmb.FlatStyle = FlatStyle.Flat
        cmb.BackColor = Theme.InputBack
    End Sub

    ''' <summary>Applies the muted auto-sizing caption style shared by search-field labels.</summary>
    Public Sub StyleFieldLabel(lbl As Label)
        lbl.AutoSize = True
        lbl.ForeColor = Theme.TextMuted
    End Sub

    ''' <summary>
    ''' Wires MouseEnter/MouseLeave so the button flips to <paramref name="hover"/>
    ''' while hovered and back to <paramref name="normal"/> otherwise.
    ''' </summary>
    Public Sub AttachHover(btn As Button, normal As Color, hover As Color)
        AddHandler btn.MouseEnter, Sub() btn.BackColor = hover
        AddHandler btn.MouseLeave, Sub() btn.BackColor = normal
    End Sub

    ''' <summary>Shows a standard informational message box.</summary>
    Public Sub ShowInfo(text As String, title As String)
        MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Module
