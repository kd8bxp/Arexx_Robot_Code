Imports Microsoft.Win32
Imports System
Imports System.Threading
Imports System.Text
Imports System.IO

Public Class Main

    Public ontvangendata As String              'De data uit de serieele poort wordt in deze variabele gezet 
    Public ontvangenbytes(37) As Byte           'Ontvangen data van de serieele poort, maar bestaat uit bytes 

    Public transmitted_packets As ULong       'Aantal verzonden pakketten van computer naar wildt thumper
    Public Received_packets As ULong          'Aantal ontvangen paketten van wild thumper naar computer 
    Public Received_wrong_packets As ULong

    Public RF_Test_Counter As Byte

    Public Elapsed_time As New Stopwatch

    Public addres_PC As Byte = 255              'Adress van de computer 
    Public addres_WT As Byte = 255              'Adress van de Wild Thumper 

    Public Direction_WT As Char                    'De actuele richting van de wild Thumper

    Public Send_Report(32) As Char

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Bij het laden van het programma 
        'Laad alle aangesloten compoorten, zodat de gebruiker de juiste kan selecteren 
        GetSerialPortNames()

        Label_start_time_application.Text = Date.Now.ToString("HH:mm:ss:ff")
        Settings.TopLevel = False
        Settings.Parent = Panel_Settings
        Settings.Show()
    End Sub

    '--------------------------------Format change-----------------------
    Private Sub Main_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        'Wanneer het formaat van de applicatie veranderd, moet het formaat van de tabcontrol meeveranderen
        'Het tabcontrol wordt kleiner, zodat er een rand naast de tabcontrol ontstaat.
        '  TabControl.Width = Me.Width - 30
        ' TabControl.Height = Me.Height - 75
        'Zoek de x en y coordinaten op waar de tijdklok moet komen te staan
        Dim XCoordinaat As Integer = ((Me.Size.Width / 2) - (TabControl1.Size.Width / 2)) - 10
        Dim YCoordinaat As Integer = ((Me.Size.Height / 2) - (TabControl1.Size.Height / 2)) - 20

        TabControl1.Location = New Point(XCoordinaat, YCoordinaat)
    End Sub

    Sub GetSerialPortNames()
        'Display alle beschikbare compoorten in de combobox (combox_comports)
        'Verwijder alle items die geschreven waren in de combobox 
        ComBox_Comports.Items.Clear()
        'Elke compoort die beschikbaar wordt toegevoegd aan de combobox 
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComBox_Comports.Items.Add(sp)
        Next
    End Sub

    Private Sub Button_refresh_comport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_refresh_comport.Click
        'Wanneer er op deze button wordt geklikt worden alle beschikbare compoorten opnieuw in de combobox geladen 
        GetSerialPortNames()
    End Sub

