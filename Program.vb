Friend Module Program

    <STAThread()>
    Friend Sub Main(args As String())
        ' Route unhandled UI-thread exceptions through our handler instead of
        ' letting them terminate the process silently.
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
        AddHandler Application.ThreadException, AddressOf OnThreadException
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf OnUnhandledException

        Application.SetHighDpiMode(HighDpiMode.SystemAware)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New frmUpdInvQtySearch)
    End Sub

    Private Sub OnThreadException(sender As Object, e As System.Threading.ThreadExceptionEventArgs)
        ReportFatal(e.Exception)
    End Sub

    Private Sub OnUnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
        ReportFatal(TryCast(e.ExceptionObject, Exception))
    End Sub

    Private Sub ReportFatal(ex As Exception)
        Dim message = If(ex IsNot Nothing, ex.Message, "發生未預期的錯誤。")
        MessageBox.Show($"發生未預期的錯誤：{Environment.NewLine}{message}",
                        "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

End Module
