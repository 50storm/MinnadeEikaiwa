Imports System.Data.SqlClient
Imports System.Net


Public Class Calener
    Inherits System.Web.UI.Page
    'Private strCss As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("ApplicationServices")
    Dim ConnString As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("MinadeEikaiwaConnectionString")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim cstype As Type = Me.GetType()
        'Dim strScript As String = ""
        'strScript += "<script language=javascript>" & vbCrLf
        'strScript += "</script>"
        'Me.ClientScript.RegisterStartupScript(cstype, "PrintJisseki", strScript)

        'Me.Panel1.Attributes.Add("onLoad", "buildCalender();")
        'Me.Form.Attributes.Add("onLoad", "buildCalender();")






    End Sub

    'Dim scheInfo As SqlDataReader
    '' それぞれの日付セルをレンダリングするタイミングで実行
    'Sub cal_DayRender(sender As Object, e As DayRenderEventArgs)
    '    Dim db As New SqlConnection("Data Source=(local);User ID=sa;Password=sa;Persist Security Info=True;Initial Catalog=dotnet")
    '    ' 出力する日付で登録されたスケジュール情報が存在するかをチェック
    '    Dim comm As New SqlCommand("SELECT sid FROM schedule WHERE sdate=@sdate", db)
    '    comm.Parameters.Add("@sdate", e.Day.Date)
    '    db.Open()
    '    Dim reader As SqlDataReader = comm.ExecuteReader()
    '    ' スケジュールが存在する場合にのみセルの背景色をセット
    '    If reader.HasRows Then e.Cell.BackColor = Color.Lavender
    '    db.Close()
    'End Sub


    '' 選択セルが変更されたタイミングで実行
    'Sub cal_Changed(sender As Object, e As EventArgs)
    '    Dim db As New SqlConnection("Data Source=(local);User ID=sa;Password=sa;Persist Security Info=True;Initial Catalog=dotnet")
    '    ' 選択された日付をキーにscheduleテーブルを検索
    '    Dim comm As New SqlCommand("SELECT * FROM schedule WHERE sdate=@sdate ORDER BY stime ASC", db)
    '    comm.Parameters.Add("@sdate", cal.SelectedDate)
    '    db.Open()
    '    ' 取得したDataReaderをRepeaterコントロールにバインド
    '    scheInfo = comm.ExecuteReader()
    '    rep.DataBind()
    '    db.Close()
    'End Sub

    ''' <summary>
    ''' Set up the initial view
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Calendar1_DayRender(sender As Object, e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
        'SetSchedule()

        'Dim day As System.DateTime = e.Day.Date
        'Dim iday As Integer = e.Day.Date.Day
        'Dim iMon As Integer = e.Day.Date.Month

        'If iMon = 4 AndAlso iday = 14 Then
        '    e.Cell.Controls.Add(New LiteralControl("<br/>" & "英会話＠新宿"))
        'Else
        '    e.Cell.Controls.Add(New LiteralControl(""))
        'End If

        Dim Sql As String = String.Empty
        Sql = "SELECT * "
        Sql += "FROM [MinnadeEikaiwa].[dbo].[Schedule] "
        Sql += "where Year= "
        Sql += "'"
        Sql += DateTime.Now.Year.ToString
        Sql += "'"

        'DayOfWeek 列挙体の定数値の範囲は、DayOfWeek.Sunday から DayOfWeek.Saturday までです。 整数にキャストする場合、値の範囲は 0 (DayOfWeek.Sunday) ～ 6 (DayOfWeek.Saturday) です。 


        Using Conn As New SqlClient.SqlConnection(ConnString.ToString)
            Conn.Open()
            Using Cmd As New SqlClient.SqlCommand(Sql, Conn)
                Using Reader As SqlClient.SqlDataReader = Cmd.ExecuteReader()

                    While (Reader.Read)
                        '曜日によって表示する
                        'What day is (it) today ?
                        Select Case e.Day.Date.DayOfWeek
                            Case DayOfWeek.Sunday
                            Case DayOfWeek.Monday
                            Case DayOfWeek.Tuesday
                                e.Cell.Controls.Add(New LiteralControl("<br/>" & Reader("Place").ToString))
                            Case DayOfWeek.Wednesday
                            Case DayOfWeek.Thursday
                                e.Cell.Controls.Add(New LiteralControl("<br/>" & Reader("Place").ToString))
                            Case DayOfWeek.Friday
                            Case DayOfWeek.Saturday



                        End Select
                    End While
                End Using
            End Using
        End Using

    End Sub

    Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged
        lblYear.Text = Calendar1.SelectedDate.Date.Year
        lblMonth.Text = Calendar1.SelectedDate.Date.Month
        lblDay.Text = Calendar1.SelectedDate.Date.Day


        Response.Redirect("~/About.aspx")

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        '送信者
        Dim senderMail As String = "sender@xxx.xxx"
        '宛先
        Dim recipientMail As String = txtMail.Text
        '件名
        Dim subject As String = "参加申し込みありがとうございます。" + txtName.Text + "さん"

        '本文
        Dim body As String = "こんにちは。" + txtName.Text + "さん" + vbCrLf + vbCrLf + "それではまた。"

        Dim sc As New System.Net.Mail.SmtpClient()
        'SMTPサーバーを指定する
        sc.Host = "localhost"
        'メールを送信する
        sc.Send(senderMail, recipientMail, subject, body)
    End Sub

    Sub SetSchedule()
        Dim Sql As String = String.Empty
        Sql = "SELECT [Date]      ,[Place]      ,[StartTime]      ,[EndTime] "
        Sql += "FROM [MinnadeEikaiwa].[dbo].[Schedule] "
        Sql += "where Year= "
        Sql += "'"
        Sql += DateTime.Now.Year.ToString
        Sql += "'"

        Using Conn As New SqlClient.SqlConnection(ConnString.ToString)
            Conn.Open()
            Using Cmd As New SqlClient.SqlCommand(Sql, Conn)
                Using Reader As SqlClient.SqlDataReader = Cmd.ExecuteReader()



                End Using
            End Using
        End Using
    End Sub


    'Sub cal_DayRender(sender As Object, e As DayRenderEventArgs)
    '    Dim objDb As New SqlConnection("Data Source=(local);User ID=sa;Password=sa;Persist Security Info=True;Initial Catalog=dotnet")
    '    ' 出力する日付セルに対応するスケジュール情報を抽出
    '    Dim objCom As New SqlCommand("SELECT sid,title,sdate,stime,etime FROM schedule WHERE sdate=@sdate ORDER BY stime ASC", objDb)
    '    objCom.Parameters.Add("@sdate", e.Day.Date)
    '    objDb.Open()
    '    Dim objDr As SqlDataReader = objCom.ExecuteReader()
    '    ' 取得したスケジュール情報を基に
    '    ' LiteralControl（固定文字列）を生成し、
    '    ' 日付セル（e.Call）配下のコントロールとして追加
    '    Do While objDr.Read()
    '        e.Cell.Controls.Add(New LiteralControl("<br />" & String.Format("{0}～{1}：{2}", objDr.GetString(3), objDr.GetString(4), objDr.GetString(1))))
    '    Loop
    '    objDb.Close()
    'End Sub


    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("~/Form/WebForm1.aspx")

    End Sub
End Class