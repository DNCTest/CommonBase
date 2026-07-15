Imports System.Data
Imports Xunit

Public Class EscapeFilterTests

    <Fact>
    Public Sub EscapeFilter_WithNoQuotes_ReturnsUnchanged()
        Assert.Equal("ITM-0001", InvQtySearchLogic.EscapeFilter("ITM-0001"))
    End Sub

    <Fact>
    Public Sub EscapeFilter_WithSingleQuote_DoublesIt()
        Assert.Equal("O''Brien", InvQtySearchLogic.EscapeFilter("O'Brien"))
    End Sub

    <Fact>
    Public Sub EscapeFilter_WithMultipleQuotes_DoublesEach()
        Assert.Equal("''a''b''", InvQtySearchLogic.EscapeFilter("'a'b'"))
    End Sub

    <Fact>
    Public Sub EscapeFilter_WithEmptyString_ReturnsEmpty()
        Assert.Equal("", InvQtySearchLogic.EscapeFilter(""))
    End Sub

    <Fact>
    Public Sub EscapeFilter_WithNothing_ReturnsEmpty()
        Assert.Equal("", InvQtySearchLogic.EscapeFilter(Nothing))
    End Sub

End Class

Public Class BuildRowFilterTests

    <Fact>
    Public Sub BuildRowFilter_WithNoCriteria_ReturnsEmpty()
        Assert.Equal("", InvQtySearchLogic.BuildRowFilter("", "", "", ""))
    End Sub

    <Fact>
    Public Sub BuildRowFilter_WithWhitespaceOnly_ReturnsEmpty()
        Assert.Equal("", InvQtySearchLogic.BuildRowFilter("   ", vbTab, Nothing, "  "))
    End Sub

    <Fact>
    Public Sub BuildRowFilter_WithItemCode_BuildsLikeClause()
        Assert.Equal("itemCode LIKE '%ITM-0001%'",
                     InvQtySearchLogic.BuildRowFilter("ITM-0001", "", "", ""))
    End Sub

    <Fact>
    Public Sub BuildRowFilter_TrimsCriteria()
        Assert.Equal("itemCode LIKE '%ITM-0001%'",
                     InvQtySearchLogic.BuildRowFilter("  ITM-0001  ", "", "", ""))
    End Sub

    <Fact>
    Public Sub BuildRowFilter_WithItemDesc_BuildsLikeClause()
        Assert.Equal("itemDesc LIKE '%Paper%'",
                     InvQtySearchLogic.BuildRowFilter("", "Paper", "", ""))
    End Sub

    <Fact>
    Public Sub BuildRowFilter_WithWarehouse_BuildsEqualsClause()
        Assert.Equal("warehouse = 'WH-A'",
                     InvQtySearchLogic.BuildRowFilter("", "", "WH-A", ""))
    End Sub

    <Fact>
    Public Sub BuildRowFilter_WithStatus_BuildsEqualsClause()
        Assert.Equal("status = 'Active'",
                     InvQtySearchLogic.BuildRowFilter("", "", "", "Active"))
    End Sub

    <Fact>
    Public Sub BuildRowFilter_WithAllCriteria_JoinsWithAnd()
        Dim expected = "itemCode LIKE '%ITM%' AND itemDesc LIKE '%Pen%' AND warehouse = 'WH-A' AND status = 'Active'"
        Assert.Equal(expected,
                     InvQtySearchLogic.BuildRowFilter("ITM", "Pen", "WH-A", "Active"))
    End Sub

    <Fact>
    Public Sub BuildRowFilter_EscapesSingleQuotes()
        Assert.Equal("itemDesc LIKE '%O''Brien%'",
                     InvQtySearchLogic.BuildRowFilter("", "O'Brien", "", ""))
    End Sub

End Class

Public Class BuildDemoDataTests

    <Fact>
    Public Sub BuildDemoData_HasExpectedColumns()
        Dim dt = InvQtySearchLogic.BuildDemoData()
        Dim names = dt.Columns.Cast(Of DataColumn)().Select(Function(c) c.ColumnName).ToArray()
        Assert.Equal({"itemCode", "itemDesc", "warehouse", "currentQty", "unit", "lastUpdated", "status"}, names)
    End Sub

    <Fact>
    Public Sub BuildDemoData_HasExpectedColumnTypes()
        Dim dt = InvQtySearchLogic.BuildDemoData()
        Assert.Equal(GetType(String), dt.Columns("itemCode").DataType)
        Assert.Equal(GetType(Decimal), dt.Columns("currentQty").DataType)
        Assert.Equal(GetType(Date), dt.Columns("lastUpdated").DataType)
    End Sub

    <Fact>
    Public Sub BuildDemoData_HasTenRows()
        Assert.Equal(10, InvQtySearchLogic.BuildDemoData().Rows.Count)
    End Sub

    <Fact>
    Public Sub BuildDemoData_ReturnsFreshInstanceEachCall()
        Dim first = InvQtySearchLogic.BuildDemoData()
        Dim second = InvQtySearchLogic.BuildDemoData()
        Assert.NotSame(first, second)
    End Sub

    <Fact>
    Public Sub BuildDemoData_ContainsTwoInactiveItems()
        Dim dt = InvQtySearchLogic.BuildDemoData()
        Dim inactive = dt.Select("status = 'Inactive'")
        Assert.Equal(2, inactive.Length)
    End Sub

End Class

''' <summary>
''' Verifies BuildRowFilter output is a valid DataView RowFilter expression that
''' filters the demo data as expected (integration of the two helpers).
''' </summary>
Public Class RowFilterIntegrationTests

    <Fact>
    Public Sub RowFilter_ByWarehouse_ReturnsMatchingRows()
        Dim dt = InvQtySearchLogic.BuildDemoData()
        dt.DefaultView.RowFilter = InvQtySearchLogic.BuildRowFilter("", "", "WH-A", "")
        Assert.Equal(5, dt.DefaultView.Count)
    End Sub

    <Fact>
    Public Sub RowFilter_ByStatus_ReturnsMatchingRows()
        Dim dt = InvQtySearchLogic.BuildDemoData()
        dt.DefaultView.RowFilter = InvQtySearchLogic.BuildRowFilter("", "", "", "Inactive")
        Assert.Equal(2, dt.DefaultView.Count)
    End Sub

    <Fact>
    Public Sub RowFilter_ByItemCode_ReturnsSingleRow()
        Dim dt = InvQtySearchLogic.BuildDemoData()
        dt.DefaultView.RowFilter = InvQtySearchLogic.BuildRowFilter("ITM-0003", "", "", "")
        Assert.Equal(1, dt.DefaultView.Count)
        Assert.Equal("Stapler Heavy Duty", CStr(dt.DefaultView(0)("itemDesc")))
    End Sub

    <Fact>
    Public Sub RowFilter_Empty_ReturnsAllRows()
        Dim dt = InvQtySearchLogic.BuildDemoData()
        dt.DefaultView.RowFilter = InvQtySearchLogic.BuildRowFilter("", "", "", "")
        Assert.Equal(10, dt.DefaultView.Count)
    End Sub

    <Fact>
    Public Sub RowFilter_WithQuoteInCriteria_DoesNotThrowAndReturnsNoRows()
        Dim dt = InvQtySearchLogic.BuildDemoData()
        ' A stray quote would break an unescaped RowFilter; escaping keeps it valid.
        dt.DefaultView.RowFilter = InvQtySearchLogic.BuildRowFilter("O'Brien", "", "", "")
        Assert.Equal(0, dt.DefaultView.Count)
    End Sub

End Class