Private Sub Button_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Connect.Click
        'Wanneer er op de button connect wordt geklikt, wordt de compoort geopend die geselecteerd is in de combobox 
        If ComBox_Comports.Text = "" Then
            'Wanneer geen compoort is geselecteerd wordt de volgende melding gegegeven 
            MsgBox("Please select comport!")
        Else
            'Wanneer nog geen verbinding is gemaakt (text op de button is connect) probeer compoort te openen 
            If Button_Connect.Text = "Connect" Then
                Try
                    SerialPort_APC220.PortName = ComBox_Comports.Text     'Haal geselecteerd compoort uit combobox 
                    'SerialPort_APC220.Encoding = System.Text.Encoding.Default
                    SerialPort_APC220.Encoding = System.Text.Encoding.GetEncoding(28591)
                    SerialPort_APC220.Open()                              'Open de compoort 
                    Button_Connect.Text = "Disconnect"                    'Verander de text op de button 
                    Timer_ASK_Data.Start()                                    'Start timer voor aanvraag data (elke 500 ms
                    ComBox_Comports.Enabled = False
                Catch ex As Exception

                End Try
                'Wanneer er al verbinding was gemaakt (text op de button is disconnect), verbreek de verbinding 
            ElseIf Button_Connect.Text = "Disconnect" Then
                Timer_ASK_Data.Stop()                                         'Stop timer voor aanvraag data 
                Try
                    SerialPort_APC220.Close()    'Sluit de compoort 
                    Button_Connect.Text = "Connect"                       'verander de text 
                    Reset_all_values()                                    'Reset alle waardes (zie data.vb)
                    Label_Connection_RP6.ForeColor = Color.DarkRed          'Status, geen data ontvangen (no signal) 
                    Label_Connection_RP6.Text = "No Signal"                 'Status, geen data ontvangen (no signal)         
                    ComBox_Comports.Enabled = True
                Catch ex As Exception

                End Try
            End If

        End If
    End Sub


    Public Sub Create_Repport_RF()

        Try

            'Check eerst of de timeout timer gereset moet worden,dit wordt gedaan wanneer er een besturings commando's worden verstuurd. 
            'De reden hiervoor is wanneer er veel besturings pakketten worden verstuurd kan de WT niks terugsturen 
            'Waardoor het lijkt of de WT niks terug stuurt. 
            If Not (Send_Report(1) = Convert.ToChar(255) Or Send_Report(1) = Convert.ToChar(254)) Then
                Timer_WT_Timeout.Stop()
                Timer_WT_Timeout.Start()
            End If

            'Reset Timer ask data,
            Timer_ASK_Data.Stop()
            Timer_ASK_Data.Start()
            'Verstuur het pakket 
            If SerialPort_APC220.IsOpen Then
                SerialPort_APC220.Write(Chr(1))
                SerialPort_APC220.Write(Chr(250))
                SerialPort_APC220.Write(Chr(8))
                SerialPort_APC220.Write(Send_Report(0))
                SerialPort_APC220.Write(Send_Report(1))             'Informatie byte
                SerialPort_APC220.Write(Send_Report(2))             'Informaite byte 
                SerialPort_APC220.Write(Chr(0))
                SerialPort_APC220.Write(Chr(4))

                transmitted_packets = transmitted_packets + 1
                Label_transmitted_packets.Text = transmitted_packets

            End If
        Catch ex As Exception

        End Try
       
    End Sub


    Private Sub Ontvangdata(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort_APC220.DataReceived
        'sla de ontvangen data op in de string ontvangendata 
        System.Threading.Thread.Sleep(100)

        'Wat te doen bij data ontvangen 
        Try
            SerialPort_APC220.Read(ontvangenbytes, 0, 32)
            'Wanneer nieuwe data binnen is gekomen, roep de functie Handles_data aan, vanuit daar wordt de data verwerkt. (zie Data.vb)
            Me.BeginInvoke(New EventHandler(AddressOf Handles_data))

        Catch ex As Exception
        End Try

    End Sub
    Public Sub Handles_data()
        'Handles_data handelt alle data af die binnenkomt.
        'Er worden gecheckt welke functie aangeroepen moet worden 

        Timer_WT_Timeout.Enabled = False
        Timer_WT_Timeout.Enabled = True
        Label_Connection_RP6.ForeColor = Color.Green
        Label_Connection_RP6.Text = "OK"

        'Geef aantal ontvangen pakketen weer
        Received_packets = Received_packets + 1
        Label_received_packets.Text = Received_packets

        'Eerst worden de ontvangen bytes omgezet naar een string, omdat de settingsdata beter als string verwerkt kan worden. 
        Dim enc As New System.Text.ASCIIEncoding()
        ontvangendata = enc.GetString(ontvangenbytes)
        Try
            'Check 1: Setting gegevens 
            'Wanneer de timer is geactiveerd, worden er settings geschreven of gelezen
            If Settings.Timer_Settings_RW.Enabled Then
                'Wanneer dit het geval is wordt gecontroleerd of data goed is binnen gekomen 
                '(Bevat het bericht "PARA " en is byte 20 de enter waarmee het bericht wordt afgesloten) 
                'Wanneer dit ook het geval is wordt de functie Handles_APCdata_settings aangeroepen (zie settings.vb) 
                If (InStr(ontvangendata, "PARA") = 1) And (ontvangenbytes(20) = 10) Then
                    Settings.Handles_APCdata_settings()
                End If

                'Wanneer de Timer voor de setting niet geactiveerd is, wordt gecontroleer of het packet voldoet aan het vastgelegde WT-protocol
            ElseIf ontvangenbytes(2) < 32 And ontvangenbytes(2) > 0 Then

                If ontvangenbytes(0) = 1 And ontvangenbytes(1) = addres_PC And ontvangenbytes(ontvangenbytes(2) - 1) = 4 Then

                    'check 2: Acknoledgment 
                    'wanneer de control byte een "A" is, wordt de functie Current_data aangeroepen om de data te verwerken 
                    If ontvangenbytes(3) = 65 Then

                        'check 3: Error 
                        'wanneer de control byte een "E" is, wordt de functie Error aangeroepen om de data te verwerken 
                    ElseIf ontvangenbytes(3) = 69 Then

                        'check 4: RF Test 
                        'wanneer de control byte 200 is, wordt de functie RF_Test aangeroepen om de data te verwerken 
                    ElseIf ontvangenbytes(3) = 200 Then
                        RF_Test()


                        'check 7: Data voor main tabblad 
                        'wanneer de control byte 254 is, wordt de functie update_main_data aangeroepen om de data te verwerken 
                    ElseIf ontvangenbytes(3) = 254 Then
                        Update_data()
                    End If

                    'Anders is er een foutief packet ontvangen, dat wordt weergegeven in het log scherm 
                Else

                    Received_wrong_packets = Received_wrong_packets + 1
                    Label_Wrong_Packets.Text = Received_wrong_packets


                End If

            Else
                Received_wrong_packets = Received_wrong_packets + 1
                Label_Wrong_Packets.Text = Received_wrong_packets
            End If

            SerialPort_APC220.DiscardInBuffer()


        Catch ex As Exception

        End Try

    End Sub


    Public Sub Update_data()
        Try
            Dim Voltage As Double                       'Spanning als double 
            'De maximale spanning die gemeten kan worden op een ADC ingang is 5V.
            'Door de spanningsdeler zal de maximaal te meten spanning 10V zijn (2*5V)
            'De nauwkeurigheid van de spanningsmeter is 8bits, dus 256 mogelijkheden 
            'Dus (4,096V*3)/255bits = 0,04818 V/bit 
            Voltage = ontvangenbytes(4) * 0.012941176 / 0.55 + 2 '0.0215 0.01294117647058823529411764705882
            'Vervolgens wordt de waarde afgerond op 1 waarde achter de komma
            Voltage = Format(Voltage, "0.0")
            'Daarna worden de progresbar gevuld en de waarde naar de label geschreven 
            ProgressBar_Voltage.Value = ontvangenbytes(4)
            Label_Battery_Voltage.Text = Voltage
            Label_Battery_Voltage.Text += " V"

            If (ontvangenbytes(10) < 101) Then
                ProgressBar_Current_Right.Value = ontvangenbytes(10)
            Else
                ProgressBar_Current_Right.Value = 100
            End If

            If (ontvangenbytes(11) < 101) Then
                ProgressBar_Current_Left.Value = ontvangenbytes(11)
            Else
                ProgressBar_Current_Left.Value = 100
            End If

            ProgressBar_Speed_Left.Value = ontvangenbytes(7)

            If (ontvangenbytes(8) < 255) Then
                ProgressBar_Speed_Right.Value = ontvangenbytes(8)
            Else
                ProgressBar_Speed_Right.Value = 255
            End If

            Label_Wrong_Packets_RP6.Text = ontvangenbytes(9)
        Catch ex As Exception

        End Try


    End Sub

    Public Sub RF_Test()
        'Deze functie verwerkt alle data die binnen komt wanneer een RF-Test wordt uitgevoerd
        'RF_Test_Counter houd het aantal ontvangen bytes bij,
        'Wanneer er een byte wordt ontvangen wordt dit direct weergegeven in het textvak 
        RF_Test_Counter = RF_Test_Counter + 1
        TextBox_Test_Status.Text += "Received pakket: "
        TextBox_Test_Status.Text += RF_Test_Counter.ToString & ControlChars.CrLf
        Timer_ASK_Data.Stop()
        'Reset Timer_I2C_RF_Test, omdat een pakket binnen gekomen is. (door te stoppen en weer te starten)
        Timer_RF_Test.Stop()
        Timer_RF_Test.Start()

        If (RF_Test_Counter = 10) Then
            'Wanneer alle 10 packetten goed zijn binnen gekomen:
            Timer_RF_Test.Stop()
            TextBox_Test_Status.Text += "Received all packets!!!" & ControlChars.CrLf
            TextBox_Test_Status.Text += "Communication: OK" & ControlChars.CrLf
            TextBox_Test_Status.Text += "End of Communication Test:" & ControlChars.CrLf
            Timer_ASK_Data.Start()
        End If
    End Sub

    'Timers
    Private Sub Timer_Connection_Check_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Connection_Check.Tick
        'Deze timer checkt om de 100ms of de verbinding niet is verbroken,
        'De status wordt weergegeven in de status balk onderaan de applicatie 
        If SerialPort_APC220.IsOpen Then                'Wanneer seriele poort is geopend 
            Label_Dongle_Status.ForeColor = Color.Green    'Tool strip label wordt groen 
            Label_Dongle_Status.Text = "Found"         'Tool strip label text wordt Connected
            Button_Connect.Text = "Disconnect"          'Connect button text wordt Disconnect

            Dim VerstrekenTijd As TimeSpan = Me.Elapsed_time.Elapsed
            'Zet het formaat op Uren:minuten:seconden:miliseconden en zet de verstrekend tijd er in.
            Label_Time_Connected.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", Math.Floor(VerstrekenTijd.Hours), (VerstrekenTijd.Minutes), VerstrekenTijd.Seconds, (VerstrekenTijd.Milliseconds / 10.1))


        Else 'Wanneer seriele poort is gesloten 
            Label_Dongle_Status.ForeColor = Color.DarkRed      'Tool strip label wordt rood 
            Label_Dongle_Status.Text = "Not Found"      'Tool strip label text wordt Disconnected
            Button_Connect.Text = "Connect"             'Disconnect button text wordt Connect
            ComBox_Comports.Enabled = True

        End If
    End Sub

    Private Sub Timer_ASK_Data_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_ASK_Data.Tick
        'Wanneer de seriele poort is geopend, wordt met behulp van deze timer elke 500ms een 'D' verstuurt. 
        'Wanneer de Wild Thumper een 'D' ontvangt, zal het alle gemeten data terugsturen. 
        'Met deze timer kan bepaald worden of de Wild Thumper data mag sturen 
        If SerialPort_APC220.IsOpen Then    'check of de seriele poort is geopend 
            Try
                Timer_WT_Timeout.Enabled = True


                Send_Report(0) = Chr(2)
                Send_Report(1) = Convert.ToChar(0)
                Send_Report(2) = Convert.ToChar(0)

                Create_Repport_RF()


            Catch ex As Exception
            End Try
        End If
    End Sub


    Private Sub Timer_WT_Timeout_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_WT_Timeout.Tick
        'Met behulp van deze timer wordt gecheckt of de WT nog communiceert met de applicatie 
        If Timer_ASK_Data.Enabled = True Then
            Label_Connection_RP6.ForeColor = Color.DarkRed
            Label_Connection_RP6.Text = "No Signal"
        End If
    End Sub


    Private Sub Button_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Stop.Click
        'Verander de kleur van de geselecteerde knop in oranje, de rest naar default (steelblue) 
        Timer_ASK_Data.Stop()
        Button_Backward.BackColor = Color.SteelBlue
        Button_Right.BackColor = Color.SteelBlue
        Button_Left.BackColor = Color.SteelBlue
        Button_Forward.BackColor = Color.SteelBlue
        Button_Stop.BackColor = Color.Orange
        Direction_WT = Convert.ToChar(53)
        Send_Report(0) = Chr(1)
        Send_Report(1) = Direction_WT
        Send_Report(2) = Chr(HScrollBar_Speed.Value)
        Create_Repport_RF()
        'Create_Repport_RF()
        Timer_ASK_Data.Start()
    End Sub

    Private Sub Button_Forward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Forward.Click
        'Verander de kleur van de geselecteerde knop in oranje, de rest naar default (steelblue) 
        Timer_ASK_Data.Stop()
        Button_Backward.BackColor = Color.SteelBlue
        Button_Right.BackColor = Color.SteelBlue
        Button_Left.BackColor = Color.SteelBlue
        Button_Stop.BackColor = Color.SteelBlue
        Button_Forward.BackColor = Color.Orange
        Direction_WT = Convert.ToChar(56)
        Send_Report(0) = Chr(1)
        Send_Report(1) = Direction_WT
        Send_Report(2) = Chr(HScrollBar_Speed.Value)
        Create_Repport_RF()
        'Create_Repport_RF()
        Timer_ASK_Data.Start()
    End Sub


    Private Sub Button_Left_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Left.Click
        'Verander de kleur van de geselecteerde knop in oranje, de rest naar default (steelblue) 
        Timer_ASK_Data.Stop()
        Button_Backward.BackColor = Color.SteelBlue
        Button_Right.BackColor = Color.SteelBlue
        Button_Forward.BackColor = Color.SteelBlue
        Button_Stop.BackColor = Color.SteelBlue
        Button_Left.BackColor = Color.Orange
        Direction_WT = Convert.ToChar(52)
        Send_Report(0) = Chr(1)
        Send_Report(1) = Direction_WT
        Send_Report(2) = Chr(HScrollBar_Speed.Value)
        Create_Repport_RF()
        'Create_Repport_RF()
        Timer_ASK_Data.Start()
    End Sub

    Private Sub Button_Right_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Right.Click
        'Verander de kleur van de geselecteerde knop in oranje, de rest naar default (steelblue) 
        Timer_ASK_Data.Stop()
        Button_Backward.BackColor = Color.SteelBlue
        Button_Forward.BackColor = Color.SteelBlue
        Button_Left.BackColor = Color.SteelBlue
        Button_Stop.BackColor = Color.SteelBlue
        Button_Right.BackColor = Color.Orange
        Direction_WT = Convert.ToChar(54)
        Send_Report(0) = Chr(1)
        Send_Report(1) = Direction_WT
        Send_Report(2) = Chr(HScrollBar_Speed.Value)
        Create_Repport_RF()
        'Create_Repport_RF()
        Timer_ASK_Data.Start()
    End Sub

    Private Sub Button_Backward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Backward.Click
        'Verander de kleur van de geselecteerde knop in oranje, de rest naar default (steelblue) 
        Timer_ASK_Data.Stop()
        Button_Forward.BackColor = Color.SteelBlue
        Button_Right.BackColor = Color.SteelBlue
        Button_Left.BackColor = Color.SteelBlue
        Button_Stop.BackColor = Color.SteelBlue
        Button_Backward.BackColor = Color.Orange
        Direction_WT = Convert.ToChar(50)
        Send_Report(0) = Chr(1)
        Send_Report(1) = Direction_WT
        Send_Report(2) = Convert.ToChar(HScrollBar_Speed.Value)
        Create_Repport_RF()
        'Create_Repport_RF()
        Timer_ASK_Data.Start()
    End Sub


    Private Sub Reset_all_values()

        ProgressBar_Voltage.Value = 0
        Label_Battery_Voltage.Text = "0.0 V"
        ProgressBar_Current_Right.Value = 0
        ProgressBar_Current_Left.Value = 0
        ProgressBar_Speed_Left.Value = 0
        ProgressBar_Speed_Right.Value = 0
    End Sub



    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Timer_ASK_Data.Stop()

        Try
            'Serieele poort sluiten
            SerialPort_APC220.Close()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button_Test_Communication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Test_Communication.Click

        If SerialPort_APC220.IsOpen = False Then

            TextBox_Test_Status.Text += "Can't check communication, not connected with serial port" & ControlChars.CrLf
            MsgBox(" Not connected with a serial port ")
            Return
        End If

        TextBox_Test_Status.Text = ""
        'Stop met het aanvragen van data vanuit de Wild Thumper:
        Timer_ASK_Data.Stop()

        RF_Test_Counter = 0

        TextBox_Test_Status.Text += "Start RF Test:" & ControlChars.CrLf
        TextBox_Test_Status.Text += "- Send command to Wild Thumper" & ControlChars.CrLf
        TextBox_Test_Status.Text += "- Wait for answer......" & ControlChars.CrLf
        TextBox_Test_Status.Text += "....................." & ControlChars.CrLf
        Timer_RF_Test.Start()

        'Wacht een tijd (250ms) zodat er niet tegelijkertijd met de Wild Thumper wordt gezonden
        System.Threading.Thread.Sleep(300)
        Send_Report(0) = Chr(3)
        Send_Report(1) = Chr(200)                    'Deze (control) byte geeft aan dat de RF test gestart wordt 
        Send_Report(2) = Chr(0)                      'Clear buffer
        Create_Repport_RF()                          'Create repport en transmit 
    End Sub

    Private Sub Timer_RF_Test_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_RF_Test.Tick

        TextBox_Test_Status.Text += "- Communication problem" & ControlChars.CrLf
        TextBox_Test_Status.Text += "- please check connection" & ControlChars.CrLf
        Timer_RF_Test.Stop()
        Timer_ASK_Data.Start()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineCheck.CheckedChanged
        Timer_ASK_Data.Stop()
        If LineCheck.Checked = True Then
            System.Threading.Thread.Sleep(50)
            Send_Report(0) = Chr(1)
            Send_Report(1) = Convert.ToChar(100)
            Send_Report(2) = Convert.ToChar(1)
            Create_Repport_RF()
        Else
            System.Threading.Thread.Sleep(50)
            Send_Report(0) = Chr(1)
            Send_Report(1) = Convert.ToChar(100)
            Send_Report(2) = Convert.ToChar(0)
            Create_Repport_RF()
        End If
        Timer_ASK_Data.Start()
    End Sub
End Class
