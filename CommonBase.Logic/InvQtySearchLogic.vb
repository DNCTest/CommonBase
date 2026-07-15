Imports System.Data

''' <summary>
''' UI-independent business logic for the inventory-quantity search form.
''' Kept free of any WinForms dependency so it can be unit tested.
''' </summary>
Public Module InvQtySearchLogic

    ''' <summary>
    ''' Escapes single-quote characters for use inside a DataView RowFilter expression.
    ''' </summary>
    Public Function EscapeFilter(value As String) As String
        If value Is Nothing Then Return String.Empty
        Return value.Replace("'", "''")
    End Function

    ''' <summary>
    ''' Builds a <see cref="DataView.RowFilter"/> expression from the supplied search criteria.
    ''' Empty / whitespace-only criteria are ignored. Returns an empty string when no
    ''' criteria are supplied (i.e. no filtering).
    ''' </summary>
    ''' <param name="itemCode">Partial item code to match (LIKE).</param>
    ''' <param name="itemDesc">Partial item description to match (LIKE).</param>
    ''' <param name="warehouse">Exact warehouse to match, or empty for all warehouses.</param>
    ''' <param name="status">Exact status to match, or empty for all statuses.</param>
    Public Function BuildRowFilter(itemCode As String,
                                   itemDesc As String,
                                   warehouse As String,
                                   status As String) As String
        Dim filters As New List(Of String)

        If Not String.IsNullOrWhiteSpace(itemCode) Then
            filters.Add($"itemCode LIKE '%{EscapeFilter(itemCode.Trim())}%'")
        End If
        If Not String.IsNullOrWhiteSpace(itemDesc) Then
            filters.Add($"itemDesc LIKE '%{EscapeFilter(itemDesc.Trim())}%'")
        End If
        If Not String.IsNullOrWhiteSpace(warehouse) Then
            filters.Add($"warehouse = '{EscapeFilter(warehouse.Trim())}'")
        End If
        If Not String.IsNullOrWhiteSpace(status) Then
            filters.Add($"status = '{EscapeFilter(status.Trim())}'")
        End If

        Return If(filters.Count > 0, String.Join(" AND ", filters), String.Empty)
    End Function

    ''' <summary>
    ''' Builds the demo / placeholder inventory <see cref="DataTable"/> shown in the grid.
    ''' </summary>
    Public Function BuildDemoData() As DataTable
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

        Return dt
    End Function

End Module
