<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUpdInvQtySearch
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        '──────────────────────────────────────────
        ' Declare controls
        '──────────────────────────────────────────
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.lblFormSubtitle = New System.Windows.Forms.Label()
        Me.lblTitleIcon = New System.Windows.Forms.Label()

        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.pnlSearchInner = New System.Windows.Forms.Panel()
        Me.lblSearchTitle = New System.Windows.Forms.Label()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.lblItemDesc = New System.Windows.Forms.Label()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.lblWarehouse = New System.Windows.Forms.Label()
        Me.cmbWarehouse = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()

        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.dgvResults = New System.Windows.Forms.DataGridView()
        Me.pnlStatusBar = New System.Windows.Forms.Panel()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.lblLastRefresh = New System.Windows.Forms.Label()

        Me.pnlActionBar = New System.Windows.Forms.Panel()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()

        Me.pnlSearch.SuspendLayout()
        Me.pnlSearchInner.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatusBar.SuspendLayout()
        Me.pnlActionBar.SuspendLayout()
        Me.SuspendLayout()

        '══════════════════════════════════════════
        ' Form
        '══════════════════════════════════════════
        Me.Text = "更新庫存數量查詢"
        Me.Size = New System.Drawing.Size(980, 680)
        Me.MinimumSize = New System.Drawing.Size(800, 560)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable

        '══════════════════════════════════════════
        ' pnlHeader  (navy gradient banner)
        '══════════════════════════════════════════
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Height = 68
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(28, 57, 101)
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)

        ' Icon label (emoji as substitute for image)
        Me.lblTitleIcon.Text = "📦"
        Me.lblTitleIcon.Font = New System.Drawing.Font("Segoe UI Emoji", 22.0!)
        Me.lblTitleIcon.ForeColor = System.Drawing.Color.White
        Me.lblTitleIcon.AutoSize = True
        Me.lblTitleIcon.Location = New System.Drawing.Point(16, 10)
        Me.lblTitleIcon.BackColor = System.Drawing.Color.Transparent

        Me.lblFormTitle.Text = "更新庫存數量查詢"
        Me.lblFormTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblFormTitle.ForeColor = System.Drawing.Color.White
        Me.lblFormTitle.AutoSize = True
        Me.lblFormTitle.Location = New System.Drawing.Point(66, 10)
        Me.lblFormTitle.BackColor = System.Drawing.Color.Transparent

        Me.lblFormSubtitle.Text = "Update Inventory Quantity Search"
        Me.lblFormSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFormSubtitle.ForeColor = System.Drawing.Color.FromArgb(174, 214, 241)
        Me.lblFormSubtitle.AutoSize = True
        Me.lblFormSubtitle.Location = New System.Drawing.Point(68, 40)
        Me.lblFormSubtitle.BackColor = System.Drawing.Color.Transparent

        Me.pnlHeader.Controls.AddRange(New System.Windows.Forms.Control() {
            Me.lblTitleIcon, Me.lblFormTitle, Me.lblFormSubtitle})

        '══════════════════════════════════════════
        ' pnlSearch  (outer padding wrapper)
        '══════════════════════════════════════════
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearch.Height = 168
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.pnlSearch.Padding = New System.Windows.Forms.Padding(14, 10, 14, 8)

        '──────────────────────────────────────────
        ' pnlSearchInner  (white card with border)
        '──────────────────────────────────────────
        Me.pnlSearchInner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSearchInner.BackColor = System.Drawing.Color.White
        Me.pnlSearchInner.Padding = New System.Windows.Forms.Padding(14, 10, 14, 8)
        ' Rounded border via Paint
        AddHandler Me.pnlSearchInner.Paint, AddressOf PnlSearchInner_Paint

        ' Section heading
        Me.lblSearchTitle.Text = "🔍  搜尋條件"
        Me.lblSearchTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(28, 57, 101)
        Me.lblSearchTitle.AutoSize = True
        Me.lblSearchTitle.Location = New System.Drawing.Point(14, 10)

        '── Row 1: Item Code | Item Desc ──────────
        Me.lblItemCode.Text = "商品編號"
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.ForeColor = System.Drawing.Color.FromArgb(89, 103, 115)
        Me.lblItemCode.Location = New System.Drawing.Point(14, 38)

        Me.txtItemCode.Location = New System.Drawing.Point(14, 56)
        Me.txtItemCode.Size = New System.Drawing.Size(180, 28)
        Me.txtItemCode.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        StyleTextBox(Me.txtItemCode)

        Me.lblItemDesc.Text = "商品描述"
        Me.lblItemDesc.AutoSize = True
        Me.lblItemDesc.ForeColor = System.Drawing.Color.FromArgb(89, 103, 115)
        Me.lblItemDesc.Location = New System.Drawing.Point(210, 38)

        Me.txtItemDesc.Location = New System.Drawing.Point(210, 56)
        Me.txtItemDesc.Size = New System.Drawing.Size(260, 28)
        Me.txtItemDesc.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        StyleTextBox(Me.txtItemDesc)

        '── Row 1: Warehouse | Status ─────────────
        Me.lblWarehouse.Text = "倉庫 / 位置"
        Me.lblWarehouse.AutoSize = True
        Me.lblWarehouse.ForeColor = System.Drawing.Color.FromArgb(89, 103, 115)
        Me.lblWarehouse.Location = New System.Drawing.Point(490, 38)

        Me.cmbWarehouse.Location = New System.Drawing.Point(490, 56)
        Me.cmbWarehouse.Size = New System.Drawing.Size(150, 28)
        Me.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWarehouse.Items.AddRange(New Object() {"全部", "WH-A", "WH-B", "WH-C"})
        Me.cmbWarehouse.SelectedIndex = 0
        Me.cmbWarehouse.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbWarehouse.BackColor = System.Drawing.Color.FromArgb(250, 251, 252)

        Me.lblStatus.Text = "狀態"
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(89, 103, 115)
        Me.lblStatus.Location = New System.Drawing.Point(658, 38)

        Me.cmbStatus.Location = New System.Drawing.Point(658, 56)
        Me.cmbStatus.Size = New System.Drawing.Size(120, 28)
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Items.AddRange(New Object() {"全部", "Active", "Inactive"})
        Me.cmbStatus.SelectedIndex = 0
        Me.cmbStatus.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStatus.BackColor = System.Drawing.Color.FromArgb(250, 251, 252)

        '── Row 2: Date From | Date To | Buttons ──
        Me.lblDateFrom.Text = "日期由"
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.ForeColor = System.Drawing.Color.FromArgb(89, 103, 115)
        Me.lblDateFrom.Location = New System.Drawing.Point(14, 98)

        Me.dtpDateFrom.Location = New System.Drawing.Point(14, 116)
        Me.dtpDateFrom.Size = New System.Drawing.Size(150, 28)
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpDateFrom.Value = Date.Today.AddMonths(-3)
        Me.dtpDateFrom.Font = New System.Drawing.Font("Segoe UI", 9.5!)

        Me.lblDateTo.Text = "至"
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.ForeColor = System.Drawing.Color.FromArgb(89, 103, 115)
        Me.lblDateTo.Location = New System.Drawing.Point(172, 98)

        Me.dtpDateTo.Location = New System.Drawing.Point(172, 116)
        Me.dtpDateTo.Size = New System.Drawing.Size(150, 28)
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpDateTo.Value = Date.Today
        Me.dtpDateTo.Font = New System.Drawing.Font("Segoe UI", 9.5!)

        ' Buttons (Search / Clear)
        Me.btnSearch.Text = "  🔍  搜 尋"
        Me.btnSearch.Location = New System.Drawing.Point(490, 112)
        Me.btnSearch.Size = New System.Drawing.Size(120, 34)
        StyleButton(Me.btnSearch, System.Drawing.Color.FromArgb(41, 128, 185))

        Me.btnClear.Text = "  ✕  清 除"
        Me.btnClear.Location = New System.Drawing.Point(622, 112)
        Me.btnClear.Size = New System.Drawing.Size(100, 34)
        StyleButton(Me.btnClear, System.Drawing.Color.FromArgb(127, 140, 141))

        Me.pnlSearchInner.Controls.AddRange(New System.Windows.Forms.Control() {
            Me.lblSearchTitle,
            Me.lblItemCode, Me.txtItemCode,
            Me.lblItemDesc, Me.txtItemDesc,
            Me.lblWarehouse, Me.cmbWarehouse,
            Me.lblStatus, Me.cmbStatus,
            Me.lblDateFrom, Me.dtpDateFrom,
            Me.lblDateTo, Me.dtpDateTo,
            Me.btnSearch, Me.btnClear})

        Me.pnlSearch.Controls.Add(Me.pnlSearchInner)

        '══════════════════════════════════════════
        ' pnlContent  (grid + status bar)
        '══════════════════════════════════════════
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(14, 4, 14, 0)

        '── DataGridView ──────────────────────────
        Me.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResults.MultiSelect = True
        Me.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResults.ReadOnly = True
        Me.dgvResults.AllowUserToAddRows = False
        Me.dgvResults.AllowUserToDeleteRows = False
        Me.dgvResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        Me.dgvResults.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgvResults.Anchor = System.Windows.Forms.AnchorStyles.Top Or
                               System.Windows.Forms.AnchorStyles.Bottom Or
                               System.Windows.Forms.AnchorStyles.Left Or
                               System.Windows.Forms.AnchorStyles.Right

        '── Status bar ────────────────────────────
        Me.pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlStatusBar.Height = 28
        Me.pnlStatusBar.BackColor = System.Drawing.Color.FromArgb(236, 240, 241)

        Me.lblRecordCount.Text = "共  0  筆記錄"
        Me.lblRecordCount.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(89, 103, 115)
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Location = New System.Drawing.Point(8, 7)

        Me.lblLastRefresh.Text = $"最後刷新：{Date.Now:HH:mm:ss}"
        Me.lblLastRefresh.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblLastRefresh.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblLastRefresh.AutoSize = True
        Me.lblLastRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblLastRefresh.Location = New System.Drawing.Point(800, 7)

        Me.pnlStatusBar.Controls.AddRange(New System.Windows.Forms.Control() {
            Me.lblRecordCount, Me.lblLastRefresh})

        Me.pnlContent.Controls.AddRange(New System.Windows.Forms.Control() {
            Me.dgvResults, Me.pnlStatusBar})

        '══════════════════════════════════════════
        ' pnlActionBar  (bottom toolbar)
        '══════════════════════════════════════════
        Me.pnlActionBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActionBar.Height = 54
        Me.pnlActionBar.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        AddHandler Me.pnlActionBar.Paint, AddressOf PnlActionBar_Paint

        Me.btnUpdate.Text = "  ✏  更新數量"
        Me.btnUpdate.Location = New System.Drawing.Point(14, 10)
        Me.btnUpdate.Size = New System.Drawing.Size(130, 34)
        StyleButton(Me.btnUpdate, System.Drawing.Color.FromArgb(39, 174, 96))

        Me.btnExport.Text = "  📄  匯出 CSV"
        Me.btnExport.Location = New System.Drawing.Point(152, 10)
        Me.btnExport.Size = New System.Drawing.Size(130, 34)
        StyleButton(Me.btnExport, System.Drawing.Color.FromArgb(26, 188, 156))

        Me.btnClose.Text = "  ✕  關 閉"
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.btnClose.Size = New System.Drawing.Size(110, 34)
        Me.btnClose.Location = New System.Drawing.Point(840, 10)
        StyleButton(Me.btnClose, System.Drawing.Color.FromArgb(192, 57, 43))

        Me.pnlActionBar.Controls.AddRange(New System.Windows.Forms.Control() {
            Me.btnUpdate, Me.btnExport, Me.btnClose})

        '══════════════════════════════════════════
        ' Assemble form
        '══════════════════════════════════════════
        Me.Controls.AddRange(New System.Windows.Forms.Control() {
            Me.pnlContent,
            Me.pnlActionBar,
            Me.pnlSearch,
            Me.pnlHeader})

        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearchInner.ResumeLayout(False)
        Me.pnlSearchInner.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatusBar.ResumeLayout(False)
        Me.pnlStatusBar.PerformLayout()
        Me.pnlActionBar.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    '══════════════════════════════════════════
    ' Shared styling helpers
    '══════════════════════════════════════════
    Private Shared Sub StyleTextBox(tb As System.Windows.Forms.TextBox)
        tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        tb.BackColor = System.Drawing.Color.FromArgb(250, 251, 252)
    End Sub

    Private Shared Sub StyleButton(btn As System.Windows.Forms.Button, bg As System.Drawing.Color)
        btn.BackColor = bg
        btn.ForeColor = System.Drawing.Color.White
        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        btn.Cursor = System.Windows.Forms.Cursors.Hand
        btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        btn.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
    End Sub

    '══════════════════════════════════════════
    ' Custom paint handlers
    '══════════════════════════════════════════
    Private Sub PnlSearchInner_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        Dim r = New System.Drawing.Rectangle(0, 0, Me.pnlSearchInner.Width - 1, Me.pnlSearchInner.Height - 1)
        Using p As New System.Drawing.Pen(System.Drawing.Color.FromArgb(213, 219, 229), 1)
            e.Graphics.DrawRectangle(p, r)
        End Using
    End Sub

    Private Sub PnlActionBar_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        ' Top separator line
        Using p As New System.Drawing.Pen(System.Drawing.Color.FromArgb(213, 219, 229), 1)
            e.Graphics.DrawLine(p, 0, 0, Me.pnlActionBar.Width, 0)
        End Using
    End Sub

    '══════════════════════════════════════════
    ' Control declarations
    '══════════════════════════════════════════
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitleIcon As System.Windows.Forms.Label
    Friend WithEvents lblFormTitle As System.Windows.Forms.Label
    Friend WithEvents lblFormSubtitle As System.Windows.Forms.Label

    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents pnlSearchInner As System.Windows.Forms.Panel
    Friend WithEvents lblSearchTitle As System.Windows.Forms.Label
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents lblItemDesc As System.Windows.Forms.Label
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblWarehouse As System.Windows.Forms.Label
    Friend WithEvents cmbWarehouse As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button

    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents dgvResults As System.Windows.Forms.DataGridView
    Friend WithEvents pnlStatusBar As System.Windows.Forms.Panel
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents lblLastRefresh As System.Windows.Forms.Label

    Friend WithEvents pnlActionBar As System.Windows.Forms.Panel
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button

End Class
