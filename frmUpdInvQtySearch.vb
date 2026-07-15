Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data

Public Class frmUpdInvQtySearch

    '────────────────────────────────────────────
    ' Form init
    '────────────────────────────────────────────
    Public Sub New()
        InitializeComponent()
        ApplyTheme()
        LoadDemoData()
    End Sub

    '────────────────────────────────────────────
    ' Apply runtime theme tweaks
    '────────────────────────────────────────────
    Private Sub ApplyTheme()
        ' Header gradient is painted via OnPaint – nothing extra needed here.

        ' DataGridView style
        With dgvResults
            .BackgroundColor = Theme.Surface
            .GridColor = Theme.Border
            .BorderStyle = BorderStyle.None
            .RowHeadersVisible = False
            .AlternatingRowsDefaultCellStyle.BackColor = Theme.GridAlt
            .DefaultCellStyle.BackColor = Theme.Surface
            .DefaultCellStyle.ForeColor = Theme.TextPrimary
            .DefaultCellStyle.SelectionBackColor = Theme.Highlight
            .DefaultCellStyle.SelectionForeColor = Theme.TextPrimary
            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .ColumnHeadersDefaultCellStyle.BackColor = Theme.GridHeader
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Padding = New Padding(6, 0, 0, 0)
            .ColumnHeadersHeight = 34
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .EnableHeadersVisualStyles = False
            .RowTemplate.Height = 30
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        End With

        ' Button hover effects
        AttachHover(btnSearch, Theme.Secondary, Theme.SecondaryHover)
        AttachHover(btnClear, Theme.TextSecondary, Theme.NeutralHover)
        AttachHover(btnUpdate, Theme.Accent, Theme.AccentHover)
        AttachHover(btnExport, Theme.Teal, Theme.TealHover)
        AttachHover(btnClose, Theme.Danger, Theme.DangerHover)
    End Sub

    '────────────────────────────────────────────
    ' Load demo / placeholder data
    '────────────────────────────────────────────
    Private Sub LoadDemoData()
        Dim dt As New DataTable
        dt.Columns.Add("itemCode", GetType(String))
        dt.Columns.Add("itemDesc", GetType(String))
        dt.Columns.Add("warehouse", GetType(String))
        dt.Columns.Add("currentQty", GetType(Decimal))
        dt.Columns.Add("unit", GetType(String))
        dt.Columns.Add("lastUpdated", GetType(Date))
        dt.Columns.Add("status", GetType(String))

        dt.Rows.Add("ITM-0001", "A4 White Paper (500 Sheets)", "WH-A", 1200D, "PKT", New Date(2026, 6, 1), "Active")
        dt.Rows.Add("ITM-0002", "Blue Ballpoint Pen (Box)", "WH-A", 85D, "BOX", New Date(2026, 6, 3), "Active")
        dt.Rows.Add("ITM-0003", "Stapler Heavy Duty", "WH-B", 30D, "PCS", New Date(2026, 5, 15), "Active")
        dt.Rows.Add("ITM-0004", "Manila Envelope (C4)", "WH-A", 500D, "PKT", New Date(2026, 5, 20), "Active")
        dt.Rows.Add("ITM-0005", "Correction Tape Roll", "WH-B", 0D, "PCS", New Date(2026, 4, 1), "Inactive")
        dt.Rows.Add("ITM-0006", "Plastic File Folder A4", "WH-C", 250D, "PCS", New Date(2026, 6, 10), "Active")
        dt.Rows.Add("ITM-0007", "Whiteboard Marker (Red)", "WH-A", 60D, "PCS", New Date(2026, 6, 5), "Active")
        dt.Rows.Add("ITM-0008", "Scissors Stainless 8 inch", "WH-B", 15D, "PCS", New Date(2026, 5, 22), "Active")
        dt.Rows.Add("ITM-0009", "Transparent Tape 18mm", "WH-C", 0D, "ROL", New Date(2026, 3, 10), "Inactive")
        dt.Rows.Add("ITM-0010", "Ring Binder A4 2-Ring", "WH-A", 180D, "PCS", New Date(2026, 6, 1), "Active")

        dgvResults.DataSource = dt
        SetGridColumns()
        UpdateStatusBar(dt.Rows.Count)
    End Sub

    Private Sub SetGridColumns()
        If dgvResults.Columns.Count = 0 Then Return

        dgvResults.Columns("itemCode").HeaderText = "商品編號"
        dgvResults.Columns("itemCode").Width = 110
        dgvResults.Columns("itemDesc").HeaderText = "商品描述"
        dgvResults.Columns("itemDesc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvResults.Columns("warehouse").HeaderText = "倉庫"
        dgvResults.Columns("warehouse").Width = 80
        dgvResults.Columns("currentQty").HeaderText = "現有數量"
        dgvResults.Columns("currentQty").Width = 90
        dgvResults.Columns("currentQty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvResults.Columns("unit").HeaderText = "單位"
        dgvResults.Columns("unit").Width = 65
        dgvResults.Columns("lastUpdated").HeaderText = "最後更新"
        dgvResults.Columns("lastUpdated").Width = 105
        dgvResults.Columns("lastUpdated").DefaultCellStyle.Format = "dd/MM/yyyy"
        dgvResults.Columns("status").HeaderText = "狀態"
        dgvResults.Columns("status").Width = 75

        ' Quantity: colour code zeros
        AddHandler dgvResults.CellFormatting, AddressOf DgvResults_CellFormatting
    End Sub

    '────────────────────────────────────────────
    ' Cell formatting – zero qty in amber
    '────────────────────────────────────────────
    Private Sub DgvResults_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If dgvResults.Columns(e.ColumnIndex).Name = "currentQty" AndAlso e.Value IsNot Nothing Then
            If CDec(e.Value) = 0 Then
                e.CellStyle.ForeColor = Theme.ZeroQty
                e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            End If
        End If
        If dgvResults.Columns(e.ColumnIndex).Name = "status" AndAlso e.Value IsNot Nothing Then
            If e.Value.ToString() = "Active" Then
                e.CellStyle.ForeColor = Theme.Accent
                e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            Else
                e.CellStyle.ForeColor = Theme.TextSecondary
            End If
        End If
    End Sub

    '────────────────────────────────────────────
    ' Status bar helper
    '────────────────────────────────────────────
    Private Sub UpdateStatusBar(count As Integer)
        lblRecordCount.Text = $"共  {count}  筆記錄"
    End Sub

    '────────────────────────────────────────────
    ' Header gradient painting
    '────────────────────────────────────────────
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        ' Header band
        Using br As New Drawing2D.LinearGradientBrush(
                pnlHeader.Bounds,
                Theme.Primary,
                Theme.PrimaryGradientEnd,
                Drawing2D.LinearGradientMode.Horizontal)
            e.Graphics.FillRectangle(br, pnlHeader.Bounds)
        End Using
    End Sub

    '────────────────────────────────────────────
    ' Button click handlers
    '────────────────────────────────────────────
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim ds = GridTable()
        If ds Is Nothing Then Return

        Dim filters As New List(Of String)

        If Not String.IsNullOrWhiteSpace(txtItemCode.Text) Then
            filters.Add($"itemCode LIKE '%{EscapeFilter(txtItemCode.Text.Trim())}%'")
        End If
        If Not String.IsNullOrWhiteSpace(txtItemDesc.Text) Then
            filters.Add($"itemDesc LIKE '%{EscapeFilter(txtItemDesc.Text.Trim())}%'")
        End If
        If cmbWarehouse.SelectedIndex > 0 Then
            filters.Add($"warehouse = '{EscapeFilter(cmbWarehouse.SelectedItem.ToString())}'")
        End If
        If cmbStatus.SelectedIndex > 0 Then
            filters.Add($"status = '{EscapeFilter(cmbStatus.SelectedItem.ToString())}'")
        End If

        Dim expr = If(filters.Count > 0, String.Join(" AND ", filters), "")
        ds.DefaultView.RowFilter = expr
        UpdateStatusBar(ds.DefaultView.Count)
    End Sub

    ''' <summary>
    ''' Escapes single-quote characters for use inside a DataView RowFilter expression.
    ''' </summary>
    Private Shared Function EscapeFilter(value As String) As String
        Return value.Replace("'", "''")
    End Function

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtItemCode.Clear()
        txtItemDesc.Clear()
        cmbWarehouse.SelectedIndex = 0
        cmbStatus.SelectedIndex = 0
        dtpDateFrom.Value = Date.Today.AddMonths(-3)
        dtpDateTo.Value = Date.Today

        Dim ds = GridTable()
        If ds IsNot Nothing Then
            ds.DefaultView.RowFilter = ""
            UpdateStatusBar(ds.DefaultView.Count)
        End If
        txtItemCode.Focus()
    End Sub

    ''' <summary>Returns the grid's bound DataTable, or Nothing if unset.</summary>
    Private Function GridTable() As DataTable
        Return TryCast(dgvResults.DataSource, DataTable)
    End Function

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvResults.SelectedRows.Count = 0 Then
            ShowInfo("請先選擇要更新的記錄。", "提示")
            Return
        End If
        ' Placeholder – wire to real update logic
        ShowInfo($"已選取 {dgvResults.SelectedRows.Count} 筆記錄，準備更新。", "更新庫存數量")
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV 檔案 (*.csv)|*.csv"
            sfd.FileName = $"InvQty_{Date.Today:yyyyMMdd}"
            If sfd.ShowDialog() = DialogResult.OK Then
                ExportToCsv(sfd.FileName)
                ShowInfo("匯出成功！", "匯出")
            End If
        End Using
    End Sub

    Private Sub ExportToCsv(path As String)
        Dim sb As New System.Text.StringBuilder
        ' Header
        Dim headers = (From c As DataGridViewColumn In dgvResults.Columns
                       Select c.HeaderText)
        sb.AppendLine(String.Join(",", headers))
        ' Rows
        For Each row As DataGridViewRow In dgvResults.Rows
            Dim vals = (From c As DataGridViewCell In row.Cells
                        Select $"""{c.FormattedValue}""")
            sb.AppendLine(String.Join(",", vals))
        Next
        IO.File.WriteAllText(path, sb.ToString(), System.Text.Encoding.UTF8)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '────────────────────────────────────────────
    ' Allow Enter key to trigger search
    '────────────────────────────────────────────
    Private Sub SearchField_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtItemCode.KeyDown, txtItemDesc.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSearch_Click(sender, e)
    End Sub

End Class
